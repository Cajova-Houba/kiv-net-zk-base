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

        private void ExportToXml()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    AddExtension = true,
                    DefaultExt = "xml"
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    GetDataContext().ExportToXml(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                DisplayError($"Unexpected exception while exporting to xml: {ex.Message}.");
            }
        }

        private void ExportToHtml()
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
                    GetDataContext().ExportToHtml(saveFileDialog.FileName);
                }
            } catch (Exception ex)
            {
                DisplayError($"Unexpected exception while exporting to html: {ex.Message}.");
            }
        }

        private void ExportToSvg()
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
                    GetDataContext().ExportToSvg(saveFileDialog.FileName);
                }
            } catch (Exception ex)
            {
                DisplayError($"Unexpected exception while exporting to svg: {ex.Message}.");
            }
        }

        private void ExportCanvasToPng()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    AddExtension = true,
                    DefaultExt = "png"
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    double dpi = 96d;
                    PixelFormat pixelFormat = PixelFormats.Default;
                    // pouzit opravdovy canvas
                    Canvas canvas = null;
                    Rect rect = new Rect(canvas.RenderSize);
                    RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right,
                      (int)rect.Bottom, dpi, dpi, pixelFormat);
                    rtb.Render(canvas);
                    //endcode as PNG
                    BitmapEncoder pngEncoder = new PngBitmapEncoder();
                    pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

                    //save to memory stream
                    MemoryStream ms = new MemoryStream();

                    pngEncoder.Save(ms);
                    ms.Close();
                    File.WriteAllBytes(saveFileDialog.FileName, ms.ToArray());
                }
            } catch (Exception ex)
            {
                DisplayError($"Unexpected exception while exporting to png: {ex.Message}.");
            }
        }

        private void DisplayError(String errorMessage)
        {
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetDataContext().AddMeteostation();
            } catch(Exception ex)
            {
                DisplayError("Error while adding meteostaiton: " + ex.Message);
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetDataContext().RefreshReportPanel();
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                GetDataContext().AddReport();
            }
            catch (Exception ex)
            {
                DisplayError("Error while adding meteostaiton: " + ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                GetDataContext().AddReportData();
            }
            catch (Exception ex)
            {
                DisplayError("Error while adding meteostaiton: " + ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ExportToXml();
        }
    }
}
