using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Asam.Ppc.Infrastructure.Extensions
{
    public static class AppDomainExtensions
    {
        public static Assembly[] GetAssembliesFromPath(
            this AppDomain appDomain, string path, Predicate<Assembly> assemblyFilter)
        {
            var assemblies = new List<Assembly>();

            IEnumerable<string> assemblyFiles = Directory.GetFiles(path).Where(
                file =>
                    {
                        string extension = Path.GetExtension(file);
                        return extension != null
                               && (extension.Equals(".exe", StringComparison.OrdinalIgnoreCase)
                                   || extension.Equals(".dll", StringComparison.OrdinalIgnoreCase));
                    });

            foreach (string assemblyFile in assemblyFiles)
            {
                Assembly theAssembly = null;
                try
                {
                    theAssembly = Assembly.LoadFrom(assemblyFile);
                }
                catch
                {
                }

                if (theAssembly != null && assemblyFilter(theAssembly))
                {
                    assemblies.Add(theAssembly);
                }
            }

            return assemblies.ToArray();
        }

        public static Assembly[] GetAssembliesFromPath(this AppDomain appDomain, string path)
        {
            return GetAssembliesFromPath(appDomain, path, a => true);
        }

        public static Assembly[] GetAssembliesFromApplicationBaseDirectory(this AppDomain appDomain)
        {
            return GetAssembliesFromApplicationBaseDirectory(appDomain, a => true);
        }

        public static Assembly[] GetAssembliesFromApplicationBaseDirectory(
            this AppDomain appDomain, Predicate<Assembly> assemblyFilter)
        {
            var assemblies = new List<Assembly>();

            assemblies.AddRange(
                GetAssembliesFromPath(appDomain, AppDomain.CurrentDomain.BaseDirectory, assemblyFilter));

            string privateBinPath = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
            if (Directory.Exists(privateBinPath))
            {
                assemblies.AddRange(GetAssembliesFromPath(appDomain, privateBinPath, assemblyFilter));
            }

            return assemblies.ToArray();
        }
    }
}