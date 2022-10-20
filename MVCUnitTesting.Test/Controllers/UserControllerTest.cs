using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Moq;
using MVCUnitTesting.Web.BD;
using MVCUnitTesting.Web.Controllers;
using MVCUnitTesting.Web.Models;
using MVCUnitTesting.Web.Repositores;
using NUnit.Framework;

namespace MVCUnitTesting.Test.Controllers;

// MOCK
public class UserControllerTest
{
    [Test]
    public void IndexOkCase01()
    {
        var moq = new Mock<IUserRepository>();
        var users = new List<User>();
        moq.Setup(o => o.GetAll()).Returns(users);
        var repository = moq.Object;
        
        var controller = new UserController(repository);
        controller.Index();
    }

    [Test]
    public void DetailsOkCase01()
    {
        var repositoryMock = new Mock<IUserRepository>();
        // repositoryMock
        //     .Setup(o => o.Find(1))
        //     .Returns(new User() {Id = 1, Name = "Luis"});
        
        // It.IsAny<>()
        // It.IsAny<int>()
        // It.IsAny<string>()
        // It.IsAny<User>()
        //2 
        repositoryMock
            .Setup(o => o.Find(1)) // cualquier numero
            .Returns(new User() {Id = 1, Name = "Luis"});
        
        // ejecucion => 1
        var controller = new UserController(repositoryMock.Object);
        var view =  controller.Details(1) as ViewResult;
        
        Assert.IsNotNull(view);
        Assert.AreEqual(1, ((User)view.Model).Id);
    }

    [Test]
    public void CreateOkCase01()
    {
        var userSetup = new User() {Name = "Messi"}; // 0X0001

        var repositoryMock = new Mock<IUserRepository>();
        repositoryMock.Setup(o => o.Create(userSetup)) 
            .Returns(userSetup); 
        
        var controller = new UserController(repositoryMock.Object); 

        var user = controller.Create(userSetup); 
        Assert.IsNotNull(user);
        Assert.AreEqual(user, userSetup); 
    }
}

// dotnet restore 
// dotnet build
// dotnet test

