using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace Eyetribe_project.Models {
    partial class EyeFilterModel {
        /// <summary>
        /// フィルター上の座標変換メソッド
        /// </summary>
        /// <param name="eye_point_location">モニター上での視点座標</param>
        /// <remarks>
        /// モニター上での視点座標をフィルター上の座標に変換するメソッド
        /// </remarks>
        public Point arangeByMonitorAndFilterSize (Point eye_point_location) {
            // 座標をモニターのサイズに調整
            double re_x = eye_point_location.X * this.filter_size.Width / this.monitor_size.Width;
            double re_y = eye_point_location.Y * this.filter_size.Height / this.monitor_size.Height;

            // 視点座標を右上端ではなくテキストボックスの中心にずらす
            re_x -= this.eye_filter.eye_point.Size.Width / 2;
            re_y -= this.eye_filter.eye_point.Size.Height / 2;

            return new Point((int)re_x, (int)re_y);
        }

        /// <summary>
        /// フィルター上の視点座標を再描画するメソッド
        /// </summary>
        /// <remarks>
        /// EyeFilterModelクラスのメンバ変数であるvisual_point_locationに再描画
        /// 座標をvisual_point_sizeの大きさに再描画
        /// 目を認識できない場合は視点を消す
        /// </remarks>
        public void redraw () {
            // モニター上の視点座標を取得
            this.visual_point_location = this.eyetribe.getEyePointLocation();
            // フィルタのサイズとモニターのサイズから計算したフィルタ上での視点座標
            Point eye_point_location_on_monitor = this.arangeByMonitorAndFilterSize(this.visual_point_location);
            eye_point_location_on_monitor = this.arrangeTitleBar(eye_point_location_on_monitor);
            Console.WriteLine(eye_point_location_on_monitor);
            if (this.is_eye()) {
                this.eye_filter.eye_point.Visible = true;
                this.eye_filter.eye_point.Location = eye_point_location_on_monitor;
                this.eye_filter.eye_point.Size = this.visual_point_size;
            } else {
                this.eye_filter.eye_point.Visible = false;
            }
            this.eye_filter.Refresh();
        }

        /// <summary>
        /// EyeTribe接続メソッド
        /// </summary>
        public void connectEyetribe () {
            this.eyetribe.Connect();
        }

        /// <summary>
        /// 視点の座標を変更するタイマーのenabledを操作するメソッド
        /// </summary>
        /// <param name="enabled">bool型パラメータ trueなら実行 falseなら停止</param>
        /// <remarks>
        /// 視点の座標を変更するタイマーのenabledを操作するメソッド
        /// trueにすればタイマーコントロールの処理がインターバルごとに実行される
        /// </remarks>
        public void enabledUpdatePointTimer (bool enabled) {
            this.eye_filter.update_point_timer.Enabled = enabled;
        }

        /// <summary>
        /// 視点の色を変更するタイマーのenabledを操作するメソッド
        /// </summary>
        /// <param name="enabled">bool型パラメータ trueなら実行 falseなら停止</param>
        /// <remarks>
        /// 視点の色を変更するタイマーのenabledを操作するメソッド
        /// trueにすればタイマーコントロールの処理がインターバルごとに実行される
        /// </remarks>
        public void enabledUpdatePointColorTimer (bool enabled) {
            this.eye_filter.update_point_color_timer.Enabled = enabled;
        }

        /// <summary>
        /// csvファイル保存用のタイマーコントロールをstart状態にするメソッド
        /// </summary>
        public void startStopwatch () {
            this.stop_watch.Start();
        }

        /// <summary>
        /// 注視状態の視点の色を変更するためのタイマーコントロールををstart状態にするメソッド
        /// </summary>
        public void startColorStopwatch () {
            this.color_stop_watch.Start();
        }

        /// <summary>
        /// 視点の色を変更するメソッド
        /// </summary>
        /// <remarks>
        /// 注視開始時の視点座標からx,y座標に対してGAZE_AREA内に視点があるとき、
        /// 視点の色がピンクから赤へどんどん濃くなる
        /// 視点がGAZE_AREAの外に出た場合ピンクに戻る
        /// </remarks>
        public void changeEyePointColor () {
            Point now_location_point = this.eyetribe.getEyePointLocation();
            long now_time_milisec = this.color_stop_watch.ElapsedMilliseconds;
            if (this.start_gaze_point.IsEmpty ||
               Math.Abs(now_location_point.X - this.start_gaze_point.X) > GAZE_AREA ||
               Math.Abs(now_location_point.Y - this.start_gaze_point.Y) > GAZE_AREA) {
                this.eye_filter.eye_point.ForeColor = this.INIT_COLOR;
                this.start_gaze_point = this.eyetribe.getEyePointLocation();
                this.start_time = now_time_milisec;
                return;
            }
            if ((int)this.eye_filter.eye_point.ForeColor.G == 0 || (int)this.eye_filter.eye_point.ForeColor.B == 0) {
                return;
            }
            int G = (int)this.eye_filter.eye_point.ForeColor.G - 20;
            int B = (int)this.eye_filter.eye_point.ForeColor.B - 20;
            this.eye_filter.eye_point.ForeColor = Color.FromArgb(255, G, B);
        }

        /// <summary>
        /// 目がeyetribeに写っているか判断するメソッド
        /// </summary>
        /// <remarks>
        /// 目が写っていたらtrueを返し、写っていなかったらfalse
        /// </remarks>
        public bool is_eye () {
            Point eye_point_locatin = this.eyetribe.getEyePointLocation();
            if ((eye_point_locatin.X <= 0 || eye_point_locatin.Y <= -SystemInformation.CaptionHeight) ||
                (eye_point_locatin.X > this.monitor_size.Width || eye_point_locatin.Y > this.monitor_size.Height)) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// スタートボタンのVisible変更メソッド
        /// </summary>
        /// <param name="visible">bool型パラメータ trueなら表示 falseなら非表示</param>
        /// <remarks>
        /// スタートボタンの表示・非表示を切り替え
        /// </remarks>
        public void visibleStartButton (bool visible) {
            this.eye_filter.start_button.Visible = visible;
        }

        public Point arrangeTitleBar (Point eye_point_location) {
            eye_point_location.Y -= SystemInformation.CaptionHeight;
            return eye_point_location;
        }
    }
}
