using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    /********************************************************************************
    * This is a basic DatabaseConnection class. This will be used to fill the DataSet
    * object used in the Form1.cs file. I wrote this with the 
    * help of an online tutorial.
    ********************************************************************************/
    class DatabaseConnection
    {
        //Sql Query String
        private string sql_string;

        //Connection String
        private string strCon;

        //Used to fill the DataSet Object in the last function
        System.Data.SqlClient.SqlDataAdapter da_1;

        //Sets the query string
        public string Sql
        {
            set { sql_string = value; }
        }

        //Sets the connection string
        public string connection_string
        {
            set { strCon = value; }
        }

        //Gets the dataset. This will be used to fill the 
        //DataSet object in the Form1.cs file.
        public System.Data.DataSet GetConnection
        {
            get
            { return MyDataSet(); }

        }

        //Opens a connection to a database, fills a DataSet object, closes the connection it opened,
        //and returns the DataSet object it filled.
        private System.Data.DataSet MyDataSet()
        {
            //Define the connection.
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(strCon);

            //Open the connection.
            con.Open();

            //Save data into the SqlDataAdapter
            da_1 = new System.Data.SqlClient.SqlDataAdapter(sql_string, con);

            //Initialize the DataSet Object
            System.Data.DataSet dat_set = new System.Data.DataSet();

            //Fill the DataSet Object
            da_1.Fill(dat_set, "Table_Data_1");

            //Close the connection.
            con.Close();

            //Return the filled DataSet Object
            return dat_set;
        }
    }
}