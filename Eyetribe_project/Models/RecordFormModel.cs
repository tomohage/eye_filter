using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using Eyetribe_project.Views;

namespace Eyetribe_project.Models {
    partial class RecordFormModel {
        private bool is_saved_as_csv_file = false;
        private string file_path_saved = null;

        private RecordForm record_form = null;
        private EyeFilterModel eye_filter_model = null;

        private StreamWriter stream_writer = null;
        private Stopwatch stop_watch = null;

        public RecordFormModel (RecordForm record_form, EyeFilterModel eye_filter_model) {
            this.stop_watch = new Stopwatch();
            this.record_form = record_form;
            this.eye_filter_model = eye_filter_model;
        }

        public void setData () {
            this.is_saved_as_csv_file = record_form.csv_file_save_checkbox.Checked;
            this.file_path_saved = record_form.CsvFilePathTextBox.Text;
        }

        /// <summary>
        /// メンバ変数の保存先ファイルパスを返すメソッド
        /// </summary>
        /// <remarks>
        /// メンバ変数の保存先ファイルパスを返すメソッド
        /// </remarks>
        /// <returns>file_path_saved</returns>
        public string getFilePathSaved () {
            return this.file_path_saved;
        }

        /// <summary>
        /// メンバ変数の保存先ファイルパスを更新メソッド
        /// </summary>
        /// <param name="file_path_saved">新しい保存先ファイルパス</param>
        /// <remarks>
        /// メンバ変数の保存先ファイルパスを返すメソッド
        /// </remarks>
        public void updateFilePathSaved (string file_path_saved) {
            this.file_path_saved = file_path_saved;
        }

        /// <summary>
        /// メンバ変数の保存するか否かの真偽値を返すメソッド
        /// </summary>
        /// <remarks>
        /// メンバ変数の保存するか否かの真偽値を返すメソッド
        /// </remarks>
        /// <returns>is_saved_as_csv_file</returns>
        public bool getIsSavedAsCsvFile () {
            return this.is_saved_as_csv_file;
        }

        /// <summary>
        /// メンバ変数の保存するか否かの真偽値を更新するメソッド
        /// </summary>
        /// <param name="is_saved_as_csv_file">セーブするかしないかの真偽値</param>
        /// <remarks>
        /// メンバ変数の保存するか否かの真偽値を更新するメソッド
        /// </remarks>
        public void updateIsSavedAsCsvFile (bool is_saved_as_csv_file) {
            this.is_saved_as_csv_file = is_saved_as_csv_file;
        }
    }
}
