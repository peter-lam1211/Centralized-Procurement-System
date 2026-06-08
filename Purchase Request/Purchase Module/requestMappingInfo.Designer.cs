
namespace Purchase_Request
{
    partial class requestMappingInfo
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblheading = new System.Windows.Forms.Label();
            this.dropDownPanel1 = new System.Windows.Forms.Panel();
            this.buttonCreateAgreement = new System.Windows.Forms.Button();
            this.buttonCreateDeliveryRequest = new System.Windows.Forms.Button();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonCreateRelease = new System.Windows.Forms.Button();
            this.buttonHandlingMethod = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtRemark = new System.Windows.Forms.RichTextBox();
            this.txtDeliveryDate = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtRestaurantID = new System.Windows.Forms.TextBox();
            this.txtRequestID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.itemQuantityTable = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.dropDownPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemQuantityTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblheading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 84);
            this.panel1.TabIndex = 1;
            // 
            // lblheading
            // 
            this.lblheading.AutoSize = true;
            this.lblheading.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblheading.ForeColor = System.Drawing.Color.White;
            this.lblheading.Location = new System.Drawing.Point(40, 22);
            this.lblheading.Name = "lblheading";
            this.lblheading.Size = new System.Drawing.Size(208, 34);
            this.lblheading.TabIndex = 0;
            this.lblheading.Text = "Request Detail";
            // 
            // dropDownPanel1
            // 
            this.dropDownPanel1.BackColor = System.Drawing.Color.White;
            this.dropDownPanel1.Controls.Add(this.buttonCreateAgreement);
            this.dropDownPanel1.Controls.Add(this.buttonCreateDeliveryRequest);
            this.dropDownPanel1.Controls.Add(this.buttonCreateOrder);
            this.dropDownPanel1.Controls.Add(this.buttonCreateRelease);
            this.dropDownPanel1.Controls.Add(this.buttonHandlingMethod);
            this.dropDownPanel1.Location = new System.Drawing.Point(33, 102);
            this.dropDownPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropDownPanel1.MaximumSize = new System.Drawing.Size(285, 227);
            this.dropDownPanel1.MinimumSize = new System.Drawing.Size(285, 49);
            this.dropDownPanel1.Name = "dropDownPanel1";
            this.dropDownPanel1.Size = new System.Drawing.Size(285, 49);
            this.dropDownPanel1.TabIndex = 29;
            // 
            // buttonCreateAgreement
            // 
            this.buttonCreateAgreement.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonCreateAgreement.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCreateAgreement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateAgreement.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateAgreement.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCreateAgreement.Location = new System.Drawing.Point(0, 182);
            this.buttonCreateAgreement.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateAgreement.Name = "buttonCreateAgreement";
            this.buttonCreateAgreement.Size = new System.Drawing.Size(285, 45);
            this.buttonCreateAgreement.TabIndex = 15;
            this.buttonCreateAgreement.Text = "Create Agreement";
            this.buttonCreateAgreement.UseVisualStyleBackColor = false;
            this.buttonCreateAgreement.Click += new System.EventHandler(this.buttonCreateAgreement_Click);
            // 
            // buttonCreateDeliveryRequest
            // 
            this.buttonCreateDeliveryRequest.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonCreateDeliveryRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCreateDeliveryRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateDeliveryRequest.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateDeliveryRequest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCreateDeliveryRequest.Location = new System.Drawing.Point(0, 137);
            this.buttonCreateDeliveryRequest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateDeliveryRequest.Name = "buttonCreateDeliveryRequest";
            this.buttonCreateDeliveryRequest.Size = new System.Drawing.Size(285, 45);
            this.buttonCreateDeliveryRequest.TabIndex = 14;
            this.buttonCreateDeliveryRequest.Text = "Create Delivery Request";
            this.buttonCreateDeliveryRequest.UseVisualStyleBackColor = false;
            this.buttonCreateDeliveryRequest.Click += new System.EventHandler(this.buttonCreateDeliveryRequest_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonCreateOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCreateOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateOrder.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateOrder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCreateOrder.Location = new System.Drawing.Point(0, 92);
            this.buttonCreateOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(285, 45);
            this.buttonCreateOrder.TabIndex = 13;
            this.buttonCreateOrder.Text = "Create Purchase Order";
            this.buttonCreateOrder.UseVisualStyleBackColor = false;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonCreateRelease
            // 
            this.buttonCreateRelease.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonCreateRelease.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCreateRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateRelease.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateRelease.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCreateRelease.Location = new System.Drawing.Point(0, 47);
            this.buttonCreateRelease.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateRelease.Name = "buttonCreateRelease";
            this.buttonCreateRelease.Size = new System.Drawing.Size(285, 45);
            this.buttonCreateRelease.TabIndex = 12;
            this.buttonCreateRelease.Text = "Create Blanket Release";
            this.buttonCreateRelease.UseVisualStyleBackColor = false;
            this.buttonCreateRelease.Click += new System.EventHandler(this.buttonCreateRelease_Click);
            // 
            // buttonHandlingMethod
            // 
            this.buttonHandlingMethod.BackColor = System.Drawing.Color.Black;
            this.buttonHandlingMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonHandlingMethod.FlatAppearance.BorderSize = 0;
            this.buttonHandlingMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHandlingMethod.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHandlingMethod.ForeColor = System.Drawing.Color.White;
            this.buttonHandlingMethod.Image = global::Purchase_Request.Properties.Resources.expand_icon;
            this.buttonHandlingMethod.Location = new System.Drawing.Point(0, 0);
            this.buttonHandlingMethod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonHandlingMethod.Name = "buttonHandlingMethod";
            this.buttonHandlingMethod.Size = new System.Drawing.Size(285, 47);
            this.buttonHandlingMethod.TabIndex = 5;
            this.buttonHandlingMethod.Text = "Handling Method";
            this.buttonHandlingMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonHandlingMethod.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonHandlingMethod.UseVisualStyleBackColor = false;
            this.buttonHandlingMethod.Click += new System.EventHandler(this.buttonHandlingMethod_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtRemark);
            this.panel2.Controls.Add(this.txtDeliveryDate);
            this.panel2.Controls.Add(this.txtUserID);
            this.panel2.Controls.Add(this.txtRestaurantID);
            this.panel2.Controls.Add(this.txtRequestID);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.itemQuantityTable);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(33, 166);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(677, 590);
            this.panel2.TabIndex = 2;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtRemark.Location = new System.Drawing.Point(360, 448);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(287, 114);
            this.txtRemark.TabIndex = 28;
            this.txtRemark.Text = "";
            // 
            // txtDeliveryDate
            // 
            this.txtDeliveryDate.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeliveryDate.Location = new System.Drawing.Point(360, 385);
            this.txtDeliveryDate.Name = "txtDeliveryDate";
            this.txtDeliveryDate.ReadOnly = true;
            this.txtDeliveryDate.Size = new System.Drawing.Size(287, 30);
            this.txtDeliveryDate.TabIndex = 26;
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.txtUserID.Location = new System.Drawing.Point(360, 109);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(287, 30);
            this.txtUserID.TabIndex = 25;
            // 
            // txtRestaurantID
            // 
            this.txtRestaurantID.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRestaurantID.Location = new System.Drawing.Point(360, 64);
            this.txtRestaurantID.Name = "txtRestaurantID";
            this.txtRestaurantID.ReadOnly = true;
            this.txtRestaurantID.Size = new System.Drawing.Size(287, 30);
            this.txtRestaurantID.TabIndex = 24;
            // 
            // txtRequestID
            // 
            this.txtRequestID.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestID.Location = new System.Drawing.Point(360, 23);
            this.txtRequestID.Name = "txtRequestID";
            this.txtRequestID.ReadOnly = true;
            this.txtRequestID.Size = new System.Drawing.Size(287, 30);
            this.txtRequestID.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(31, 448);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 20;
            this.label12.Text = "Remark /";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 480);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(263, 23);
            this.label10.TabIndex = 18;
            this.label10.Text = "Special Delivery Request :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 385);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(251, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Expected Delivery Date :";
            // 
            // itemQuantityTable
            // 
            this.itemQuantityTable.AllowUserToAddRows = false;
            this.itemQuantityTable.AllowUserToDeleteRows = false;
            this.itemQuantityTable.AllowUserToResizeColumns = false;
            this.itemQuantityTable.AllowUserToResizeRows = false;
            this.itemQuantityTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemQuantityTable.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemQuantityTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.itemQuantityTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemQuantityTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemQuantityTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemQuantityTable.Location = new System.Drawing.Point(35, 189);
            this.itemQuantityTable.Name = "itemQuantityTable";
            this.itemQuantityTable.ReadOnly = true;
            this.itemQuantityTable.RowHeadersVisible = false;
            this.itemQuantityTable.RowHeadersWidth = 51;
            this.itemQuantityTable.RowTemplate.Height = 27;
            this.itemQuantityTable.Size = new System.Drawing.Size(612, 177);
            this.itemQuantityTable.TabIndex = 14;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "itemID";
            this.Column4.HeaderText = "ItemID";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "virtualItemID";
            this.Column1.HeaderText = "Virtual ItemID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "itemName";
            this.Column2.HeaderText = "Item Name";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "quantity";
            this.Column3.HeaderText = "Quantity";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(279, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Request Item and quantity :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "User ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Restaurant ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Purchase request ID :";
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // requestMappingInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 773);
            this.Controls.Add(this.dropDownPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "requestMappingInfo";
            this.Text = "requestMappingInfo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.dropDownPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemQuantityTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblheading;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.DataGridView itemQuantityTable;
        public System.Windows.Forms.TextBox txtDeliveryDate;
        public System.Windows.Forms.TextBox txtUserID;
        public System.Windows.Forms.TextBox txtRestaurantID;
        public System.Windows.Forms.TextBox txtRequestID;
        public System.Windows.Forms.RichTextBox txtRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Panel dropDownPanel1;
        private System.Windows.Forms.Button buttonCreateDeliveryRequest;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonCreateRelease;
        private System.Windows.Forms.Button buttonHandlingMethod;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonCreateAgreement;
    }
}