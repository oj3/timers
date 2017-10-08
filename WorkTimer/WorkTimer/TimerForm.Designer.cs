namespace WorkTimer
{
    partial class TimerForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startButton = new System.Windows.Forms.Button();
            this.resetTimerButton = new System.Windows.Forms.Button();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.flashTimer = new System.Windows.Forms.Timer(this.components);
            this.minTextBox = new System.Windows.Forms.TextBox();
            this.secTextBox = new System.Windows.Forms.TextBox();
            this.millisecTextBox = new System.Windows.Forms.TextBox();
            this.colonLabel = new System.Windows.Forms.Label();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.pointLabel = new System.Windows.Forms.Label();
            this.minUpButton = new System.Windows.Forms.Button();
            this.secUpButton = new System.Windows.Forms.Button();
            this.minDownButton = new System.Windows.Forms.Button();
            this.secDownButton = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.millisecUpButton = new System.Windows.Forms.Button();
            this.millisecDownButton = new System.Windows.Forms.Button();
            this.stepTextBox = new System.Windows.Forms.TextBox();
            this.stepUpButton = new System.Windows.Forms.Button();
            this.stepDownButton = new System.Windows.Forms.Button();
            this.inputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.Control;
            this.startButton.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.startButton.Location = new System.Drawing.Point(22, 150);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(189, 60);
            this.startButton.TabIndex = 12;
            this.startButton.TabStop = false;
            this.startButton.Text = "●";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            this.startButton.Enter += new System.EventHandler(this.Button_Enter);
            this.startButton.Leave+= new System.EventHandler(this.Button_Leave);
            this.startButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            // 
            // resetTimerButton
            // 
            this.resetTimerButton.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.resetTimerButton.Location = new System.Drawing.Point(227, 150);
            this.resetTimerButton.Name = "resetTimerButton";
            this.resetTimerButton.Size = new System.Drawing.Size(75, 60);
            this.resetTimerButton.TabIndex = 13;
            this.resetTimerButton.TabStop = false;
            this.resetTimerButton.Text = "○";
            this.resetTimerButton.UseVisualStyleBackColor = true;
            this.resetTimerButton.Click += new System.EventHandler(this.ResetTimerButton_Click);
            this.resetTimerButton.Enter += new System.EventHandler(this.Button_Enter);
            this.resetTimerButton.Leave += new System.EventHandler(this.Button_Leave);
            this.resetTimerButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // flashTimer
            // 
            this.flashTimer.Interval = 300;
            // 
            // minTextBox
            // 
            this.minTextBox.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.minTextBox.Location = new System.Drawing.Point(10, 3);
            this.minTextBox.MaxLength = 3;
            this.minTextBox.Name = "minTextBox";
            this.minTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.minTextBox.Size = new System.Drawing.Size(65, 55);
            this.minTextBox.TabIndex = 0;
            this.minTextBox.TabStop = false;
            this.minTextBox.Text = "25";
            this.minTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.minTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.minTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            this.minTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            // 
            // secTextBox
            // 
            this.secTextBox.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.secTextBox.Location = new System.Drawing.Point(83, 3);
            this.secTextBox.MaxLength = 2;
            this.secTextBox.Name = "secTextBox";
            this.secTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.secTextBox.Size = new System.Drawing.Size(45, 55);
            this.secTextBox.TabIndex = 2;
            this.secTextBox.TabStop = false;
            this.secTextBox.Text = "00";
            this.secTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.secTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.secTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            this.secTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            // 
            // millisecTextBox
            // 
            this.millisecTextBox.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.millisecTextBox.Location = new System.Drawing.Point(134, 3);
            this.millisecTextBox.MaxLength = 3;
            this.millisecTextBox.Name = "millisecTextBox";
            this.millisecTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.millisecTextBox.Size = new System.Drawing.Size(65, 55);
            this.millisecTextBox.TabIndex = 4;
            this.millisecTextBox.TabStop = false;
            this.millisecTextBox.Text = "000";
            this.millisecTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.millisecTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.millisecTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            this.millisecTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            // 
            // colonLabel
            // 
            this.colonLabel.AutoSize = true;
            this.colonLabel.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.colonLabel.Location = new System.Drawing.Point(64, 6);
            this.colonLabel.Name = "colonLabel";
            this.colonLabel.Size = new System.Drawing.Size(34, 48);
            this.colonLabel.TabIndex = 1;
            this.colonLabel.Text = ":";
            this.colonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.minTextBox);
            this.inputPanel.Controls.Add(this.millisecTextBox);
            this.inputPanel.Controls.Add(this.secTextBox);
            this.inputPanel.Controls.Add(this.colonLabel);
            this.inputPanel.Controls.Add(this.pointLabel);
            this.inputPanel.Location = new System.Drawing.Point(12, 12);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(209, 61);
            this.inputPanel.TabIndex = 0;
            // 
            // pointLabel
            // 
            this.pointLabel.AutoSize = true;
            this.pointLabel.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pointLabel.Location = new System.Drawing.Point(119, 6);
            this.pointLabel.Name = "pointLabel";
            this.pointLabel.Size = new System.Drawing.Size(31, 48);
            this.pointLabel.TabIndex = 3;
            this.pointLabel.Text = ".";
            this.pointLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // minUpButton
            // 
            this.minUpButton.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.minUpButton.Location = new System.Drawing.Point(22, 79);
            this.minUpButton.Name = "minUpButton";
            this.minUpButton.Size = new System.Drawing.Size(65, 26);
            this.minUpButton.TabIndex = 2;
            this.minUpButton.TabStop = false;
            this.minUpButton.Text = "▲";
            this.minUpButton.UseVisualStyleBackColor = true;
            this.minUpButton.Click += new System.EventHandler(this.UpButton_Click);
            this.minUpButton.Enter += new System.EventHandler(this.Button_Enter);
            this.minUpButton.Leave += new System.EventHandler(this.Button_Leave);
            this.minUpButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            // 
            // secUpButton
            // 
            this.secUpButton.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.secUpButton.Location = new System.Drawing.Point(95, 79);
            this.secUpButton.Name = "secUpButton";
            this.secUpButton.Size = new System.Drawing.Size(45, 26);
            this.secUpButton.TabIndex = 4;
            this.secUpButton.TabStop = false;
            this.secUpButton.Text = "▲";
            this.secUpButton.UseVisualStyleBackColor = true;
            this.secUpButton.Click += new System.EventHandler(this.UpButton_Click);
            this.secUpButton.Enter += new System.EventHandler(this.Button_Enter);
            this.secUpButton.Leave += new System.EventHandler(this.Button_Leave);
            this.secUpButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            // 
            // minDownButton
            // 
            this.minDownButton.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.minDownButton.Location = new System.Drawing.Point(22, 107);
            this.minDownButton.Name = "minDownButton";
            this.minDownButton.Size = new System.Drawing.Size(65, 26);
            this.minDownButton.TabIndex = 3;
            this.minDownButton.TabStop = false;
            this.minDownButton.Text = "▼";
            this.minDownButton.UseVisualStyleBackColor = true;
            this.minDownButton.Click += new System.EventHandler(this.DownButton_Click);
            this.minDownButton.Enter += new System.EventHandler(this.TimeDownButton_Enter);
            this.minDownButton.Enter += new System.EventHandler(this.Button_Enter);
            this.minDownButton.Leave += new System.EventHandler(this.Button_Leave);
            this.minDownButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            // 
            // secDownButton
            // 
            this.secDownButton.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.secDownButton.Location = new System.Drawing.Point(95, 107);
            this.secDownButton.Name = "secDownButton";
            this.secDownButton.Size = new System.Drawing.Size(45, 26);
            this.secDownButton.TabIndex = 5;
            this.secDownButton.TabStop = false;
            this.secDownButton.Text = "▼";
            this.secDownButton.UseVisualStyleBackColor = true;
            this.secDownButton.Click += new System.EventHandler(this.DownButton_Click);
            this.secDownButton.Enter += new System.EventHandler(this.TimeDownButton_Enter);
            this.secDownButton.Enter += new System.EventHandler(this.Button_Enter);
            this.secDownButton.Leave += new System.EventHandler(this.Button_Leave);
            this.secDownButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.timeLabel.Location = new System.Drawing.Point(16, -7);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(205, 48);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.Text = "025:00.000";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // millisecUpButton
            // 
            this.millisecUpButton.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.millisecUpButton.Location = new System.Drawing.Point(146, 79);
            this.millisecUpButton.Name = "millisecUpButton";
            this.millisecUpButton.Size = new System.Drawing.Size(65, 26);
            this.millisecUpButton.TabIndex = 6;
            this.millisecUpButton.TabStop = false;
            this.millisecUpButton.Text = "▲";
            this.millisecUpButton.UseVisualStyleBackColor = true;
            this.millisecUpButton.Click += new System.EventHandler(this.UpButton_Click);
            this.millisecUpButton.Enter += new System.EventHandler(this.Button_Enter);
            this.millisecUpButton.Leave += new System.EventHandler(this.Button_Leave);
            this.millisecUpButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            // 
            // millisecDownButton
            // 
            this.millisecDownButton.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.millisecDownButton.Location = new System.Drawing.Point(146, 107);
            this.millisecDownButton.Name = "millisecDownButton";
            this.millisecDownButton.Size = new System.Drawing.Size(65, 26);
            this.millisecDownButton.TabIndex = 7;
            this.millisecDownButton.TabStop = false;
            this.millisecDownButton.Text = "▼";
            this.millisecDownButton.UseVisualStyleBackColor = true;
            this.millisecDownButton.Click += new System.EventHandler(this.DownButton_Click);
            this.millisecDownButton.Enter += new System.EventHandler(this.TimeDownButton_Enter);
            this.millisecDownButton.Enter += new System.EventHandler(this.Button_Enter);
            this.millisecDownButton.Leave += new System.EventHandler(this.Button_Leave);
            this.millisecDownButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            // 
            // stepTextBox
            // 
            this.stepTextBox.Enabled = false;
            this.stepTextBox.Font = new System.Drawing.Font("メイリオ", 20F);
            this.stepTextBox.Location = new System.Drawing.Point(262, 83);
            this.stepTextBox.MaxLength = 2;
            this.stepTextBox.Name = "stepTextBox";
            this.stepTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.stepTextBox.Size = new System.Drawing.Size(40, 47);
            this.stepTextBox.TabIndex = 9;
            this.stepTextBox.TabStop = false;
            this.stepTextBox.Text = "99";
            this.stepTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // stepUpButton
            // 
            this.stepUpButton.Font = new System.Drawing.Font("メイリオ", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stepUpButton.Location = new System.Drawing.Point(227, 83);
            this.stepUpButton.Name = "stepUpButton";
            this.stepUpButton.Size = new System.Drawing.Size(30, 22);
            this.stepUpButton.TabIndex = 14;
            this.stepUpButton.TabStop = false;
            this.stepUpButton.Text = "△";
            this.stepUpButton.UseVisualStyleBackColor = true;
            this.stepUpButton.Click += new System.EventHandler(this.UpButton_Click);
            this.stepUpButton.Enter += new System.EventHandler(this.Button_Enter);
            this.stepUpButton.Leave += new System.EventHandler(this.Button_Leave);
            this.stepUpButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            // 
            // stepDownButton
            // 
            this.stepDownButton.Font = new System.Drawing.Font("メイリオ", 6.5F);
            this.stepDownButton.Location = new System.Drawing.Point(227, 107);
            this.stepDownButton.Name = "stepDownButton";
            this.stepDownButton.Size = new System.Drawing.Size(30, 23);
            this.stepDownButton.TabIndex = 15;
            this.stepDownButton.TabStop = false;
            this.stepDownButton.Text = "▽";
            this.stepDownButton.UseVisualStyleBackColor = true;
            this.stepDownButton.Click += new System.EventHandler(this.DownButton_Click);
            this.stepDownButton.Enter += new System.EventHandler(this.Button_Enter);
            this.stepDownButton.Leave += new System.EventHandler(this.Button_Leave);
            this.stepDownButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            // 
            // TimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 222);
            this.Controls.Add(this.stepDownButton);
            this.Controls.Add(this.stepUpButton);
            this.Controls.Add(this.millisecDownButton);
            this.Controls.Add(this.millisecUpButton);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.secDownButton);
            this.Controls.Add(this.minDownButton);
            this.Controls.Add(this.secUpButton);
            this.Controls.Add(this.minUpButton);
            this.Controls.Add(this.inputPanel);
            this.Controls.Add(this.resetTimerButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stepTextBox);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TimerForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Work timer";
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button resetTimerButton;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Timer flashTimer;
        private System.Windows.Forms.TextBox minTextBox;
        private System.Windows.Forms.TextBox secTextBox;
        private System.Windows.Forms.TextBox millisecTextBox;
        private System.Windows.Forms.Label colonLabel;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Label pointLabel;
        private System.Windows.Forms.Button minUpButton;
        private System.Windows.Forms.Button secUpButton;
        private System.Windows.Forms.Button minDownButton;
        private System.Windows.Forms.Button secDownButton;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button millisecUpButton;
        private System.Windows.Forms.Button millisecDownButton;
        private System.Windows.Forms.TextBox stepTextBox;
        private System.Windows.Forms.Button stepUpButton;
        private System.Windows.Forms.Button stepDownButton;
    }
}