using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Eyetribe_project.Models;


namespace Eyetribe_project.Views {
    public partial class EyeFilterSetting : Form {
        private EyeFilterSettingModel eye_filter_setting_model;

        public EyeFilterSetting () {
            InitializeComponent();
        }

        private void EyeFilterSetting_Load (object sender, EventArgs e) {

        }

        private void StartButton_Click (object sender, EventArgs e) {
            this.eye_filter_setting_model = new EyeFilterSettingModel(this);
            try {
                EyeFilter eye_filter = new EyeFilter(this.eye_filter_setting_model);
                eye_filter.Show();
            } catch (FormatException) {
                MessageBox.Show("正しい値を入力してください");
                return;
            }
            start_button.Visible = false;
        }

        private void CancelButton_Click (object sender, EventArgs e) {
            Environment.Exit(0);
        }

    }
}
