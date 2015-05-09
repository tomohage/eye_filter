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
    public partial class RecordForm : Form {
        private RecordFormModel record_form_model = null;

        public RecordForm (EyeFilterModel eye_filter_model) {
            this.record_form_model = new RecordFormModel(this, eye_filter_model);
            InitializeComponent();
        }

        private void start_button_Click (object sender, EventArgs e) {
            this.record_form_model.updateFilePathSaved(this.CsvFilePathTextBox.Text);
            this.record_form_model.updateIsSavedAsCsvFile(this.csv_file_save_checkbox.Checked);

            this.record_form_model.startSavingCsvFile();

            this.record_form_model.visibleStartButton(false);
            this.record_form_model.visibleStopButton(true);

            this.record_form_model.enabledCsvFileSaveCheckBox(false);
            this.record_form_model.enabledFileReferenceButton(false);

            write_csv_file_timer.Enabled = true;
        }

        private void file_reference_button_Click (object sender, EventArgs e) {
            this.FileDialog();
        }

        private void FileDialog () {
            // 実行ファイルのディレクトリパス
            string dir_path = System.IO.Directory.GetCurrentDirectory();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "";
            sfd.InitialDirectory = dir_path;
            sfd.Filter =
                "CSVファイル(*.csv)|*.csv";
            sfd.FilterIndex = 2;
            sfd.Title = "保存先のファイルを選択してください";
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            if (sfd.ShowDialog() == DialogResult.OK) {
                CsvFilePathTextBox.Text = sfd.FileName;
            }
        }

        private void write_csv_file_timer_Tick (object sender, EventArgs e) {
            this.record_form_model.writeEyePointLocationOnCsvFile();
            this.record_form_model.updateRecordStopwatchTimeLabel();
        }

        private void stop_button_Click (object sender, EventArgs e) {
            this.record_form_model.visibleStartButton(true);
            this.record_form_model.visibleStopButton(false);
            this.write_csv_file_timer.Enabled = false;

            this.record_form_model.enabledCsvFileSaveCheckBox(true);
            this.record_form_model.enabledFileReferenceButton(true);

            this.record_form_model.stopSavingCsvFile();
        }

        private void csv_file_save_checkbox_CheckedChanged (object sender, EventArgs e) {
            if (csv_file_save_checkbox.Checked) {
                file_reference_button.Enabled = true;
                start_button.Enabled = true;
            } else {
                file_reference_button.Enabled = false;
                start_button.Enabled = false;
            }
        }
    }
}
