using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Loan_management_system.All_User_Control
{
    public partial class UC_View : UserControl
    {
       
        public UC_View()
        {
            InitializeComponent();
        }

        private void UC_View_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"data source = .;database = loanManagement;integrated security = True");
        
        private void fetchData()
        {
            if(txtCode.Text == "")
            {
                MessageBox.Show("Enter the Customer Code");
            }
            else
            {
                con.Open();
                String query = "select * from customers where cCode='" + txtCode.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    lblCode.Text = dr["cCode"].ToString();
                    lblName.Text = dr["cname"].ToString();
                    lblGender.Text = dr["gender"].ToString();
                    lblHadd.Text = dr["address"].ToString();
                    lblTel.Text = dr["mobile"].ToString();
                    lblType.Text = dr["type"].ToString();
                    lblAmount.Text = dr["amount"].ToString();
                    lblStart.Text = dr["starts"].ToString();
                    lblEnd.Text = dr["ends"].ToString();


                }
                con.Close();
            }
            
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            fetchData();
        }

        double interest,total;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("==Dumbara Micro Credit==", new Font("centuty Gothic",25,FontStyle.Bold),Brushes.Red, new Point(180));
            e.Graphics.DrawString("  Corporate Office, Mirigama", new Font("centuty Gothic", 20, FontStyle.Regular),Brushes.Black, new Point(180,50));
            e.Graphics.DrawString("Contact - 0332 276 355, 077 778 7371", new Font("centuty Gothic", 20, FontStyle.Regular), Brushes.Black, new Point(180, 90));
            e.Graphics.DrawString("Address - 47 Negombo Rd, Mirigama, Sri Lanka", new Font("centuty Gothic", 20, FontStyle.Regular), Brushes.Black, new Point(180, 140));
            e.Graphics.DrawString("Customer Code :- " + lblCode.Text+ "\t\tName :- "+ lblName.Text  , new Font("centuty Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(30,190));
            e.Graphics.DrawString("Gender :- " + lblGender.Text + "\t\tHome Address :- " + lblHadd.Text, new Font("centuty Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(30, 220));
            e.Graphics.DrawString("Telephone No :- " + lblTel.Text + "\tLoan Type :- " + lblType.Text, new Font("centuty Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(30, 250));
            e.Graphics.DrawString("Amount (Rs) :- " + lblAmount.Text + "\t\tReceiving Date :- " + lblStart.Text, new Font("centuty Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(30, 280));
            e.Graphics.DrawString("Ending Date :- " + lblEnd.Text + "\t\tMonthly Interest :- " + interest, new Font("centuty Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(30, 310));
            e.Graphics.DrawString("Monthly Payment :- " + total, new Font("centuty Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(30, 340));
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if(txtCode.Text == "")
            {
                MessageBox.Show("Select a customer");
            }
            else
            {
                if(lblType.Text == "Personal Loan")
                {
                    interest = 0.09;
                }else if(lblType.Text == "Home Loan")
                {
                    interest = 0.1;
                }else if(lblType.Text == "Small Business Loan")
                {
                    interest = 0.13;
                }else if(lblType.Text == "Business Loan")
                {
                    interest = 0.12;
                }else
                {
                    interest = 0.08;
                }
                total = interest * Convert.ToInt32(lblAmount.Text);
                PrintDoc.Text = "Customer Code :- " + lblCode.Text + "\n" +"Name :- "+ lblName.Text + "\n" + "Gender :- "+lblGender.Text + "\n" +"Home Address :- "+ lblHadd.Text + "\n" +"Telephone No :- "+ lblTel.Text + "\n" + "Loan Type :- "+lblType.Text + "\n" +"Amount (Rs) :- "+ lblAmount.Text + "\n" +"Receiving Data :- "+ lblStart.Text + "\n" + "Ending Date :- "+lblEnd.Text + "\n" + "Monthly Interest :- "+interest + "\n" +"Monthly Payment (Rs) :- "+ total;
            }
        }
    }
}
