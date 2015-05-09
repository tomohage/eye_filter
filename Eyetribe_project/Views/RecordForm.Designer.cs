namespace Eyetribe_project.Views {
    public partial class RecordForm {
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
            this.csv_file_save_checkbox = new System.Windows.Forms.CheckBox();
            this.CsvFilePathTextBox = new System.Windows.Forms.TextBox();
            this.file_reference_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.start_button = new System.Windows.Forms.Button();
            this.write_csv_file_timer = new System.Windows.Forms.Timer(this.components);
            this.record_stopwatch_time_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // csv_file_save_checkbox
            // 
            this.csv_file_save_checkbox.AutoSize = true;
            this.csv_file_save_checkbox.Location = new System.Drawing.Point(12, 12);
            this.csv_file_save_checkbox.Name = "csv_file_save_checkbox";
            this.csv_file_save_checkbox.Size = new System.Drawing.Size(131, 16);
            this.csv_file_save_checkbox.TabIndex = 4;
            this.csv_file_save_checkbox.Text = "CSVファイルとして保存";
            this.csv_file_save_checkbox.UseVisualStyleBackColor = true;
            this.csv_file_save_checkbox.CheckedChanged += new System.EventHandler(this.csv_file_save_checkbox_CheckedChanged);
            // 
            // CsvFilePathTextBox
            // 
            this.CsvFilePathTextBox.Location = new System.Drawing.Point(12, 34);
            this.CsvFilePathTextBox.Name = "CsvFilePathTextBox";
            this.CsvFilePathTextBox.ReadOnly = true;
            this.CsvFilePathTextBox.Size = new System.Drawing.Size(270, 19);
            this.CsvFilePathTextBox.TabIndex = 5;
            // 
            // file_reference_button
            // 
            this.file_reference_button.Enabled = false;
            this.file_reference_button.Location = new System.Drawing.Point(298, 32);
            this.file_reference_button.Name = "file_reference_button";
            this.file_reference_button.Size = new System.Drawing.Size(75, 23);
            this.file_reference_button.TabIndex = 6;
            this.file_reference_button.Text = "参照";
            this.file_reference_button.UseVisualStyleBackColor = true;
            this.file_reference_button.Click += new System.EventHandler(this.file_reference_button_Click);
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(156, 97);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(75, 23);
            this.stop_button.TabIndex = 11;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Visible = false;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // start_button
            // 
            this.start_button.Enabled = false;
            this.start_button.Location = new System.Drawing.Point(156, 97);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(75, 23);
            this.start_button.TabIndex = 12;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // write_csv_file_timer
            // 
            this.write_csv_file_timer.Interval = 10;
            this.write_csv_file_timer.Tick += new System.EventHandler(this.write_csv_file_timer_Tick);
            // 
            // record_stopwatch_time_label
            // 
            this.record_stopwatch_time_label.AutoSize = true;
            this.record_stopwatch_time_label.Location = new System.Drawing.Point(170, 68);
            this.record_stopwatch_time_label.Name = "record_stopwatch_time_label";
            this.record_stopwatch_time_label.Size = new System.Drawing.Size(38, 12);
            this.record_stopwatch_time_label.TabIndex = 13;
            this.record_stopwatch_time_label.Text = "0 [ms]";
            // 
            // RecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 130);
            this.Controls.Add(this.record_stopwatch_time_label);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.file_reference_button);
            this.Controls.Add(this.CsvFilePathTextBox);
            this.Controls.Add(this.csv_file_save_checkbox);
            this.Name = "RecordForm";
            this.Text = "RecordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox csv_file_save_checkbox;
        public System.Windows.Forms.TextBox CsvFilePathTextBox;
        public System.Windows.Forms.Button stop_button;
        public System.Windows.Forms.Button start_button;
        public System.Windows.Forms.Button file_reference_button;
        public System.Windows.Forms.Timer write_csv_file_timer;
        public System.Windows.Forms.Label record_stopwatch_time_label;
    }
}