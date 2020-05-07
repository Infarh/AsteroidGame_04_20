using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditorFinforms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            var result = OpenFile.ShowDialog();
            if (result != DialogResult.OK) return;

            var file_name = OpenFile.FileName;

            if (!File.Exists(file_name))
            {
                MessageBox.Show(
                    "Выбранный файл не найден!", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            var file_text = File.ReadAllText(file_name);

            MainTextBox.Text = file_text;
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            var save_file_dialog = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                Title = "Выбор файла для сохранения"
            };

            var result = save_file_dialog.ShowDialog();

            if(result != DialogResult.OK) return;

            var file_name = save_file_dialog.FileName;

            File.WriteAllText(file_name, MainTextBox.Text);
        }
    }
}
