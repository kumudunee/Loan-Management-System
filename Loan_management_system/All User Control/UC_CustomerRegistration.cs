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
    public partial class UC_CustomerRegistration : UserControl
    {
        function fn = new function();
        String query;
        public UC_CustomerRegistration()
        {
            InitializeComponent();
        }

        private void UC_CustomerRegistration_Load(object sender, EventArgs e)
        {
            
        }
        String loantype;
        private void txtLoanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select loanInterest,loanType from loans where loanType = '"+txtLoanType.Text+"'";
            DataSet ds = fn.getData(query);
            txtLoanInterest.Text = ds.Tables[0].Rows[0][0].ToString();
            loantype = ds.Tables[0].Rows[0][1].ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text != "" && txtName.Text != "" && txtDob.Text != "" && txtAge.Text != "" && txtGender.Text != "" && txtHomeAddress.Text!="" && txtEmailAddress.Text!="" && txtTelephone.Text!="" && txtCivil.Text!=""&&txtNationality.Text!="" && txtID.Text!="" && txtLoanType.Text!="" && txtLoanInterest.Text!="" && txtLoanAmount.Text!="" && txtDuration.Text!="" && txtLoanPurpose.Text!="" && txtLoanStarts.Text!="" && txtLoanEnds.Text!="" && txtJob.Text!="" && txtIncome.Text!="" && txtCompanyAddress.Text!="" && txtCompanyTelephone.Text!="" )
            {
                String code = txtCode.Text;
                String name = txtName.Text;
                String dob = txtDob.Text;
                String age = txtAge.Text;
                String gender = txtGender.Text;
                String homeAdd = txtHomeAddress.Text;
                String emailAdd = txtEmailAddress.Text;
                Int64 mobile = Int64.Parse(txtTelephone.Text);
                String civil = txtCivil.Text;
                String nationality = txtNationality.Text;
                String id = txtID.Text;
                String type = txtLoanType.Text;
                String interest = txtLoanInterest.Text;
                String amount = txtLoanAmount.Text;
                String duration = txtDuration.Text;
                String purpose = txtLoanPurpose.Text;
                String starts = txtLoanStarts.Text;
                String ends = txtLoanEnds.Text;
                String job = txtJob.Text;
                String income = txtIncome.Text;
                String comAdd = txtCompanyAddress.Text;
                String comTel = txtCompanyTelephone.Text;

                query = "insert into customers (cCode,cname,dob,age,gender,address,emailAddress,mobile,civilStatus,nationality,id,type,loanInterest,amount,duration,purpose,starts,ends,job,income,Caddress,Cmobile) values ('"+ code + "','"+ name + "','"+ dob + "','"+ age + "','"+ gender + "','"+ homeAdd + "','"+ emailAdd + "',"+ mobile + ",'"+ civil + "','"+ nationality + "','"+ id + "','"+ type + "','"+ interest + "','"+ amount + "','"+ duration + "','"+ purpose + "','"+ starts + "','"+ ends + "','"+ job + "','"+ income + "','"+ comAdd + "',"+ comTel + ") ";
                fn.setData(query, "Loan Successfully Allocated");
                clearAll();
                
            }
            else
            {
                MessageBox.Show("Fill all Feilds","Information !!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }
        public void clearAll()
        {
            txtCode.Clear();
            txtName.Clear();
            txtDob.ResetText();
            txtAge.Clear();
            txtGender.SelectedIndex = -1;
            txtHomeAddress.Clear();
            txtEmailAddress.Clear();
            txtTelephone.Clear();
            txtCivil.SelectedIndex = -1;
            txtNationality.Clear();
            txtID.Clear();
            txtLoanAmount.Clear();
            txtDuration.Clear();
            txtLoanPurpose.Clear();
            txtLoanStarts.ResetText();
            txtLoanEnds.ResetText();
            txtJob.Clear();
            txtIncome.Clear();
            txtCompanyAddress.Clear();
            txtCompanyTelephone.Clear();

        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            
        }

        private void UC_CustomerRegistration_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
