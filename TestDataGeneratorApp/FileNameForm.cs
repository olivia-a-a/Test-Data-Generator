using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestDataGeneratorApp.Presenters;
using TestDataGeneratorApp.Views;

namespace TestDataGeneratorApp
{
    public partial class FileNameForm : Form, IFileNameView
    {
        private FileNamePresenter Presenter;
        private string _file_name = "";

        public event EventHandler? ValidateFileName;
        public event EventHandler? LoadView;
        public string EnteredFileName { get => FileNameTextBox.Text; set => FileNameTextBox.Text = value; }

        public string FileName { get => _file_name; set => _file_name = value; }

        public string DefaultFileTypeExplain { set => DefaultFileTypeExplainLbl.Text += value; }

        public FileNameForm()
        {
            InitializeComponent();
            this.Presenter = new FileNamePresenter(this);
        }

        public void ShowAsDialogue()
        {
            this.ShowDialog();
        }

        private void FileNameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidateFileName?.Invoke(this, EventArgs.Empty);
        }

        private void FileNameForm_Load(object sender, EventArgs e)
        {
            LoadView?.Invoke(this, EventArgs.Empty);
        }
    }
}
