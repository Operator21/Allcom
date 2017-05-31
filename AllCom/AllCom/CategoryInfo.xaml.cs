using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AllCom
{
    public partial class CategoryInfo : ContentPage
    {
        Category cat;
        Game game;
        public CategoryInfo(Category c, Game g)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            cat = c;
            name.Text = c.Name;
            content.Text = c.Text;
            game = g;
        }

        private void Edit(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewCategory(cat,game), false);
        }
        private void Delete(object sender, EventArgs e)
        {
            App.Database.DeleteItemAsync(cat);
            Navigation.PushAsync(new CategoryList(game), false);
        }
        private void Back(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new CategoryList(game), false);
        }
    }
}
