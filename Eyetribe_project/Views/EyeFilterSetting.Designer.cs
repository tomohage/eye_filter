namespace Eyetribe_project.Views {
    partial class EyeFilterSetting {
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
            this.start_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.monitor_width_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.monitor_height_textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(93, 53);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(75, 23);
            this.start_button.TabIndex = 4;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(193, 53);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 5;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "モニターサイズ";
            // 
            // monitor_width_textbox
            // 
            this.monitor_width_textbox.Location = new System.Drawing.Point(93, 15);
            this.monitor_width_textbox.Name = "monitor_width_textbox";
            this.monitor_width_textbox.Size = new System.Drawing.Size(73, 19);
            this.monitor_width_textbox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "×";
            // 
            // monitor_height_textbox
            // 
            this.monitor_height_textbox.Location = new System.Drawing.Point(195, 15);
            this.monitor_height_textbox.Name = "monitor_height_textbox";
            this.monitor_height_textbox.Size = new System.Drawing.Size(73, 19);
            this.monitor_height_textbox.TabIndex = 9;
            // 
            // EyeFilterSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 91);
            this.Controls.Add(this.monitor_height_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.monitor_width_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.start_button);
            this.Name = "EyeFilterSetting";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.EyeFilterSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox monitor_width_textbox;
        public System.Windows.Forms.TextBox monitor_height_textbox;
        public System.Windows.Forms.Button start_button;
        public System.Windows.Forms.Button cancel_button;
    }
}