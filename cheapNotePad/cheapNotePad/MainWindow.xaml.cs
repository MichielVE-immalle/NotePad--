using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cheapNotePad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentFile = "";
        private string initialDir;

        public MainWindow()
        {
            InitializeComponent();

            initialDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void exitItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OpenFileVenster = new OpenFileDialog();
            string startdir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            OpenFileVenster.InitialDirectory = startdir;
            OpenFileVenster.Filter = "Doc Files | *txt;";

            if (OpenFileVenster.ShowDialog() == true)
            {
                MessageBox.Show(OpenFileVenster.FileName);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (currentFile == "")
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = initialDir;
                dialog.Filter = "Doc Files | *txt;";
                if (dialog.ShowDialog() == true)
                {
                    currentFile = dialog.FileName + ".txt";
                    File.WriteAllText(dialog.FileName, currentFile);
                }
            }
            StreamWriter outputStream = File.CreateText(currentFile);
            outputStream.Write(schrijfPanel.Text);
            outputStream.Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gewoon in typen!", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter outputStream;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = initialDir;
            if (dialog.ShowDialog() == true)
            {
                currentFile = dialog.FileName + ".txt";
                outputStream = File.CreateText(currentFile);
                outputStream.Write(schrijfPanel);
                outputStream.Close();
            }
        }

        private void Nieuw_Click(object sender, RoutedEventArgs e)
        {
            schrijfPanel.Clear();
        }
    }
}
