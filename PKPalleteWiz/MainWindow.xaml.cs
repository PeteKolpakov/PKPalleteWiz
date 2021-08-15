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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Win32;

namespace PKPaletteWiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string FILE_DIALOG_FILTER = "Palette Files|*.palette|All Files|*.*";
        private ObservableCollection<PaletteEntry> _currentPallete;
        public MainWindow()
        {
            InitializeComponent();

            // read data from config file

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

        #region FileMenuButtonEvents
        private void OnNewPaletteButtonClicked(object sender, RoutedEventArgs e)
        {

        }
        private void OnOpenFileButtonClicked(object sender, RoutedEventArgs e)
        {
            // should also display list of recently opened files
        }
        private void OnSaveButtonClicked(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = FILE_DIALOG_FILTER; // make sure to not add spaces to the extention definitions, or it will search for the sapces as well xP
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sfd.OverwritePrompt = true;
            // save data
            string fileName = sfd.FileName;

            try
            {
                // Bianary
                using (FileStream fs = File.OpenWrite(fileName)) // using blocks will automatically dispose of IDisposable types once the block is exited
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, _currentPallete);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR:", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    
        private void OnSaveAsButtonClicked(object sender, RoutedEventArgs e)
        {

        }
        private void OnPreferencesButtonClicked(object sender, RoutedEventArgs e)
        {

        }
        private void OnQuitButtonClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region OtherMenuButtonEvents
        private void OnHelpButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show
                (                 
                "Welcome to PKPaletteWiz! \n" +
                "This simple program allows you to store and edit color palettes, and to easily acsess the Hex values of the colors in the stored palettes. \n" +
                "\n", 
                "Help"
                );
        }
        
        #endregion


    }
}
