﻿namespace AVRHexFlasher
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
      this.config_button.Location = new System.Drawing.Point(10, 80);
      this.config_button.Name = "config_button";
      this.config_button.Size = new System.Drawing.Size(137, 29);
      this.config_button.TabIndex = 8;
      this.config_button.TabStop = false;
      this.config_button.Text = "Configuration";
      this.config_button.UseSelectable = true;
      this.config_button.Click += new System.EventHandler(this.Config_Click);
      // 
      // openhex
      // 
      this.openhex.BackColor = System.Drawing.Color.SeaShell;
      this.openhex.Location = new System.Drawing.Point(10, 14);
      this.openhex.Name = "openhex";
      this.openhex.Size = new System.Drawing.Size(137, 29);
      this.openhex.TabIndex = 9;
      this.openhex.TabStop = false;
      this.openhex.Text = "Open hex";
      this.openhex.UseSelectable = true;
      this.openhex.Click += new System.EventHandler(this.OpenHex_Click);
      // 
      // flash
      // 
      this.flash.BackColor = System.Drawing.Color.White;
      this.flash.Location = new System.Drawing.Point(153, 80);
      this.flash.Name = "flash";
      this.flash.Size = new System.Drawing.Size(137, 29);
      this.flash.TabIndex = 10;
      this.flash.TabStop = false;
      this.flash.Text = "Flash";
      this.flash.UseSelectable = true;
      this.flash.Click += new System.EventHandler(this.Flash_Click);
      // 
      // refresh
      // 
      this.refresh.BackColor = System.Drawing.Color.White;
      this.refresh.Location = new System.Drawing.Point(153, 14);
      this.refresh.Name = "refresh";
      this.refresh.Size = new System.Drawing.Size(137, 29);
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
      this.comports.Location = new System.Drawing.Point(153, 47);
      this.comports.Name = "comports";
      this.comports.Size = new System.Drawing.Size(137, 29);
      this.comports.TabIndex = 12;
      this.comports.UseSelectable = true;
      this.comports.SelectedIndexChanged += new System.EventHandler(this.Comports_SelectedIndexChanged);
      // 
      // hexpath
      // 
      // 
      // 
      // 
      this.hexpath.CustomButton.Image = null;
      this.hexpath.CustomButton.Location = new System.Drawing.Point(110, 1);
      this.hexpath.CustomButton.Name = "";
      this.hexpath.CustomButton.Size = new System.Drawing.Size(27, 27);
      this.hexpath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
      this.hexpath.CustomButton.TabIndex = 1;
      this.hexpath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
      this.hexpath.CustomButton.UseSelectable = true;
      this.hexpath.CustomButton.Visible = false;
      this.hexpath.FontSize = MetroFramework.MetroTextBoxSize.Tall;
      this.hexpath.Lines = new string[0];
      this.hexpath.Location = new System.Drawing.Point(10, 47);
      this.hexpath.MaxLength = 32767;
      this.hexpath.Name = "hexpath";
      this.hexpath.PasswordChar = '\0';
      this.hexpath.ReadOnly = true;
      this.hexpath.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.hexpath.SelectedText = "";
      this.hexpath.SelectionLength = 0;
      this.hexpath.SelectionStart = 0;
      this.hexpath.ShortcutsEnabled = true;
      this.hexpath.Size = new System.Drawing.Size(138, 29);
      this.hexpath.TabIndex = 13;
      this.hexpath.UseSelectable = true;
      this.hexpath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
      this.hexpath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      // 
      // log
      // 
      // 
      // 
      // 
      this.log.CustomButton.Image = null;
      this.log.CustomButton.Location = new System.Drawing.Point(47, 2);
      this.log.CustomButton.Name = "";
      this.log.CustomButton.Size = new System.Drawing.Size(245, 245);
      this.log.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
      this.log.CustomButton.TabIndex = 1;
      this.log.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
      this.log.CustomButton.UseSelectable = true;
      this.log.CustomButton.Visible = false;
      this.log.Lines = new string[0];
      this.log.Location = new System.Drawing.Point(3, 113);
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
      this.log.Size = new System.Drawing.Size(295, 250);
      this.log.TabIndex = 14;
      this.log.UseSelectable = true;
      this.log.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
      this.log.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
      // 
      // help_button
      // 
      this.help_button.AutoSize = true;
      this.help_button.Location = new System.Drawing.Point(317, 472);
      this.help_button.Name = "help_button";
      this.help_button.Size = new System.Drawing.Size(36, 19);
      this.help_button.TabIndex = 15;
      this.help_button.Text = "Help";
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
      this.flasherpanel.Location = new System.Drawing.Point(0, 3);
      this.flasherpanel.Name = "flasherpanel";
      this.flasherpanel.Size = new System.Drawing.Size(301, 366);
      this.flasherpanel.TabIndex = 16;
      this.flasherpanel.VerticalScrollbarBarColor = true;
      this.flasherpanel.VerticalScrollbarHighlightOnWheel = false;
      this.flasherpanel.VerticalScrollbarSize = 10;
      // 
      // tabs
      // 
      this.tabs.Controls.Add(this.flasher_tab);
      this.tabs.Controls.Add(this.compiler_tab);
      this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabs.Location = new System.Drawing.Point(20, 60);
      this.tabs.Name = "tabs";
      this.tabs.SelectedIndex = 0;
      this.tabs.Size = new System.Drawing.Size(309, 411);
      this.tabs.TabIndex = 18;
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
      this.flasher_tab.Location = new System.Drawing.Point(4, 38);
      this.flasher_tab.Name = "flasher_tab";
      this.flasher_tab.Size = new System.Drawing.Size(301, 369);
      this.flasher_tab.TabIndex = 0;
      this.flasher_tab.Text = "Flasher";
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
      this.compiler_tab.Location = new System.Drawing.Point(4, 38);
      this.compiler_tab.Name = "compiler_tab";
      this.compiler_tab.Size = new System.Drawing.Size(301, 369);
      this.compiler_tab.TabIndex = 1;
      this.compiler_tab.Text = "Compiler";
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
      this.compilerpanel.Location = new System.Drawing.Point(0, 3);
      this.compilerpanel.Name = "compilerpanel";
      this.compilerpanel.Size = new System.Drawing.Size(301, 366);
      this.compilerpanel.TabIndex = 2;
      this.compilerpanel.VerticalScrollbarBarColor = true;
      this.compilerpanel.VerticalScrollbarHighlightOnWheel = false;
      this.compilerpanel.VerticalScrollbarSize = 10;
      // 
      // spinner
      // 
      this.spinner.Location = new System.Drawing.Point(60, 87);
      this.spinner.Maximum = 100;
      this.spinner.Name = "spinner";
      this.spinner.Size = new System.Drawing.Size(16, 16);
      this.spinner.TabIndex = 22;
      this.spinner.TabStop = false;
      this.spinner.UseSelectable = true;
      this.spinner.Visible = false;
      // 
      // config_button2
      // 
      this.config_button2.BackColor = System.Drawing.Color.White;
      this.config_button2.Location = new System.Drawing.Point(153, 14);
      this.config_button2.Name = "config_button2";
      this.config_button2.Size = new System.Drawing.Size(137, 29);
      this.config_button2.TabIndex = 15;
      this.config_button2.TabStop = false;
      this.config_button2.Text = "Configuration";
      this.config_button2.UseSelectable = true;
      this.config_button2.Click += new System.EventHandler(this.Config_Click);
      // 
      // opensketch
      // 
      this.opensketch.BackColor = System.Drawing.Color.SeaShell;
      this.opensketch.Location = new System.Drawing.Point(10, 14);
      this.opensketch.Name = "opensketch";
      this.opensketch.Size = new System.Drawing.Size(137, 29);
      this.opensketch.TabIndex = 16;
      this.opensketch.TabStop = false;
      this.opensketch.Text = "Open sketch";
      this.opensketch.UseSelectable = true;
      this.opensketch.Click += new System.EventHandler(this.OpenSketch_Click);
      // 
      // log2
      // 
      // 
      // 
      // 
      this.log2.CustomButton.Image = null;
      this.log2.CustomButton.Location = new System.Drawing.Point(47, 2);
      this.log2.CustomButton.Name = "";
      this.log2.CustomButton.Size = new System.Drawing.Size(245, 245);
      this.log2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
      this.log2.CustomButton.TabIndex = 1;
      this.log2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
      this.log2.CustomButton.UseSelectable = true;
      this.log2.CustomButton.Visible = false;
      this.log2.Lines = new string[0];
      this.log2.Location = new System.Drawing.Point(3, 113);
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
      this.log2.Size = new System.Drawing.Size(295, 250);
      this.log2.TabIndex = 21;
      this.log2.UseSelectable = true;
      this.log2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
      this.log2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
      // 
      // compile
      // 
      this.compile.BackColor = System.Drawing.Color.White;
      this.compile.Enabled = false;
      this.compile.Location = new System.Drawing.Point(82, 80);
      this.compile.Name = "compile";
      this.compile.Size = new System.Drawing.Size(137, 29);
      this.compile.TabIndex = 17;
      this.compile.TabStop = false;
      this.compile.Text = "Compile";
      this.compile.UseSelectable = true;
      this.compile.Click += new System.EventHandler(this.Compile_Click);
      // 
      // sketchpath
      // 
      // 
      // 
      // 
      this.sketchpath.CustomButton.Image = null;
      this.sketchpath.CustomButton.Location = new System.Drawing.Point(253, 1);
      this.sketchpath.CustomButton.Name = "";
      this.sketchpath.CustomButton.Size = new System.Drawing.Size(27, 27);
      this.sketchpath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
      this.sketchpath.CustomButton.TabIndex = 1;
      this.sketchpath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
      this.sketchpath.CustomButton.UseSelectable = true;
      this.sketchpath.CustomButton.Visible = false;
      this.sketchpath.FontSize = MetroFramework.MetroTextBoxSize.Tall;
      this.sketchpath.Lines = new string[0];
      this.sketchpath.Location = new System.Drawing.Point(10, 47);
      this.sketchpath.MaxLength = 32767;
      this.sketchpath.Name = "sketchpath";
      this.sketchpath.PasswordChar = '\0';
      this.sketchpath.ReadOnly = true;
      this.sketchpath.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.sketchpath.SelectedText = "";
      this.sketchpath.SelectionLength = 0;
      this.sketchpath.SelectionStart = 0;
      this.sketchpath.ShortcutsEnabled = true;
      this.sketchpath.Size = new System.Drawing.Size(281, 29);
      this.sketchpath.TabIndex = 20;
      this.sketchpath.UseSelectable = true;
      this.sketchpath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
      this.sketchpath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      // 
      // Main
      // 
      this.ApplyImageInvert = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackLocation = MetroFramework.Forms.BackLocation.TopRight;
      this.ClientSize = new System.Drawing.Size(349, 491);
      this.Controls.Add(this.tabs);
      this.Controls.Add(this.help_button);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Main";
      this.Resizable = false;
      this.ShadowType = MetroFramework.Forms.MetroFormShadowType.SystemShadow;
      this.Text = "Flasher";
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

