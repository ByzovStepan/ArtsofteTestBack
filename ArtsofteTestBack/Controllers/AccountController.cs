using ArtsofteTestBack.Interfaces;
using ArtsofteTestBack.Models;
using ArtsofteTestBack.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArtsofteTestBack.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUser _user;

        public AccountController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = _user.GetAll().FirstOrDefault(u => u.Phone == model.Phone && u.Password == model.Password);
                if (currentUser != null)
                {
                    await Authenticate(model.Phone);
                    currentUser.LastLogin = DateTime.Now;
                    _user.Update(currentUser);
                    _user.Save();

                    return RedirectToAction("Cabinet"); // в случае успешной авторизации переделать редирект в кабинет
                }
                ModelState.AddModelError("", "Ошибка авторизации");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = _user.GetAll().FirstOrDefault(u => u.Phone == model.Phone || u.Email == model.Email);
                if (currentUser == null)
                {

                    var registeredUser = new User
                    {
                        FIO = model.FIO,
                        Phone = model.Phone,
                        Email = model.Email,
                        Password = model.Password,
                        LastLogin = DateTime.Now
                    };

                    // добавляем пользователя в бд
                    _user.Insert(registeredUser);
                    _user.Save();

                    //await Authenticate(model.Phone);
                    ViewBag.fio = registeredUser.FIO;
                    return View("RedirectToLogin");
                }
                else
                    ModelState.AddModelError("", "Пользователь с указанным Email / Номером телефона уже есть в системе ");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult RedirectToLogin()
        {
            return View();
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));  
        }

        [Authorize]
        [HttpGet]
        public IActionResult Cabinet()
        {
            User currentUser = _user.GetAll().Where(u => u.Phone == User.Identity.Name).FirstOrDefault();
            return View(currentUser);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
