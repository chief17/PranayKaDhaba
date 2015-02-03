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
    public partial class billquantity : Form
    {
        public string[] ReturnValue1 { get; set; }
        String name;
        String qu;
        String code;
        String cost;
        DataGridView b;
        String tx;
        public billquantity(String iname, String quant, String icode, String price, ref DataGridView bill, String tax)
        {
            InitializeComponent();
            name = iname;
            qu = quant;
            code = icode;
            cost = price;
            b = bill;
            tx = tax;
            textBox1.Text = quant;
            textBox2.Text = price;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doaction();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                doaction();
            }
        }

        public void doaction()
        {
            if (qu != textBox1.Text)
            {

                String newq = textBox1.Text;
                Double nq = Convert.ToDouble(newq);
                Double p = Convert.ToDouble(textBox2.Text);
                Double total = (nq * p);
                Double taxation = total * (Convert.ToDouble(tx) / 100);
                string[] row1 = new string[] { name, newq, taxation.ToString(), total.ToString()};
                b.Rows.Add(row1);
                //ttl.Text = (Convert.ToDouble(ttl.Text) + total).ToString(); ;
                this.Close();
            }
            else
                MessageBox.Show("Do You want to sell complete stock or you dont have enough ?");
        }
    }
}
