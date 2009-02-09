using System;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Reflection;

namespace BriteBIT.Stuff
{
    /// <summary>
    /// This class abstracts GAC installation and removal.
    /// </summary>
    public sealed class Gac
    {
        public static void InstallAssembly(string assemblyPath)
        {
            string errorMessage;
            if (String.IsNullOrEmpty(assemblyPath))
            {
                throw new FileNotFoundException("Could not find assembly file to add to the GAC.", assemblyPath);
            }
            
            try
            {
                Assembly assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);
                byte[] pkey = assembly.GetName().GetPublicKeyToken();
                if (pkey.Length == 0)
                {
                    errorMessage = string.Format("Cannot install an unsigned assembly into the GAC. '{0}'", assemblyPath);
                    throw new NotSupportedException(errorMessage);
                }
            }
            catch (BadImageFormatException ex)
            {
                errorMessage = string.Format("The assembly is not a CLR assembly. '{0}'", assemblyPath);
                throw new BadImageFormatException(errorMessage, ex);
            }
            catch (FileLoadException ex)
            {
                if (!ex.Message.Contains("has already loaded from a different location"))
                {
                    errorMessage = string.Format("CLR assembly found but could not be loaded. '{0}'", assemblyPath);
                    throw new FileLoadException(errorMessage, ex);
                }
            }

            var publish = new Publish();
            publish.GacInstall(assemblyPath.Trim());
            
        }

        public static void RemoveAssembly(string assemblyPath)
        {
            var publish = new Publish();
            try
            {
                publish.GacRemove(assemblyPath.Trim());
            }
            catch (FileNotFoundException)
            {
                
                // Do nothing.  If the assembly is not there
                // then we expect this to happen.
            }
            
        }

        public static bool IsInGac(string assemblyFullName)
        {
            try
            {
                return Assembly.ReflectionOnlyLoad(assemblyFullName) != null && Assembly.ReflectionOnlyLoad(assemblyFullName).GlobalAssemblyCache;
            }
            catch (FileNotFoundException)
            {
                return false;            
            }
        }
    }
}