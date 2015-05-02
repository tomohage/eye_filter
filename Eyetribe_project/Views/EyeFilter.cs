using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using System.Diagnostics;
using Eyetribe_project.Models;

namespace Eyetribe_project.Views {
    public partial class EyeFilter : Form {
        private EyeFilterModel eye_filter_model = null;
        // 設定フォームの操作も行うのでメンバ変数に追加
        private EyeFilterSettingModel eye_filter_setting_model = null;

        public EyeFilter (EyeFilterSettingModel eye_filter_setting_model) {
            this.eye_filter_setting_model = eye_filter_setting_model;
            InitializeComponent();
        }

        private void EyeFilter_Load (object sender, EventArgs e) {
            this.eye_filter_model = new EyeFilterModel(this, this.eye_filter_setting_model);

            Color red = Color.FromArgb(255, 200, 200);
            eye_point.ForeColor = red;

            // 設定フォームで入力したモニターサイズをEyeFilterモデルクラスのインスタンスに覚えさせる
            Size monitor_size = this.eye_filter_setting_model.getMonitorSize();
            this.eye_filter_model.updateMonitorSize(monitor_size);
        }

        private void StartButton_Click (object sender, EventArgs e) {
            // startボタンを押したときのフィルタのサイズをモデルに記録
            this.eye_filter_model.updateFilterSize(this.Size);
            // フィルタのサイズは変更できないようにする
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // 設定フォームのスタートボタンを非表示、ストップボタンを表示
            // キャンセルボタンを無効にする（ストップボタンを押せば有効になる）
            this.eye_filter_setting_model.visibleStartButton(false);
            this.eye_filter_setting_model.enableCancelButton(false);

            // フィルタ上のスタートボタンを非表示
            this.eye_filter_model.visibleStartButton(false);

            // EyeTribe接続
            this.eye_filter_model.connectEyetribe();

            // Timerを実行する
            this.eye_filter_model.enabledUpdatePointTimer(true);

            // 視点の色を変化するために用いるストップウォッチインスタンスを起動
            this.eye_filter_model.startColorStopwatch();

            this.eye_filter_model.enabledUpdatePointColorTimer(true);

            RecordForm record_form = new RecordForm(this.eye_filter_model);
            record_form.Show();
        }

        private void update_point_timer_Tick (object sender, EventArgs e) {
            this.eye_filter_model.redraw();
            this.Refresh();
        }

        private void update_point_color_timer_Tick (object sender, EventArgs e) {
            this.eye_filter_model.changeEyePointColor();
            this.Refresh();
        }
    }
}
