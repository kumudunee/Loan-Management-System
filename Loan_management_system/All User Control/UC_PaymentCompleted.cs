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
    public partial class UC_PaymentCompleted : UserControl
    {
        public UC_PaymentCompleted()
        {
            InitializeComponent();
        }

        function fn = new function();
        String query;
        private void UC_PaymentCompleted_Load(object sender, EventArgs e)
        {
            query = "select cCode, cname, gender, mobile, type, id, amount, starts  from customers where eds = 'NO'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "select cCode, cname, gender, mobile, type, id, amount, starts  from customers where mobile like '"+txtName.Text+ "%' and eds = 'NO'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCname.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCucode.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnPaymentClose_Click(object sender, EventArgs e)
        {
            if(txtCname.Text != "" )
            {
                if(MessageBox.Show("Customer Successfully Completed the Payment.", "Comfirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)
                {
                    String cdate = txtClose.Text;
                    query = "update customers set eds = 'YES',ends = '"+cdate+ "' where cCode ="+id+"";
                    fn.setData(query, "Payment Completed.");
                    UC_PaymentCompleted_Load(this, null);
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("No Customer Selected.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            txtCname.Clear();
            txtCucode.Clear();
            txtName.Clear();
            txtClose.ResetText();
        }

        private void UC_PaymentCompleted_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
