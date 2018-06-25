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

namespace KivNetExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private AppVM.AppVM GetDataContext()
        {
            return (AppVM.AppVM)DataContext;
        }

        private void OnExportToHtmlClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    AddExtension = true,
                    DefaultExt = "html"
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    string htmlData = GetDataContext().ExportToHtml();
                    File.WriteAllText(saveFileDialog.FileName, htmlData);
                }
            } catch (Exception ex)
            {
                DisplayError($"Unexpected exception while exporting to html: {ex.Message}.");
            }
        }

        private void OnExportToSvgClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    AddExtension = true,
                    DefaultExt = "svg"
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    string svgData = GetDataContext().ExportToSvg();
                    File.WriteAllText(saveFileDialog.FileName, svgData);
                }
            } catch (Exception ex)
            {
                DisplayError($"Unexpected exception while exporting to svg: {ex.Message}.");
            }
        }

        private void DisplayError(String errorMessage)
        {
            MessageBox.Show("Error", errorMessage, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
