using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Asam.Ppc.Domain.AssessmentModule;
using Asam.Ppc.Domain.CommonModule;
using Asam.Ppc.Primitives;
using Asam.Ppc.Service.Messages.Assessment;
using Asam.Ppc.Service.Messages.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pillar.Domain;

namespace Asam.Ppc.Service.Messages.Tests
{
    [TestClass]
    public class ResourceTests
    {
        [TestMethod]
        public void AllAssementDtoPropertiesHaveResourceTest()
        {
            var ignore = new List<string> { "Key", "DataErrorInfoCollection", "MetadataDto" };
            var resourceManager = AsamPpcResources.ResourceManager;
            var dtoTypes = (typeof(IAssessmentDto)).Assembly.GetTypes().Where(t => typeof(IAssessmentDto).IsAssignableFrom(t));

            var notFound = new List<KeyValuePair<string, string>>();
            foreach (var dtoType in dtoTypes)
            {
                foreach (var propertyInfo in dtoType.GetProperties().Where(pi => !ignore.Contains(pi.Name) && pi.GetCustomAttributes ( typeof(HiddenInputAttribute), false ).Length == 0))
                {
                    if (resourceManager.GetString(string.Format("{0}_{1}", dtoType.Name.Replace("Dto", ""), propertyInfo.Name)) == null)
                    {
                        notFound.Add(new KeyValuePair<string, string> (dtoType.Name, propertyInfo.Name));
                    }
                }
            }

            Assert.IsTrue(notFound.Count == 0, "No resource found for " + string.Join(",", notFound.Select(i => i.Key + "." + i.Value)));
        }

        [TestMethod]
        public void AllSectionSubSectionHaveResourceTest()
        {
            var ignore = new List<Type> { typeof(AggregateRootBase) };
            var sections = typeof(Entity).Assembly.GetTypes().Where(t => !ignore.Contains(t) && t.BaseType == typeof(Entity));

            var resourceManager = AsamPpcResources.ResourceManager;
            var notFound = new List<string>();

            foreach (var section in sections)
            {
                if (resourceManager.GetString(section.Name) == null)
                {
                    notFound.Add(section.Name);
                }
                foreach (var propertyInfo in section.GetProperties().Where(p => p.PropertyType.BaseType == typeof(RevisionBase)))
                {
                    if (resourceManager.GetString(section.Name + "_" + propertyInfo.Name) == null)
                    {
                        notFound.Add(section.Name);
                    }
                }
            }

            Assert.IsTrue(notFound.Count == 0, "No resource found for " + string.Join(",", notFound));
        }

        [TestMethod]
        public void AllGroupHeadersHaveResourceTest()
        {
            var resourceManager = AsamPpcResources.ResourceManager;
            var dtoTypes = (typeof(IAssessmentDto)).Assembly.GetTypes().Where(t => typeof(IAssessmentDto).IsAssignableFrom(t));

            var notFound = new List<Tuple<string, string, string>>();
            foreach (var dtoType in dtoTypes)
            {
                foreach (var propertyInfo in dtoType.GetProperties().Where(pi => pi.GetCustomAttributes(typeof(QuestionGroupAttribute), false).Any()))
                {
                    var attributes = propertyInfo.GetCustomAttributes(typeof(QuestionGroupAttribute), false);
                    foreach (QuestionGroupAttribute attribute in attributes)
                    {
                        if (resourceManager.GetString(attribute.QuestionResourceName) == null)
                        {
                            notFound.Add(new Tuple<string, string, string>(dtoType.Name, propertyInfo.Name, attribute.QuestionResourceName));
                        }
                    }
                }
            }
            Assert.IsTrue(notFound.Count == 0, "No resource found for " + string.Join(",", notFound.Select(i => string.Join(".", new[] { i.Item1, i.Item2, i.Item3 }))));
        }

        [TestMethod]
        public void AllScalesHaveResourceTest()
        {
            var resourceManager = AsamPpcScaleResources.ResourceManager;
            var dtoTypes = (typeof(IAssessmentDto)).Assembly.GetTypes().Where(t => typeof(IAssessmentDto).IsAssignableFrom(t));

            var notFound = new List<KeyValuePair<string, string>>();
            foreach (var dtoType in dtoTypes)
            {
                foreach (var propertyInfo in dtoType.GetProperties().Where(pi => typeof(Scale).IsAssignableFrom(pi.PropertyType)))
                {
                    if (resourceManager.GetString(dtoType.Name.Replace ( "Dto", "" ) + "_" + propertyInfo.Name) == null)
                    {
                        notFound.Add(new KeyValuePair<string, string> (dtoType.Name, propertyInfo.Name));
                    }
                }
            }
            Assert.IsTrue(notFound.Count == 0, "No scale resource found for " + string.Join(",", notFound.Select(i => string.Join(".", new[] { i.Key, i.Value }))));
        }
    }
}
