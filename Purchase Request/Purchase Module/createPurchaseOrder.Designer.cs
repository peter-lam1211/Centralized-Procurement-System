
namespace Purchase_Request
{
    partial class createPurchaseOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblheading = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboOrderType = new System.Windows.Forms.ComboBox();
            this.comboAgreementID = new System.Windows.Forms.ComboBox();
            this.agreementItemInfoTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderItemInfoTable = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.itemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.comboSupplierID = new System.Windows.Forms.ComboBox();
            this.lblAgreementItemInfo = new System.Windows.Forms.Label();
            this.lblOrderItemInfo = new System.Windows.Forms.Label();
            this.effectiveDate = new System.Windows.Forms.DateTimePicker();
            this.createDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboRestaurantID = new System.Windows.Forms.ComboBox();
            this.comboWarehouseID = new System.Windows.Forms.ComboBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTermAndCondition = new System.Windows.Forms.RichTextBox();
            this.txtRemark = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.standardOrderItemTable = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonItemName = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHandlingRequestID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agreementItemInfoTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemInfoTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.standardOrderItemTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblheading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 84);
            this.panel1.TabIndex = 2;
            // 
            // lblheading
            // 
            this.lblheading.AutoSize = true;
            this.lblheading.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblheading.ForeColor = System.Drawing.Color.White;
            this.lblheading.Location = new System.Drawing.Point(40, 22);
            this.lblheading.Name = "lblheading";
            this.lblheading.Size = new System.Drawing.Size(327, 34);
            this.lblheading.TabIndex = 0;
            this.lblheading.Text = "Create Purchase Order";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Purchase Order ID :";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderID.Location = new System.Drawing.Point(27, 142);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(245, 30);
            this.txtOrderID.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(613, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Purchase Agreement ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(316, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Purchase Order Type :";
            // 
            // comboOrderType
            // 
            this.comboOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOrderType.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboOrderType.FormattingEnabled = true;
            this.comboOrderType.Items.AddRange(new object[] {
            "Select one",
            "Planned Purchase Order",
            "Contract Purchase Order",
            "Standard Purchase Order"});
            this.comboOrderType.Location = new System.Drawing.Point(320, 143);
            this.comboOrderType.Name = "comboOrderType";
            this.comboOrderType.Size = new System.Drawing.Size(245, 29);
            this.comboOrderType.TabIndex = 32;
            this.comboOrderType.SelectedIndexChanged += new System.EventHandler(this.comboOrderType_SelectedIndexChanged);
            // 
            // comboAgreementID
            // 
            this.comboAgreementID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAgreementID.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAgreementID.FormattingEnabled = true;
            this.comboAgreementID.Items.AddRange(new object[] {
            "Select one"});
            this.comboAgreementID.Location = new System.Drawing.Point(617, 143);
            this.comboAgreementID.Name = "comboAgreementID";
            this.comboAgreementID.Size = new System.Drawing.Size(245, 29);
            this.comboAgreementID.TabIndex = 33;
            this.comboAgreementID.SelectedIndexChanged += new System.EventHandler(this.comboAgreementID_SelectedIndexChanged);
            // 
            // agreementItemInfoTable
            // 
            this.agreementItemInfoTable.AllowUserToAddRows = false;
            this.agreementItemInfoTable.AllowUserToDeleteRows = false;
            this.agreementItemInfoTable.AllowUserToResizeColumns = false;
            this.agreementItemInfoTable.AllowUserToResizeRows = false;
            this.agreementItemInfoTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.agreementItemInfoTable.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.agreementItemInfoTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.agreementItemInfoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.agreementItemInfoTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column11});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.agreementItemInfoTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.agreementItemInfoTable.Location = new System.Drawing.Point(27, 287);
            this.agreementItemInfoTable.Name = "agreementItemInfoTable";
            this.agreementItemInfoTable.ReadOnly = true;
            this.agreementItemInfoTable.RowHeadersVisible = false;
            this.agreementItemInfoTable.RowHeadersWidth = 51;
            this.agreementItemInfoTable.RowTemplate.Height = 27;
            this.agreementItemInfoTable.Size = new System.Drawing.Size(548, 195);
            this.agreementItemInfoTable.TabIndex = 34;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "itemID";
            this.Column1.HeaderText = "itemID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "price";
            this.Column2.HeaderText = "price";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "incompletedQuantity";
            this.Column3.HeaderText = "incompleted quantity";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "agreementID";
            this.Column11.HeaderText = "agreementID";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // orderItemInfoTable
            // 
            this.orderItemInfoTable.AllowUserToAddRows = false;
            this.orderItemInfoTable.AllowUserToDeleteRows = false;
            this.orderItemInfoTable.AllowUserToResizeColumns = false;
            this.orderItemInfoTable.AllowUserToResizeRows = false;
            this.orderItemInfoTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderItemInfoTable.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.orderItemInfoTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.orderItemInfoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderItemInfoTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.itemID,
            this.Column4,
            this.Column12,
            this.Column13});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.orderItemInfoTable.DefaultCellStyle = dataGridViewCellStyle4;
            this.orderItemInfoTable.Location = new System.Drawing.Point(617, 287);
            this.orderItemInfoTable.Name = "orderItemInfoTable";
            this.orderItemInfoTable.RowHeadersVisible = false;
            this.orderItemInfoTable.RowHeadersWidth = 51;
            this.orderItemInfoTable.RowTemplate.Height = 27;
            this.orderItemInfoTable.Size = new System.Drawing.Size(532, 195);
            this.orderItemInfoTable.TabIndex = 35;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Add";
            this.Column5.FalseValue = "false";
            this.Column5.HeaderText = "Add";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.TrueValue = "true";
            // 
            // itemID
            // 
            this.itemID.DataPropertyName = "itemID";
            this.itemID.HeaderText = "itemID";
            this.itemID.MinimumWidth = 6;
            this.itemID.Name = "itemID";
            this.itemID.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "quantity";
            this.Column4.HeaderText = "quantity";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "agreementID";
            this.Column12.HeaderText = "agreementID";
            this.Column12.MinimumWidth = 6;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "incompletedQuantity";
            this.Column13.HeaderText = "incompletedQuantity";
            this.Column13.MinimumWidth = 6;
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(900, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 23);
            this.label4.TabIndex = 36;
            this.label4.Text = "SupplierID :";
            // 
            // comboSupplierID
            // 
            this.comboSupplierID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSupplierID.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSupplierID.FormattingEnabled = true;
            this.comboSupplierID.Items.AddRange(new object[] {
            "Select one"});
            this.comboSupplierID.Location = new System.Drawing.Point(904, 142);
            this.comboSupplierID.Name = "comboSupplierID";
            this.comboSupplierID.Size = new System.Drawing.Size(245, 29);
            this.comboSupplierID.TabIndex = 37;
            this.comboSupplierID.SelectedIndexChanged += new System.EventHandler(this.comboSupplierID_SelectedIndexChanged);
            // 
            // lblAgreementItemInfo
            // 
            this.lblAgreementItemInfo.AutoSize = true;
            this.lblAgreementItemInfo.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgreementItemInfo.Location = new System.Drawing.Point(23, 251);
            this.lblAgreementItemInfo.Name = "lblAgreementItemInfo";
            this.lblAgreementItemInfo.Size = new System.Drawing.Size(208, 23);
            this.lblAgreementItemInfo.TabIndex = 38;
            this.lblAgreementItemInfo.Text = "Agreement item info :";
            // 
            // lblOrderItemInfo
            // 
            this.lblOrderItemInfo.AutoSize = true;
            this.lblOrderItemInfo.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderItemInfo.Location = new System.Drawing.Point(613, 251);
            this.lblOrderItemInfo.Name = "lblOrderItemInfo";
            this.lblOrderItemInfo.Size = new System.Drawing.Size(157, 23);
            this.lblOrderItemInfo.TabIndex = 39;
            this.lblOrderItemInfo.Text = "Order item info :";
            // 
            // effectiveDate
            // 
            this.effectiveDate.CalendarFont = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.effectiveDate.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.effectiveDate.Location = new System.Drawing.Point(804, 203);
            this.effectiveDate.Name = "effectiveDate";
            this.effectiveDate.Size = new System.Drawing.Size(345, 28);
            this.effectiveDate.TabIndex = 43;
            // 
            // createDate
            // 
            this.createDate.CalendarFont = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createDate.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createDate.Location = new System.Drawing.Point(182, 203);
            this.createDate.Name = "createDate";
            this.createDate.Size = new System.Drawing.Size(345, 28);
            this.createDate.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(551, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(238, 23);
            this.label7.TabIndex = 41;
            this.label7.Text = "Expected Delivery Date :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 23);
            this.label8.TabIndex = 40;
            this.label8.Text = "Create Date :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(355, 558);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 23);
            this.label9.TabIndex = 44;
            this.label9.Text = "Shipping address :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(355, 672);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 23);
            this.label10.TabIndex = 45;
            this.label10.Text = "WarehouseID ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(355, 592);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 23);
            this.label11.TabIndex = 46;
            this.label11.Text = "RestaurantID";
            // 
            // comboRestaurantID
            // 
            this.comboRestaurantID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRestaurantID.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRestaurantID.FormattingEnabled = true;
            this.comboRestaurantID.Items.AddRange(new object[] {
            "Select one"});
            this.comboRestaurantID.Location = new System.Drawing.Point(353, 629);
            this.comboRestaurantID.Name = "comboRestaurantID";
            this.comboRestaurantID.Size = new System.Drawing.Size(245, 29);
            this.comboRestaurantID.TabIndex = 47;
            // 
            // comboWarehouseID
            // 
            this.comboWarehouseID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWarehouseID.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboWarehouseID.FormattingEnabled = true;
            this.comboWarehouseID.Items.AddRange(new object[] {
            "Select one"});
            this.comboWarehouseID.Location = new System.Drawing.Point(353, 709);
            this.comboWarehouseID.Name = "comboWarehouseID";
            this.comboWarehouseID.Size = new System.Drawing.Size(245, 29);
            this.comboWarehouseID.TabIndex = 48;
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(34, 541);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(276, 30);
            this.txtUserID.TabIndex = 51;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(30, 504);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 23);
            this.label13.TabIndex = 50;
            this.label13.Text = "User ID :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(30, 590);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(198, 23);
            this.label12.TabIndex = 52;
            this.label12.Text = "Term and condition :";
            // 
            // txtTermAndCondition
            // 
            this.txtTermAndCondition.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTermAndCondition.Location = new System.Drawing.Point(34, 629);
            this.txtTermAndCondition.Name = "txtTermAndCondition";
            this.txtTermAndCondition.Size = new System.Drawing.Size(276, 114);
            this.txtTermAndCondition.TabIndex = 53;
            this.txtTermAndCondition.Text = "";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(647, 629);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(276, 114);
            this.txtRemark.TabIndex = 55;
            this.txtRemark.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(643, 560);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 23);
            this.label14.TabIndex = 54;
            this.label14.Text = "Remark /";
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.Black;
            this.buttonCreate.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.ForeColor = System.Drawing.Color.White;
            this.buttonCreate.Location = new System.Drawing.Point(988, 541);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(128, 47);
            this.buttonCreate.TabIndex = 57;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.Black;
            this.buttonClear.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.ForeColor = System.Drawing.Color.White;
            this.buttonClear.Location = new System.Drawing.Point(988, 635);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(128, 47);
            this.buttonClear.TabIndex = 56;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // standardOrderItemTable
            // 
            this.standardOrderItemTable.AllowUserToAddRows = false;
            this.standardOrderItemTable.AllowUserToDeleteRows = false;
            this.standardOrderItemTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.standardOrderItemTable.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.standardOrderItemTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.standardOrderItemTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.standardOrderItemTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.standardOrderItemTable.DefaultCellStyle = dataGridViewCellStyle6;
            this.standardOrderItemTable.Location = new System.Drawing.Point(27, 287);
            this.standardOrderItemTable.Name = "standardOrderItemTable";
            this.standardOrderItemTable.RowHeadersVisible = false;
            this.standardOrderItemTable.RowHeadersWidth = 51;
            this.standardOrderItemTable.RowTemplate.Height = 27;
            this.standardOrderItemTable.Size = new System.Drawing.Size(1122, 195);
            this.standardOrderItemTable.TabIndex = 58;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "itemID";
            this.Column6.HeaderText = "itemID";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "price";
            this.Column7.HeaderText = "price";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "unit";
            this.Column8.HeaderText = "UOM";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.FalseValue = "false";
            this.Column9.HeaderText = "Add";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.TrueValue = "true";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "quantity";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // buttonItemName
            // 
            this.buttonItemName.BackColor = System.Drawing.Color.Black;
            this.buttonItemName.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonItemName.ForeColor = System.Drawing.Color.White;
            this.buttonItemName.Location = new System.Drawing.Point(1002, 244);
            this.buttonItemName.Name = "buttonItemName";
            this.buttonItemName.Size = new System.Drawing.Size(147, 36);
            this.buttonItemName.TabIndex = 59;
            this.buttonItemName.Text = "item Name";
            this.buttonItemName.UseVisualStyleBackColor = false;
            this.buttonItemName.Click += new System.EventHandler(this.buttonItemName_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(643, 592);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 23);
            this.label5.TabIndex = 60;
            this.label5.Text = "Special delivery request :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(355, 504);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(294, 23);
            this.label6.TabIndex = 78;
            this.label6.Text = "Handling Purchase Request ID :";
            // 
            // txtHandlingRequestID
            // 
            this.txtHandlingRequestID.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHandlingRequestID.Location = new System.Drawing.Point(665, 502);
            this.txtHandlingRequestID.Name = "txtHandlingRequestID";
            this.txtHandlingRequestID.Size = new System.Drawing.Size(276, 30);
            this.txtHandlingRequestID.TabIndex = 79;
            // 
            // createPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1176, 768);
            this.Controls.Add(this.txtHandlingRequestID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonItemName);
            this.Controls.Add(this.standardOrderItemTable);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtTermAndCondition);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comboWarehouseID);
            this.Controls.Add(this.comboRestaurantID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.effectiveDate);
            this.Controls.Add(this.createDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblOrderItemInfo);
            this.Controls.Add(this.lblAgreementItemInfo);
            this.Controls.Add(this.comboSupplierID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.orderItemInfoTable);
            this.Controls.Add(this.agreementItemInfoTable);
            this.Controls.Add(this.comboAgreementID);
            this.Controls.Add(this.comboOrderType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "createPurchaseOrder";
            this.Text = "createPurchaseOrder";
            this.Load += new System.EventHandler(this.createPurchaseOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agreementItemInfoTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemInfoTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.standardOrderItemTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblheading;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboOrderType;
        public System.Windows.Forms.ComboBox comboAgreementID;
        private System.Windows.Forms.DataGridView agreementItemInfoTable;
        private System.Windows.Forms.DataGridView orderItemInfoTable;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox comboSupplierID;
        private System.Windows.Forms.Label lblAgreementItemInfo;
        private System.Windows.Forms.Label lblOrderItemInfo;
        public System.Windows.Forms.DateTimePicker effectiveDate;
        public System.Windows.Forms.DateTimePicker createDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.ComboBox comboRestaurantID;
        public System.Windows.Forms.ComboBox comboWarehouseID;
        public System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.RichTextBox txtTermAndCondition;
        public System.Windows.Forms.RichTextBox txtRemark;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Button buttonCreate;
        public System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.DataGridView standardOrderItemTable;
        public System.Windows.Forms.Button buttonItemName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtHandlingRequestID;
    }
}