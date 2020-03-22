using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomSearchBar
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        List<string> _items;

        public MainPage()
        {
            InitializeComponent();

            _items = new List<string>();
            _items.Add("Baboon");
            _items.Add("Capuchin Monkey");
            _items.Add("Blue Monkey");
            _items.Add("Squirrel Monkey");
            _items.Add("Golden Lion Tamarin");
            _items.Add("Howler Monkey");
            _items.Add("Japanese Macaque");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = _items;
            searchBar.PropertyChanged += OnSearchTextChanged;
        }

        void OnSearchTextChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Text"))
            {
                var searchText = ((SearchBar)sender).Text;
                if (searchText != null)
                {
                    if (!searchText.Trim().Equals(""))
                    {
                        listView.ItemsSource = _items.Where(item => {
                            return item.Trim().ToLower().Contains(
                                searchText.Trim().ToLower());
                        });
                    }
                    else
                    {
                        listView.ItemsSource = _items;
                    }
                }
                else
                {
                    listView.ItemsSource = _items;
                }
            }
        }
    }
}
