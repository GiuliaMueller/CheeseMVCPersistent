using CheeseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class ViewMenuViewModel
    {
        public Menu Menu { get; set; }
        public IList<CheeseMenu> Items { get; set; }

        public ViewMenuViewModel() //default constructor needed to make madel binding work in the EF
        {

        }

        public ViewMenuViewModel( Menu theMenu, IList<CheeseMenu> item)
        {
            Menu = theMenu;
            Items = item;
        }
    }
}
