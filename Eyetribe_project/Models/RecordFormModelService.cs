using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Eyetribe_project.Models {
    partial class RecordFormModel {
        /// <summary>
        /// CSVファイルに視線データを記録スタートするメソッド
        /// </summary>
        /// <remarks>
        /// 計測を開始するメソッド
        /// 計測終了する際はstopSavingCsvFileメソッドを実行してください
        /// このクラスのインスタンスのメンバ変数
        /// </remarks>
        public void startSavingCsvFile () {
            if (this.file_path_saved == "") {
                MessageBox.Show("ファイルパスを指定してください");
                return;
            }
            this.stream_writer = new StreamWriter(this.file_path_saved);
            Size monitor_size = this.eye_filter_model.getMonitorSize();
            Size filter_size = this.eye_filter_model.getFilterSize();
            this.stream_writer.WriteLine("[monitor size],width," + monitor_size.Width + ",height," + monitor_size.Height);
            this.stream_writer.WriteLine("[filter size],width," + filter_size.Width + ",height," + filter_size.Height);
            this.stream_writer.WriteLine("when eye is closed: (x y)=(0 0)");
            this.stream_writer.WriteLine("");
            this.stream_writer.WriteLine("time(ms),x,y");
            this.stop_watch.Start();
        }

        /// <summary>
        /// CSVファイルに視線データを書きこむメソッド
        /// </summary>
        /// <remarks>
        /// 実行するたびにcsvファイルに現在の視点座標を書き込むメソッド
        /// startSavingCsvFileメソッドが実行された後に実行できる
        /// </remarks>
        public void writeEyePointLocationOnCsvFile () {
            if (this.stream_writer == null) {
                throw new Exception("StreamWriterクラスのインスタンスが未定義っぽい。startSavingCsvFileメソッド実行した？");
            }

            // 目が認識できない場合は座標を0,0とする
            if (this.eye_filter_model.is_eye()) {
                Point visual_point_location = this.eye_filter_model.getVisualPointLocation();
                this.stream_writer.WriteLine(this.stop_watch.ElapsedMilliseconds + "," +
                    visual_point_location.X + "," + visual_point_location.Y);
            } else {
                this.stream_writer.WriteLine(this.stop_watch.ElapsedMilliseconds + ",0,0");
            }
        }

        /// <summary>
        /// CSVファイルに視線データを記録終了するメソッド
        /// </summary>
        /// <remarks>
        /// 計測を開始するメソッド
        /// 計測終了する際はstopSavingCsvFileメソッドを実行してください
        /// このクラスのインスタンスのメンバ変数
        /// </remarks>
        public void stopSavingCsvFile () {
            this.stream_writer.Close();
            this.stop_watch.Stop();
        }

        /// <summary>
        /// stopボタンのvisibleを切り替えるメソッド
        /// </summary>
        /// <param name="visible">boolで切り替える</param>
        /// <remarks>
        /// stopボタンのvisibleを切り替えるメソッド
        /// </remarks>
        public void visibleStopButton (bool visible) {
            this.record_form.stop_button.Visible = visible;
        }

        /// <summary>
        /// startボタンのvisibleを切り替えるメソッド
        /// </summary>
        /// <param name="visible">boolで切り替える</param>
        /// <remarks>
        /// startボタンのvisibleを切り替えるメソッド
        /// </remarks>
        public void visibleStartButton (bool visible) {
            this.record_form.start_button.Visible = visible;
        }

        /// <summary>
        /// CsvFileSaveCheckBoxのenabledを切り替えるメソッド
        /// </summary>
        /// <param name="enabled">boolで切り替える</param>
        /// <remarks>
        /// CsvFileSaveCheckBoxのenabledを切り替えるメソッド
        /// </remarks>
        public void enabledCsvFileSaveCheckBox (bool enabled) {
            this.record_form.csv_file_save_checkbox.Enabled = enabled;
        }

        /// <summary>
        /// FileReferenceButtonを切り替えるメソッド
        /// </summary>
        /// <param name="enabled">boolで切り替える</param>
        /// <remarks>
        /// FileReferenceButtonのenabledを切り替えるメソッド
        /// </remarks>
        public void enabledFileReferenceButton (bool enabled) {
            this.record_form.file_reference_button.Enabled = enabled;
        }

        /// <summary>
        /// saving_csv_file_checkboxの切り替えに対して他のコントロールに連動させるメソッド
        /// </summary>
        /// <param name="is_checked">saving_csv_file_checkboxのchecked</param>
        /// <remarks>
        /// saving_csv_file_checkboxの切り替えに対して他のコントロールに連動させるメソッド
        /// file_referece_buttonとstart_buttonと連動
        /// </remarks>
        public void changeSavingCsvFileCheckBox (bool is_checked) {
            this.record_form.csv_file_save_checkbox.Checked = is_checked;
            if (is_checked) {
                this.record_form.file_reference_button.Enabled = true;
                this.record_form.start_button.Enabled = true;
            } else {
                this.record_form.file_reference_button.Enabled = false;
                this.record_form.start_button.Enabled = false;
            }
        }
    }
}
