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
    public partial class CustomerDetails : UserControl
    {
        function fn = new function();
        String query;
        public CustomerDetails()
        {
            InitializeComponent();
        }

        private void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtSearchBy.SelectedIndex == 0)
            {
                query = "select * from customers";
                DataSet ds = fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];

            }
            else if(txtSearchBy.SelectedIndex == 1)
            {
                query = "select * from customers where eds = 'NO'";
                DataSet ds = fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
            }
            else if(txtSearchBy.SelectedIndex == 2)
            {
                query = "select * from customers where eds = 'YES'";
                DataSet ds = fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
