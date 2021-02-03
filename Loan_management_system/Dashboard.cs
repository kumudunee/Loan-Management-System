using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loan_management_system
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCustomerRegistration_Click(object sender, EventArgs e)
        {
            MovingPannel.Left = btnCustomerRegistration.Left+15;
            uC_CustomerRegistration1.Visible = true;
            uC_CustomerRegistration1.BringToFront();
        }

        private void btnAddloan_Click(object sender, EventArgs e)
        {
            MovingPannel.Left = btnAddloan.Left+7;
            uC_AddLoan1.Visible = true;
            uC_AddLoan1.BringToFront();

        }

        private void btnPaymentCompleted_Click(object sender, EventArgs e)
        {
            uC_PaymentCompleted1.Visible = true;
            uC_PaymentCompleted1.BringToFront();
            MovingPannel.Left = btnPaymentCompleted.Left+7;

        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            customerDetails1.Visible = true;
            customerDetails1.BringToFront();
            MovingPannel.Left = btnCustomerDetails.Left + 25;

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            MovingPannel.Left = btnUsers.Left +10;
            uC_Users1.Visible = true;
            uC_Users1.BringToFront();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_AddLoan1.Visible = false;
            uC_CustomerRegistration1.Visible = false;
            btnAddloan.PerformClick();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MovingPannel.Left = guna2Button1.Left + 10;
            uC_View1.Visible = true;
            uC_View1.BringToFront();
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            log.Show();
            this.Hide();

        }
    }
}
