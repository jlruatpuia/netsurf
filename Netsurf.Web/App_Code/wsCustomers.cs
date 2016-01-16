using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for wsCustomers
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class wsCustomers : System.Web.Services.WebService
{

    MySqlConnection cm = new MySqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
    public wsCustomers()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    public struct Customer
    {
        public string CustomerNo;
    }

    [WebMethod]
    public DataTable CustomerList(int Pending)
    {
        MySqlCommand cmd = new MySqlCommand("SELECT CustomerID, CustomerNo, CustomerName, Category, CONCAT(Address, ', ', PinNo, ', ', City, ', ', State) AS Address, TelOff, EmailPri, CASE WHEN PlanSelected='BB' Then 'Broadband' WHEN PlanSelected='HS' THEN 'High Speed' WHEN PlanSelected='DD' THEN 'Dedicated' END AS PlanSelected, Speed, FROM customer WHERE Pending=" + Pending, cm);
        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds.Tables[0];
    }
}
