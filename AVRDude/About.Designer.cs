namespace AVRDude
{
  partial class About
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
      this.aboutpanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // idea
      // 
      this.idea.AutoSize = true;
      this.idea.Location = new System.Drawing.Point(104, 7);
      this.idea.Name = "idea";
      this.idea.Size = new System.Drawing.Size(91, 19);
      this.idea.TabIndex = 0;
      this.idea.Text = "Idea: MrMaxP";
      // 
      // code
      // 
      this.code.AutoSize = true;
      this.code.Location = new System.Drawing.Point(45, 45);
      this.code.Name = "code";
      this.code.Size = new System.Drawing.Size(199, 19);
      this.code.TabIndex = 1;
      this.code.Text = "Code: MrMaxP and AlexeyZavar";
      // 
      // design
      // 
      this.design.AutoSize = true;
      this.design.Location = new System.Drawing.Point(2, 80);
      this.design.Name = "design";
      this.design.Size = new System.Drawing.Size(294, 19);
      this.design.TabIndex = 2;
      this.design.Text = "Design: MrMaxP, AlexeyZavar and Egor Machnev";
      // 
      // github
      // 
      this.github.Location = new System.Drawing.Point(94, 116);
      this.github.Name = "github";
      this.github.Size = new System.Drawing.Size(110, 19);
      this.github.TabIndex = 3;
      this.github.Text = "GitHub";
      this.github.UseSelectable = true;
      this.github.Click += new System.EventHandler(this.Github_Click);
      // 
      // aboutpanel
      // 
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
      this.aboutpanel.Size = new System.Drawing.Size(298, 146);
      this.aboutpanel.TabIndex = 4;
      this.aboutpanel.VerticalScrollbarBarColor = true;
      this.aboutpanel.VerticalScrollbarHighlightOnWheel = false;
      this.aboutpanel.VerticalScrollbarSize = 10;
      // 
      // About
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(338, 196);
      this.Controls.Add(this.aboutpanel);
      this.DisplayHeader = false;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Movable = false;
      this.Name = "About";
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
  }
}