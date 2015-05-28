#region Using Statements

using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Agatha.Common;
using Asam.Ppc.Common.Crypto;
using Asam.Ppc.Domain.SecurityModule;
using Asam.Ppc.Mvc.Infrastructure.Security;
using Asam.Ppc.Mvc.Infrastructure.Service;
using Asam.Ppc.Mvc4.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

#endregion

namespace Asam.Ppc.Mvc4.Tests
{
    [TestClass]
    public class RouteTests
    {
        [TestMethod]
        public void CanMapNormalControllerActionRoute()
        {
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            var httpContextMock = new Mock<HttpContextBase>();
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/patient/index");

            var routeData = routes.GetRouteData(httpContextMock.Object);

            Assert.IsNotNull(routeData);
            RouteTestHelper.AssertRoute(routes, routeData.Values, new {controller = "patient", action = "index"});
        }

        [TestMethod]
        public void RouteHasDefaultActionWhenUrlWithoutAction()
        {
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            RouteTestHelper.AssertRoute(routes, "~/patient", new {controller = "patient", action = "index"});
        }

        [TestMethod]
        public void TestOutgoingRoutes()
        {
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            var context = new RequestContext(RouteTestHelper.CreateHttpContext(), new RouteData());

            var result = UrlHelper.GenerateUrl(null, "Index", "Home", null, routes, context, true);
            var routeValues = new RouteValueDictionary();
            routeValues.Add("Id", "TheId");
            string result2 = UrlHelper.GenerateUrl(null, "Index", "Home", routeValues, routes, context, true);

            Assert.AreEqual("/", result);
            Assert.AreEqual("/Home/Index/TheId", result2);
        }

        [TestMethod]
        public void SectoionControllerRedirectedToCorrectPage()
        {
            var requestDispatcherFactoryMock = new Mock<IRequestDispatcherFactory>();
            var routeNavigationServiceMock = new Mock<IRouteNavigationService>();
            routeNavigationServiceMock.Setup(i => i.GetInitialRoute(It.IsAny<long?> ()))
                                      .Returns(new RouteInfo("GeneralInformationSection", 0));
            var patientAccessControlManagerMock = new Mock<IPatientAccessControlManager>();

            var assessmentController = new AssessmentController(requestDispatcherFactoryMock.Object,
                                                                          routeNavigationServiceMock.Object,
                                                                          patientAccessControlManagerMock.Object);

            var result = assessmentController.Edit(It.IsAny<long>());

            Assert.IsNotNull(result);
            var redirectToRouteResult = result as RedirectToRouteResult;
            Assert.AreEqual(redirectToRouteResult.RouteName, "SectionRoute");

            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            RouteTestHelper.AssertRoute(routes, redirectToRouteResult.RouteValues, new { id = "0", section = "GeneralInformationSection" });
        }

        [TestMethod]
        public void CannotAccessAllPatientReturnsHttpNotFoundResult()
        {
            var requestDispatcherFactoryMock = new Mock<IRequestDispatcherFactory>();
            var patientAccessControlManagerMock = new Mock<IPatientAccessControlManager>();
            var apiSystemAccountRepositoryMock = new Mock<IApiSystemAccountRepository>();
            var systemAccountRepositoryMock = new Mock<ISystemAccountRepository>();
            var cryptoMock = new Mock<ICrypto>();

            patientAccessControlManagerMock.Setup(i => i.CanAccessAllPatients).Returns(false);
            var homeController = new HomeController(requestDispatcherFactoryMock.Object,
                                                    patientAccessControlManagerMock.Object,
                                                    apiSystemAccountRepositoryMock.Object,
                                                    systemAccountRepositoryMock.Object,
                                                    cryptoMock.Object);

            var controllerContextMock = new Mock<ControllerContext>();

            homeController.ControllerContext = controllerContextMock.Object;
            var result = homeController.Index();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.GetType().Name, "HttpNotFoundResult");
        }

        [TestMethod]
        public void CanAccessAllPatientReturnsReviewResult()
        {
            var requestDispatcherFactoryMock = new Mock<IRequestDispatcherFactory>();
            var patientAccessControlManagerMock = new Mock<IPatientAccessControlManager>();
            var apiSystemAccountRepositoryMock = new Mock<IApiSystemAccountRepository>();
            var systemAccountRepositoryMock = new Mock<ISystemAccountRepository>();
            var cryptoMock = new Mock<ICrypto>();

            patientAccessControlManagerMock.Setup(i => i.CanAccessAllPatients).Returns(true);

            var homeController = new HomeController(requestDispatcherFactoryMock.Object,
                                                    patientAccessControlManagerMock.Object,
                                                    apiSystemAccountRepositoryMock.Object,
                                                    systemAccountRepositoryMock.Object,
                                                    cryptoMock.Object);

            var controllerContextMock = new Mock<ControllerContext>();

            homeController.ControllerContext = controllerContextMock.Object;
            var result = homeController.Index();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.GetType().Name, "ViewResult");
        }

        [TestMethod]
        public void MatchRoutes()
        {
            RouteTestHelper.TestRouteMatch("~/Error/HttpError", "Error", "HttpError");
            RouteTestHelper.TestRouteMatch("~/Error/Http404", "Error", "Http404");
            RouteTestHelper.TestRouteMatch("~/interview/GenernalInformationSection/Edit/1", "Section", "Edit");
            RouteTestHelper.TestRouteMatch("~/interview/DrugAndAlcoholSection/AlcoholUse/Edit/1", "Section", "Edit");
        }

        [TestMethod]
        public void RouteForEmbeddedResource()
        {
            var mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("∼/handler.axd");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            var routeData = routes.GetRouteData(mockContext.Object);

            Assert.IsNotNull(routeData);
            Assert.IsInstanceOfType(routeData.RouteHandler, typeof(StopRoutingHandler));
        }
    }
}