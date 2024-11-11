namespace CarageMS.View
{
    partial class CtrlAnalysis
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEmployees = new System.Windows.Forms.Label();
            this.lblCars = new System.Windows.Forms.Label();
            this.lblSpairParts = new System.Windows.Forms.Label();
            this.lblFinanes = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEmployees
            // 
            this.lblEmployees.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmployees.BackColor = System.Drawing.Color.Gainsboro;
            this.lblEmployees.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployees.Location = new System.Drawing.Point(87, 189);
            this.lblEmployees.Name = "lblEmployees";
            this.lblEmployees.Size = new System.Drawing.Size(234, 117);
            this.lblEmployees.TabIndex = 0;
            this.lblEmployees.Text = " Employees: ";
            this.lblEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCars
            // 
            this.lblCars.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCars.BackColor = System.Drawing.Color.Gainsboro;
            this.lblCars.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCars.Location = new System.Drawing.Point(434, 189);
            this.lblCars.Name = "lblCars";
            this.lblCars.Size = new System.Drawing.Size(234, 117);
            this.lblCars.TabIndex = 1;
            this.lblCars.Text = " Cars: ";
            this.lblCars.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpairParts
            // 
            this.lblSpairParts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSpairParts.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSpairParts.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpairParts.Location = new System.Drawing.Point(781, 189);
            this.lblSpairParts.Name = "lblSpairParts";
            this.lblSpairParts.Size = new System.Drawing.Size(234, 117);
            this.lblSpairParts.TabIndex = 2;
            this.lblSpairParts.Text = " Spair parts: ";
            this.lblSpairParts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFinanes
            // 
            this.lblFinanes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFinanes.BackColor = System.Drawing.Color.Gainsboro;
            this.lblFinanes.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinanes.Location = new System.Drawing.Point(434, 405);
            this.lblFinanes.Name = "lblFinanes";
            this.lblFinanes.Size = new System.Drawing.Size(234, 117);
            this.lblFinanes.TabIndex = 3;
            this.lblFinanes.Text = " Finanes: ";
            this.lblFinanes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Location = new System.Drawing.Point(1001, 584);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(111, 58);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // CtrlAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblFinanes);
            this.Controls.Add(this.lblSpairParts);
            this.Controls.Add(this.lblCars);
            this.Controls.Add(this.lblEmployees);
            this.Name = "CtrlAnalysis";
            this.Size = new System.Drawing.Size(1115, 645);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblEmployees;
        public System.Windows.Forms.Label lblCars;
        public System.Windows.Forms.Label lblSpairParts;
        public System.Windows.Forms.Label lblFinanes;
        public System.Windows.Forms.Button btnUpdate;
    }
}
