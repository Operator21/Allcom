using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AllCom
{

    public partial class Page1 : ContentPage
    {
        List<Test> t = new List<Test>();
        public Page1()
        {
            InitializeComponent();
            for (int x = 0; x < 10; x++)
            {
                Test test = new Test();
                test.s = "zaznam" + x;
                App.Database.SaveItemAsync(test);
            }
            t = App.Database.GetTestAsync().Result;
            foreach (Test te in t)
            {
                Debug.WriteLine(te.ID + te.s);
            }
        }
    }
}
