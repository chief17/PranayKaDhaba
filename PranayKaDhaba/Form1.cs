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
    public partial class Form1 : Form
    {
        StockEngine item;
        int response;
        public Form1()
        {
            InitializeComponent();
            item = new StockEngine();
            response = 0;
            DateTime today = DateTime.Today;
            MessageBox.Show(today.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));
            chequeEngine cq = new chequeEngine();
            double total = cq.fetchtotal(today.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture));
            amount.Text = "Rs. " + total.ToString();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'billViewDataSet.pkd_main_inventory' table. You can move, or remove it, as needed.
           // this.pkd_main_inventoryTableAdapter1.Fill(this.billViewDataSet.pkd_main_inventory);
            // TODO: This line of code loads data into the 'testDataSet1.pkd_main_inventory' table. You can move, or remove it, as needed.
            this.pkd_main_inventoryTableAdapter1.Fill(this.billViewDataSet.pkd_main_inventory);
            // TODO: This line of code loads data into the 'testDataSet.pkd_cheques' table. You can move, or remove it, as needed.
            this.pkd_chequesTableAdapter.Fill(this.testDataSet.pkd_cheques);
            // TODO: This line of code loads data into the 'itemListDataSet.pkd_main_inventory' table. You can move, or remove it, as needed.
            try
            {
                pkd_main_inventoryTableAdapter.Fill(this.itemListDataSet.pkd_main_inventory);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error In Loading Item Data : "+ex.Message);
            }
        }
        private void tab3AddNewItem_Click(object sender, EventArgs e)
        {
            Item_Properties f = new Item_Properties(1, 0);
            //f.actionEvent(1,0);
            f.ShowDialog();
            int index = tab3ItemDataGrid.SelectedCells[0].RowIndex;
            pkd_main_inventoryTableAdapter.Fill(itemListDataSet.pkd_main_inventory);
            pkdmaininventoryBindingSource.ResetBindings(false);
            tab3ItemDataGrid.CurrentCell = tab3ItemDataGrid.Rows[index].Cells[0];
        }
        
        private void tab3ItemDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (tab3ItemDataGrid.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = tab3ItemDataGrid.Rows[tab3ItemDataGrid.SelectedCells[0].RowIndex];
                tab3itemCode.Text = selectedRow.Cells[0].Value.ToString();
                tab3itemName.Text = selectedRow.Cells[1].Value.ToString();
                tab3sp.Text = selectedRow.Cells[3].Value.ToString();
                tab3currquant.Text = selectedRow.Cells[2].Value.ToString();
                tab3newquant.Text = "";
                tab3newcp.Text = "";
                tab3newcptot.Text = "";
            }
        }

        private void tab3ItemDataGrid_DoubleClick(object sender, EventArgs e)
        {
            if (tab3ItemDataGrid.SelectedCells.Count > 0)
            {
                Item_Properties f = new Item_Properties(2, Convert.ToUInt32(tab3itemCode.Text));
                //f.Show();
                f.ShowDialog();
                int index = tab3ItemDataGrid.SelectedCells[0].RowIndex;
                pkd_main_inventoryTableAdapter.Fill(itemListDataSet.pkd_main_inventory);
                pkdmaininventoryBindingSource.ResetBindings(false);
                tab3ItemDataGrid.CurrentCell = tab3ItemDataGrid.Rows[index].Cells[0];
            }
        }

        private void tab3Search_TextChanged(object sender, EventArgs e)
        {
            pkdmaininventoryBindingSource.Filter = "itemName LIKE '" + tab3Search.Text + "%'";
        }

       /* private void tab1Search_TextChanged(object sender, EventArgs e)
        {
            pkdmaininventoryBindingSource1.Filter = "itemName LIKE '" + tab1search.Text + "%'";
        } **/

        private void tab3addstock_Click(object sender, EventArgs e)
        {
            if (!tab3Validate())
                return;
            item.itemCode = Convert.ToUInt32(tab3itemCode.Text);
            item.quantity = Convert.ToDouble(tab3currquant.Text) + Convert.ToDouble(tab3newquant.Text);
            item.currQuantity = Convert.ToDouble(tab3newquant.Text);
            item.initQuantity = Convert.ToDouble(tab3newquant.Text);
            item.costPrice = Convert.ToDouble(tab3newcp.Text);
            response = item.addNewStock();
            if (response == 0)
            {
                MessageBox.Show("Stocks Updated");
                int index = tab3ItemDataGrid.SelectedCells[0].RowIndex; 
                pkd_main_inventoryTableAdapter.Fill(itemListDataSet.pkd_main_inventory);
                pkdmaininventoryBindingSource.ResetBindings(false);
                tab3ItemDataGrid.CurrentCell = tab3ItemDataGrid.Rows[index].Cells[0];
            }
            else
                MessageBox.Show("Oopsie Doopsie, Something Went Wrong!!! Response Code:" + response);
        }

        private Boolean tab3Validate()
        {
            double a;
            if (String.IsNullOrWhiteSpace(tab3newquant.Text))
            {
                MessageBox.Show("OopsyDoopsy, Quantity Needs to Be Mentioned!!!");
                tab3newquant.Focus();
                return false;
            }
            else if (!(Double.TryParse(tab3newquant.Text, out a)))
            {
                MessageBox.Show("Oopsy Doopsy, Quantity Can Only Be Numbers!!!");
                tab3newquant.Focus();
                return false;
            }
            else if (String.IsNullOrWhiteSpace(tab3newcp.Text) || String.IsNullOrWhiteSpace(tab3newcptot.Text))
            {
                MessageBox.Show("Oopsy Doopsy, Mention CostPrice!!!");
                return false;
            }
            else if(!(Double.TryParse(tab3newcp.Text, out a))||!(Double.TryParse(tab3newquant.Text, out a)))
            {
                MessageBox.Show("Oopsy Doopsy, CP Should be Numeric!!!");
                return false;
            }
            return true;
        }

        private void tab3newquant_TextChanged(object sender, EventArgs e)
        {
            double a;
            if (!(Double.TryParse(tab3newquant.Text, out a)))
            {
                tab3newquant.Focus();
                tab3newcp.Enabled = false;
                tab3newcptot.Enabled = false;
                return;
            }
            else
            {
                tab3newcp.Enabled = true;
                tab3newcptot.Enabled = true;
            }
            if (tab3newquant.Text.Length == 0)
            {
                tab3newcp.Enabled = false;
                tab3newcptot.Enabled = false;
            }
        }

        private void tab3newcp_TextChanged(object sender, EventArgs e)
        {
            double a;
            if (string.IsNullOrEmpty(tab3newcp.Text))
            {
                tab3newcptot.Text = "";
                return;
            }
            if (!(Double.TryParse(tab3newcp.Text, out a)))
            {
                tab3newcp.Focus();
                MessageBox.Show("New Cost Price Can only be Numeric");
                return;
            }
            else
            {
                tab3newcptot.Text = Convert.ToString(Convert.ToDouble(tab3newcp.Text) * Convert.ToDouble(tab3newquant.Text));
            }
        }

        private void tab3newcptot_TextChanged(object sender, EventArgs e)
        {
            double a;
            if (String.IsNullOrEmpty(tab3newcptot.Text))
            {
                tab3newcp.Text = "";
                return;
            }
            if (!(Double.TryParse(tab3newcptot.Text, out a)))
            {
                tab3newcptot.Focus();
                MessageBox.Show("New Cost Price Total Can only be Numeric");
                return;
            }
            else
            {
                tab3newcp.Text = Convert.ToString((Convert.ToDouble(tab3newcptot.Text) /Convert.ToDouble(tab3newquant.Text)));
            }
        }

        private void onDateChange(object sender, EventArgs e)
        {
            string newdate = dateTimePicker1.Value.ToString("yyyyMMdd");
            //MessageBox.Show("New Date is " + newdate);
            chequeEngine cq = new chequeEngine();
            double total = cq.fetchtotal(newdate);
            amount.Text = "Rs. " + total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chequeEngine cq = new chequeEngine();
            if (textBox3.Text != null || textBox3.Text != "" || textBox1.Text != null || textBox1.Text != "" || textBox2.Text != null || textBox2.Text != "")
                if (cq.addcheque(textBox1.Text, textBox2.Text, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"), textBox3.Text))
                {
                    MessageBox.Show("Cheque Added Successfully!");
                    textBox3.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";
                }
                else
                    MessageBox.Show("Some Error occured");
            else
                MessageBox.Show("Please fill in the data completely!");

            pkd_chequesTableAdapter.Fill(testDataSet.pkd_cheques);
            pkdchequesBindingSource.ResetBindings(false);
            string newdate = dateTimePicker1.Value.ToString("yyyyMMdd");
            //MessageBox.Show("New Date is " + newdate);
            cq = new chequeEngine();
            double total = cq.fetchtotal(newdate);
            amount.Text = total.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chequeEngine cq = new chequeEngine();
            DataGridViewRow selectedRow = chequeGrid.Rows[chequeGrid.SelectedCells[0].RowIndex];
            String cno = selectedRow.Cells[0].Value.ToString();
            if (cq.delcheque(cno))
            {
                MessageBox.Show("Cheque Removed Successfully!");
            }
            else
                MessageBox.Show("Some error occurred.");
            pkd_chequesTableAdapter.Fill(testDataSet.pkd_cheques);
            pkdchequesBindingSource.ResetBindings(false);
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.pkd_main_inventoryTableAdapter1.Fill(this.billViewDataSet.pkd_main_inventory);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void tab1search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];
                    String itemname = selectedRow.Cells[0].Value.ToString();
                    String quant = selectedRow.Cells[1].Value.ToString();
                    String price = selectedRow.Cells[2].Value.ToString();
                    String itemcode = selectedRow.Cells[5].Value.ToString();
                    String tax = selectedRow.Cells[4].Value.ToString();
                    billquantity add = new billquantity(itemname, quant, itemcode, price, ref dataGridView2, tax);
                    var result = add.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        
                    }
                }
            }
            else
                pkdmaininventoryBindingSource1.Filter = "itemName LIKE '" + tab1search.Text + "%'";
        }

        private void tab1search_TextChanged(object sender, EventArgs e)
        {
            pkdmaininventoryBindingSource1.Filter = "itemName LIKE '" + tab1search.Text + "%'";
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double currtotal = 0.00;
            double tax = 0.00;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {

                currtotal += Convert.ToDouble(row.Cells["totprice"].Value);
                tax += Convert.ToDouble(row.Cells["tax"].Value);
                label21.Text = (currtotal + tax).ToString();
            }
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            double currtotal = 0.00;
            double tax = 0.00;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                
                currtotal += Convert.ToDouble(row.Cells["totprice"].Value);
                tax += Convert.ToDouble(row.Cells["tax"].Value);
                label21.Text = (currtotal + tax).ToString();
            }
        }

                                 
    }
}
