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
      this.procsel = new System.Windows.Forms.ComboBox();
      this.proc = new System.Windows.Forms.Label();
      this.baudrate = new System.Windows.Forms.Label();
      this.baudratesel = new System.Windows.Forms.ComboBox();
      this.save = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // procsel
      // 
      this.procsel.FormattingEnabled = true;
      this.procsel.Items.AddRange(new object[] {
            "ATMega328p",
            "ATMega168",
            "ATMega2560",
            "ATMega1280"});
      this.procsel.Location = new System.Drawing.Point(182, 67);
      this.procsel.Name = "procsel";
      this.procsel.Size = new System.Drawing.Size(121, 21);
      this.procsel.TabIndex = 0;
      // 
      // proc
      // 
      this.proc.AutoSize = true;
      this.proc.Location = new System.Drawing.Point(34, 70);
      this.proc.Name = "proc";
      this.proc.Size = new System.Drawing.Size(54, 13);
      this.proc.TabIndex = 2;
      this.proc.Text = "Processor";
      // 
      // baudrate
      // 
      this.baudrate.AutoSize = true;
      this.baudrate.Location = new System.Drawing.Point(34, 105);
      this.baudrate.Name = "baudrate";
      this.baudrate.Size = new System.Drawing.Size(50, 13);
      this.baudrate.TabIndex = 3;
      this.baudrate.Text = "Baudrate";
      // 
      // baudratesel
      // 
      this.baudratesel.FormattingEnabled = true;
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
      this.baudratesel.Location = new System.Drawing.Point(182, 102);
      this.baudratesel.Name = "baudratesel";
      this.baudratesel.Size = new System.Drawing.Size(121, 21);
      this.baudratesel.TabIndex = 4;
      // 
      // save
      // 
      this.save.Location = new System.Drawing.Point(114, 139);
      this.save.Name = "save";
      this.save.Size = new System.Drawing.Size(98, 37);
      this.save.TabIndex = 5;
      this.save.Text = "Save";
      this.save.UseVisualStyleBackColor = true;
      this.save.Click += new System.EventHandler(this.Save_Click);
      // 
      // Configuration
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(326, 198);
      this.ControlBox = false;
      this.Controls.Add(this.save);
      this.Controls.Add(this.baudratesel);
      this.Controls.Add(this.baudrate);
      this.Controls.Add(this.proc);
      this.Controls.Add(this.procsel);
      this.Movable = false;
      this.Name = "Configuration";
      this.Resizable = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Configuration";
      this.Load += new System.EventHandler(this.Configuration_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label proc;
    private System.Windows.Forms.Label baudrate;
    private System.Windows.Forms.Button save;
    public System.Windows.Forms.ComboBox procsel;
    public System.Windows.Forms.ComboBox baudratesel;
  }
}