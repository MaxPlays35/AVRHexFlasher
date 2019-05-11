namespace AVRDude
{
  partial class Main
  {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.directory = new System.Windows.Forms.OpenFileDialog();
      this.log_updater = new System.Windows.Forms.Timer(this.components);
      this.config = new MetroFramework.Controls.MetroButton();
      this.open = new MetroFramework.Controls.MetroButton();
      this.flash = new MetroFramework.Controls.MetroButton();
      this.refresh = new MetroFramework.Controls.MetroButton();
      this.comports = new MetroFramework.Controls.MetroComboBox();
      this.path = new MetroFramework.Controls.MetroTextBox();
      this.log = new MetroFramework.Controls.MetroTextBox();
      this.about = new MetroFramework.Controls.MetroLabel();
      this.avr_kill = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // log_updater
      // 
      this.log_updater.Enabled = true;
      this.log_updater.Interval = 50;
      this.log_updater.Tick += new System.EventHandler(this.Log_updater_Tick);
      // 
      // config
      // 
      this.config.BackColor = System.Drawing.Color.White;
      this.config.Location = new System.Drawing.Point(7, 125);
      this.config.Name = "config";
      this.config.Size = new System.Drawing.Size(140, 29);
      this.config.TabIndex = 8;
      this.config.TabStop = false;
      this.config.Text = "Configuration";
      this.config.UseSelectable = true;
      this.config.Click += new System.EventHandler(this.Config_Click);
      // 
      // open
      // 
      this.open.BackColor = System.Drawing.Color.SeaShell;
      this.open.Location = new System.Drawing.Point(167, 63);
      this.open.Name = "open";
      this.open.Size = new System.Drawing.Size(140, 29);
      this.open.TabIndex = 9;
      this.open.TabStop = false;
      this.open.Text = "Open";
      this.open.UseSelectable = true;
      this.open.Click += new System.EventHandler(this.Open_Click);
      // 
      // flash
      // 
      this.flash.BackColor = System.Drawing.Color.White;
      this.flash.Location = new System.Drawing.Point(167, 125);
      this.flash.Name = "flash";
      this.flash.Size = new System.Drawing.Size(140, 29);
      this.flash.TabIndex = 10;
      this.flash.TabStop = false;
      this.flash.Text = "Flash";
      this.flash.UseSelectable = true;
      this.flash.Click += new System.EventHandler(this.Flash_Click);
      // 
      // refresh
      // 
      this.refresh.BackColor = System.Drawing.Color.White;
      this.refresh.Location = new System.Drawing.Point(167, 94);
      this.refresh.Name = "refresh";
      this.refresh.Size = new System.Drawing.Size(140, 29);
      this.refresh.TabIndex = 11;
      this.refresh.TabStop = false;
      this.refresh.Text = "Refresh";
      this.refresh.UseSelectable = true;
      this.refresh.Click += new System.EventHandler(this.Refresh_Click);
      // 
      // comports
      // 
      this.comports.FormattingEnabled = true;
      this.comports.ItemHeight = 23;
      this.comports.Location = new System.Drawing.Point(7, 94);
      this.comports.Name = "comports";
      this.comports.Size = new System.Drawing.Size(140, 29);
      this.comports.TabIndex = 12;
      this.comports.UseSelectable = true;
      this.comports.SelectedIndexChanged += new System.EventHandler(this.Comports_SelectedIndexChanged);
      // 
      // path
      // 
      // 
      // 
      // 
      this.path.CustomButton.Image = null;
      this.path.CustomButton.Location = new System.Drawing.Point(113, 1);
      this.path.CustomButton.Name = "";
      this.path.CustomButton.Size = new System.Drawing.Size(27, 27);
      this.path.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
      this.path.CustomButton.TabIndex = 1;
      this.path.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
      this.path.CustomButton.UseSelectable = true;
      this.path.CustomButton.Visible = false;
      this.path.Lines = new string[] {
        "C:\\Users\\admin\\source\\repos\\AVRDude\\AVRDude\\bin\\Debug\\55.ino.hex"};
      this.path.Location = new System.Drawing.Point(7, 63);
      this.path.MaxLength = 32767;
      this.path.Name = "path";
      this.path.PasswordChar = '\0';
      this.path.ReadOnly = true;
      this.path.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.path.SelectedText = "";
      this.path.SelectionLength = 0;
      this.path.SelectionStart = 0;
      this.path.ShortcutsEnabled = true;
      this.path.Size = new System.Drawing.Size(141, 29);
      this.path.TabIndex = 13;
      this.path.Text = "C:\\Users\\admin\\source\\repos\\AVRDude\\AVRDude\\bin\\Debug\\55.ino.hex";
      this.path.UseSelectable = true;
      this.path.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
      this.path.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
      // 
      // log
      // 
      // 
      // 
      // 
      this.log.CustomButton.Image = null;
      this.log.CustomButton.Location = new System.Drawing.Point(67, 1);
      this.log.CustomButton.Name = "";
      this.log.CustomButton.Size = new System.Drawing.Size(233, 233);
      this.log.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
      this.log.CustomButton.TabIndex = 1;
      this.log.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
      this.log.CustomButton.UseSelectable = true;
      this.log.CustomButton.Visible = false;
      this.log.Lines = new string[0];
      this.log.Location = new System.Drawing.Point(6, 160);
      this.log.MaxLength = 32767;
      this.log.Multiline = true;
      this.log.Name = "log";
      this.log.PasswordChar = '\0';
      this.log.ReadOnly = true;
      this.log.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.log.SelectedText = "";
      this.log.SelectionLength = 0;
      this.log.SelectionStart = 0;
      this.log.ShortcutsEnabled = true;
      this.log.Size = new System.Drawing.Size(301, 235);
      this.log.TabIndex = 14;
      this.log.UseSelectable = true;
      this.log.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
      this.log.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
      // 
      // about
      // 
      this.about.AutoSize = true;
      this.about.Location = new System.Drawing.Point(262, 395);
      this.about.Name = "about";
      this.about.Size = new System.Drawing.Size(45, 19);
      this.about.TabIndex = 15;
      this.about.Text = "About";
      this.about.Click += new System.EventHandler(this.About_Click);
      // 
      // avr_kill
      // 
      this.avr_kill.Interval = 60000;
      this.avr_kill.Tick += new System.EventHandler(this.Avr_kill_Tick);
      // 
      // Main
      // 
      this.ApplyImageInvert = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackLocation = MetroFramework.Forms.BackLocation.TopRight;
      this.ClientSize = new System.Drawing.Size(312, 412);
      this.Controls.Add(this.about);
      this.Controls.Add(this.log);
      this.Controls.Add(this.path);
      this.Controls.Add(this.comports);
      this.Controls.Add(this.refresh);
      this.Controls.Add(this.flash);
      this.Controls.Add(this.open);
      this.Controls.Add(this.config);
      this.MaximizeBox = false;
      this.Movable = false;
      this.Name = "Main";
      this.Resizable = false;
      this.Text = "Uploader";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.OpenFileDialog directory;
    private System.Windows.Forms.Timer log_updater;
    private MetroFramework.Controls.MetroButton config;
    private MetroFramework.Controls.MetroButton open;
    private MetroFramework.Controls.MetroButton flash;
    private MetroFramework.Controls.MetroButton refresh;
    private MetroFramework.Controls.MetroComboBox comports;
    private MetroFramework.Controls.MetroTextBox path;
    private MetroFramework.Controls.MetroTextBox log;
    private MetroFramework.Controls.MetroLabel about;
    private System.Windows.Forms.Timer avr_kill;
  }
}

