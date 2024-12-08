namespace prismProject
{
    partial class menuEmployee
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
            this.deleteTick = new System.Windows.Forms.RadioButton();
            this.editTick = new System.Windows.Forms.RadioButton();
            this.newTick = new System.Windows.Forms.RadioButton();
            this.lblWelcome = new System.Windows.Forms.Label();
            btnSubmit = new System.Windows.Forms.Button();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnSubmit.ForeColor = System.Drawing.Color.Black;
            btnSubmit.Location = new System.Drawing.Point(942, 374);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new System.Drawing.Size(114, 35);
            btnSubmit.TabIndex = 13;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // ticketLabel
            // 
            this.ticketLabel.AutoSize = true;
            this.ticketLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketLabel.Location = new System.Drawing.Point(356, 165);
            this.ticketLabel.Name = "ticketLabel";
            this.ticketLabel.Size = new System.Drawing.Size(129, 33);
            this.ticketLabel.TabIndex = 15;
            this.ticketLabel.Text = "Ticket(s)";
            // 
            // listTicket
            // 
            this.listTicket.HideSelection = false;
            this.listTicket.Location = new System.Drawing.Point(82, 219);
            this.listTicket.Name = "listTicket";
            this.listTicket.Size = new System.Drawing.Size(747, 317);
            this.listTicket.TabIndex = 14;
            this.listTicket.UseCompatibleStateImageBehavior = false;
            // 
            // lblLIS
            // 
            this.lblLIS.AutoSize = true;
            this.lblLIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLIS.ForeColor = System.Drawing.Color.Black;
            this.lblLIS.Location = new System.Drawing.Point(544, 79);
            this.lblLIS.Name = "lblLIS";
            this.lblLIS.Size = new System.Drawing.Size(233, 26);
            this.lblLIS.TabIndex = 12;
            this.lblLIS.Text = "Welcome to PRISM, LIU";
            this.lblLIS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.deleteTick);
            this.grpOptions.Controls.Add(this.editTick);
            this.grpOptions.Controls.Add(this.newTick);
            this.grpOptions.Location = new System.Drawing.Point(877, 219);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(225, 149);
            this.grpOptions.TabIndex = 11;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // deleteTick
            // 
            this.deleteTick.AutoSize = true;
            this.deleteTick.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteTick.Location = new System.Drawing.Point(23, 87);
            this.deleteTick.Name = "deleteTick";
            this.deleteTick.Size = new System.Drawing.Size(154, 28);
            this.deleteTick.TabIndex = 2;
            this.deleteTick.TabStop = true;
            this.deleteTick.Text = "Remove Ticket";
            this.deleteTick.UseVisualStyleBackColor = true;
            // 
            // editTick
            // 
            this.editTick.AutoSize = true;
            this.editTick.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTick.Location = new System.Drawing.Point(23, 53);
            this.editTick.Name = "editTick";
            this.editTick.Size = new System.Drawing.Size(115, 28);
            this.editTick.TabIndex = 1;
            this.editTick.TabStop = true;
            this.editTick.Text = "Edit Ticket";
            this.editTick.UseVisualStyleBackColor = true;
            // 
            // newTick
            // 
            this.newTick.AutoSize = true;
            this.newTick.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newTick.Location = new System.Drawing.Point(23, 19);
            this.newTick.Name = "newTick";
            this.newTick.Size = new System.Drawing.Size(122, 28);
            this.newTick.TabIndex = 0;
            this.newTick.TabStop = true;
            this.newTick.Text = "New Ticket";
            this.newTick.UseVisualStyleBackColor = true;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(537, 27);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(245, 37);
            this.lblWelcome.TabIndex = 10;
            this.lblWelcome.Text = "Employee Menu";
            // 
            // menuEmployee
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
            this.Name = "menuEmployee";
            this.Text = "menuEmployee";
            this.Load += new System.EventHandler(this.menuEmployee_Load);
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
        private System.Windows.Forms.RadioButton deleteTick;
        private System.Windows.Forms.RadioButton editTick;
        private System.Windows.Forms.RadioButton newTick;
        private System.Windows.Forms.Label lblWelcome;
    }
}