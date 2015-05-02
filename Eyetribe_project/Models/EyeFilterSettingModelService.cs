using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Eyetribe_project.Models {
    partial class EyeFilterSettingModel {

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
