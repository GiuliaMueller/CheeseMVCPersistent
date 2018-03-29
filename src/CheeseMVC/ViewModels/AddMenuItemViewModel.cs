using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddMenuItemViewModel
    {
        public int cheeseID { get; set; }
        public List<SelectListItem> Cheeses { get; set; }

        public int menuID { get; set; }
        public Menu Menu { get; set; }

        public AddMenuItemViewModel()
        { }

        public AddMenuItemViewModel(Menu a_menu, IEnumerable<Cheese> some_cheeses)
        {
            Cheeses = new List<SelectListItem>();

            foreach (var cheese in some_cheeses)
            {
                Cheeses.Add(new SelectListItem
                {
                    Value = cheese.ID.ToString(),
                    Text = cheese.Name
                });
            }

            Menu = a_menu;
        }
    }
}
