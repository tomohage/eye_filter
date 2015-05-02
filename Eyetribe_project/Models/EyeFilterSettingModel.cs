using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Eyetribe_project.Views;

namespace Eyetribe_project.Models {
    public partial class EyeFilterSettingModel {
        EyeFilterSetting eye_filter_setting;

        private int monitor_width;
        private int monitor_height;

        public EyeFilterSettingModel (EyeFilterSetting eye_filter_setting) {
            this.eye_filter_setting = eye_filter_setting;
            this.monitor_width = int.Parse(this.eye_filter_setting.monitor_width_textbox.Text);
            this.monitor_height = int.Parse(this.eye_filter_setting.monitor_height_textbox.Text);
        }

        /// <summary>
        /// モニターサイズ取得メソッド
        /// </summary>
        /// <remarks>
        /// 設定フォームで入力したモニターサイズを返す
        /// </remarks>
        public Size getMonitorSize () {
            return new Size(this.monitor_width, this.monitor_height);
        }
    }
}
