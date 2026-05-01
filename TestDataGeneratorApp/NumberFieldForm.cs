using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestDataGeneratorApp.Models;
using TestDataGeneratorApp.Presenters;
using TestDataGeneratorApp.Views;

namespace TestDataGeneratorApp
{
    public partial class NumberFieldForm : Form, INumberFieldView, IOptionView
    {
        private NumberFieldPresenter Presenter;
        private bool _allow_close = false;
        private string _msg = "";
        public IField FieldFormat { get; set; }

        public string Msg { get => _msg; set => _msg = value; }

        public string FieldName { get => FieldNameLbl.Text; set => FieldNameLbl.Text = value; }

        public decimal DecimalPlace { get => DecimalPlaces.Value; set => DecimalPlaces.Value = value; }

        public bool DecimalPlaceEnabled { get => DecimalPlaces.Enabled; set => DecimalPlaces.Enabled = value; }

        public string MaxNum { get => MaxNumTextBox.Text; set => MaxNumTextBox.Text = value; }
        public bool MaxNumEnabled { get => MaxNumTextBox.Enabled; set => MaxNumTextBox.Enabled = value; }
        public string MinNum { get => MinNumTextBox.Text; set => MinNumTextBox.Text = value; }

        public bool MinNumEnabled { get => MaxNumTextBox.Enabled; set => MinNumTextBox.Enabled = value; }

        public bool StaysTheSame { get => StaysSameCheckBox.Checked; set => StaysSameCheckBox.Checked = value; }
        public bool StaysTheSameEnabled { get => StaysSameCheckBox.Enabled; set => StaysSameCheckBox.Enabled = value; }

        public string Custom { get => CustomNumTextBox.Text; set => CustomNumTextBox.Text = value; }
        public bool CustomEnabled { get => CustomNumTextBox.Enabled; set => CustomNumTextBox.Enabled = value; }

        public bool CancelClose { get => _allow_close; set => _allow_close = value; }

        public event EventHandler? MaxNumChanged;
        public event EventHandler? MinNumChanged;
        public event EventHandler? CustomNumChanged;
        public event EventHandler? FieldFormClosing;
        public event EventHandler? LoadView;

        public NumberFieldForm()
        {
            InitializeComponent();
            this.Presenter = new NumberFieldPresenter(this);
        }

        public void ShowAsDialogue()
        {
            this.ShowDialog();
        }

        private void NumberFieldOptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FieldFormClosing?.Invoke(this, EventArgs.Empty);
            e.Cancel = CancelClose;
        }

        private void NumberFieldOptionForm_Load(object sender, EventArgs e)
        {
            LoadView?.Invoke(this, EventArgs.Empty);
        }

        private void MaxNumTextBox_TextChanged(object sender, EventArgs e)
        {
            MaxNumChanged?.Invoke(this, EventArgs.Empty);
        }

        private void MinNumTextBox_TextChanged(object sender, EventArgs e)
        {
            MinNumChanged?.Invoke(this, EventArgs.Empty);
        }

        private void CustomNumTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomNumChanged?.Invoke(this, EventArgs.Empty);
        }
        public void show_Message()
        {
            MessageBox.Show(Msg);
        }
    }
}
