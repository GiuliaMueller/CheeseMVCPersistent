using CheeseMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class ViewMenuViewModel
    {
        public string Menu { get; set; }
        IList<CheeseMenu> Items { get; set; }
    }
}
