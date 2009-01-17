using MvcApplicationPreview4.Controllers;
using MvcApplicationPreview4.Models;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using System.Web.Mvc;
using NUnit.Framework.Extensions;

namespace MvcApplicationPreview4Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [RowTest]
        [Row("Index",Colour.red)]
        [Row("About",Colour.blue)]
        [Category("Unit")]
        public void Home_FirstVisit_ViewDataContainsDefaultColour(string methodName, Colour expectedColour)
        {
            // arrange
            var theExpectedColour = expectedColour;

            // act
            var homeController = new HomeController();
            var viewResult = CallControllerMethodAndReturnViewResult(homeController, methodName) ;
           
            // assert
            Assert.That(viewResult, Is.Not.Null);
            if (viewResult == null || !(viewResult.ViewData["Colour"] is Colour))
            {
                Assert.Fail("ViewData does not contain a Colour.");
                return;
            }

            var actualColour = (Colour)viewResult.ViewData["Colour"];
            Assert.That(actualColour, Is.EqualTo(theExpectedColour));

        }

        private static ViewResult CallControllerMethodAndReturnViewResult(Controller controller, string methodName)
        {
            var controlleType = controller.GetType();
            var methodToTest = controlleType.GetMethod(methodName);
            Assert.That(methodToTest, Is.Not.Null, string.Format("No method called {0} found.", methodName));
            return methodToTest.Invoke(controller, null) as ViewResult;
        }

    }
}
