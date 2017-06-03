using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AllCom
{
    public partial class Main : ContentPage
    {
        List<Game> games = new List<Game>();

        public Main()
        {
            InitializeComponent();
            
            /*for (int x = 0; x < 25; x++)
            {
                Game g = new Game();
                g.Name = "Game" + x;
                g.URL = "unk.jpg";
                App.Database.SaveItemAsync(g);
            }*/
            NavigationPage.SetHasNavigationBar(this, false);
            /*games = App.Database.GetItemsAsync().Result;
            foreach(Game ga in games)
            {
                Debug.WriteLine(ga.Name);
            }*/
            /*foreach(Game g in games)
            {
                DisplayAlert("",g.Name,"Kill me");
            }
            
            /*for (int x = 0; x < 10; x++)
            {
                Category item = new Category();
                item.Name = "Category "+ x;
                item.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce malesuada velit ultrices, pretium urna et, cursus dolor. Morbi eget ante rutrum diam sagittis condimentum. Vivamus consequat lectus vel imperdiet lacinia. Ut molestie est ut lectus laoreet sagittis. Maecenas pretium, odio eu volutpat cursus, ipsum neque rutrum ipsum, eget maximus mi enim id tortor. Sed iaculis urna in metus commodo accumsan. Aliquam eu sodales lacus, vel semper est. Morbi nec volutpat metus. Suspendisse ultricies diam purus, ut placerat enim fermentum rhoncus. Nam ex ex, semper ut risus imperdiet, luctus suscipit ipsum. Phasellus nec tortor a ex vulputate porta.";
                item.GameID = 0;
                App.Database.SaveItemAsync(item);
            }*/
            games = App.Database.GetItemsAsync().Result;
            game_list.ItemsSource = games;
        }
        private void ToCategories(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new CategoryList(e.Item as Game), false);
        }
        private void New(Object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewGame(), false);
        }
        private void Edit(Object sender, EventArgs e)
        {
            var item = ((MenuItem)sender).CommandParameter as Game;
            Navigation.PushAsync(new NewGame(item), false);
        }
        private void Delete(Object sender, EventArgs e)
        {
            var item = ((MenuItem)sender).CommandParameter as Game;
            App.Database.DeleteItemAsync(item);
            Navigation.PushAsync(new Main(), false);
        }


    }
}
