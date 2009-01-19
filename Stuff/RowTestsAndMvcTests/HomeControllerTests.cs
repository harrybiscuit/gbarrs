using System;
using System.Reflection;
using System.Web.Mvc;
using NUnit.Framework;
using NUnit.Framework.Extensions;
using NUnit.Framework.SyntaxHelpers;
using RowTestsAndMvc.Controllers;
using RowTestsAndMvc.Models;

namespace RowTestsAndMvcTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [RowTest]
        [Row("Index", Colour.red)]
        [Row("About", Colour.blue)]
        [Category("Unit")]
        public void HomeController_ActionCalled_ViewDataContainsExpectedColour(string actionName, Colour expectedColour)
        {
            // arrange
            Colour theExpectedColour = expectedColour;

            // act
            var homeController = new HomeController();
            ViewResult viewResult = CallControllerMethodAndReturnViewResult(homeController, actionName);

            // assert
            Assert.That(viewResult, Is.Not.Null);
            if (viewResult == null || !(viewResult.ViewData["Colour"] is Colour))
            {
                Assert.Fail("ViewData does not contain a Colour.");
                return;
            }

            var actualColour = (Colour) viewResult.ViewData["Colour"];
            Assert.That(actualColour, Is.EqualTo(theExpectedColour));
        }

        private static ViewResult CallControllerMethodAndReturnViewResult(Controller controller, string methodName)
        {
            Type controllerType = controller.GetType();
            MethodInfo methodToTest = controllerType.GetMethod(methodName);
            Assert.That(methodToTest, Is.Not.Null, string.Format("No method called {0} found.", methodName));
            return methodToTest.Invoke(controller, null) as ViewResult;
        }
    }
}