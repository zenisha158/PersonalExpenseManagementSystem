using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.Data.OleDb;

namespace ExpenseTracker
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button_Login_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["userConnection"].ConnectionString);
            conn.Open();

            string checkUser = "Select count(*) from [User] where UserName= '" + TextBoxUsername.Text + "'";
            SqlCommand cmd = new SqlCommand(checkUser, conn);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            //Response.Write(temp);
            conn.Close();

            if (temp == 1)
            {
                conn.Open();
                string checkPassowrdQuery = "select Password from [User] where UserName='" + TextBoxUsername.Text + "'";
                SqlCommand comPass = new SqlCommand(checkPassowrdQuery, conn);
                string password = comPass.ExecuteScalar().ToString().Replace(" ", "");

                string checkUnameQuery = "select UserName from [User] where UserName = '" + TextBoxUsername.Text + "'";
                SqlCommand comUname = new SqlCommand(checkUnameQuery, conn);
                string uname = comUname.ExecuteScalar().ToString();

                if (password == TextBoxPassword.Text)
                {
                    Session["User"] = TextBoxUsername.Text;

                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    Response.Write("Password is incorrect");
                }


                conn.Close();
            }
        }
    }
}