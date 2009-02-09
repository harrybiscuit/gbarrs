using System;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using System.IO;

namespace BriteBIT.Stuff.Tests
{
    [TestFixture]
    public class GacTests
    {
        private const string _assemblyFullName = "UltiDevCassiniHttpRequestProcessor2.0, Version=2.1.4.3, Culture=neutral, PublicKeyToken=cc16caed94880aaa";
        private const string _assemblyFilePath = @"Resources\UltiDevCassiniHttpRequestProcessor2.0.dll";



        [TearDown]
        public void TestTearDown()
        {
            Gac.RemoveAssembly(_assemblyFilePath);
        }

        [Test]
        [Category("Unit")]
        public void InstallAssembly_HttpRequestNotInGac_PublishedHttpRequestAvailable()
        {
            // arrange
            Gac.RemoveAssembly(_assemblyFilePath);
            try
            {
                Assembly.ReflectionOnlyLoad(_assemblyFullName);
            }
            catch (FileNotFoundException)
            {
                //We expect this so swallow exception.             
            }
            catch(Exception ex)
            {
                Assert.Fail("Unexpected exception whilst arranging test",ex);
            }

            // act
            
            Gac.InstallAssembly(_assemblyFilePath);

            // assert
            Assert.That(Assembly.ReflectionOnlyLoad(_assemblyFullName), Is.Not.Null);
        }

        [Test]
        [Category("Unit")]
        public void IsInGac_AssemblyNotInGac_ReturnFalse()
        {        
            Gac.RemoveAssembly(_assemblyFilePath);
            Thread.Sleep(2000);
            Assert.That(Gac.IsInGac(_assemblyFullName),Is.False);
        }


        //ToDo : work out why this fails
        [Test]
        [Category("Unit")]
        public void IsInGac_AssemblyInGac_ReturnTrue()
        {
            Gac.RemoveAssembly(_assemblyFilePath);
            Thread.Sleep(2000);
            Gac.InstallAssembly(_assemblyFilePath);
            Thread.Sleep(2000);
            Assert.That(Gac.IsInGac(_assemblyFullName), Is.True);
        }

    }
}
