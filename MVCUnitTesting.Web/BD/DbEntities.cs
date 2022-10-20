using Microsoft.EntityFrameworkCore;
using MVCUnitTesting.Web.Models;

namespace MVCUnitTesting.Web.BD;


public class DbEntities: DbContext
{
    public DbSet<User> Users { get; set; } // que es? attributo / propiedad
}