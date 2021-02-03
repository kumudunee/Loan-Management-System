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
    public partial class UC_Users : UserControl
    {
        function fn = new function();
        string query;
        public UC_Users()
        {
            InitializeComponent();
        }

        private void UC_Users_Load(object sender, EventArgs e)
        {
            getID();
        }
        public void getID()
        {
            query = "select max(eid) from employee";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Int64 num = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                labelToSet.Text = (num + 1).ToString();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtMobile.Text != "" && txtGender.Text != "" && txtEmail.Text != "" && txtUsername.Text != "" && txtPassword.Text != "")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String gender = txtGender.Text;
                String email = txtEmail.Text;
                String username = txtUsername.Text;
                String password = txtPassword.Text;

                query = "insert into employee (ename,mobile,gender,emailid,username,pass) values('"+name+"',"+mobile+",'"+gender+"','"+email+"','"+username+"','"+password+"')";
                fn.setData(query, "Employee Registered.");

                clearAll();
                getID();
            }
            else
            {
                MessageBox.Show("Fill all feilds.", "Warning...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabEmployee.SelectedIndex == 1)
            {
                query = "select * from employee";
                DataSet ds = fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];
            }
            else if(tabEmployee.SelectedIndex == 2)
            {
                query = "select * from employee";
                DataSet ds = fn.getData(query);
                guna2DataGridView2.DataSource = ds.Tables[0];
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (MessageBox.Show("Are You Sure?", "Comfirmation..!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    query = "delete from employee where eid = " + txtID.Text + "";
                    fn.setData(query, "Record Deleted");
                    tabControl1_SelectedIndexChanged(this, null);
                }
            }
        }
        private void UC_Users_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
        //methods
        public void clearAll()
        {
            txtName.Clear();
            txtMobile.Clear();
            txtGender.SelectedIndex = -1;
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();

        }

        
    }
}
