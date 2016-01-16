using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Netsurf.Codes
{
    public class Customers
    {
        MySqlConnection cm = new MySqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);

        private string _customerNo;
        private string _customerName;
        private string _category;
        private string _address;
        private string _pinNo;
        private string _city;
        private string _state;
        private string _phoneNo;
        private string _email;
        private string _planSelected;
        private string _speed;
        private byte[] _photo;
        private string _material;

        public string CustomerNo
        {
            get { return _customerNo; }
            set { _customerNo = value; }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string PinNo
        {
            get { return _pinNo; }
            set { _pinNo = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string PhoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string PlanSelected
        {
            get { return _planSelected; }
            set { _planSelected = value; }
        }

        public string Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public DataTable CustomerList(int Pending)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT CustomerID, CustomerNo, CustomerName, Category, CONCAT(Address, ', ', PinNo, ', ', City, ', ', State) AS Address, TelOff, EmailPri, CASE WHEN PlanSelected='BB' Then 'Broadband' WHEN PlanSelected='HS' THEN 'High Speed' WHEN PlanSelected='DD' THEN 'Dedicated' END AS PlanSelected, Speed, FROM customer WHERE Pending=" + Pending, cm);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public bool AddCustomer(string CustomerNo, string CustomerName, string Category, string Address, string PinNo, string City, string State, string PhoneNo, string Email, string PlanSelected, string Speed, byte[] Photo, string Material)
        {
            bool r = false;
            MySqlCommand cmd = new MySqlCommand("INSERT INTO customer (CustomerNo, CustomerName, Category, Address, PinNo, City, State, TelOff, EmailPri, PlanSelected, Speed, Photo, Pending, Material) VALUES (@CNO, @CNM, @CAT, @ADD, @PIN, @CTY, @STT, @PHO, @EMP, @PLN, @SPD, @IMG, @PDG, @MTR)", cm);
            cmd.Parameters.AddWithValue("@CNO", CustomerNo);
            cmd.Parameters.AddWithValue("@CNM", CustomerName);
            cmd.Parameters.AddWithValue("@CAT", Category);
            cmd.Parameters.AddWithValue("@ADD", Address);
            cmd.Parameters.AddWithValue("@PIN", PinNo);
            cmd.Parameters.AddWithValue("@CTY", City);
            cmd.Parameters.AddWithValue("@STT", State);
            cmd.Parameters.AddWithValue("@PHO", PhoneNo);
            cmd.Parameters.AddWithValue("@EMP", Email);
            cmd.Parameters.AddWithValue("@PLN", PlanSelected);
            cmd.Parameters.AddWithValue("@SPD", Speed);
            cmd.Parameters.AddWithValue("@IMG", Photo);
            cmd.Parameters.AddWithValue("@PDG", 0);
            cmd.Parameters.AddWithValue("@MTR", Material);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
                r = true;
            }
            catch { r = false; }
            finally { cm.Close(); }
            return r;
        }

        public bool UpdateCustomer(string CustomerNo, string CustomerName, string Category, string Address, string PinNo, string City, string State, string PhoneNo, string Email, string PlanSelected, string Speed, byte[] Photo, string Material, int CustomerID)
        {
            bool r = false;
            MySqlCommand cmd = new MySqlCommand("UPDATE customer SET CustomerNo=@CNO, CustomerName=@CNM, Category=@CAT, Address=@ADD, PinNo=@PIN, City=@CTY, State=@STT, TelOff=@PHO, EmailPri=@EMP, PlanSelected=@PLN, Speed=@SPD, Photo=@IMG WHERE CustomerID=" + CustomerID, cm);
            cmd.Parameters.AddWithValue("@CNO", CustomerNo);
            cmd.Parameters.AddWithValue("@CNM", CustomerName);
            cmd.Parameters.AddWithValue("@CAT", Category);
            cmd.Parameters.AddWithValue("@ADD", Address);
            cmd.Parameters.AddWithValue("@PIN", PinNo);
            cmd.Parameters.AddWithValue("@CTY", City);
            cmd.Parameters.AddWithValue("@STT", State);
            cmd.Parameters.AddWithValue("@PHO", PhoneNo);
            cmd.Parameters.AddWithValue("@EMP", Email);
            cmd.Parameters.AddWithValue("@PLN", PlanSelected);
            cmd.Parameters.AddWithValue("@SPD", Speed);
            cmd.Parameters.AddWithValue("@IMG", Photo);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
                r = true;
            }
            catch { r = false; }
            finally { cm.Close(); }
            return r;
        }

        public bool UpdateCustomer(string CustomerNo, string CustomerName, string Category, string Address, string PinNo, string City, string State, string PhoneNo, string Email, string PlanSelected, string Speed, string Material, int CustomerID)
        {
            bool r = false;
            MySqlCommand cmd = new MySqlCommand("UPDATE customer SET CustomerNo=@CNO, CustomerName=@CNM, Category=@CAT, Address=@ADD, PinNo=@PIN, City=@CTY, State=@STT, TelOff=@PHO, EmailPri=@EMP, PlanSelected=@PLN, Speed=@SPD WHERE CustomerID=" + CustomerID, cm);
            cmd.Parameters.AddWithValue("@CNO", CustomerNo);
            cmd.Parameters.AddWithValue("@CNM", CustomerName);
            cmd.Parameters.AddWithValue("@CAT", Category);
            cmd.Parameters.AddWithValue("@ADD", Address);
            cmd.Parameters.AddWithValue("@PIN", PinNo);
            cmd.Parameters.AddWithValue("@CTY", City);
            cmd.Parameters.AddWithValue("@STT", State);
            cmd.Parameters.AddWithValue("@PHO", PhoneNo);
            cmd.Parameters.AddWithValue("@EMP", Email);
            cmd.Parameters.AddWithValue("@PLN", PlanSelected);
            cmd.Parameters.AddWithValue("@SPD", Speed);
            try
            {
                cm.Open();
                cmd.ExecuteNonQuery();
                r = true;
            }
            catch { r = false; }
            finally { cm.Close(); }
            return r;
        }

        public bool DeleteCustomer(string CustomerNo)
        {
            bool b = true;
            MySqlCommand cmd;
            cm.Open();

            try
            {
                cmd = new MySqlCommand("DELETE FROM customer WHERE CustomerNo='" + CustomerNo + "'", cm);
                cmd.ExecuteNonQuery();
            }
            catch { b = false; }
            try
            {
                cmd = new MySqlCommand("DELETE FROM bill WHERE CustomerNo='" + CustomerNo + "'", cm);
                cmd.ExecuteNonQuery();
            }
            catch {; }
            try
            {
                cmd = new MySqlCommand("DELETE FROM complaint WHERE CustomerNo='" + CustomerNo + "'", cm);
                cmd.ExecuteNonQuery();
            }
            catch {; }
            try
            {
                cmd = new MySqlCommand("DELETE FROM installation WHERE CustomerNo='" + CustomerNo + "'", cm);
                cmd.ExecuteNonQuery();
            }
            catch {; }
            try
            {
                cmd = new MySqlCommand("DELETE FROM otp WHERE CustomerNo='" + CustomerNo + "'", cm);
                cmd.ExecuteNonQuery();
            }
            catch {; }
            try
            {
                cmd = new MySqlCommand("DELETE FROM sales WHERE CustomerNo='" + CustomerNo + "'", cm);
                cmd.ExecuteNonQuery();
            }
            catch {; }
            try
            {
                cmd = new MySqlCommand("DELETE FROM trans WHERE CustomerNo='" + CustomerNo + "'", cm);
                cmd.ExecuteNonQuery();
            }
            catch {; }
            try
            {
                cmd = new MySqlCommand("DELETE FROM uploaded WHERE CustomerNo='" + CustomerNo + "'", cm);
                cmd.ExecuteNonQuery();
            }
            catch {; }
            cm.Close();
            return b;
        }
        
    }
}