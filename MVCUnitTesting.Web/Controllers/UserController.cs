using Microsoft.AspNetCore.Mvc;
using MVCUnitTesting.Web.BD;
using MVCUnitTesting.Web.Models;
using MVCUnitTesting.Web.Repositores;

namespace MVCUnitTesting.Web.Controllers;

public class UserController: Controller
{
    // new UserController(new UserRepository());
    
    private readonly IUserRepository repository;
    public UserController(IUserRepository repository)
    {
        this.repository = repository;;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var users = repository.GetAll();
        return View(users);
    }
    
    [HttpGet]
    public IActionResult Details(int id)
    {
        var user = repository.Find(id);
        return View(user);
    }

    [HttpGet]
    public User Create(User user)
    {
        user = repository.Create(user);
        return user;
    }
    
}