using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AllCom
{
    public partial class NewCategory : ContentPage
    {
        bool edit;
        Category cat;
        int game_id;
        Game game;
        public NewCategory(Game g)
        {
            InitializeComponent();
            game_id = g.ID;
            game = g;
            Setup(g);
        }
        public NewCategory(Category c, Game g)
        {
            InitializeComponent();
            cat = c;
            edit = true;
            game_id = g.ID;
            name.Text = c.Name;
            content.Text = c.Text;
            Setup(g);
        }
        private void Save(Object sender, EventArgs e)
        {
            Category item = new Category();
            if (edit)
            {
                item.ID = cat.ID;
            }
            item.GameID = game_id;
            item.Name = name.Text;
            item.Text = content.Text;

            App.Database.SaveItemAsync(item);
            Navigation.PushAsync(new CategoryList(game), false);
        }
        private void Back(Object sender, EventArgs e)
        {
            if (edit)
            {
                Navigation.PushAsync(new CategoryInfo(cat,game), false);
            }
            else
            {
                Navigation.PushAsync(new CategoryList(game), false);
            }
            
        }
        private void Setup(Game g)
        {
            game = g;
            NavigationPage.SetHasNavigationBar(this, false);
            //Title.Text = "Back";
        }
    }
}
