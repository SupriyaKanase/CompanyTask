using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace CompanyRegistration.Models
{
    public class BAL
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0MCE4J6\\SQLEXPRESS01;Initial Catalog=CompanyTask1;Integrated Security=True");

        public void AddRegister(string firstname,string lastname,string dob,string emailid,string pass,string conpass)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("CompanyTask1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddRegister");
            cmd.Parameters.AddWithValue("@FirstName", firstname);
            cmd.Parameters.AddWithValue("@LastName", lastname);
            cmd.Parameters.AddWithValue("@DateOfBirth", dob);
            cmd.Parameters.AddWithValue("@EmailId", emailid);
            cmd.Parameters.AddWithValue("@Password", pass);
            cmd.Parameters.AddWithValue("@ConfirmPassword", conpass);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public SqlDataReader Login(string email,string pass)
        {
           
            con.Open();
            SqlCommand cmd = new SqlCommand("CompanyTask1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Login");
            cmd.Parameters.AddWithValue("@EmailId", email);
            cmd.Parameters.AddWithValue("@Password",pass);
            
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }

        public DataSet ShowData()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("CompanyTask1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ShowData");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

            con.Close();
        }


        public SqlDataReader ShowSingleEmployee(int RegisterId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("CompanyTask1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ShowSingleEmployee");
            cmd.Parameters.AddWithValue("@RegisterId", RegisterId);
            
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
           
            return dr;

            con.Close();
        }

        public void EditEmployee(int RegisterId, string name, string lastname, string dob)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("CompanyTask1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "EditEmployee");
            cmd.Parameters.AddWithValue("@FirstName", name);
            cmd.Parameters.AddWithValue("@LastName", lastname);
            cmd.Parameters.AddWithValue("@DateOfBirth", dob);
            cmd.Parameters.AddWithValue("@RegisterId", RegisterId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteEmployee(int RegisterId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("CompanyTask1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DeleteEmployee");
            cmd.Parameters.AddWithValue("@RegisterId", RegisterId);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }

}