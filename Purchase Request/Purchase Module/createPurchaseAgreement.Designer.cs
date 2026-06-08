
namespace Purchase_Request
{
    partial class createPurchaseAgreement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblheading = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAgreementID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboSupplierID = new System.Windows.Forms.ComboBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.createDate = new System.Windows.Forms.DateTimePicker();
            this.effectiveDate = new System.Windows.Forms.DateTimePicker();
            this.agreementItemTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountAgreed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtExpectedDiscount = new System.Windows.Forms.TextBox();
            this.comboCurrency = new System.Windows.Forms.ComboBox();
            this.comboTentativeSchedule = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTermAndCondition = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRevision = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.comboAgreementType = new System.Windows.Forms.ComboBox();
            this.txtTentativeSchedule = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonItemName = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agreementItemTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblheading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 75);
            this.panel1.TabIndex = 1;
            // 
            // lblheading
            // 
            this.lblheading.AutoSize = true;
            this.lblheading.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblheading.ForeColor = System.Drawing.Color.White;
            this.lblheading.Location = new System.Drawing.Point(39, 20);
            this.lblheading.Name = "lblheading";
            this.lblheading.Size = new System.Drawing.Size(402, 34);
            this.lblheading.TabIndex = 0;
            this.lblheading.Text = "Create Purchase Agreement";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(394, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Purchase Agreement Type :";
            // 
            // txtAgreementID
            // 
            this.txtAgreementID.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgreementID.Location = new System.Drawing.Point(45, 134);
            this.txtAgreementID.Name = "txtAgreementID";
            this.txtAgreementID.Size = new System.Drawing.Size(276, 30);
            this.txtAgreementID.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Supplier ID :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(748, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "User ID :";
            // 
            // comboSupplierID
            // 
            this.comboSupplierID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSupplierID.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSupplierID.FormattingEnabled = true;
            this.comboSupplierID.Items.AddRange(new object[] {
            "Select one"});
            this.comboSupplierID.Location = new System.Drawing.Point(45, 220);
            this.comboSupplierID.Name = "comboSupplierID";
            this.comboSupplierID.Size = new System.Drawing.Size(276, 29);
            this.comboSupplierID.TabIndex = 10;
            this.comboSupplierID.SelectedIndexChanged += new System.EventHandler(this.comboSupplierID_SelectedIndexChanged);
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(752, 133);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(276, 30);
            this.txtUserID.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(440, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Create Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(426, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Effective Date :";
            // 
            // createDate
            // 
            this.createDate.CalendarFont = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createDate.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createDate.Location = new System.Drawing.Point(613, 184);
            this.createDate.Name = "createDate";
            this.createDate.Size = new System.Drawing.Size(345, 28);
            this.createDate.TabIndex = 15;
            // 
            // effectiveDate
            // 
            this.effectiveDate.CalendarFont = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.effectiveDate.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.effectiveDate.Location = new System.Drawing.Point(613, 227);
            this.effectiveDate.Name = "effectiveDate";
            this.effectiveDate.Size = new System.Drawing.Size(345, 28);
            this.effectiveDate.TabIndex = 16;
            // 
            // agreementItemTable
            // 
            this.agreementItemTable.AllowUserToAddRows = false;
            this.agreementItemTable.AllowUserToDeleteRows = false;
            this.agreementItemTable.AllowUserToResizeColumns = false;
            this.agreementItemTable.AllowUserToResizeRows = false;
            this.agreementItemTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.agreementItemTable.BackgroundColor = System.Drawing.Color.White;
            this.agreementItemTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.agreementItemTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.agreementItemTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.agreementItemTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.quantity,
            this.amountAgreed,
            this.MoQ});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.agreementItemTable.DefaultCellStyle = dataGridViewCellStyle12;
            this.agreementItemTable.Location = new System.Drawing.Point(45, 307);
            this.agreementItemTable.Name = "agreementItemTable";
            this.agreementItemTable.RowHeadersVisible = false;
            this.agreementItemTable.RowHeadersWidth = 51;
            this.agreementItemTable.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.agreementItemTable.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.agreementItemTable.RowTemplate.Height = 27;
            this.agreementItemTable.Size = new System.Drawing.Size(994, 182);
            this.agreementItemTable.TabIndex = 17;
            this.agreementItemTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.agreementItemTable_CellEndEdit);
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
            this.Column3.DataPropertyName = "unit";
            this.Column3.HeaderText = "UOM";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Add";
            this.Column4.FalseValue = "false";
            this.Column4.HeaderText = "Add";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.TrueValue = "true";
            // 
            // quantity
            // 
            this.quantity.HeaderText = "quantity";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            // 
            // amountAgreed
            // 
            this.amountAgreed.HeaderText = "amountAgreed";
            this.amountAgreed.MinimumWidth = 6;
            this.amountAgreed.Name = "amountAgreed";
            // 
            // MoQ
            // 
            this.MoQ.HeaderText = "MoQ";
            this.MoQ.MinimumWidth = 6;
            this.MoQ.Name = "MoQ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(284, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "Item and related information :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(41, 507);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 23);
            this.label8.TabIndex = 19;
            this.label8.Text = "Currency :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(41, 591);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(193, 23);
            this.label9.TabIndex = 20;
            this.label9.Text = "Ecpected discount :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(41, 676);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(193, 23);
            this.label10.TabIndex = 21;
            this.label10.Text = "Tentative schedule :";
            // 
            // txtExpectedDiscount
            // 
            this.txtExpectedDiscount.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpectedDiscount.Location = new System.Drawing.Point(45, 626);
            this.txtExpectedDiscount.Name = "txtExpectedDiscount";
            this.txtExpectedDiscount.Size = new System.Drawing.Size(276, 30);
            this.txtExpectedDiscount.TabIndex = 22;
            // 
            // comboCurrency
            // 
            this.comboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCurrency.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCurrency.FormattingEnabled = true;
            this.comboCurrency.Items.AddRange(new object[] {
            "Select one",
            "Hong Kong Dollar (HKD)",
            "Chinese Renminbi (RMB)",
            "United States Dollar (USD)",
            "Great British Pound (GBP)",
            "New Zealand Dollar (NZD)",
            "Australia Dollar (AUD)"});
            this.comboCurrency.Location = new System.Drawing.Point(45, 542);
            this.comboCurrency.Name = "comboCurrency";
            this.comboCurrency.Size = new System.Drawing.Size(276, 29);
            this.comboCurrency.TabIndex = 23;
            // 
            // comboTentativeSchedule
            // 
            this.comboTentativeSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTentativeSchedule.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTentativeSchedule.FormattingEnabled = true;
            this.comboTentativeSchedule.Items.AddRange(new object[] {
            "Select one",
            "day",
            "week",
            "month"});
            this.comboTentativeSchedule.Location = new System.Drawing.Point(150, 713);
            this.comboTentativeSchedule.Name = "comboTentativeSchedule";
            this.comboTentativeSchedule.Size = new System.Drawing.Size(171, 29);
            this.comboTentativeSchedule.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(394, 507);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(198, 23);
            this.label11.TabIndex = 25;
            this.label11.Text = "Term and condition :";
            // 
            // txtTermAndCondition
            // 
            this.txtTermAndCondition.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTermAndCondition.Location = new System.Drawing.Point(398, 542);
            this.txtTermAndCondition.Name = "txtTermAndCondition";
            this.txtTermAndCondition.Size = new System.Drawing.Size(276, 114);
            this.txtTermAndCondition.TabIndex = 26;
            this.txtTermAndCondition.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(394, 676);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 23);
            this.label12.TabIndex = 27;
            this.label12.Text = "Revision :";
            // 
            // txtRevision
            // 
            this.txtRevision.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRevision.Location = new System.Drawing.Point(398, 713);
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Size = new System.Drawing.Size(276, 30);
            this.txtRevision.TabIndex = 28;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.Black;
            this.buttonClear.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.ForeColor = System.Drawing.Color.White;
            this.buttonClear.Location = new System.Drawing.Point(900, 664);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(128, 47);
            this.buttonClear.TabIndex = 29;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.Black;
            this.buttonCreate.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.ForeColor = System.Drawing.Color.White;
            this.buttonCreate.Location = new System.Drawing.Point(737, 664);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(128, 47);
            this.buttonCreate.TabIndex = 30;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // comboAgreementType
            // 
            this.comboAgreementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAgreementType.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAgreementType.FormattingEnabled = true;
            this.comboAgreementType.Items.AddRange(new object[] {
            "Select one",
            "Blanket Purchase Agreement",
            "Contract Purchase Agreement",
            "Planned Purchase Agreement"});
            this.comboAgreementType.Location = new System.Drawing.Point(398, 134);
            this.comboAgreementType.Name = "comboAgreementType";
            this.comboAgreementType.Size = new System.Drawing.Size(276, 29);
            this.comboAgreementType.TabIndex = 31;
            this.comboAgreementType.SelectedIndexChanged += new System.EventHandler(this.comboAgreementType_SelectedIndexChanged);
            // 
            // txtTentativeSchedule
            // 
            this.txtTentativeSchedule.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTentativeSchedule.Location = new System.Drawing.Point(45, 713);
            this.txtTentativeSchedule.Name = "txtTentativeSchedule";
            this.txtTentativeSchedule.Size = new System.Drawing.Size(99, 30);
            this.txtTentativeSchedule.TabIndex = 32;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(733, 507);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(216, 23);
            this.label13.TabIndex = 33;
            this.label13.Text = "Total Agreed Amount :";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(737, 542);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(276, 30);
            this.txtTotalAmount.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Purchase Agreement ID :";
            // 
            // buttonItemName
            // 
            this.buttonItemName.BackColor = System.Drawing.Color.Black;
            this.buttonItemName.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonItemName.ForeColor = System.Drawing.Color.White;
            this.buttonItemName.Location = new System.Drawing.Point(892, 265);
            this.buttonItemName.Name = "buttonItemName";
            this.buttonItemName.Size = new System.Drawing.Size(147, 36);
            this.buttonItemName.TabIndex = 35;
            this.buttonItemName.Text = "item Name";
            this.buttonItemName.UseVisualStyleBackColor = false;
            this.buttonItemName.Click += new System.EventHandler(this.buttonItemName_Click);
            // 
            // createPurchaseAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1083, 779);
            this.Controls.Add(this.buttonItemName);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTentativeSchedule);
            this.Controls.Add(this.comboAgreementType);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.txtRevision);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTermAndCondition);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboTentativeSchedule);
            this.Controls.Add(this.comboCurrency);
            this.Controls.Add(this.txtExpectedDiscount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.agreementItemTable);
            this.Controls.Add(this.effectiveDate);
            this.Controls.Add(this.createDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.comboSupplierID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAgreementID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "createPurchaseAgreement";
            this.Text = "createPurchaseAgreement";
            this.Load += new System.EventHandler(this.createPurchaseAgreement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agreementItemTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblheading;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtAgreementID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtExpectedDiscount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtRevision;
        public System.Windows.Forms.Button buttonClear;
        public System.Windows.Forms.Button buttonCreate;
        public System.Windows.Forms.TextBox txtTentativeSchedule;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountAgreed;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoQ;
        public System.Windows.Forms.ComboBox comboAgreementType;
        public System.Windows.Forms.ComboBox comboSupplierID;
        public System.Windows.Forms.DateTimePicker createDate;
        public System.Windows.Forms.DateTimePicker effectiveDate;
        public System.Windows.Forms.DataGridView agreementItemTable;
        public System.Windows.Forms.ComboBox comboCurrency;
        public System.Windows.Forms.ComboBox comboTentativeSchedule;
        public System.Windows.Forms.RichTextBox txtTermAndCondition;
        public System.Windows.Forms.Button buttonItemName;
    }
}