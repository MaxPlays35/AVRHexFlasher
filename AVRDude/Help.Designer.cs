namespace AVRHexFlasher
{
  partial class Help
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
      this.idea = new MetroFramework.Controls.MetroLabel();
      this.code = new MetroFramework.Controls.MetroLabel();
      this.design = new MetroFramework.Controls.MetroLabel();
      this.github = new MetroFramework.Controls.MetroLink();
      this.aboutpanel = new MetroFramework.Controls.MetroPanel();
      this.compiler3 = new MetroFramework.Controls.MetroLabel();
      this.close = new MetroFramework.Controls.MetroButton();
      this.about = new MetroFramework.Controls.MetroLabel();
      this.compiler5 = new MetroFramework.Controls.MetroLabel();
      this.compiler4 = new MetroFramework.Controls.MetroLabel();
      this.compiler2 = new MetroFramework.Controls.MetroLabel();
      this.compiler1 = new MetroFramework.Controls.MetroLabel();
      this.flasher5 = new MetroFramework.Controls.MetroLabel();
      this.flasher3 = new MetroFramework.Controls.MetroLabel();
      this.flasher4 = new MetroFramework.Controls.MetroLabel();
      this.flasher2 = new MetroFramework.Controls.MetroLabel();
      this.flasher1 = new MetroFramework.Controls.MetroLabel();
      this.compiler = new MetroFramework.Controls.MetroLabel();
      this.flasher = new MetroFramework.Controls.MetroLabel();
      this.aboutpanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // idea
      // 
      this.idea.AutoSize = true;
      this.idea.Location = new System.Drawing.Point(155, 304);
      this.idea.Name = "idea";
      this.idea.Size = new System.Drawing.Size(91, 19);
      this.idea.TabIndex = 0;
      this.idea.Text = "Idea: MrMaxP";
      // 
      // code
      // 
      this.code.AutoSize = true;
      this.code.Location = new System.Drawing.Point(96, 342);
      this.code.Name = "code";
      this.code.Size = new System.Drawing.Size(199, 19);
      this.code.TabIndex = 1;
      this.code.Text = "Code: MrMaxP and AlexeyZavar";
      // 
      // design
      // 
      this.design.AutoSize = true;
      this.design.Location = new System.Drawing.Point(53, 377);
      this.design.Name = "design";
      this.design.Size = new System.Drawing.Size(294, 19);
      this.design.TabIndex = 2;
      this.design.Text = "Design: MrMaxP, AlexeyZavar and Egor Machnev";
      // 
      // github
      // 
      this.github.Location = new System.Drawing.Point(145, 413);
      this.github.Name = "github";
      this.github.Size = new System.Drawing.Size(110, 19);
      this.github.TabIndex = 3;
      this.github.TabStop = false;
      this.github.Text = "GitHub";
      this.github.UseSelectable = true;
      this.github.Click += new System.EventHandler(this.Github_Click);
      // 
      // aboutpanel
      // 
      this.aboutpanel.Controls.Add(this.compiler3);
      this.aboutpanel.Controls.Add(this.close);
      this.aboutpanel.Controls.Add(this.about);
      this.aboutpanel.Controls.Add(this.compiler5);
      this.aboutpanel.Controls.Add(this.compiler4);
      this.aboutpanel.Controls.Add(this.compiler2);
      this.aboutpanel.Controls.Add(this.compiler1);
      this.aboutpanel.Controls.Add(this.flasher5);
      this.aboutpanel.Controls.Add(this.flasher3);
      this.aboutpanel.Controls.Add(this.flasher4);
      this.aboutpanel.Controls.Add(this.flasher2);
      this.aboutpanel.Controls.Add(this.flasher1);
      this.aboutpanel.Controls.Add(this.compiler);
      this.aboutpanel.Controls.Add(this.flasher);
      this.aboutpanel.Controls.Add(this.github);
      this.aboutpanel.Controls.Add(this.design);
      this.aboutpanel.Controls.Add(this.code);
      this.aboutpanel.Controls.Add(this.idea);
      this.aboutpanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.aboutpanel.HorizontalScrollbarBarColor = true;
      this.aboutpanel.HorizontalScrollbarHighlightOnWheel = false;
      this.aboutpanel.HorizontalScrollbarSize = 10;
      this.aboutpanel.Location = new System.Drawing.Point(20, 30);
      this.aboutpanel.Name = "aboutpanel";
      this.aboutpanel.Size = new System.Drawing.Size(394, 483);
      this.aboutpanel.TabIndex = 4;
      this.aboutpanel.VerticalScrollbarBarColor = true;
      this.aboutpanel.VerticalScrollbarHighlightOnWheel = false;
      this.aboutpanel.VerticalScrollbarSize = 10;
      // 
      // compiler3
      // 
      this.compiler3.AutoSize = true;
      this.compiler3.Location = new System.Drawing.Point(16, 213);
      this.compiler3.Name = "compiler3";
      this.compiler3.Size = new System.Drawing.Size(369, 19);
      this.compiler3.TabIndex = 18;
      this.compiler3.Text = "2.2) Drop custom hardware folders in \"files/custom/hardware\"";
      // 
      // close
      // 
      this.close.Location = new System.Drawing.Point(161, 447);
      this.close.Name = "close";
      this.close.Size = new System.Drawing.Size(75, 23);
      this.close.TabIndex = 17;
      this.close.TabStop = false;
      this.close.Text = "Close";
      this.close.UseSelectable = true;
      this.close.Click += new System.EventHandler(this.Close_Click);
      // 
      // about
      // 
      this.about.AutoSize = true;
      this.about.FontSize = MetroFramework.MetroLabelSize.Tall;
      this.about.Location = new System.Drawing.Point(173, 264);
      this.about.Name = "about";
      this.about.Size = new System.Drawing.Size(58, 25);
      this.about.TabIndex = 16;
      this.about.Text = "About";
      // 
      // compiler5
      // 
      this.compiler5.AutoSize = true;
      this.compiler5.Location = new System.Drawing.Point(16, 251);
      this.compiler5.Name = "compiler5";
      this.compiler5.Size = new System.Drawing.Size(114, 19);
      this.compiler5.TabIndex = 15;
      this.compiler5.Text = "4) Click \"Compile\"";
      // 
      // compiler4
      // 
      this.compiler4.AutoSize = true;
      this.compiler4.Location = new System.Drawing.Point(16, 232);
      this.compiler4.Name = "compiler4";
      this.compiler4.Size = new System.Drawing.Size(276, 19);
      this.compiler4.TabIndex = 13;
      this.compiler4.Text = "3) Click \"Configuration\" and select your board";
      // 
      // compiler2
      // 
      this.compiler2.AutoSize = true;
      this.compiler2.Location = new System.Drawing.Point(16, 194);
      this.compiler2.Name = "compiler2";
      this.compiler2.Size = new System.Drawing.Size(321, 19);
      this.compiler2.TabIndex = 12;
      this.compiler2.Text = "2.1) Drop libs that sketch imports in \"files/custom/libs\"";
      // 
      // compiler1
      // 
      this.compiler1.AutoSize = true;
      this.compiler1.Location = new System.Drawing.Point(16, 175);
      this.compiler1.Name = "compiler1";
      this.compiler1.Size = new System.Drawing.Size(208, 19);
      this.compiler1.TabIndex = 11;
      this.compiler1.Text = "1) Select sketch with \"Open sketch\"";
      // 
      // flasher5
      // 
      this.flasher5.AutoSize = true;
      this.flasher5.Location = new System.Drawing.Point(16, 111);
      this.flasher5.Name = "flasher5";
      this.flasher5.Size = new System.Drawing.Size(94, 19);
      this.flasher5.TabIndex = 10;
      this.flasher5.Text = "5) Click \"Flash\"";
      // 
      // flasher3
      // 
      this.flasher3.AutoSize = true;
      this.flasher3.Location = new System.Drawing.Point(16, 73);
      this.flasher3.Name = "flasher3";
      this.flasher3.Size = new System.Drawing.Size(125, 19);
      this.flasher3.TabIndex = 9;
      this.flasher3.Text = "3) Select COM-Port";
      // 
      // flasher4
      // 
      this.flasher4.AutoSize = true;
      this.flasher4.Location = new System.Drawing.Point(16, 92);
      this.flasher4.Name = "flasher4";
      this.flasher4.Size = new System.Drawing.Size(276, 19);
      this.flasher4.TabIndex = 8;
      this.flasher4.Text = "4) Click \"Configuration\" and select your board";
      // 
      // flasher2
      // 
      this.flasher2.AutoSize = true;
      this.flasher2.Location = new System.Drawing.Point(16, 54);
      this.flasher2.Name = "flasher2";
      this.flasher2.Size = new System.Drawing.Size(254, 19);
      this.flasher2.TabIndex = 7;
      this.flasher2.Text = "2) Select compiled sketch with \"Open hex\"";
      // 
      // flasher1
      // 
      this.flasher1.AutoSize = true;
      this.flasher1.Location = new System.Drawing.Point(16, 35);
      this.flasher1.Name = "flasher1";
      this.flasher1.Size = new System.Drawing.Size(327, 19);
      this.flasher1.TabIndex = 6;
      this.flasher1.Text = "1) Compile sketch with Arduino IDE or builtin Compiler";
      // 
      // compiler
      // 
      this.compiler.AutoSize = true;
      this.compiler.FontSize = MetroFramework.MetroLabelSize.Tall;
      this.compiler.Location = new System.Drawing.Point(163, 150);
      this.compiler.Name = "compiler";
      this.compiler.Size = new System.Drawing.Size(81, 25);
      this.compiler.TabIndex = 5;
      this.compiler.Text = "Compiler";
      // 
      // flasher
      // 
      this.flasher.AutoSize = true;
      this.flasher.FontSize = MetroFramework.MetroLabelSize.Tall;
      this.flasher.Location = new System.Drawing.Point(168, 10);
      this.flasher.Name = "flasher";
      this.flasher.Size = new System.Drawing.Size(65, 25);
      this.flasher.TabIndex = 4;
      this.flasher.Text = "Flasher";
      // 
      // Help
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(434, 533);
      this.ControlBox = false;
      this.Controls.Add(this.aboutpanel);
      this.DisplayHeader = false;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Movable = false;
      this.Name = "Help";
      this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
      this.Resizable = false;
      this.Text = "About";
      this.TopMost = true;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.About_FormClosing);
      this.aboutpanel.ResumeLayout(false);
      this.aboutpanel.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    public MetroFramework.Controls.MetroPanel aboutpanel;
    public MetroFramework.Controls.MetroLabel idea;
    public MetroFramework.Controls.MetroLabel code;
    public MetroFramework.Controls.MetroLabel design;
    public MetroFramework.Controls.MetroLink github;
    private MetroFramework.Controls.MetroLabel flasher2;
    private MetroFramework.Controls.MetroLabel flasher1;
    private MetroFramework.Controls.MetroLabel compiler;
    private MetroFramework.Controls.MetroLabel flasher;
    private MetroFramework.Controls.MetroLabel flasher3;
    private MetroFramework.Controls.MetroLabel flasher4;
    private MetroFramework.Controls.MetroLabel flasher5;
    private MetroFramework.Controls.MetroLabel compiler5;
    private MetroFramework.Controls.MetroLabel compiler4;
    private MetroFramework.Controls.MetroLabel compiler2;
    private MetroFramework.Controls.MetroLabel compiler1;
    private MetroFramework.Controls.MetroLabel about;
    public MetroFramework.Controls.MetroButton close;
    private MetroFramework.Controls.MetroLabel compiler3;
  }
}