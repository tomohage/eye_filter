using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.IO;
using Eyetribe_project.Views;

namespace Eyetribe_project.Models {
    public partial class EyeFilterModel {

        private EyeTribe eyetribe;

        // view
        private EyeFilter eye_filter;

        // model
        private EyeFilterSettingModel eye_filter_setting_model;

        private Size monitor_size;
        private Size filter_size;
        private Point visual_point_location;
        private Size visual_point_size;

        private Stopwatch stop_watch = new Stopwatch();

        // 視点の色変化用メンバ変数
        private Stopwatch color_stop_watch = new Stopwatch();
        private const int GAZE_AREA = 50;
        private Color INIT_COLOR = Color.FromArgb(255, 200, 200);
        private Point start_gaze_point = new Point(0, 0);
        private float start_time;

        public EyeFilterModel (EyeFilter eye_filter, EyeFilterSettingModel eye_filter_setting_model) {
            this.eye_filter = eye_filter;
            this.eye_filter_setting_model = eye_filter_setting_model;

            this.eyetribe = new EyeTribe();

            this.monitor_size = eye_filter_setting_model.getMonitorSize();
            this.filter_size = eye_filter.Size;
            this.visual_point_location = eye_filter.eye_point.Location;
            this.visual_point_size = eye_filter.eye_point.Size;

            this.eye_filter.eye_point.ForeColor = INIT_COLOR;

            this.stop_watch = new Stopwatch();
        }

        /// <summary>
        /// フィルターのサイズを変更するメソッド
        /// </summary>
        /// <param name="filter_size">Size型フィルターのサイズ</param>
        /// <remarks>
        /// フィルターフォームのサイズを変更する
        /// </remarks>
        public void updateFilterSize (Size filter_size) {
            this.filter_size = filter_size;
        }

        /// <summary>
        /// モニターのサイズを変更するメソッド
        /// </summary>
        /// <param name="filter_size">Size型モニターのサイズ</param>
        /// <remarks>
        /// トラッキングする対象モニターのサイズを変更する
        /// </remarks>
        public void updateMonitorSize (Size monitor_size) {
            this.monitor_size = monitor_size;
        }

        /// <summary>
        /// モデルのメンバ変数の視点座標を変更するメソッド
        /// </summary>
        /// <param name="filter_size">Point型視点の座標</param>
        /// <remarks>
        /// メンバ変数の視点座標を変更する
        /// </remarks>
        public void updateVisualPointLocation (Point visual_point_location) {
            this.visual_point_location = visual_point_location;
        }

        /// <summary>
        /// 実行された時の視点座標を返すメソッド
        /// </summary>
        /// <remarks>
        /// メンバ変数でPoint型であるvisual_point_location変数を返す
        /// </remarks>
        public Point getVisualPointLocation () {
            return this.visual_point_location;
        }

        /// <summary>
        /// フィルター設定で登録したモニターのサイズを返すメソッド
        /// </summary>
        public Size getMonitorSize () {
            return this.monitor_size;
        }

        /// <summary>
        /// レコードを開始した際のフィルターのサイズを返すメソッド
        /// </summary>
        public Size getFilterSize () {
            return this.filter_size;
        }
    }
}
