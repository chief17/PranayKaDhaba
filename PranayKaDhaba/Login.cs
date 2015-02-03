using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace PranayKaDhaba
{
    public partial class Login : Form
    {
        User user;
        int response;
        public Login()
        {
            user = new User();
            InitializeComponent();
            userPass.PasswordChar = '*';
            progressBar1.Visible = false;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(userName.Text))
            {
                MessageBox.Show("Oopsy Doopsy, Enter User Name");
                userName.Focus();
                return;    
            }
            if (string.IsNullOrWhiteSpace(userPass.Text))
            {
                MessageBox.Show("Oopsy Doopsy, Enter Password");
                userPass.Focus();
                return;
            }

            user.userName = userName.Text;
            user.userPass = userPass.Text;

            response=user.validateUser();

            progressBar1.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Maximum = 10000;
            progressBar1.Value = 1;
            progressBar1.Step = 1;
            for (int y = 1; y <= 10000; y++)
            {
                progressBar1.PerformStep();
            }
            if (response == 0)
            {
                Thread mainFormThd = new Thread(new ThreadStart(runMainForm));
                mainFormThd.Start();
                this.Close();
            }
            else if (response == 1)
                MessageBox.Show("Oopsy Doopsy!!! Could Not connect to DB");
            else if (response == 2) 
                MessageBox.Show("Oopsy Doopsy!!! Wrong Credentials");

            userName.Focus();
            progressBar1.Visible = false;
        }

        private void runMainForm()
        {
            Application.Run(new Form1());
        }

        private void userPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                loginButton_Click(sender, e);

            }
        }

       
    }
}
