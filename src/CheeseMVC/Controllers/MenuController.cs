using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Controllers
{
    public class MenuController : Controller

    {
        private readonly CheeseDbContext context;
        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<Menu> menus = context.Menus.ToList();
            return View(menus);
        }

        public IActionResult Add ()
        {
            AddMenuViewModel addMenuViewModel = new AddMenuViewModel();
            return View(addMenuViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuViewModel)
        {
                if (ModelState.IsValid)
                {
                    Menu newMenu = new Menu
                    {
                        Name = addMenuViewModel.Name
                    };

                    context.Menus.Add(newMenu);
                    context.SaveChanges();

                    return Redirect("/Menu/ViewMenu/" + newMenu.ID);
                }

            return View(addMenuViewModel);
        }

        public IActionResult ViewMenu(int id)
        {
            if (id == 0)
            {
                return Redirect("/Menu");
            }

            Menu theMenu = context.Menus.Single(m => m.ID == id);

            List<CheeseMenu> items = context
                .CheeseMenus
                .Include(item => item.Cheese)
                .Where(cm => cm.MenuID == id)
                .ToList();
            ViewMenuViewModel viewMenuViewModel = new ViewMenuViewModel { Menu = theMenu, Items = items };

            ViewBag.title = theMenu.Name;
            return View(viewMenuViewModel);

        }
        public IActionResult AddItem(int id)
        {
            Menu menu = context.Menus.Single(m => m.ID == id);
            return View();
        }

    }
}
