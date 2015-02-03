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
    public partial class updateStock : Form
    {
        public string iscode;
        public string icode;
        public String iquant;
        public String cquant;
        public string updatequant = null;
        public updateStock()
        {
            InitializeComponent();
            
        }
        public void setCounter()
        {
            decimal q = Convert.ToDecimal(cquant);
            numericUpDown1.Value = q;
        }

        private void boxvalue_changed(object sender, EventArgs e)
        {
            updatequant = numericUpDown1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (updatequant != null && Convert.ToDecimal(cquant) == Convert.ToDecimal(iquant))
            {
                if (Convert.ToDecimal(cquant) > Convert.ToDecimal(updatequant))   //removal of stock
                {
                    StockEngine_EditSystem es = new StockEngine_EditSystem();
                    if (es.removeStock(this, Convert.ToDecimal(cquant) - Convert.ToDecimal(updatequant)) &&
                    es.removeInvestment(this, Convert.ToDecimal(cquant) - Convert.ToDecimal(updatequant)))
                    {
                        MessageBox.Show("Updated Successfully!");
                    }
                    else
                        MessageBox.Show("Error Occured");
                }
                else if (Convert.ToDecimal(cquant) < Convert.ToDecimal(updatequant))     //addition of stock
                {
                    StockEngine_EditSystem es = new StockEngine_EditSystem();
                    if (es.addStock(this, Convert.ToDecimal(updatequant) - Convert.ToDecimal(cquant)) &&
                    es.addInvestment(this, Convert.ToDecimal(updatequant) - Convert.ToDecimal(cquant)))
                    {
                        MessageBox.Show("Updated Successfully!");
                    }
                    else
                        MessageBox.Show("Error Occured");
                }
            }
            else
                MessageBox.Show("No Changes Made to Stock");
        }
        
    }
}
