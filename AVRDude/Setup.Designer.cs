namespace AVRHexFlasher
{
  partial class Setup
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose ( bool disposing )
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
    private void InitializeComponent ()
    {
      this.welcome1 = new MetroFramework.Controls.MetroLabel();
      this.welcome2 = new MetroFramework.Controls.MetroLabel();
      this.github = new MetroFramework.Controls.MetroLink();
      this.themesel = new MetroFramework.Controls.MetroComboBox();
      this.theme = new MetroFramework.Controls.MetroLabel();
      this.compilersupport = new MetroFramework.Controls.MetroCheckBox();
      this.done = new MetroFramework.Controls.MetroButton();
      this.lang = new MetroFramework.Controls.MetroLabel();
      this.langsel = new MetroFramework.Controls.MetroComboBox();
      this.SuspendLayout();
      // 
      // welcome1
      // 
      this.welcome1.AutoSize = true;
      this.welcome1.Location = new System.Drawing.Point(20, 30);
      this.welcome1.Name = "welcome1";
      this.welcome1.Size = new System.Drawing.Size(175, 19);
      this.welcome1.TabIndex = 0;
      this.welcome1.Text = "Welcome to AVRHexFlasher!";
      // 
      // welcome2
      // 
      this.welcome2.AutoSize = true;
      this.welcome2.Location = new System.Drawing.Point(18, 80);
      this.welcome2.Name = "welcome2";
      this.welcome2.Size = new System.Drawing.Size(180, 19);
      this.welcome2.TabIndex = 1;
      this.welcome2.Text = "We need to set some settings";
      // 
      // github
      // 
      this.github.Location = new System.Drawing.Point(73, 399);
      this.github.Name = "github";
      this.github.Size = new System.Drawing.Size(75, 23);
      this.github.TabIndex = 2;
      this.github.TabStop = false;
      this.github.Text = "GitHub";
      this.github.UseSelectable = true;
      this.github.Click += new System.EventHandler(this.Github_Click);
      // 
      // themesel
      // 
      this.themesel.FormattingEnabled = true;
      this.themesel.ItemHeight = 23;
      this.themesel.Items.AddRange(new object[] {
            "Light",
            "Dark"});
      this.themesel.Location = new System.Drawing.Point(47, 152);
      this.themesel.Name = "themesel";
      this.themesel.Size = new System.Drawing.Size(121, 29);
      this.themesel.TabIndex = 3;
      this.themesel.TabStop = false;
      this.themesel.UseSelectable = true;
      // 
      // theme
      // 
      this.theme.AutoSize = true;
      this.theme.Location = new System.Drawing.Point(83, 121);
      this.theme.Name = "theme";
      this.theme.Size = new System.Drawing.Size(49, 19);
      this.theme.TabIndex = 4;
      this.theme.Text = "Theme";
      // 
      // compilersupport
      // 
      this.compilersupport.AutoSize = true;
      this.compilersupport.Location = new System.Drawing.Point(49, 294);
      this.compilersupport.Name = "compilersupport";
      this.compilersupport.Size = new System.Drawing.Size(116, 15);
      this.compilersupport.TabIndex = 5;
      this.compilersupport.TabStop = false;
      this.compilersupport.Text = "Compiler support";
      this.compilersupport.UseSelectable = true;
      this.compilersupport.CheckedChanged += new System.EventHandler(this.Compilersupport_CheckedChanged);
      // 
      // done
      // 
      this.done.Location = new System.Drawing.Point(73, 344);
      this.done.Name = "done";
      this.done.Size = new System.Drawing.Size(75, 23);
      this.done.TabIndex = 6;
      this.done.TabStop = false;
      this.done.Text = "Done";
      this.done.UseSelectable = true;
      this.done.Click += new System.EventHandler(this.Done_Click);
      // 
      // lang
      // 
      this.lang.AutoSize = true;
      this.lang.Location = new System.Drawing.Point(75, 203);
      this.lang.Name = "lang";
      this.lang.Size = new System.Drawing.Size(66, 19);
      this.lang.TabIndex = 8;
      this.lang.Text = "Language";
      // 
      // langsel
      // 
      this.langsel.FormattingEnabled = true;
      this.langsel.ItemHeight = 23;
      this.langsel.Location = new System.Drawing.Point(49, 236);
      this.langsel.Name = "langsel";
      this.langsel.Size = new System.Drawing.Size(121, 29);
      this.langsel.TabIndex = 7;
      this.langsel.TabStop = false;
      this.langsel.UseSelectable = true;
      // 
      // Setup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(218, 428);
      this.ControlBox = false;
      this.Controls.Add(this.lang);
      this.Controls.Add(this.langsel);
      this.Controls.Add(this.done);
      this.Controls.Add(this.compilersupport);
      this.Controls.Add(this.theme);
      this.Controls.Add(this.themesel);
      this.Controls.Add(this.github);
      this.Controls.Add(this.welcome2);
      this.Controls.Add(this.welcome1);
      this.DisplayHeader = false;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Movable = false;
      this.Name = "Setup";
      this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
      this.Resizable = false;
      this.ShadowType = MetroFramework.Forms.MetroFormShadowType.SystemShadow;
      this.Text = "Setup";
      this.TopMost = true;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private MetroFramework.Controls.MetroLabel welcome1;
    private MetroFramework.Controls.MetroLabel welcome2;
    private MetroFramework.Controls.MetroLink github;
    private MetroFramework.Controls.MetroComboBox themesel;
    private MetroFramework.Controls.MetroLabel theme;
    private MetroFramework.Controls.MetroCheckBox compilersupport;
    private MetroFramework.Controls.MetroButton done;
    private MetroFramework.Controls.MetroLabel lang;
    public MetroFramework.Controls.MetroComboBox langsel;
  }
}