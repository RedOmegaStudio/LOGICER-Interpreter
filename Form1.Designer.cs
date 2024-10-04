namespace Logicer_Interpreter
{
    // CODE MADED BY FRANCISZEK CHMIELEWSKI
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        // CODE MADED BY FRANCISZEK CHMIELEWSKI

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        ///code maded by franciszekchmielewski
        protected override void Dispose(bool disposing)
        {
            // CODE MADED BY FRANCISZEK CHMIELEWSKI
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        // CODE MADED BY FRANCISZEK CHMIELEWSKI
        // CODE MADED BY FRANCISZEK CHMIELEWSKI
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            codeBox = new RichTextBox();
            menuStrip1 = new MenuStrip();
            edycjaToolStripMenuItem = new ToolStripMenuItem();
            deugujToolStripMenuItem = new ToolStripMenuItem();
            console = new RichTextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // codeBox
            // 
            codeBox.AcceptsTab = true;
            codeBox.Dock = DockStyle.Fill;
            codeBox.Location = new Point(0, 24);
            codeBox.Name = "codeBox";
            codeBox.Size = new Size(800, 426);
            codeBox.TabIndex = 0;
            codeBox.TabStop = false;
            codeBox.Text = "mind.sit();";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { edycjaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // edycjaToolStripMenuItem
            // 
            edycjaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { deugujToolStripMenuItem });
            edycjaToolStripMenuItem.Name = "edycjaToolStripMenuItem";
            edycjaToolStripMenuItem.Size = new Size(39, 20);
            edycjaToolStripMenuItem.Text = "Edit";
            // 
            // deugujToolStripMenuItem
            // 
            deugujToolStripMenuItem.Name = "deugujToolStripMenuItem";
            deugujToolStripMenuItem.Size = new Size(180, 22);
            deugujToolStripMenuItem.Text = "Debug";
            deugujToolStripMenuItem.Click += deugujToolStripMenuItem_Click;
            // 
            // console
            // 
            console.Dock = DockStyle.Bottom;
            console.Location = new Point(0, 314);
            console.Name = "console";
            console.ReadOnly = true;
            console.Size = new Size(800, 136);
            console.TabIndex = 2;
            console.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(console);
            Controls.Add(codeBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Logicer Interpreter";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        // CODE MADED BY FRANCISZEK CHMIELEWSKI
        private RichTextBox codeBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem edycjaToolStripMenuItem;
        // CODE MADED BY FRANCISZEK CHMIELEWSKI
        private ToolStripMenuItem deugujToolStripMenuItem;
        private RichTextBox console;
        // CODE MADED BY FRANCISZEK CHMIELEWSKI
    }
    // CODE MADED BY FRANCISZEK CHMIELEWSKI
}
// CODE MADED BY FRANCISZEK CHMIELEWSKI
