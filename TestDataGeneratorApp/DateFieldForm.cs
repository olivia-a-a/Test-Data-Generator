using Bogus.DataSets;
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
    public partial class DateFieldForm : Form, IDateFieldView, IOptionView
    {
        private DateFieldPresenter Presenter;

        private string _msg = "";
        private bool _allow_close = false;

        public string Msg { get => _msg; set => _msg = value; }
        public IField FieldFormat { get; set; }

        public string FieldName { get => FieldNameLbl.Text; set => FieldNameLbl.Text = value; }

        public DateTime MaxDate { get => MaxDateTimePicker.Value; set => MaxDateTimePicker.Value = value; }
        public bool MaxDateEnabled { get => MaxDateTimePicker.Enabled; set => MaxDateTimePicker.Enabled = value; }
        public string SetMaxDateToolTip { set => FormatExplainToolTip.SetToolTip(MaxDateTimePicker, value); }
        public string SetMaxDateFormat { set => MaxDateTimePicker.CustomFormat = value; }

        public DateTime MinDate { get => MinDateTimePicker.Value; set => MinDateTimePicker.Value = value; }
        public bool MinDateEnabled { get => MinDateTimePicker.Enabled; set => MinDateTimePicker.Enabled = value; }
        public string SetMinDateToolTip { set => FormatExplainToolTip.SetToolTip(MinDateTimePicker, value); }
        public string SetMinDateFormat { set => MinDateTimePicker.CustomFormat = value; }

        public string Custom { get => CustomDateTextBox.Text; set => CustomDateTextBox.Text = value; }
        public bool CustomEnabled { get => CustomDateTextBox.Enabled; set => CustomDateTextBox.Enabled = value; }

        public string Format { get => DateFormatTextBox.Text; set => DateFormatTextBox.Text = value; }
        public bool FormatEnabled { get => DateFormatTextBox.Enabled; set => DateFormatTextBox.Enabled = value; }

        public bool StaysTheSame { get => StaysSameCheckBox.Checked; set => StaysSameCheckBox.Checked = value; }
        public bool StaysTheSameEnabled { get => StaysSameCheckBox.Enabled; set => StaysSameCheckBox.Enabled = value; }

        public bool CancelClose { get => _allow_close; set => _allow_close = value; }

        public event EventHandler? FormatLinkClicked;

        public event EventHandler? CustomDateChanged;

        public event EventHandler? DateFormatChanged;

        public event EventHandler? FieldFormClosing;

        public event EventHandler? LoadView;

        public DateFieldForm()
        {
            this.Presenter = new DateFieldPresenter(this);
            InitializeComponent();
        }

        private void DateFieldOptionForm_Load(object sender, EventArgs e)
        {
            LoadView?.Invoke(this, EventArgs.Empty);
        }

        public void ShowAsDialogue()
        {
            this.ShowDialog();
        }
        public void show_Message()
        {
            MessageBox.Show(Msg);
        }

        private void DateFormatTextBox_TextChanged(object sender, EventArgs e)
        {
            DateFormatChanged?.Invoke(this, EventArgs.Empty);
        }

        private void DateFieldOptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FieldFormClosing?.Invoke(this, EventArgs.Empty);
            e.Cancel = CancelClose;
        }

        private void CustomDateTextBox_TextChanged(object sender, EventArgs e)
        {
            CustomDateChanged?.Invoke(this, EventArgs.Empty);
        }

        private void DateFormatLinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormatLinkClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
