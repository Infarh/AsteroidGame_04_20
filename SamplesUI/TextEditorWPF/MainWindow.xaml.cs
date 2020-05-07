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
using Microsoft.Win32;

namespace TextEditorWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Title = "123";
            //Width = 800;
            //Height = 600;
        }

        private void OnCloseMenuItemClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnOpenFileMenuClick(object Sender, RoutedEventArgs E)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выбор файла для редактирования", 
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
            };

            if(dialog.ShowDialog() != true) return;

            var file_name = dialog.FileName;

            MainTextEdit.Text = File.ReadAllText(file_name);
        }

        private void OnSaveFileMenuClick(object Sender, RoutedEventArgs E)
        {
            var dialog = new SaveFileDialog
            {
                Title = "Выбор файла для редактирования",
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
            };

            if (dialog.ShowDialog() != true) return;

            var file_name = dialog.FileName;

            File.WriteAllText(file_name, MainTextEdit.Text);
        }
    }
}
