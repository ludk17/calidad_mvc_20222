using MVCUnitTesting.Web.Controllers;
using NUnit.Framework;

namespace MVCUnitTesting.Test.Controllers;

public class HomeControllerTest
{
    [Test]
    public void IndexOkCase01()
    {
        var controller = new HomeController();
        var view = controller.Index();
        Assert.IsNotNull(view); // verificar(validar si) IsNotNull
    }
}