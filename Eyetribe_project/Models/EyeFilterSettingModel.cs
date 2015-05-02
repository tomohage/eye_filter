using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Eyetribe_project.Views;

namespace Eyetribe_project.Models {
    public class EyeFilterSettingModel {
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

        /// <summary>
        /// スタートボタンのVisible変更メソッド
        /// </summary>
        /// <param name="visible">bool型パラメータ trueなら表示 falseなら非表示</param>
        /// <remarks>
        /// スタートボタンの表示・非表示を切り替え
        /// </remarks>
        public void visibleStartButton (bool visible) {
            this.eye_filter_setting.start_button.Visible = visible;
            this.eye_filter_setting.Refresh();
        }

        /// <summary>
        /// キャンセルボタンのEnable変更メソッド
        /// </summary>
        /// <param name="enabled">bool型パラメータ trueなら有効 falseなら無効</param>
        /// <remarks>
        /// キャンセルボタンの有効・無効を切り替え
        /// </remarks>
        public void enableCancelButton (bool enabled) {
            this.eye_filter_setting.cancel_button.Enabled = enabled;
            this.eye_filter_setting.Refresh();
        }


    }
}
