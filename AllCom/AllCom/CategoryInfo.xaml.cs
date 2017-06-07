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
        private async void Delete(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Delete", "Are you sure ?", "Yes", "Cancel");
            if (result)
            {
                await App.Database.DeleteItemAsync(cat);
                await Navigation.PushAsync(new CategoryList(game), false);
            }
        }
        private void Back(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new CategoryList(game), false);
        }
    }
}
