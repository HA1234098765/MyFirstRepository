namespace CarageMS.View
{
    partial class CtrlBilling
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCarParts = new System.Windows.Forms.DataGridView();
            this.btnCalculateFees = new System.Windows.Forms.Button();
            this.btnSaveBill = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtMechanicsFees = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTotalCarParts = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickerDate = new System.Windows.Forms.DateTimePicker();
            this.cboCarNumber = new System.Windows.Forms.ComboBox();
            this.lblTotalFess = new System.Windows.Forms.Label();
            this.lblPartFees = new System.Windows.Forms.Label();
            this.dBCarageMsDataSet2 = new CarageMS.DBCarageMsDataSet2();
            this.dBCarageMsDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBCarageMsDataSet3 = new CarageMS.DBCarageMsDataSet3();
            this.tbCarsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbCarsTableAdapter = new CarageMS.DBCarageMsDataSet3TableAdapters.tbCarsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalCarParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBCarageMsDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBCarageMsDataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBCarageMsDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCarsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCarParts
            // 
            this.dgvCarParts.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dgvCarParts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarParts.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCarParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarParts.Location = new System.Drawing.Point(7, 41);
            this.dgvCarParts.MultiSelect = false;
            this.dgvCarParts.Name = "dgvCarParts";
            this.dgvCarParts.ReadOnly = true;
            this.dgvCarParts.RowHeadersVisible = false;
            this.dgvCarParts.RowHeadersWidth = 51;
            this.dgvCarParts.RowTemplate.Height = 26;
            this.dgvCarParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarParts.Size = new System.Drawing.Size(422, 482);
            this.dgvCarParts.TabIndex = 40;
            // 
            // btnCalculateFees
            // 
            this.btnCalculateFees.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCalculateFees.BackColor = System.Drawing.Color.Maroon;
            this.btnCalculateFees.FlatAppearance.BorderSize = 0;
            this.btnCalculateFees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculateFees.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculateFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCalculateFees.Location = new System.Drawing.Point(461, 480);
            this.btnCalculateFees.Name = "btnCalculateFees";
            this.btnCalculateFees.Size = new System.Drawing.Size(187, 34);
            this.btnCalculateFees.TabIndex = 39;
            this.btnCalculateFees.Text = "Calculate fees";
            this.btnCalculateFees.UseVisualStyleBackColor = false;
            // 
            // btnSaveBill
            // 
            this.btnSaveBill.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSaveBill.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSaveBill.FlatAppearance.BorderSize = 0;
            this.btnSaveBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBill.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBill.ForeColor = System.Drawing.Color.White;
            this.btnSaveBill.Location = new System.Drawing.Point(824, 594);
            this.btnSaveBill.Name = "btnSaveBill";
            this.btnSaveBill.Size = new System.Drawing.Size(140, 34);
            this.btnSaveBill.TabIndex = 38;
            this.btnSaveBill.Text = "Save bill";
            this.btnSaveBill.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAdd.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(152, 538);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 34);
            this.btnAdd.TabIndex = 37;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // txtMechanicsFees
            // 
            this.txtMechanicsFees.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMechanicsFees.BackColor = System.Drawing.Color.DarkGray;
            this.txtMechanicsFees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMechanicsFees.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMechanicsFees.ForeColor = System.Drawing.Color.White;
            this.txtMechanicsFees.Location = new System.Drawing.Point(459, 382);
            this.txtMechanicsFees.Multiline = true;
            this.txtMechanicsFees.Name = "txtMechanicsFees";
            this.txtMechanicsFees.Size = new System.Drawing.Size(198, 30);
            this.txtMechanicsFees.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(458, 396);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 35);
            this.label4.TabIndex = 36;
            this.label4.Text = "____________________";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtQuantity.BackColor = System.Drawing.Color.DarkGray;
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantity.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.ForeColor = System.Drawing.Color.White;
            this.txtQuantity.Location = new System.Drawing.Point(459, 302);
            this.txtQuantity.Multiline = true;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(198, 30);
            this.txtQuantity.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(458, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 35);
            this.label3.TabIndex = 34;
            this.label3.Text = "____________________";
            // 
            // dgvTotalCarParts
            // 
            this.dgvTotalCarParts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvTotalCarParts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTotalCarParts.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalCarParts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTotalCarParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalCarParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvTotalCarParts.Location = new System.Drawing.Point(686, 41);
            this.dgvTotalCarParts.Name = "dgvTotalCarParts";
            this.dgvTotalCarParts.RowHeadersVisible = false;
            this.dgvTotalCarParts.RowHeadersWidth = 51;
            this.dgvTotalCarParts.RowTemplate.Height = 26;
            this.dgvTotalCarParts.Size = new System.Drawing.Size(422, 482);
            this.dgvTotalCarParts.TabIndex = 41;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "PartName";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Quantity";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Price";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Total";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // pickerDate
            // 
            this.pickerDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pickerDate.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pickerDate.Location = new System.Drawing.Point(461, 226);
            this.pickerDate.Name = "pickerDate";
            this.pickerDate.Size = new System.Drawing.Size(196, 28);
            this.pickerDate.TabIndex = 42;
            // 
            // cboCarNumber
            // 
            this.cboCarNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboCarNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCarNumber.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCarNumber.FormattingEnabled = true;
            this.cboCarNumber.Location = new System.Drawing.Point(459, 34);
            this.cboCarNumber.Name = "cboCarNumber";
            this.cboCarNumber.Size = new System.Drawing.Size(199, 29);
            this.cboCarNumber.TabIndex = 43;
            // 
            // lblTotalFess
            // 
            this.lblTotalFess.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalFess.AutoSize = true;
            this.lblTotalFess.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFess.Location = new System.Drawing.Point(992, 538);
            this.lblTotalFess.Name = "lblTotalFess";
            this.lblTotalFess.Size = new System.Drawing.Size(83, 21);
            this.lblTotalFess.TabIndex = 44;
            this.lblTotalFess.Text = "TotalFees";
            // 
            // lblPartFees
            // 
            this.lblPartFees.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPartFees.AutoSize = true;
            this.lblPartFees.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartFees.Location = new System.Drawing.Point(725, 538);
            this.lblPartFees.Name = "lblPartFees";
            this.lblPartFees.Size = new System.Drawing.Size(75, 21);
            this.lblPartFees.TabIndex = 45;
            this.lblPartFees.Text = "PartFees";
            // 
            // dBCarageMsDataSet2
            // 
            this.dBCarageMsDataSet2.DataSetName = "DBCarageMsDataSet2";
            this.dBCarageMsDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dBCarageMsDataSet2BindingSource
            // 
            this.dBCarageMsDataSet2BindingSource.DataSource = this.dBCarageMsDataSet2;
            this.dBCarageMsDataSet2BindingSource.Position = 0;
            // 
            // dBCarageMsDataSet3
            // 
            this.dBCarageMsDataSet3.DataSetName = "DBCarageMsDataSet3";
            this.dBCarageMsDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbCarsBindingSource
            // 
            this.tbCarsBindingSource.DataMember = "tbCars";
            this.tbCarsBindingSource.DataSource = this.dBCarageMsDataSet3;
            // 
            // tbCarsTableAdapter
            // 
            this.tbCarsTableAdapter.ClearBeforeFill = true;
            // 
            // CtrlBilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.Controls.Add(this.lblPartFees);
            this.Controls.Add(this.lblTotalFess);
            this.Controls.Add(this.cboCarNumber);
            this.Controls.Add(this.pickerDate);
            this.Controls.Add(this.dgvTotalCarParts);
            this.Controls.Add(this.dgvCarParts);
            this.Controls.Add(this.btnCalculateFees);
            this.Controls.Add(this.btnSaveBill);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtMechanicsFees);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label3);
            this.Name = "CtrlBilling";
            this.Size = new System.Drawing.Size(1115, 645);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalCarParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBCarageMsDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBCarageMsDataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBCarageMsDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCarsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DBCarageMsDataSet2 dBCarageMsDataSet2;
        private System.Windows.Forms.BindingSource dBCarageMsDataSet2BindingSource;
        public System.Windows.Forms.DataGridView dgvCarParts;
        public System.Windows.Forms.Button btnCalculateFees;
        public System.Windows.Forms.Button btnSaveBill;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.TextBox txtMechanicsFees;
        public System.Windows.Forms.TextBox txtQuantity;
        public System.Windows.Forms.DataGridView dgvTotalCarParts;
        public System.Windows.Forms.DateTimePicker pickerDate;
        public System.Windows.Forms.ComboBox cboCarNumber;
        public System.Windows.Forms.Label lblTotalFess;
        public System.Windows.Forms.Label lblPartFees;
        private System.Windows.Forms.BindingSource tbCarsBindingSource;
        private DBCarageMsDataSet3 dBCarageMsDataSet3;
        private DBCarageMsDataSet3TableAdapters.tbCarsTableAdapter tbCarsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
