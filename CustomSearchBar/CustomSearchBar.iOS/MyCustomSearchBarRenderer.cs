using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CustomSearchBar;
using CustomSearchBar.iOS;

[assembly: ExportRenderer(typeof(MyCustomSearchBar),
    typeof(MyCustomSearchBarRenderer))]
namespace CustomSearchBar.iOS
{
    public class MyCustomSearchBarRenderer: SearchBarRenderer
    {
        protected override void OnElementPropertyChanged(object sender,
            PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null)
            {
                // hide cancel button after it is pressed
                if (((SearchBar) sender).Text == null)
                {
                    Control.SetShowsCancelButton(false, false);
                }
                else
                {
                    Control.SetShowsCancelButton(true, false);
                }
            }
        }

    }
}
