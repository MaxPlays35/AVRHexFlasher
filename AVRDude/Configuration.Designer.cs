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
      this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
      this.lang_sel = new MetroFramework.Controls.MetroLabel();
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
      resources.ApplyResources(this.confpanel, "confpanel");
      this.confpanel.Controls.Add(this.metroComboBox1);
      this.confpanel.Controls.Add(this.lang_sel);
      this.confpanel.Controls.Add(this.reset);
      this.confpanel.Controls.Add(this.board);
      this.confpanel.Controls.Add(this.boardSel);
      this.confpanel.Controls.Add(this.themeSel);
      this.confpanel.Controls.Add(this.theme);
      this.confpanel.Controls.Add(this.save);
      this.confpanel.HorizontalScrollbarBarColor = true;
      this.confpanel.HorizontalScrollbarHighlightOnWheel = false;
      this.confpanel.HorizontalScrollbarSize = 10;
      this.confpanel.Name = "confpanel";
      this.confpanel.VerticalScrollbarBarColor = true;
      this.confpanel.VerticalScrollbarHighlightOnWheel = false;
      this.confpanel.VerticalScrollbarSize = 10;
      // 
      // metroComboBox1
      // 
      resources.ApplyResources(this.metroComboBox1, "metroComboBox1");
      this.metroComboBox1.FormattingEnabled = true;
      this.metroComboBox1.Items.AddRange(new object[] {
            resources.GetString("metroComboBox1.Items"),
            resources.GetString("metroComboBox1.Items1")});
      this.metroComboBox1.Name = "metroComboBox1";
      this.metroComboBox1.UseSelectable = true;
      // 
      // lang_sel
      // 
      resources.ApplyResources(this.lang_sel, "lang_sel");
      this.lang_sel.Name = "lang_sel";
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
      resources.ApplyResources(this.boardSel, "boardSel");
      this.boardSel.FormattingEnabled = true;
      this.boardSel.Name = "boardSel";
      this.boardSel.TabStop = false;
      this.boardSel.UseSelectable = true;
      this.boardSel.SelectedIndexChanged += new System.EventHandler(this.BoardSel_SelectedIndexChanged);
      // 
      // themeSel
      // 
      resources.ApplyResources(this.themeSel, "themeSel");
      this.themeSel.FormattingEnabled = true;
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
    private MetroFramework.Controls.MetroLabel board;
    public MetroFramework.Controls.MetroComboBox boardSel;
    public MetroFramework.Controls.MetroButton reset;
    private MetroFramework.Controls.MetroComboBox metroComboBox1;
    private MetroFramework.Controls.MetroLabel lang_sel;
  }
}