using System;
using System.Collections.Generic;
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

namespace FolderStructureImporterExporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtRootpath.Focus();
        }

        private void btnImport_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRootpath.Text))
                {
                    MessageBox.Show("Please enter a valid Root Path", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtRootpath.Focus();
                    return;
                }

                var rootPath = @"C:\Users\sukanta.sharma\Desktop\test";// txtRootpath.Text;
                var importHelperObj = new ImportHelper();
                importHelperObj.Import(rootPath);

                MessageBox.Show("Successfully Imported", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnExport_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRootpath.Text))
                {
                    MessageBox.Show("Please enter a valid Root Path", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtRootpath.Focus();
                    return;
                }

                var rootPath = @"D:\1241327\StudyProjects\FolderStructureImporterExporter"; //txtRootpath.Text;// ;
                var exportHelperObj = new ExportHelper();
                exportHelperObj.Export(rootPath);

                MessageBox.Show("Successfully Exported", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
