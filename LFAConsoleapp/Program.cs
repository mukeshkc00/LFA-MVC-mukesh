using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using LFA.sharedclass;


  
namespace LFAConsoleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString=@"User ID=sa;Password=P@ssw0rd;Initial Catalog=LFA-Forum1;Data Source=.\SQLEXPRESS";
            SqlConnection conn = new SqlConnection(connString);
            //string sqlQuery = "select * from UserStatus"; 
            string sqlQuery = "getuserstatus";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.CommandType = CommandType.StoredProcedure;//text
             cmd.Connection = conn;

            conn.Open();
            //UserStatus userstatus = new UserStatus();
            List<UserStatus> lstuserstatus = new List<UserStatus>(); //for holding and listing more than one item
             SqlDataReader dr = cmd.ExecuteReader();
          
            while(dr.Read())
            {
                UserStatus objUserStatus = new UserStatus();
                objUserStatus.ID = Convert.ToInt32(dr[0]);
                objUserStatus.Name = dr[1].ToString();
                 lstuserstatus.Add(objUserStatus);
                //userstatus.ID = Convert.ToInt32(dr[0]);
                //userstatus.Name = dr[1].ToString();

             // Console.WriteLine(dr[0] + "" + dr["Name"]);  // for displaying single item

            }
          //  Console.WriteLine(userstatus.ID + " " + userstatus.Name);
            foreach (UserStatus item in lstuserstatus)//instead of UserStatus we can also use//var
            {

                Console.WriteLine(item.ID + " " + item.Name);
            }
            Console.ReadLine();
            
            Console.WriteLine(conn.State);
            conn.Close();
            Console.WriteLine(conn.State);
            Console.ReadLine();
        }
    }
}
