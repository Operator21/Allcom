using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AllCom
{
    public static class Utility
    {
        public static void Setup(Page p)
        {
            NavigationPage.SetHasNavigationBar(p, false);
        }   
    }
}
