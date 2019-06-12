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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
      this.confpanel = new MetroFramework.Controls.MetroPanel();
      this.langSel = new MetroFramework.Controls.MetroComboBox();
      this.lang = new MetroFramework.Controls.MetroLabel();
      this.reset = new MetroFramework.Controls.MetroButton();
      this.board = new MetroFramework.Controls.MetroLabel();
      this.boardSel = new MetroFramework.Controls.MetroComboBox();
      this.themeSel = new MetroFramework.Controls.MetroComboBox();
      this.theme = new MetroFramework.Controls.MetroLabel();
      this.save = new MetroFramework.Controls.MetroButton();
      this.confpanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // confpanel
      // 
      this.confpanel.Controls.Add(this.langSel);
      this.confpanel.Controls.Add(this.lang);
      this.confpanel.Controls.Add(this.reset);
      this.confpanel.Controls.Add(this.board);
      this.confpanel.Controls.Add(this.boardSel);
      this.confpanel.Controls.Add(this.themeSel);
      this.confpanel.Controls.Add(this.theme);
      this.confpanel.Controls.Add(this.save);
      resources.ApplyResources(this.confpanel, "confpanel");
      this.confpanel.HorizontalScrollbarBarColor = true;
      this.confpanel.HorizontalScrollbarHighlightOnWheel = false;
      this.confpanel.HorizontalScrollbarSize = 10;
      this.confpanel.Name = "confpanel";
      this.confpanel.VerticalScrollbarBarColor = true;
      this.confpanel.VerticalScrollbarHighlightOnWheel = false;
      this.confpanel.VerticalScrollbarSize = 10;
      // 
      // langSel
      // 
      this.langSel.FormattingEnabled = true;
      resources.ApplyResources(this.langSel, "langSel");
      this.langSel.Name = "langSel";
      this.langSel.UseSelectable = true;
      // 
      // lang
      // 
      resources.ApplyResources(this.lang, "lang");
      this.lang.Name = "lang";
      // 
      // reset
      // 
      resources.ApplyResources(this.reset, "reset");
      this.reset.Name = "reset";
      this.reset.TabStop = false;
      this.reset.UseSelectable = true;
      this.reset.Click += new System.EventHandler(this.Reset_Click);
      // 
      // board
      // 
      resources.ApplyResources(this.board, "board");
      this.board.Name = "board";
      // 
      // boardSel
      // 
      this.boardSel.FormattingEnabled = true;
      resources.ApplyResources(this.boardSel, "boardSel");
      this.boardSel.Name = "boardSel";
      this.boardSel.TabStop = false;
      this.boardSel.UseSelectable = true;
      this.boardSel.SelectedIndexChanged += new System.EventHandler(this.BoardSel_SelectedIndexChanged);
      // 
      // themeSel
      // 
      this.themeSel.FormattingEnabled = true;
      resources.ApplyResources(this.themeSel, "themeSel");
      this.themeSel.Items.AddRange(new object[] {
            resources.GetString("themeSel.Items"),
            resources.GetString("themeSel.Items1")});
      this.themeSel.Name = "themeSel";
      this.themeSel.TabStop = false;
      this.themeSel.UseSelectable = true;
      // 
      // theme
      // 
      resources.ApplyResources(this.theme, "theme");
      this.theme.Name = "theme";
      // 
      // save
      // 
      resources.ApplyResources(this.save, "save");
      this.save.Name = "save";
      this.save.TabStop = false;
      this.save.UseSelectable = true;
      this.save.Click += new System.EventHandler(this.Save_Click);
      // 
      // Configuration
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ControlBox = false;
      this.Controls.Add(this.confpanel);
      this.Name = "Configuration";
      this.Resizable = false;
      this.ShadowType = MetroFramework.Forms.MetroFormShadowType.SystemShadow;
      this.confpanel.ResumeLayout(false);
      this.confpanel.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion
    public MetroFramework.Controls.MetroPanel confpanel;
    public MetroFramework.Controls.MetroButton save;
    public MetroFramework.Controls.MetroLabel theme;
    public MetroFramework.Controls.MetroComboBox themeSel;
    public MetroFramework.Controls.MetroComboBox boardSel;
    public MetroFramework.Controls.MetroButton reset;
    public MetroFramework.Controls.MetroLabel board;
    public MetroFramework.Controls.MetroComboBox langSel;
    public MetroFramework.Controls.MetroLabel lang;
  }
}