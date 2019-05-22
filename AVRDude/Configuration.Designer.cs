namespace AVRHexFlasher
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
    protected override void Dispose( bool disposing )
    {
      if ( disposing && ( components != null ) )
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
      this.reset = new MetroFramework.Controls.MetroButton();
      this.board = new MetroFramework.Controls.MetroLabel();
      this.boardsel = new MetroFramework.Controls.MetroComboBox();
      this.themesel = new MetroFramework.Controls.MetroComboBox();
      this.theme = new MetroFramework.Controls.MetroLabel();
      this.save = new MetroFramework.Controls.MetroButton();
      this.confpanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // confpanel
      // 
      this.confpanel.Controls.Add(this.reset);
      this.confpanel.Controls.Add(this.board);
      this.confpanel.Controls.Add(this.boardsel);
      this.confpanel.Controls.Add(this.themesel);
      this.confpanel.Controls.Add(this.theme);
      this.confpanel.Controls.Add(this.save);
      this.confpanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.confpanel.HorizontalScrollbarBarColor = true;
      this.confpanel.HorizontalScrollbarHighlightOnWheel = false;
      this.confpanel.HorizontalScrollbarSize = 10;
      this.confpanel.Location = new System.Drawing.Point(20, 60);
      this.confpanel.Name = "confpanel";
      this.confpanel.Size = new System.Drawing.Size(444, 129);
      this.confpanel.TabIndex = 6;
      this.confpanel.VerticalScrollbarBarColor = true;
      this.confpanel.VerticalScrollbarHighlightOnWheel = false;
      this.confpanel.VerticalScrollbarSize = 10;
      // 
      // reset
      // 
      this.reset.Location = new System.Drawing.Point(231, 88);
      this.reset.Name = "reset";
      this.reset.Size = new System.Drawing.Size(119, 38);
      this.reset.TabIndex = 15;
      this.reset.TabStop = false;
      this.reset.Text = "Reset";
      this.reset.UseSelectable = true;
      this.reset.Click += new System.EventHandler(this.Reset_Click);
      // 
      // board
      // 
      this.board.AutoSize = true;
      this.board.Location = new System.Drawing.Point(3, 8);
      this.board.Name = "board";
      this.board.Size = new System.Drawing.Size(45, 19);
      this.board.TabIndex = 14;
      this.board.Text = "Board";
      // 
      // boardsel
      // 
      this.boardsel.FormattingEnabled = true;
      this.boardsel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.boardsel.ItemHeight = 23;
      this.boardsel.Location = new System.Drawing.Point(115, 3);
      this.boardsel.Name = "boardsel";
      this.boardsel.Size = new System.Drawing.Size(326, 29);
      this.boardsel.TabIndex = 13;
      this.boardsel.TabStop = false;
      this.boardsel.UseSelectable = true;
      this.boardsel.SelectedIndexChanged += new System.EventHandler(this.Boardsel_SelectedIndexChanged);
      // 
      // themesel
      // 
      this.themesel.FormattingEnabled = true;
      this.themesel.ItemHeight = 23;
      this.themesel.Items.AddRange(new object[] {
            "Light",
            "Dark"});
      this.themesel.Location = new System.Drawing.Point(115, 38);
      this.themesel.Name = "themesel";
      this.themesel.Size = new System.Drawing.Size(326, 29);
      this.themesel.TabIndex = 12;
      this.themesel.TabStop = false;
      this.themesel.UseSelectable = true;
      // 
      // theme
      // 
      this.theme.AutoSize = true;
      this.theme.Location = new System.Drawing.Point(3, 43);
      this.theme.Name = "theme";
      this.theme.Size = new System.Drawing.Size(49, 19);
      this.theme.TabIndex = 9;
      this.theme.Text = "Theme";
      // 
      // save
      // 
      this.save.Location = new System.Drawing.Point(106, 88);
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
      this.ClientSize = new System.Drawing.Size(484, 209);
      this.ControlBox = false;
      this.Controls.Add(this.confpanel);
      this.Name = "Configuration";
      this.Resizable = false;
      this.ShadowType = MetroFramework.Forms.MetroFormShadowType.SystemShadow;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Configuration";
      this.confpanel.ResumeLayout(false);
      this.confpanel.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    public MetroFramework.Controls.MetroPanel confpanel;
    public MetroFramework.Controls.MetroButton save;
    public MetroFramework.Controls.MetroLabel theme;
    public MetroFramework.Controls.MetroComboBox themesel;
    private MetroFramework.Controls.MetroLabel board;
    public MetroFramework.Controls.MetroComboBox boardsel;
    public MetroFramework.Controls.MetroButton reset;
  }
}