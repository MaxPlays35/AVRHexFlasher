namespace AVRDude
{
  partial class Configuration
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.confpanel = new MetroFramework.Controls.MetroPanel();
      this.baudratesel = new MetroFramework.Controls.MetroComboBox();
      this.procsel = new MetroFramework.Controls.MetroComboBox();
      this.themesel = new MetroFramework.Controls.MetroComboBox();
      this.proc = new MetroFramework.Controls.MetroLabel();
      this.baudrate = new MetroFramework.Controls.MetroLabel();
      this.theme = new MetroFramework.Controls.MetroLabel();
      this.save = new MetroFramework.Controls.MetroButton();
      this.confpanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // confpanel
      // 
      this.confpanel.Controls.Add(this.baudratesel);
      this.confpanel.Controls.Add(this.procsel);
      this.confpanel.Controls.Add(this.themesel);
      this.confpanel.Controls.Add(this.proc);
      this.confpanel.Controls.Add(this.baudrate);
      this.confpanel.Controls.Add(this.theme);
      this.confpanel.Controls.Add(this.save);
      this.confpanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.confpanel.HorizontalScrollbarBarColor = true;
      this.confpanel.HorizontalScrollbarHighlightOnWheel = false;
      this.confpanel.HorizontalScrollbarSize = 10;
      this.confpanel.Location = new System.Drawing.Point(20, 60);
      this.confpanel.Name = "confpanel";
      this.confpanel.Size = new System.Drawing.Size(286, 171);
      this.confpanel.TabIndex = 6;
      this.confpanel.VerticalScrollbarBarColor = true;
      this.confpanel.VerticalScrollbarHighlightOnWheel = false;
      this.confpanel.VerticalScrollbarSize = 10;
      // 
      // baudratesel
      // 
      this.baudratesel.FormattingEnabled = true;
      this.baudratesel.ItemHeight = 23;
      this.baudratesel.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "250000",
            "500000",
            "1000000",
            "2000000"});
      this.baudratesel.Location = new System.Drawing.Point(162, 47);
      this.baudratesel.Name = "baudratesel";
      this.baudratesel.Size = new System.Drawing.Size(121, 29);
      this.baudratesel.TabIndex = 14;
      this.baudratesel.TabStop = false;
      this.baudratesel.UseSelectable = true;
      // 
      // procsel
      // 
      this.procsel.FormattingEnabled = true;
      this.procsel.ItemHeight = 23;
      this.procsel.Items.AddRange(new object[] {
            "ATMega328p",
            "ATMega168",
            "ATMega2560",
            "ATMega1280"});
      this.procsel.Location = new System.Drawing.Point(162, 15);
      this.procsel.Name = "procsel";
      this.procsel.Size = new System.Drawing.Size(121, 29);
      this.procsel.TabIndex = 13;
      this.procsel.TabStop = false;
      this.procsel.UseSelectable = true;
      // 
      // themesel
      // 
      this.themesel.FormattingEnabled = true;
      this.themesel.ItemHeight = 23;
      this.themesel.Items.AddRange(new object[] {
            "Light",
            "Dark"});
      this.themesel.Location = new System.Drawing.Point(162, 79);
      this.themesel.Name = "themesel";
      this.themesel.Size = new System.Drawing.Size(121, 29);
      this.themesel.TabIndex = 12;
      this.themesel.TabStop = false;
      this.themesel.UseSelectable = true;
      // 
      // proc
      // 
      this.proc.AutoSize = true;
      this.proc.Location = new System.Drawing.Point(17, 19);
      this.proc.Name = "proc";
      this.proc.Size = new System.Drawing.Size(66, 19);
      this.proc.TabIndex = 11;
      this.proc.Text = "Processor";
      // 
      // baudrate
      // 
      this.baudrate.AutoSize = true;
      this.baudrate.Location = new System.Drawing.Point(17, 51);
      this.baudrate.Name = "baudrate";
      this.baudrate.Size = new System.Drawing.Size(62, 19);
      this.baudrate.TabIndex = 10;
      this.baudrate.Text = "Baudrate";
      // 
      // theme
      // 
      this.theme.AutoSize = true;
      this.theme.Location = new System.Drawing.Point(17, 83);
      this.theme.Name = "theme";
      this.theme.Size = new System.Drawing.Size(49, 19);
      this.theme.TabIndex = 9;
      this.theme.Text = "Theme";
      // 
      // save
      // 
      this.save.Location = new System.Drawing.Point(89, 130);
      this.save.Name = "save";
      this.save.Size = new System.Drawing.Size(119, 38);
      this.save.TabIndex = 8;
      this.save.TabStop = false;
      this.save.Text = "Save";
      this.save.UseSelectable = true;
      this.save.Click += new System.EventHandler(this.Save_Click);
      // 
      // Configuration
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(326, 251);
      this.ControlBox = false;
      this.Controls.Add(this.confpanel);
      this.Movable = false;
      this.Name = "Configuration";
      this.Resizable = false;
      this.ShadowType = MetroFramework.Forms.MetroFormShadowType.SystemShadow;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Configuration";
      this.TopMost = true;
      this.confpanel.ResumeLayout(false);
      this.confpanel.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    public MetroFramework.Controls.MetroPanel confpanel;
    public MetroFramework.Controls.MetroButton save;
    public MetroFramework.Controls.MetroLabel proc;
    public MetroFramework.Controls.MetroLabel baudrate;
    public MetroFramework.Controls.MetroLabel theme;
    public MetroFramework.Controls.MetroComboBox baudratesel;
    public MetroFramework.Controls.MetroComboBox procsel;
    public MetroFramework.Controls.MetroComboBox themesel;
  }
}