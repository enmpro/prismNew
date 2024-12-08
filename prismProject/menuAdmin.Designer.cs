namespace prismProject
{
    partial class menuAdmin
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
            System.Windows.Forms.Button btnSubmit;
            this.ticketLabel = new System.Windows.Forms.Label();
            this.listTicket = new System.Windows.Forms.ListView();
            this.lblLIS = new System.Windows.Forms.Label();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.closedOpt = new System.Windows.Forms.RadioButton();
            this.uninstallOpt = new System.Windows.Forms.RadioButton();
            this.installOpt = new System.Windows.Forms.RadioButton();
            this.repairOpt = new System.Windows.Forms.RadioButton();
            this.lblWelcome = new System.Windows.Forms.Label();
            btnSubmit = new System.Windows.Forms.Button();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnSubmit.ForeColor = System.Drawing.Color.Black;
            btnSubmit.Location = new System.Drawing.Point(119, 471);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new System.Drawing.Size(114, 35);
            btnSubmit.TabIndex = 19;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // ticketLabel
            // 
            this.ticketLabel.AutoSize = true;
            this.ticketLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketLabel.Location = new System.Drawing.Point(439, 128);
            this.ticketLabel.Name = "ticketLabel";
            this.ticketLabel.Size = new System.Drawing.Size(398, 33);
            this.ticketLabel.TabIndex = 21;
            this.ticketLabel.Text = "Available Ticket(s) to work on";
            // 
            // listTicket
            // 
            this.listTicket.HideSelection = false;
            this.listTicket.Location = new System.Drawing.Point(326, 189);
            this.listTicket.Name = "listTicket";
            this.listTicket.Size = new System.Drawing.Size(747, 317);
            this.listTicket.TabIndex = 20;
            this.listTicket.UseCompatibleStateImageBehavior = false;
            // 
            // lblLIS
            // 
            this.lblLIS.AutoSize = true;
            this.lblLIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLIS.ForeColor = System.Drawing.Color.Black;
            this.lblLIS.Location = new System.Drawing.Point(519, 77);
            this.lblLIS.Name = "lblLIS";
            this.lblLIS.Size = new System.Drawing.Size(233, 26);
            this.lblLIS.TabIndex = 18;
            this.lblLIS.Text = "Welcome to PRISM, LIU";
            this.lblLIS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.closedOpt);
            this.grpOptions.Controls.Add(this.uninstallOpt);
            this.grpOptions.Controls.Add(this.installOpt);
            this.grpOptions.Controls.Add(this.repairOpt);
            this.grpOptions.Location = new System.Drawing.Point(63, 264);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(225, 175);
            this.grpOptions.TabIndex = 17;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // closedOpt
            // 
            this.closedOpt.AutoSize = true;
            this.closedOpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closedOpt.Location = new System.Drawing.Point(23, 121);
            this.closedOpt.Name = "closedOpt";
            this.closedOpt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.closedOpt.Size = new System.Drawing.Size(151, 28);
            this.closedOpt.TabIndex = 3;
            this.closedOpt.TabStop = true;
            this.closedOpt.Text = "Closed Tickets";
            this.closedOpt.UseVisualStyleBackColor = true;
            // 
            // uninstallOpt
            // 
            this.uninstallOpt.AutoSize = true;
            this.uninstallOpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uninstallOpt.Location = new System.Drawing.Point(23, 87);
            this.uninstallOpt.Name = "uninstallOpt";
            this.uninstallOpt.Size = new System.Drawing.Size(98, 28);
            this.uninstallOpt.TabIndex = 2;
            this.uninstallOpt.TabStop = true;
            this.uninstallOpt.Text = "Uninstall";
            this.uninstallOpt.UseVisualStyleBackColor = true;
            // 
            // installOpt
            // 
            this.installOpt.AutoSize = true;
            this.installOpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installOpt.Location = new System.Drawing.Point(23, 53);
            this.installOpt.Name = "installOpt";
            this.installOpt.Size = new System.Drawing.Size(74, 28);
            this.installOpt.TabIndex = 1;
            this.installOpt.TabStop = true;
            this.installOpt.Text = "Install";
            this.installOpt.UseVisualStyleBackColor = true;
            // 
            // repairOpt
            // 
            this.repairOpt.AutoSize = true;
            this.repairOpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repairOpt.Location = new System.Drawing.Point(23, 19);
            this.repairOpt.Name = "repairOpt";
            this.repairOpt.Size = new System.Drawing.Size(83, 28);
            this.repairOpt.TabIndex = 0;
            this.repairOpt.TabStop = true;
            this.repairOpt.Text = "Repair";
            this.repairOpt.UseVisualStyleBackColor = true;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(537, 27);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(197, 37);
            this.lblWelcome.TabIndex = 16;
            this.lblWelcome.Text = "Admin Menu";
            // 
            // menuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 563);
            this.Controls.Add(this.ticketLabel);
            this.Controls.Add(this.listTicket);
            this.Controls.Add(btnSubmit);
            this.Controls.Add(this.lblLIS);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "menuAdmin";
            this.Text = "menuAdmin";
            this.Load += new System.EventHandler(this.menuAdmin_Load);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ticketLabel;
        private System.Windows.Forms.ListView listTicket;
        public System.Windows.Forms.Label lblLIS;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.RadioButton uninstallOpt;
        private System.Windows.Forms.RadioButton installOpt;
        private System.Windows.Forms.RadioButton repairOpt;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.RadioButton closedOpt;
    }
}