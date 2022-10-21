using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ExpenseTracker
{
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\source\repos\ExpenseTracker\ExpenseTracker\App_Data\MainData.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
           { 
              con.Close();
           }
           con.Open();
           disp_data();
        }
         

        protected void btninsert_Click(object sender, EventArgs e)
        {
            String user = Session["User"].ToString() ;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into tblExpenses values('"+ DropDownList1.Text+ "','"+ desc .Text+ "','"+paymentdate.Text+"','"+amt.Text+ "','" + user  + "')";
            cmd.ExecuteNonQuery();

            DropDownList1.Text = "";
            desc.Text = "";
            amt.Text = "";

            disp_data();
        }
        public void disp_data()
        {
            String user = Session["User"].ToString();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            String Q = "select * from tblExpenses where username='{0}'";
            Q=String.Format(Q,user);
            cmd.CommandText = Q;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        static int expense_id=0;
        protected void ExpenseGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            expense_id = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            DropDownList1.Text = GridView1.SelectedRow.Cells[2].Text;
            desc.Text = GridView1.SelectedRow.Cells[3].Text;
            paymentdate.Text = GridView1.SelectedRow.Cells[4].Text;
            amt.Text = GridView1.SelectedRow.Cells[5].Text;
            
        }
        protected void btndlt_Click(object sender, EventArgs e)
        {
            String typeofexpense = DropDownList1.Text;
            String desc1 = desc.Text;
            String dateofpay = paymentdate.Text;
            String amt1 = amt.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["userconnection"].ConnectionString;
            string Query = "DELETE FROM tblExpenses Where ID=@Ekey";
            try
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand(Query))
                    {
                        cmd.Parameters.AddWithValue("@Ekey", expense_id);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }

                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            disp_data();
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //string Query = "delete from tblExpenses where ID= @Ekey";
            //cmd.Parameters.AddWithValue("@Ekey", expense_id);
            //cmd.ExecuteNonQuery();
            //disp_data();
            //DropDownList1.Text ="";
            //desc.Text = "";
            //paymentdate.Text = "";
            //amt.Text = "";

        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            String typeofexpense = DropDownList1.Text;
            String desc1 = desc.Text;
            String dateofpay = paymentdate.Text;
            String amt1 = amt.Text;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string Query = "update tblExpenses set Description='{1}',dateofPayment='{2}',amount='{3}' where ExpenseType='{0}' ";
            Query = string.Format(Query, typeofexpense,desc1,dateofpay,amt1);
            cmd.CommandText = Query;
            cmd.ExecuteNonQuery();
            disp_data();
            DropDownList1.Text = "";
            desc.Text = "";
            paymentdate.Text = "";
            amt.Text = "";


        }


        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Session["User"] = "";
            Response.Redirect("Login.aspx");
        }
    }
}