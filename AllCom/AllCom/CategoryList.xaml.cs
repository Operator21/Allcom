using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AllCom
{
    public partial class CategoryList : ContentPage
    {
        Game game;
        List<Category> c = new List<Category>();

        public CategoryList(Game g)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            if (Uri.IsWellFormedUriString(g.URL, UriKind.Absolute))
            {
                image.Source = new Uri(g.URL);
            }
            else
            {
                image.Source = ImageSource.FromFile(g.URL);
            }

            game = g;
            name.Text = g.Name;   
            c = App.Database.GetCategories(g.ID).Result;
            category_list.ItemsSource = c;
            //Title.Text = "Back";
        }
        private void New(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewCategory(game), false);
        }
        private void Info(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new CategoryInfo(e.Item as Category, game), false);
        }
        private void Back(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new Main(), false);
        }
        private void Edit(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewGame(game), false);
        }
        private void Delete(Object sender, EventArgs e)
        {
            App.Database.DeleteItemAsync(game);
            Navigation.PushAsync(new Main(), false);
        }
        private void Edit_c(object sender, EventArgs e)
        {
            var item = ((MenuItem)sender).CommandParameter as Category;
            Navigation.PushAsync(new NewCategory(item, game), false);


        }
        private void Delete_c(object sender, EventArgs e)
        {
            var item = ((MenuItem)sender).CommandParameter as Category;
            App.Database.DeleteItemAsync(item);
            Navigation.PushAsync(new CategoryList(game), false);

        }

    }
}
