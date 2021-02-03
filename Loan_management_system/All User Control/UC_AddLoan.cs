using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loan_management_system.All_User_Control
{
    public partial class UC_AddLoan : UserControl
    {
        function fn = new function();
        String query;
        public UC_AddLoan()
        {
            InitializeComponent();
        }

        private void UC_AddLoan_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        public void clearAll()
        {
            txtType.SelectedIndex = -1;
            txtInterest.SelectedIndex = -1;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddloan_Click(object sender, EventArgs e)
        {
            if(txtType.Text !="" && txtInterest.Text != "")
            {
                String type = txtType.Text;
                String interest = txtInterest.Text;

                query = "insert into loans (loanType,loanInterest)values('"+type+"','"+interest+"')";
                fn.setData(query,"Loan Added");
                UC_AddLoan_Load_1(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Fill All Fields.", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UC_AddLoan_Load_1(object sender, EventArgs e)
        {
            query = "select * from loans";
            DataSet ds = fn.getData(query);
            GridView1.DataSource = ds.Tables[0];
        }

        private void UC_AddLoan_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_AddLoan_Enter(object sender, EventArgs e)
        {
            UC_AddLoan_Load_1(this, null);
        }
    }
}
