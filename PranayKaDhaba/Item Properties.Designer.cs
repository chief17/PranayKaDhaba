namespace PranayKaDhaba
{
    partial class Item_Properties
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
            this.tabItemDetail = new System.Windows.Forms.TabControl();
            this.tab1ItemDetails = new System.Windows.Forms.TabPage();
            this.tab1Type = new System.Windows.Forms.CheckBox();
            this.tab1Unit = new System.Windows.Forms.ComboBox();
            this.tab1DeleteButton = new System.Windows.Forms.Button();
            this.tab1ModifyButton = new System.Windows.Forms.Button();
            this.tab1AddButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tab1VendorDetails = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tab1Wsp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tab1SellingPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tab1Tax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tab1CostPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tab1Buffer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tab1Quantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tab1ItemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tab1ItemCode = new System.Windows.Forms.TextBox();
            this.tab2StockHistory = new System.Windows.Forms.TabPage();
            this.tab2InitQuantity = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tab2NewCP = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tab2OldCP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tab2SubCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tab2ItemCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tab2CPdataGrid = new System.Windows.Forms.DataGridView();
            this.tab2AmendCP = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pkdcostpriceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.costPriceDataSet = new PranayKaDhaba.costPriceDataSet();
            this.pkd_cost_priceTableAdapter = new PranayKaDhaba.costPriceDataSetTableAdapters.pkd_cost_priceTableAdapter();
            this.tabItemDetail.SuspendLayout();
            this.tab1ItemDetails.SuspendLayout();
            this.tab2StockHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tab2CPdataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pkdcostpriceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costPriceDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tabItemDetail
            // 
            this.tabItemDetail.Controls.Add(this.tab1ItemDetails);
            this.tabItemDetail.Controls.Add(this.tab2StockHistory);
            this.tabItemDetail.Location = new System.Drawing.Point(13, 8);
            this.tabItemDetail.Name = "tabItemDetail";
            this.tabItemDetail.SelectedIndex = 0;
            this.tabItemDetail.Size = new System.Drawing.Size(669, 469);
            this.tabItemDetail.TabIndex = 0;
            // 
            // tab1ItemDetails
            // 
            this.tab1ItemDetails.Controls.Add(this.tab1Type);
            this.tab1ItemDetails.Controls.Add(this.tab1Unit);
            this.tab1ItemDetails.Controls.Add(this.tab1DeleteButton);
            this.tab1ItemDetails.Controls.Add(this.tab1ModifyButton);
            this.tab1ItemDetails.Controls.Add(this.tab1AddButton);
            this.tab1ItemDetails.Controls.Add(this.label9);
            this.tab1ItemDetails.Controls.Add(this.tab1VendorDetails);
            this.tab1ItemDetails.Controls.Add(this.label7);
            this.tab1ItemDetails.Controls.Add(this.tab1Wsp);
            this.tab1ItemDetails.Controls.Add(this.label8);
            this.tab1ItemDetails.Controls.Add(this.tab1SellingPrice);
            this.tab1ItemDetails.Controls.Add(this.label5);
            this.tab1ItemDetails.Controls.Add(this.tab1Tax);
            this.tab1ItemDetails.Controls.Add(this.label6);
            this.tab1ItemDetails.Controls.Add(this.tab1CostPrice);
            this.tab1ItemDetails.Controls.Add(this.label3);
            this.tab1ItemDetails.Controls.Add(this.tab1Buffer);
            this.tab1ItemDetails.Controls.Add(this.label4);
            this.tab1ItemDetails.Controls.Add(this.tab1Quantity);
            this.tab1ItemDetails.Controls.Add(this.label2);
            this.tab1ItemDetails.Controls.Add(this.tab1ItemName);
            this.tab1ItemDetails.Controls.Add(this.label1);
            this.tab1ItemDetails.Controls.Add(this.tab1ItemCode);
            this.tab1ItemDetails.Location = new System.Drawing.Point(4, 22);
            this.tab1ItemDetails.Name = "tab1ItemDetails";
            this.tab1ItemDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tab1ItemDetails.Size = new System.Drawing.Size(661, 443);
            this.tab1ItemDetails.TabIndex = 0;
            this.tab1ItemDetails.Text = "Item Details";
            this.tab1ItemDetails.UseVisualStyleBackColor = true;
            // 
            // tab1Type
            // 
            this.tab1Type.AutoSize = true;
            this.tab1Type.Location = new System.Drawing.Point(466, 182);
            this.tab1Type.Name = "tab1Type";
            this.tab1Type.Size = new System.Drawing.Size(96, 17);
            this.tab1Type.TabIndex = 18;
            this.tab1Type.Text = "Type2 Product";
            this.tab1Type.UseVisualStyleBackColor = true;
            // 
            // tab1Unit
            // 
            this.tab1Unit.FormattingEnabled = true;
            this.tab1Unit.Items.AddRange(new object[] {
            "Piece(s)",
            "Gram",
            "KiloGram(s)"});
            this.tab1Unit.Location = new System.Drawing.Point(457, 70);
            this.tab1Unit.Name = "tab1Unit";
            this.tab1Unit.Size = new System.Drawing.Size(74, 21);
            this.tab1Unit.TabIndex = 7;
            // 
            // tab1DeleteButton
            // 
            this.tab1DeleteButton.Location = new System.Drawing.Point(459, 228);
            this.tab1DeleteButton.Name = "tab1DeleteButton";
            this.tab1DeleteButton.Size = new System.Drawing.Size(73, 20);
            this.tab1DeleteButton.TabIndex = 21;
            this.tab1DeleteButton.Text = "Delete";
            this.tab1DeleteButton.UseVisualStyleBackColor = true;
            // 
            // tab1ModifyButton
            // 
            this.tab1ModifyButton.Location = new System.Drawing.Point(377, 228);
            this.tab1ModifyButton.Name = "tab1ModifyButton";
            this.tab1ModifyButton.Size = new System.Drawing.Size(73, 20);
            this.tab1ModifyButton.TabIndex = 20;
            this.tab1ModifyButton.Text = "Modify";
            this.tab1ModifyButton.UseVisualStyleBackColor = true;
            this.tab1ModifyButton.Click += new System.EventHandler(this.tab1ModifyButton_Click);
            // 
            // tab1AddButton
            // 
            this.tab1AddButton.Location = new System.Drawing.Point(298, 228);
            this.tab1AddButton.Name = "tab1AddButton";
            this.tab1AddButton.Size = new System.Drawing.Size(73, 20);
            this.tab1AddButton.TabIndex = 19;
            this.tab1AddButton.Text = "Add";
            this.tab1AddButton.UseVisualStyleBackColor = true;
            this.tab1AddButton.Click += new System.EventHandler(this.tab1AddButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 30);
            this.label9.TabIndex = 18;
            this.label9.Text = "Vendor\r\nDetails :";
            // 
            // tab1VendorDetails
            // 
            this.tab1VendorDetails.Location = new System.Drawing.Point(118, 149);
            this.tab1VendorDetails.Multiline = true;
            this.tab1VendorDetails.Name = "tab1VendorDetails";
            this.tab1VendorDetails.Size = new System.Drawing.Size(332, 57);
            this.tab1VendorDetails.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(247, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "WSP:";
            // 
            // tab1Wsp
            // 
            this.tab1Wsp.Location = new System.Drawing.Point(306, 122);
            this.tab1Wsp.Name = "tab1Wsp";
            this.tab1Wsp.Size = new System.Drawing.Size(144, 20);
            this.tab1Wsp.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Selling Price :";
            // 
            // tab1SellingPrice
            // 
            this.tab1SellingPrice.Location = new System.Drawing.Point(118, 123);
            this.tab1SellingPrice.Name = "tab1SellingPrice";
            this.tab1SellingPrice.Size = new System.Drawing.Size(111, 20);
            this.tab1SellingPrice.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(247, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tax :";
            // 
            // tab1Tax
            // 
            this.tab1Tax.Location = new System.Drawing.Point(306, 96);
            this.tab1Tax.Name = "tab1Tax";
            this.tab1Tax.Size = new System.Drawing.Size(144, 20);
            this.tab1Tax.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Cost Price :";
            // 
            // tab1CostPrice
            // 
            this.tab1CostPrice.Location = new System.Drawing.Point(118, 97);
            this.tab1CostPrice.Name = "tab1CostPrice";
            this.tab1CostPrice.Size = new System.Drawing.Size(111, 20);
            this.tab1CostPrice.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(247, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Buffer :";
            // 
            // tab1Buffer
            // 
            this.tab1Buffer.Location = new System.Drawing.Point(306, 70);
            this.tab1Buffer.Name = "tab1Buffer";
            this.tab1Buffer.Size = new System.Drawing.Size(144, 20);
            this.tab1Buffer.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Quantity :";
            // 
            // tab1Quantity
            // 
            this.tab1Quantity.Location = new System.Drawing.Point(118, 71);
            this.tab1Quantity.Name = "tab1Quantity";
            this.tab1Quantity.Size = new System.Drawing.Size(111, 20);
            this.tab1Quantity.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Item Name :";
            // 
            // tab1ItemName
            // 
            this.tab1ItemName.Location = new System.Drawing.Point(118, 45);
            this.tab1ItemName.Name = "tab1ItemName";
            this.tab1ItemName.Size = new System.Drawing.Size(414, 20);
            this.tab1ItemName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item Code :";
            // 
            // tab1ItemCode
            // 
            this.tab1ItemCode.Enabled = false;
            this.tab1ItemCode.Location = new System.Drawing.Point(118, 19);
            this.tab1ItemCode.Name = "tab1ItemCode";
            this.tab1ItemCode.Size = new System.Drawing.Size(144, 20);
            this.tab1ItemCode.TabIndex = 0;
            // 
            // tab2StockHistory
            // 
            this.tab2StockHistory.Controls.Add(this.button1);
            this.tab2StockHistory.Controls.Add(this.tab2InitQuantity);
            this.tab2StockHistory.Controls.Add(this.label14);
            this.tab2StockHistory.Controls.Add(this.tab2NewCP);
            this.tab2StockHistory.Controls.Add(this.label13);
            this.tab2StockHistory.Controls.Add(this.tab2OldCP);
            this.tab2StockHistory.Controls.Add(this.label12);
            this.tab2StockHistory.Controls.Add(this.tab2SubCode);
            this.tab2StockHistory.Controls.Add(this.label11);
            this.tab2StockHistory.Controls.Add(this.tab2ItemCode);
            this.tab2StockHistory.Controls.Add(this.label10);
            this.tab2StockHistory.Controls.Add(this.tab2CPdataGrid);
            this.tab2StockHistory.Controls.Add(this.tab2AmendCP);
            this.tab2StockHistory.Location = new System.Drawing.Point(4, 22);
            this.tab2StockHistory.Name = "tab2StockHistory";
            this.tab2StockHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tab2StockHistory.Size = new System.Drawing.Size(661, 443);
            this.tab2StockHistory.TabIndex = 1;
            this.tab2StockHistory.Text = "Stock History";
            this.tab2StockHistory.UseVisualStyleBackColor = true;
            // 
            // tab2InitQuantity
            // 
            this.tab2InitQuantity.Enabled = false;
            this.tab2InitQuantity.Location = new System.Drawing.Point(474, 8);
            this.tab2InitQuantity.Name = "tab2InitQuantity";
            this.tab2InitQuantity.Size = new System.Drawing.Size(107, 20);
            this.tab2InitQuantity.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(400, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Quantity";
            // 
            // tab2NewCP
            // 
            this.tab2NewCP.Location = new System.Drawing.Point(283, 36);
            this.tab2NewCP.Name = "tab2NewCP";
            this.tab2NewCP.Size = new System.Drawing.Size(107, 20);
            this.tab2NewCP.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(209, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "New CP";
            // 
            // tab2OldCP
            // 
            this.tab2OldCP.Enabled = false;
            this.tab2OldCP.Location = new System.Drawing.Point(283, 7);
            this.tab2OldCP.Name = "tab2OldCP";
            this.tab2OldCP.Size = new System.Drawing.Size(107, 20);
            this.tab2OldCP.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(209, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Old CP";
            // 
            // tab2SubCode
            // 
            this.tab2SubCode.Enabled = false;
            this.tab2SubCode.Location = new System.Drawing.Point(94, 36);
            this.tab2SubCode.Name = "tab2SubCode";
            this.tab2SubCode.Size = new System.Drawing.Size(107, 20);
            this.tab2SubCode.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Sub Code";
            // 
            // tab2ItemCode
            // 
            this.tab2ItemCode.Enabled = false;
            this.tab2ItemCode.Location = new System.Drawing.Point(94, 10);
            this.tab2ItemCode.Name = "tab2ItemCode";
            this.tab2ItemCode.Size = new System.Drawing.Size(107, 20);
            this.tab2ItemCode.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Item Code";
            // 
            // tab2CPdataGrid
            // 
            this.tab2CPdataGrid.AllowUserToAddRows = false;
            this.tab2CPdataGrid.AllowUserToDeleteRows = false;
            this.tab2CPdataGrid.AllowUserToResizeColumns = false;
            this.tab2CPdataGrid.AllowUserToResizeRows = false;
            this.tab2CPdataGrid.AutoGenerateColumns = false;
            this.tab2CPdataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.tab2CPdataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tab2CPdataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.initQuantityDataGridViewTextBoxColumn,
            this.currQuantityDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn9});
            this.tab2CPdataGrid.DataSource = this.pkdcostpriceBindingSource;
            this.tab2CPdataGrid.Location = new System.Drawing.Point(37, 81);
            this.tab2CPdataGrid.MultiSelect = false;
            this.tab2CPdataGrid.Name = "tab2CPdataGrid";
            this.tab2CPdataGrid.ReadOnly = true;
            this.tab2CPdataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tab2CPdataGrid.Size = new System.Drawing.Size(561, 356);
            this.tab2CPdataGrid.TabIndex = 1;
            this.tab2CPdataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tab2CPdataGrid_CellClick);
            // 
            // tab2AmendCP
            // 
            this.tab2AmendCP.Location = new System.Drawing.Point(416, 36);
            this.tab2AmendCP.Name = "tab2AmendCP";
            this.tab2AmendCP.Size = new System.Drawing.Size(77, 31);
            this.tab2AmendCP.TabIndex = 0;
            this.tab2AmendCP.Text = "Update CP";
            this.tab2AmendCP.UseVisualStyleBackColor = true;
            this.tab2AmendCP.Click += new System.EventHandler(this.tab2AmendCP_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(519, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 31);
            this.button1.TabIndex = 12;
            this.button1.Text = "Update Latest Stock";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.onstockhistorydoubleclick);
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "itemCode";
            this.dataGridViewTextBoxColumn6.HeaderText = "Item Code";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "itemSubCode";
            this.dataGridViewTextBoxColumn7.HeaderText = "Sub Code";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 79;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "costPrice";
            this.dataGridViewTextBoxColumn8.HeaderText = "Cost Price";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // initQuantityDataGridViewTextBoxColumn
            // 
            this.initQuantityDataGridViewTextBoxColumn.DataPropertyName = "initQuantity";
            this.initQuantityDataGridViewTextBoxColumn.HeaderText = "Initial Quantity";
            this.initQuantityDataGridViewTextBoxColumn.Name = "initQuantityDataGridViewTextBoxColumn";
            this.initQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.initQuantityDataGridViewTextBoxColumn.Width = 98;
            // 
            // currQuantityDataGridViewTextBoxColumn
            // 
            this.currQuantityDataGridViewTextBoxColumn.DataPropertyName = "currQuantity";
            this.currQuantityDataGridViewTextBoxColumn.HeaderText = "Current Quantity";
            this.currQuantityDataGridViewTextBoxColumn.Name = "currQuantityDataGridViewTextBoxColumn";
            this.currQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.currQuantityDataGridViewTextBoxColumn.Width = 99;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "inDate";
            this.dataGridViewTextBoxColumn9.HeaderText = "Date";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 55;
            // 
            // pkdcostpriceBindingSource
            // 
            this.pkdcostpriceBindingSource.DataMember = "pkd_cost_price";
            this.pkdcostpriceBindingSource.DataSource = this.costPriceDataSet;
            // 
            // costPriceDataSet
            // 
            this.costPriceDataSet.DataSetName = "costPriceDataSet";
            this.costPriceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pkd_cost_priceTableAdapter
            // 
            this.pkd_cost_priceTableAdapter.ClearBeforeFill = true;
            // 
            // Item_Properties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 489);
            this.Controls.Add(this.tabItemDetail);
            this.Name = "Item_Properties";
            this.Text = "Item_Properties";
            this.Load += new System.EventHandler(this.Item_Properties_Load);
            this.tabItemDetail.ResumeLayout(false);
            this.tab1ItemDetails.ResumeLayout(false);
            this.tab1ItemDetails.PerformLayout();
            this.tab2StockHistory.ResumeLayout(false);
            this.tab2StockHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tab2CPdataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pkdcostpriceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costPriceDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabItemDetail;
        private System.Windows.Forms.TabPage tab1ItemDetails;
        private System.Windows.Forms.TabPage tab2StockHistory;
        private System.Windows.Forms.TextBox tab1ItemCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tab1ItemName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tab1Buffer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tab1Quantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tab1Tax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tab1CostPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tab1Wsp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tab1SellingPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tab1VendorDetails;
        private System.Windows.Forms.Button tab1DeleteButton;
        private System.Windows.Forms.Button tab1ModifyButton;
        private System.Windows.Forms.Button tab1AddButton;
        private System.Windows.Forms.ComboBox tab1Unit;
        private System.Windows.Forms.CheckBox tab1Type;
        private System.Windows.Forms.Button tab2AmendCP;
        private System.Windows.Forms.DataGridView tab2CPdataGrid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tab2ItemCode;
        private System.Windows.Forms.TextBox tab2SubCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tab2OldCP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemSubCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.TextBox tab2NewCP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tab2InitQuantity;
        private System.Windows.Forms.Label label14;
        private costPriceDataSet costPriceDataSet;
        private System.Windows.Forms.BindingSource pkdcostpriceBindingSource;
        private costPriceDataSetTableAdapters.pkd_cost_priceTableAdapter pkd_cost_priceTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn initQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Button button1;

    }
}