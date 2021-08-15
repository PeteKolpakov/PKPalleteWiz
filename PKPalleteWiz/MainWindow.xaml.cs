using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media;

namespace PKPaletteWiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<PaletteEntry> _currentPallete;
        public MainWindow()
        {
            InitializeComponent();
            _currentPallete = new ObservableCollection<PaletteEntry>();
            _currentPallete.Add(new PaletteEntry());
            _currentPallete.Add(new PaletteEntry());
            _currentPallete.Add(new PaletteEntry());
            _currentPallete.Add(new PaletteEntry());
            _currentPallete.Add(new PaletteEntry());
            _currentPallete.Add(new PaletteEntry());
            PalleteDisplay.ItemsSource = _currentPallete;
        }

        private void OnCopyHexToClipboardButtonClick(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("berber");
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show
                (                 
                "Welcome to PKPaletteWiz! \n" +
                "This simple program allows you to store and edit color palettes, and to easily acsess the Hex values of the colors in the stored palettes. \n" +
                "\n", 
                "Help"
                );
        }


    }
}
