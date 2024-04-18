using FastFood.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Ropository
{
    public class DbInitializer : IDbInitializer
    {
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public DbInitializer(RoleManager<IdentityRole> rolemanager, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _rolemanager = rolemanager;
            _userManager = userManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if(_context.Database.GetPendingMigrations().Count()>0)
                {
                    _context.Database.Migrate();
                }
            }
            catch(Exception)
            {
                throw;
            }
            if (_context.Roles.Any(x => x.Name == "Admin")) return;
            _rolemanager.CreateAsync(new IdentityRole("Manager")).GetAwaiter().GetResult();
            _rolemanager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            _rolemanager.CreateAsync(new IdentityRole("Customer")).GetAwaiter().GetResult();

            var user = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                Name = "Nimur",
                City="Dhaka",
                Address="Badda",
                PostalCode="333"
            };
            _userManager.CreateAsync(user,"Admin@123").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(user,"Admin");

        }
    }
}
