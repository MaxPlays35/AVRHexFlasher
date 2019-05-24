namespace AVRHexFlasher
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
    protected override void Dispose( bool disposing )
    {
      if ( disposing && ( components != null ) )
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
      this.ofile = new System.Windows.Forms.OpenFileDialog();
      this.button_updater = new System.Windows.Forms.Timer(this.components);
      this.config_button = new MetroFramework.Controls.MetroButton();
      this.openhex = new MetroFramework.Controls.MetroButton();
      this.flash = new MetroFramework.Controls.MetroButton();
      this.refresh = new MetroFramework.Controls.MetroButton();
      this.comports = new MetroFramework.Controls.MetroComboBox();
      this.hexpath = new MetroFramework.Controls.MetroTextBox();
      this.log = new MetroFramework.Controls.MetroTextBox();
      this.help_button = new MetroFramework.Controls.MetroLabel();
      this.flasherpanel = new MetroFramework.Controls.MetroPanel();
      this.tabs = new MetroFramework.Controls.MetroTabControl();
      this.flasher_tab = new MetroFramework.Controls.MetroTabPage();
      this.compiler_tab = new MetroFramework.Controls.MetroTabPage();
      this.compilerpanel = new MetroFramework.Controls.MetroPanel();
      this.spinner = new MetroFramework.Controls.MetroProgressSpinner();
      this.config_button2 = new MetroFramework.Controls.MetroButton();
      this.opensketch = new MetroFramework.Controls.MetroButton();
      this.log2 = new MetroFramework.Controls.MetroTextBox();
      this.compile = new MetroFramework.Controls.MetroButton();
      this.sketchpath = new MetroFramework.Controls.MetroTextBox();
      this.flasherpanel.SuspendLayout();
      this.tabs.SuspendLayout();
      this.flasher_tab.SuspendLayout();
      this.compiler_tab.SuspendLayout();
      this.compilerpanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // button_updater
      // 
      this.button_updater.Enabled = true;
      this.button_updater.Interval = 50;
      this.button_updater.Tick += new System.EventHandler(this.Button_updater_Tick);
      // 
      // config_button
      // 
      this.config_button.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.config_button, "config_button");
      this.config_button.Name = "config_button";
      this.config_button.TabStop = false;
      this.config_button.UseSelectable = true;
      this.config_button.Click += new System.EventHandler(this.Config_Click);
      // 
      // openhex
      // 
      this.openhex.BackColor = System.Drawing.Color.SeaShell;
      resources.ApplyResources(this.openhex, "openhex");
      this.openhex.Name = "openhex";
      this.openhex.TabStop = false;
      this.openhex.UseSelectable = true;
      this.openhex.Click += new System.EventHandler(this.OpenHex_Click);
      // 
      // flash
      // 
      this.flash.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.flash, "flash");
      this.flash.Name = "flash";
      this.flash.TabStop = false;
      this.flash.UseSelectable = true;
      this.flash.Click += new System.EventHandler(this.Flash_Click);
      // 
      // refresh
      // 
      this.refresh.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.refresh, "refresh");
      this.refresh.Name = "refresh";
      this.refresh.TabStop = false;
      this.refresh.UseSelectable = true;
      this.refresh.Click += new System.EventHandler(this.Refresh_Click);
      // 
      // comports
      // 
      this.comports.FormattingEnabled = true;
      resources.ApplyResources(this.comports, "comports");
      this.comports.Name = "comports";
      this.comports.UseSelectable = true;
      this.comports.SelectedIndexChanged += new System.EventHandler(this.Comports_SelectedIndexChanged);
      // 
      // hexpath
      // 
      // 
      // 
      // 
      this.hexpath.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
      this.hexpath.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode")));
      this.hexpath.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
      this.hexpath.CustomButton.Name = "";
      this.hexpath.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
      this.hexpath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
      this.hexpath.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
      this.hexpath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
      this.hexpath.CustomButton.UseSelectable = true;
      this.hexpath.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
      this.hexpath.FontSize = MetroFramework.MetroTextBoxSize.Tall;
      this.hexpath.Lines = new string[0];
      resources.ApplyResources(this.hexpath, "hexpath");
      this.hexpath.MaxLength = 32767;
      this.hexpath.Name = "hexpath";
      this.hexpath.PasswordChar = '\0';
      this.hexpath.ReadOnly = true;
      this.hexpath.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.hexpath.SelectedText = "";
      this.hexpath.SelectionLength = 0;
      this.hexpath.SelectionStart = 0;
      this.hexpath.ShortcutsEnabled = true;
      this.hexpath.UseSelectable = true;
      this.hexpath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
      this.hexpath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      // 
      // log
      // 
      // 
      // 
      // 
      this.log.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
      this.log.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode1")));
      this.log.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location1")));
      this.log.CustomButton.Name = "";
      this.log.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size1")));
      this.log.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
      this.log.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex1")));
      this.log.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
      this.log.CustomButton.UseSelectable = true;
      this.log.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible1")));
      this.log.Lines = new string[0];
      resources.ApplyResources(this.log, "log");
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
      this.log.UseSelectable = true;
      this.log.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
      this.log.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
      // 
      // help_button
      // 
      resources.ApplyResources(this.help_button, "help_button");
      this.help_button.Name = "help_button";
      this.help_button.Click += new System.EventHandler(this.Help_Click);
      // 
      // flasherpanel
      // 
      this.flasherpanel.Controls.Add(this.config_button);
      this.flasherpanel.Controls.Add(this.openhex);
      this.flasherpanel.Controls.Add(this.comports);
      this.flasherpanel.Controls.Add(this.log);
      this.flasherpanel.Controls.Add(this.refresh);
      this.flasherpanel.Controls.Add(this.flash);
      this.flasherpanel.Controls.Add(this.hexpath);
      this.flasherpanel.HorizontalScrollbarBarColor = true;
      this.flasherpanel.HorizontalScrollbarHighlightOnWheel = false;
      this.flasherpanel.HorizontalScrollbarSize = 10;
      resources.ApplyResources(this.flasherpanel, "flasherpanel");
      this.flasherpanel.Name = "flasherpanel";
      this.flasherpanel.VerticalScrollbarBarColor = true;
      this.flasherpanel.VerticalScrollbarHighlightOnWheel = false;
      this.flasherpanel.VerticalScrollbarSize = 10;
      // 
      // tabs
      // 
      this.tabs.Controls.Add(this.flasher_tab);
      this.tabs.Controls.Add(this.compiler_tab);
      resources.ApplyResources(this.tabs, "tabs");
      this.tabs.Name = "tabs";
      this.tabs.SelectedIndex = 0;
      this.tabs.Theme = MetroFramework.MetroThemeStyle.Light;
      this.tabs.UseSelectable = true;
      this.tabs.SelectedIndexChanged += new System.EventHandler(this.Tabs_SelectedIndexChanged);
      // 
      // flasher_tab
      // 
      this.flasher_tab.Controls.Add(this.flasherpanel);
      this.flasher_tab.HorizontalScrollbarBarColor = true;
      this.flasher_tab.HorizontalScrollbarHighlightOnWheel = false;
      this.flasher_tab.HorizontalScrollbarSize = 10;
      resources.ApplyResources(this.flasher_tab, "flasher_tab");
      this.flasher_tab.Name = "flasher_tab";
      this.flasher_tab.VerticalScrollbarBarColor = true;
      this.flasher_tab.VerticalScrollbarHighlightOnWheel = false;
      this.flasher_tab.VerticalScrollbarSize = 10;
      // 
      // compiler_tab
      // 
      this.compiler_tab.Controls.Add(this.compilerpanel);
      this.compiler_tab.HorizontalScrollbarBarColor = true;
      this.compiler_tab.HorizontalScrollbarHighlightOnWheel = false;
      this.compiler_tab.HorizontalScrollbarSize = 10;
      resources.ApplyResources(this.compiler_tab, "compiler_tab");
      this.compiler_tab.Name = "compiler_tab";
      this.compiler_tab.VerticalScrollbarBarColor = true;
      this.compiler_tab.VerticalScrollbarHighlightOnWheel = false;
      this.compiler_tab.VerticalScrollbarSize = 10;
      // 
      // compilerpanel
      // 
      this.compilerpanel.Controls.Add(this.spinner);
      this.compilerpanel.Controls.Add(this.config_button2);
      this.compilerpanel.Controls.Add(this.opensketch);
      this.compilerpanel.Controls.Add(this.log2);
      this.compilerpanel.Controls.Add(this.compile);
      this.compilerpanel.Controls.Add(this.sketchpath);
      this.compilerpanel.HorizontalScrollbarBarColor = true;
      this.compilerpanel.HorizontalScrollbarHighlightOnWheel = false;
      this.compilerpanel.HorizontalScrollbarSize = 10;
      resources.ApplyResources(this.compilerpanel, "compilerpanel");
      this.compilerpanel.Name = "compilerpanel";
      this.compilerpanel.VerticalScrollbarBarColor = true;
      this.compilerpanel.VerticalScrollbarHighlightOnWheel = false;
      this.compilerpanel.VerticalScrollbarSize = 10;
      // 
      // spinner
      // 
      resources.ApplyResources(this.spinner, "spinner");
      this.spinner.Maximum = 100;
      this.spinner.Name = "spinner";
      this.spinner.TabStop = false;
      this.spinner.UseSelectable = true;
      // 
      // config_button2
      // 
      this.config_button2.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.config_button2, "config_button2");
      this.config_button2.Name = "config_button2";
      this.config_button2.TabStop = false;
      this.config_button2.UseSelectable = true;
      this.config_button2.Click += new System.EventHandler(this.Config_Click);
      // 
      // opensketch
      // 
      this.opensketch.BackColor = System.Drawing.Color.SeaShell;
      resources.ApplyResources(this.opensketch, "opensketch");
      this.opensketch.Name = "opensketch";
      this.opensketch.TabStop = false;
      this.opensketch.UseSelectable = true;
      this.opensketch.Click += new System.EventHandler(this.OpenSketch_Click);
      // 
      // log2
      // 
      // 
      // 
      // 
      this.log2.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
      this.log2.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode2")));
      this.log2.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location2")));
      this.log2.CustomButton.Name = "";
      this.log2.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size2")));
      this.log2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
      this.log2.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex2")));
      this.log2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
      this.log2.CustomButton.UseSelectable = true;
      this.log2.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible2")));
      this.log2.Lines = new string[0];
      resources.ApplyResources(this.log2, "log2");
      this.log2.MaxLength = 32767;
      this.log2.Multiline = true;
      this.log2.Name = "log2";
      this.log2.PasswordChar = '\0';
      this.log2.ReadOnly = true;
      this.log2.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.log2.SelectedText = "";
      this.log2.SelectionLength = 0;
      this.log2.SelectionStart = 0;
      this.log2.ShortcutsEnabled = true;
      this.log2.UseSelectable = true;
      this.log2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
      this.log2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
      // 
      // compile
      // 
      this.compile.BackColor = System.Drawing.Color.White;
      resources.ApplyResources(this.compile, "compile");
      this.compile.Name = "compile";
      this.compile.TabStop = false;
      this.compile.UseSelectable = true;
      this.compile.Click += new System.EventHandler(this.Compile_Click);
      // 
      // sketchpath
      // 
      // 
      // 
      // 
      this.sketchpath.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
      this.sketchpath.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode3")));
      this.sketchpath.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location3")));
      this.sketchpath.CustomButton.Name = "";
      this.sketchpath.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size3")));
      this.sketchpath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
      this.sketchpath.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex3")));
      this.sketchpath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
      this.sketchpath.CustomButton.UseSelectable = true;
      this.sketchpath.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible3")));
      this.sketchpath.FontSize = MetroFramework.MetroTextBoxSize.Tall;
      this.sketchpath.Lines = new string[0];
      resources.ApplyResources(this.sketchpath, "sketchpath");
      this.sketchpath.MaxLength = 32767;
      this.sketchpath.Name = "sketchpath";
      this.sketchpath.PasswordChar = '\0';
      this.sketchpath.ReadOnly = true;
      this.sketchpath.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.sketchpath.SelectedText = "";
      this.sketchpath.SelectionLength = 0;
      this.sketchpath.SelectionStart = 0;
      this.sketchpath.ShortcutsEnabled = true;
      this.sketchpath.UseSelectable = true;
      this.sketchpath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
      this.sketchpath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      // 
      // Main
      // 
      this.ApplyImageInvert = true;
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackLocation = MetroFramework.Forms.BackLocation.TopRight;
      this.Controls.Add(this.tabs);
      this.Controls.Add(this.help_button);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Main";
      this.Resizable = false;
      this.ShadowType = MetroFramework.Forms.MetroFormShadowType.SystemShadow;
      this.flasherpanel.ResumeLayout(false);
      this.tabs.ResumeLayout(false);
      this.flasher_tab.ResumeLayout(false);
      this.compiler_tab.ResumeLayout(false);
      this.compilerpanel.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    public System.Windows.Forms.OpenFileDialog ofile;
    public System.Windows.Forms.Timer button_updater;
    public MetroFramework.Controls.MetroButton config_button;
    public MetroFramework.Controls.MetroButton openhex;
    public MetroFramework.Controls.MetroButton refresh;
    public MetroFramework.Controls.MetroTextBox log;
    public MetroFramework.Controls.MetroLabel help_button;
    public MetroFramework.Controls.MetroPanel compilerpanel;
    public MetroFramework.Controls.MetroButton config_button2;
    public MetroFramework.Controls.MetroButton opensketch;
    public MetroFramework.Controls.MetroTextBox log2;
    public MetroFramework.Controls.MetroProgressSpinner spinner;
    public MetroFramework.Controls.MetroButton flash;
    public MetroFramework.Controls.MetroButton compile;
    public MetroFramework.Controls.MetroTabControl tabs;
    public MetroFramework.Controls.MetroTextBox sketchpath;
    public MetroFramework.Controls.MetroTextBox hexpath;
    public MetroFramework.Controls.MetroPanel flasherpanel;
    public MetroFramework.Controls.MetroTabPage flasher_tab;
    public MetroFramework.Controls.MetroComboBox comports;
    public MetroFramework.Controls.MetroTabPage compiler_tab;
  }
}

