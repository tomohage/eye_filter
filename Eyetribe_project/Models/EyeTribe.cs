using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using System.Diagnostics;

using TETCSharpClient;
using TETCSharpClient.Data;
using System.Runtime.InteropServices;

namespace Eyetribe_project.Models {
    /// <summary>
    /// Eyeクラス
    /// <newpara>
    /// EyeTribeの接続設定と視点座標を管理するクラス
    /// </newpara>
    /// </summary>
    /// <remarks>
    /// Eyeクラスの詳しい詳細
    /// <newpara>
    /// このクラスのインスタンスを用いることで、
    /// 座標をメンバ変数で管理しonGazeUpdateメソッドで更新する
    /// </newpara>
    /// </remarks>
    public class EyeTribe : IGazeListener {
        private double x;
        private double y;
        private bool is_connected;

        public bool Enabled { get; set; }

        public EyeTribe () {
            this.is_connected = false;
        }

        /// <summary>
        /// 視点座標更新メソッド
        /// </summary>
        /// <param name="gazeData">EyeTribeから受信した視点情報のインスタンス</param>
        /// <remarks>
        /// 常に実行しており、this.xとthis.yを常に更新し続ける
        /// </remarks>
        public void OnGazeUpdate (GazeData gaze_data) {
            this.x = gaze_data.SmoothedCoordinates.X;
            this.y = gaze_data.SmoothedCoordinates.Y;
        }

        /// <summary>
        /// 接続用メソッド
        /// </summary>
        /// <remarks>
        /// メソッド使用例
        /// <newpare>
        /// Eye eye = new Eye(this);
        /// eye.Connect();
        /// </newpare>
        /// </remarks>
        public void Connect () {
            this.is_connected = GazeManager.Instance.Activate(GazeManager.ApiVersion.VERSION_1_0, GazeManager.ClientMode.Push);
            GazeManager.Instance.AddGazeListener(this);
            if (!this.is_connected) {
                Console.WriteLine("接続できてないっす");
            }
            Console.WriteLine("接続しました");
        }

        /// <summary>
        /// 切断用メソッド
        /// </summary>
        /// <remarks>
        /// メソッド使用例
        /// <newpare>
        /// Eye eye = new Eye(this);
        /// eye.Connect();
        /// eye.Disconnect();
        /// </newpare>
        /// </remarks>
        public void Disconnect () {
            GazeManager.Instance.Deactivate();
            this.is_connected = false;
            Console.WriteLine("勇気の切断");
        }

        public Point getEyePointLocation () {
            return new Point((int)this.x, (int)this.y);
        }
    }
}
