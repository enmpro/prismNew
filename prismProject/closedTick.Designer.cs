namespace prismProject
{
    partial class closedTick
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
            this.labelClose = new System.Windows.Forms.Label();
            this.closeTickView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.Location = new System.Drawing.Point(322, 56);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(117, 23);
            this.labelClose.TabIndex = 0;
            this.labelClose.Text = "Closed Tickets";
            // 
            // closeTickView
            // 
            this.closeTickView.HideSelection = false;
            this.closeTickView.Location = new System.Drawing.Point(55, 98);
            this.closeTickView.Name = "closeTickView";
            this.closeTickView.Size = new System.Drawing.Size(654, 290);
            this.closeTickView.TabIndex = 1;
            this.closeTickView.UseCompatibleStateImageBehavior = false;
            // 
            // closedTick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.closeTickView);
            this.Controls.Add(this.labelClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "closedTick";
            this.Text = "closedTick";
            this.Load += new System.EventHandler(this.closedTick_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.ListView closeTickView;
    }
}