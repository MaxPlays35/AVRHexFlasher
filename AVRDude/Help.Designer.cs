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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
      this.idea = new MetroFramework.Controls.MetroLabel();
      this.code = new MetroFramework.Controls.MetroLabel();
      this.design = new MetroFramework.Controls.MetroLabel();
      this.github = new MetroFramework.Controls.MetroLink();
      this.helpanel = new MetroFramework.Controls.MetroPanel();
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
      this.helpanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // idea
      // 
      resources.ApplyResources(this.idea, "idea");
      this.idea.Name = "idea";
      // 
      // code
      // 
      resources.ApplyResources(this.code, "code");
      this.code.Name = "code";
      // 
      // design
      // 
      resources.ApplyResources(this.design, "design");
      this.design.Name = "design";
      // 
      // github
      // 
      resources.ApplyResources(this.github, "github");
      this.github.Name = "github";
      this.github.TabStop = false;
      this.github.UseSelectable = true;
      this.github.Click += new System.EventHandler(this.Github_Click);
      // 
      // helpanel
      // 
      this.helpanel.Controls.Add(this.compiler3);
      this.helpanel.Controls.Add(this.close);
      this.helpanel.Controls.Add(this.about);
      this.helpanel.Controls.Add(this.compiler5);
      this.helpanel.Controls.Add(this.compiler4);
      this.helpanel.Controls.Add(this.compiler2);
      this.helpanel.Controls.Add(this.compiler1);
      this.helpanel.Controls.Add(this.flasher5);
      this.helpanel.Controls.Add(this.flasher3);
      this.helpanel.Controls.Add(this.flasher4);
      this.helpanel.Controls.Add(this.flasher2);
      this.helpanel.Controls.Add(this.flasher1);
      this.helpanel.Controls.Add(this.compiler);
      this.helpanel.Controls.Add(this.flasher);
      this.helpanel.Controls.Add(this.github);
      this.helpanel.Controls.Add(this.design);
      this.helpanel.Controls.Add(this.code);
      this.helpanel.Controls.Add(this.idea);
      resources.ApplyResources(this.helpanel, "helpanel");
      this.helpanel.HorizontalScrollbarBarColor = true;
      this.helpanel.HorizontalScrollbarHighlightOnWheel = false;
      this.helpanel.HorizontalScrollbarSize = 10;
      this.helpanel.Name = "helpanel";
      this.helpanel.VerticalScrollbarBarColor = true;
      this.helpanel.VerticalScrollbarHighlightOnWheel = false;
      this.helpanel.VerticalScrollbarSize = 10;
      // 
      // compiler3
      // 
      resources.ApplyResources(this.compiler3, "compiler3");
      this.compiler3.Name = "compiler3";
      // 
      // close
      // 
      resources.ApplyResources(this.close, "close");
      this.close.Name = "close";
      this.close.TabStop = false;
      this.close.UseSelectable = true;
      this.close.Click += new System.EventHandler(this.Close_Click);
      // 
      // about
      // 
      resources.ApplyResources(this.about, "about");
      this.about.FontSize = MetroFramework.MetroLabelSize.Tall;
      this.about.Name = "about";
      // 
      // compiler5
      // 
      resources.ApplyResources(this.compiler5, "compiler5");
      this.compiler5.Name = "compiler5";
      // 
      // compiler4
      // 
      resources.ApplyResources(this.compiler4, "compiler4");
      this.compiler4.Name = "compiler4";
      // 
      // compiler2
      // 
      resources.ApplyResources(this.compiler2, "compiler2");
      this.compiler2.Name = "compiler2";
      // 
      // compiler1
      // 
      resources.ApplyResources(this.compiler1, "compiler1");
      this.compiler1.Name = "compiler1";
      // 
      // flasher5
      // 
      resources.ApplyResources(this.flasher5, "flasher5");
      this.flasher5.Name = "flasher5";
      // 
      // flasher3
      // 
      resources.ApplyResources(this.flasher3, "flasher3");
      this.flasher3.Name = "flasher3";
      // 
      // flasher4
      // 
      resources.ApplyResources(this.flasher4, "flasher4");
      this.flasher4.Name = "flasher4";
      // 
      // flasher2
      // 
      resources.ApplyResources(this.flasher2, "flasher2");
      this.flasher2.Name = "flasher2";
      // 
      // flasher1
      // 
      resources.ApplyResources(this.flasher1, "flasher1");
      this.flasher1.Name = "flasher1";
      // 
      // compiler
      // 
      resources.ApplyResources(this.compiler, "compiler");
      this.compiler.FontSize = MetroFramework.MetroLabelSize.Tall;
      this.compiler.Name = "compiler";
      // 
      // flasher
      // 
      resources.ApplyResources(this.flasher, "flasher");
      this.flasher.FontSize = MetroFramework.MetroLabelSize.Tall;
      this.flasher.Name = "flasher";
      // 
      // Help
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ControlBox = false;
      this.Controls.Add(this.helpanel);
      this.DisplayHeader = false;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Movable = false;
      this.Name = "Help";
      this.Resizable = false;
      this.TopMost = true;
      this.helpanel.ResumeLayout(false);
      this.helpanel.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    public MetroFramework.Controls.MetroPanel helpanel;
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