using System.Drawing;
using System.Windows.Forms;
namespace Eyetribe_project.Views {
    partial class EyeFilter {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent () {
            this.components = new System.ComponentModel.Container();
            this.update_point_timer = new System.Windows.Forms.Timer(this.components);
            this.start_button = new System.Windows.Forms.Button();
            this.eye_point = new System.Windows.Forms.Label();
            this.update_point_color_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // update_point_timer
            // 
            this.update_point_timer.Interval = 10;
            this.update_point_timer.Tick += new System.EventHandler(this.update_point_timer_Tick);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(458, 180);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(75, 23);
            this.start_button.TabIndex = 1;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // eye_point
            // 
            this.eye_point.AutoSize = true;
            this.eye_point.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.eye_point.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.eye_point.Location = new System.Drawing.Point(2, 9);
            this.eye_point.Name = "eye_point";
            this.eye_point.Size = new System.Drawing.Size(68, 48);
            this.eye_point.TabIndex = 2;
            this.eye_point.Text = "●";
            this.eye_point.Visible = false;
            // 
            // update_point_color_timer
            // 
            this.update_point_color_timer.Interval = 500;
            this.update_point_color_timer.Tick += new System.EventHandler(this.update_point_color_timer_Tick);
            // 
            // EyeFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.eye_point);
            this.Controls.Add(this.start_button);
            this.Name = "EyeFilter";
            this.Text = "EyeFilter";
            this.TransparencyKey = System.Drawing.Color.GhostWhite;
            this.Load += new System.EventHandler(this.EyeFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Timer update_point_timer;
        public Button start_button;
        public Label eye_point;
        public Timer update_point_color_timer;

    }
}