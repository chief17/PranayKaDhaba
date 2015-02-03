using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PranayKaDhaba
{
    public partial class Item_Properties : Form
    {
        int action, response;
        UInt32 itemCode;
        StockEngine item;

        public Item_Properties(int a1, UInt32 i1)
        {
            action = a1;
            itemCode = i1;
            InitializeComponent();
            InitializeForm();
        }

        void InitializeForm()
        {

            tab1Unit.SelectedIndex = 0;
            item = new StockEngine();
 
            //MessageBox.Show(action + "  "+ itemCode);
            if (action == 1)
            {
                foreach (Control ctl in tab2StockHistory.Controls) ctl.Enabled = false;
                tab1AddButton.Show();
                tab1ModifyButton.Hide();
                tab1DeleteButton.Hide();
            }
            else if (action == 2)
            {
                tab1ItemCode.Text = Convert.ToString(itemCode);
                tab1CostPrice.Enabled = false;
                tab1Quantity.Enabled = false;
                tab1AddButton.Hide();
                tab1ModifyButton.Show();
                tab1DeleteButton.Show();

                item.itemCode = itemCode;
                if (item.getItemDetails()==1)
                {
                    tab1ItemName.Text = item.itemName;
                    tab1Quantity.Text = item.quantity.ToString();
                    tab1Buffer.Text = item.buffer.ToString();
                    tab1Unit.SelectedIndex = item.measuringUnit -1;
                    tab1CostPrice.Text = item.costPrice.ToString();
                    tab1Tax.Text=item.taxPercentage.ToString();
                    tab1SellingPrice.Text=item.sellingPrice.ToString();
                    tab1Wsp.Text = item.wholeSalePrice.ToString();
                    tab1VendorDetails.Text = item.vendorDetails;
                    if (item.itemType == 200)
                        tab1Type.Checked = true;
                    else
                        tab1Type.Checked = false;
                }

                else
                {
                    MessageBox.Show("Oopsie Doopsie, Something Went Wrong");
                }
                
            }
            else
            {
                Console.WriteLine("Invalid Option");
            }
            

        }

        // PROCESSING FOR TAB1
        //****************** Add Button is Clicked ********************
        // Caputr data from from. Its validated and then tables are   *
        // updated                                                    *
        //*************************************************************
        private void tab1AddButton_Click(object sender, EventArgs e)
        {
            if (!Validate_Data())
                return;

            item.itemName = tab1ItemName.Text;
            item.quantity = Convert.ToDouble(tab1Quantity.Text);
            item.buffer = Convert.ToDouble(tab1Buffer.Text);
            item.measuringUnit = Convert.ToUInt16(tab1Unit.SelectedIndex + 1);
            item.costPrice = Convert.ToDouble(tab1CostPrice.Text);
            item.taxPercentage = Convert.ToDouble(tab1Tax.Text);
            item.sellingPrice = Convert.ToDouble(tab1SellingPrice.Text);
            item.wholeSalePrice = Convert.ToDouble(tab1Wsp.Text);
            item.vendorDetails = tab1VendorDetails.Text;
            if (tab1Type.Checked == true)
                item.itemType = 200; //Under the Table Product
            else
                item.itemType = 100; //Normal Product

            response = item.addItem();

            tab1VendorDetails.Text = item.vendorDetails;

            if (response == 0)
            {
                MessageBox.Show("Item Added Succesfully");
                action = 2;
                tab1AddButton.Hide();
                tab1ModifyButton.Show();
                tab1DeleteButton.Show();
                tab1CostPrice.Enabled = false;
                tab1Quantity.Enabled = false;
                tab1ItemCode.Text = item.itemCode.ToString();
                tab2NewCP.Enabled = true;
                tab2AmendCP.Enabled = true;
                tab2CPdataGrid.Enabled = true;
                pkd_cost_priceTableAdapter.Fill(this.costPriceDataSet.pkd_cost_price);
                pkdcostpriceBindingSource.Filter = "itemCode=" + item.itemCode;
            }
            else if (response == 1)
                MessageBox.Show("Oopsy Doopsy!!! Item Name Already Exists");
            else
                MessageBox.Show("Oopsy Doopsy, Something Went Wrong Response Code: " + response);




            //investable to be updated if quantity >0 at the time of addtion of product. 
        }

        private void tab1ModifyButton_Click(object sender, EventArgs e)
        {
            if (!Validate_Data())
                return;
            
            item.itemCode = Convert.ToUInt32(tab1ItemCode.Text);
            item.itemName = tab1ItemName.Text;
            item.buffer = Convert.ToDouble(tab1Buffer.Text);
            item.quantity = Convert.ToDouble(tab1Quantity.Text);
            item.measuringUnit = Convert.ToUInt16(tab1Unit.SelectedIndex + 1);
            //item.costPrice = Convert.ToDouble(tab1CostPrice.Text);
            item.taxPercentage = Convert.ToDouble(tab1Tax.Text);
            item.sellingPrice = Convert.ToDouble(tab1SellingPrice.Text);
            item.wholeSalePrice = Convert.ToDouble(tab1Wsp.Text);
            item.vendorDetails = tab1VendorDetails.Text;
            if (tab1Type.Checked == true)
                item.itemType = 200;
            else
                item.itemType = 100;

            response = item.modifyItem();

            if (response == 0)
            {
                MessageBox.Show("Item Modified Sucessfully");
            }
            else if (response == 1)
            {
                MessageBox.Show("Oopsy Doopsy,Item with the same Already Exist!!!");
            }
            else
            {
                tab1VendorDetails.Text = item.vendorDetails;
                MessageBox.Show("Oopsy Doopsy, Something went wrong. Response" + response);
            }
        }
        private Boolean Validate_Data()
        {
            double a;
            if (String.IsNullOrWhiteSpace(tab1ItemName.Text))
            {
                MessageBox.Show("Oopsy Doopsy, Item Name Cant be Left Empty!!!");
                tab1ItemName.Focus();
                return false;
            }
            else if (String.IsNullOrWhiteSpace(tab1Quantity.Text))
            {
                MessageBox.Show("Oopsy Doopsy, Quantity Cant be Left Empty!!!");
                tab1Quantity.Focus();
                return false;
            }//QUANTITY NUMERIC NEED TO BE CHECKED
            else if (!(Double.TryParse(tab1Quantity.Text, out a)))
            {
                MessageBox.Show("Oopsy Doopsy, Quantity Can Be Only Numbers!!!");
                tab1Quantity.Focus();
                return false;
            }
            else if (!(String.IsNullOrWhiteSpace(tab1Buffer.Text)) && !(Double.TryParse(tab1Buffer.Text, out a)))
            {
                MessageBox.Show("Oopsy Doopsy, Buffer Can be Only Numbers!!!");
                tab1Buffer.Focus();
                return false;
            }
            else if (String.IsNullOrWhiteSpace(tab1CostPrice.Text))
            {
                MessageBox.Show("OopsyDoopsy, Cost Price Needs to Be Mentioned!!!");
                tab1CostPrice.Focus();
                return false;
            }
            else if (!(Double.TryParse(tab1CostPrice.Text, out a)))
            {
                MessageBox.Show("Oopsy Doopsy, Cost Price Can Only Be Numbers!!!");
                tab1CostPrice.Focus();
                return false;
            }
            else if (Convert.ToDouble(tab1CostPrice.Text) <= 0 && action ==1)
            {
                MessageBox.Show("Oopsy Doopsy, Cost Price Cant Be Zero!!!");
                tab1CostPrice.Focus();
                return false;
            }
            else if (!(String.IsNullOrWhiteSpace(tab1Tax.Text)) && !(Double.TryParse(tab1Tax.Text, out a)))
            {
                MessageBox.Show("Oopsy Doopsy, Tax Percentage Can be Only Numbers!!!");
                tab1Tax.Focus();
                return false;
            }
            else if (!(String.IsNullOrWhiteSpace(tab1SellingPrice.Text)) && !(Double.TryParse(tab1SellingPrice.Text, out a)))
            {
                MessageBox.Show("Oopsy Doopsy, Selling Price Can be Only Numbers!!!");
                tab1SellingPrice.Focus();
                return false;
            }
            else if (!(String.IsNullOrWhiteSpace(tab1Wsp.Text)) && !(Double.TryParse(tab1Wsp.Text, out a)))
            {
                MessageBox.Show("Oopsy Doopsy, Whole Sale Price Can be Only Numbers!!!");
                tab1Wsp.Focus();
                return false;
            }

            //Checking the Non Null Fields If null setting some default value 
            if (String.IsNullOrWhiteSpace(tab1Buffer.Text))
            {
                tab1Buffer.Text = "0";
            }

            if (String.IsNullOrWhiteSpace(tab1Tax.Text))
            {
                tab1Tax.Text = "0";
            }
            if (String.IsNullOrWhiteSpace(tab1SellingPrice.Text))
            {
                tab1SellingPrice.Text = "0";
            }
            if (String.IsNullOrWhiteSpace(tab1Wsp.Text))
            {
                tab1Wsp.Text = "0";
            }
            if (String.IsNullOrWhiteSpace(tab1VendorDetails.Text))
            {
                tab1VendorDetails.Text = " ";
            }

            return true;


        }


        //PROCESSING FOR TAB2
        /* Load the Data Grid with the corresponding itemCode history*/
        private void Item_Properties_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'costPriceDataSet.pkd_cost_price' table. You can move, or remove it, as needed.
            pkd_cost_priceTableAdapter.Fill(this.costPriceDataSet.pkd_cost_price);
            pkdcostpriceBindingSource.Filter = "itemCode=" + itemCode;
        }

        private void tab2CPdataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = tab2CPdataGrid.Rows[tab2CPdataGrid.SelectedCells[0].RowIndex];

            tab2ItemCode.Text = selectedRow.Cells[0].Value.ToString();
            tab2SubCode.Text = selectedRow.Cells[1].Value.ToString();
            tab2OldCP.Text = selectedRow.Cells[2].Value.ToString();
            tab2InitQuantity.Text = selectedRow.Cells[3].Value.ToString();
            tab2CPdataGrid.Rows[tab2CPdataGrid.SelectedCells[0].RowIndex].Selected = true;
        }

        private void tab2AmendCP_Click(object sender, EventArgs e)
        {
            double a;
            if (String.IsNullOrWhiteSpace(tab2NewCP.Text))
            {
                MessageBox.Show("OopsyDoopsy, Cost Price Needs to Be Mentioned!!!");
                tab2NewCP.Focus();
                return;
            }
            else if (!(Double.TryParse(tab2NewCP.Text, out a)))
            {
                MessageBox.Show("Oopsy Doopsy, Cost Price Can Only Be Numbers!!!");
                tab2NewCP.Focus();
                return;
            }
            else if (Convert.ToDouble(tab2NewCP.Text) <= 0)
            {
                MessageBox.Show("Oopsy Doopsy, Cost Price Cant Be Zero!!!");
                tab2NewCP.Focus();
                return;
            }
            else if (Convert.ToDouble(tab2NewCP.Text) == Convert.ToDouble(tab2OldCP.Text))
            {
                MessageBox.Show("Oopsy Doopsy, Same CP, nothing to update!!!");
                tab2NewCP.Focus();
                return;
            }

            item.itemCode = Convert.ToUInt32(tab2ItemCode.Text);
            item.itemSubCode = Convert.ToUInt16(tab2SubCode.Text);
            item.costPrice = Convert.ToDouble(tab2NewCP.Text);
            item.quantity = Convert.ToDouble(tab2InitQuantity.Text);
            response = item.UpdateCostPrice();

            if (response == 0)
            {
                MessageBox.Show("Updated Successfully");
                int index = tab2CPdataGrid.SelectedCells[0].RowIndex;
                pkd_cost_priceTableAdapter.Fill(costPriceDataSet.pkd_cost_price);
                pkdcostpriceBindingSource.ResetBindings(false);
                tab2CPdataGrid.Rows[index].Selected = true;
            }
            else
                MessageBox.Show("Oopsie Doopsie!!! Something went wrong. Response Code:" + response);
            

        }

        public void onstockhistorydoubleclick(object sender, EventArgs e)
        {
            updateStock us = new updateStock();
            DataGridViewRow selectedRow = tab2CPdataGrid.Rows[0];
            us.icode = selectedRow.Cells[0].Value.ToString();
            us.iscode = selectedRow.Cells[1].Value.ToString();
            us.iquant = selectedRow.Cells[3].Value.ToString();
            us.cquant = selectedRow.Cells[4].Value.ToString();
            MessageBox.Show("Data = " + us.cquant);
            us.setCounter();
            us.Show();
            pkd_cost_priceTableAdapter.Fill(costPriceDataSet.pkd_cost_price);
            pkdcostpriceBindingSource.ResetBindings(false);
        }

                    

    }
}
