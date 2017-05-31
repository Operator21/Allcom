using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AllCom
{
    public partial class NewGame : ContentPage
    {
        bool edit;
        Game game;
        public NewGame()
        {
            InitializeComponent();
            Setup();
        }
        public NewGame(Game g)
        {
            InitializeComponent();
            Setup();
            if(g.URL != "unk.png")
            {
                url.Text = g.URL;
            }
            game = g;
            edit = true;
            name.Text = game.Name;
            
        }
        private void Save(Object sender, EventArgs e)
        {
            Game item = new Game();
            if (edit)
            {
                item.ID = game.ID;
            }
            item.Name = name.Text;
            if(string.IsNullOrWhiteSpace(url.Text) || string.IsNullOrEmpty(url.Text))
            {
                item.URL = "unk.png";
            }
            else
            {
                item.URL = url.Text;
            }
            
            App.Database.SaveItemAsync(item);
            Navigation.PushAsync(new Main(), false);
        }
        private void Back(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new CategoryList(game), false);
        }
        private void Setup()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            
        }

        private void url_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*if (Uri.IsWellFormedUriString(url.Text, UriKind.Absolute))
            {
                preview.Source = new Uri(url.Text);
            } else
            {
                preview.Source = ImageSource.FromFile("error.jpg");
            }*/
            
        }
    }
}
