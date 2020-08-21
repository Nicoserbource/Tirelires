using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Tirelires.Models;
using System.Security.Claims;

namespace Tirelires.Controllers
{
    public class CompteController : Controller
    {
        private SignInManager<Client> _signInManager;
        private UserManager<Client> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public CompteController(SignInManager<Client> signInManager, UserManager<Client> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost, ActionName("Login")]
        public async Task<IActionResult> LoginPost(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, login.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Failed to login");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ActionName("Register")]
        public async Task<IActionResult> RegisterPost(Register register)
        {
            if (ModelState.IsValid)
            {
                Client client = new Client
                {
                    Prenom = register.FirstName,
                    Nom = register.LastName,
                    Email = register.Email,
                    UserName = register.UserName,
                    Statut = true
                };

                var result = await _userManager.CreateAsync(client, register.Password);
                if (result.Succeeded)
                {
                    bool roleExists = await _roleManager.RoleExistsAsync(register.RoleName);
                    if (!roleExists)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(register.RoleName));
                    }

                    if (!await _userManager.IsInRoleAsync(client, register.RoleName))
                    {
                        await _userManager.AddToRoleAsync(client, register.RoleName);
                    }

                    if (!string.IsNullOrWhiteSpace(client.Email))
                    {
                        Claim claim = new Claim(ClaimTypes.Email, client.Email);
                        await _userManager.AddClaimAsync(client, claim);
                    }

                    var resultSignIn = await _signInManager.PasswordSignInAsync(register.UserName, register.Password, register.RememberMe, false);
                    if (resultSignIn.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
