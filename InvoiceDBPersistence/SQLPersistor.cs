using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using InvoiceDBPersistence.Models;


namespace InvoiceDBPersistence
{
    public class SQLPersistor
    {
        private readonly string connString = string.Empty;

        public SQLPersistor(string connectionString)
        {
            connString = connectionString;
        }

        public int DbSet { get; private set; }

        /// <summary>
        /// Add new sale record
        /// </summary>
        /// <param name="sale"></param>
        public void AddSales(DBSale sale)
        {
            try
            {
                string sp_name = "[dbo].[sp_InsertSales]";

                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sp_name, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@SalesItem", SqlDbType.VarChar).Value = sale.SalesItem;
                        cmd.Parameters.Add("@DateSold", SqlDbType.DateTime).Value = sale.DateSold;
                        cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = sale.Quantity;
                        cmd.Parameters.Add("@Price", SqlDbType.Money).Value = sale.Price;
                        cmd.Parameters.Add("@ShipToLoc", SqlDbType.VarChar).Value = sale.ShipToLoc;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message.ToString();
                throw;
            }
        }

        /// <summary>
        /// Fetch the invoice detail rows for corrosponding invoice number
        /// </summary>
        /// <returns></returns>
        public DataTable GetInvoiceList()
        {
            List<DBInvoice> invoices = new List<DBInvoice>();
            DataTable dt = new DataTable();

            try
            {
                string sp_name = "[dbo].[sp_getInvoiceList]";
                

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sp_name,conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataReader dr = cmd.ExecuteReader();
                       
                        dt.Load(dr);

                        /*
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        Console.WriteLine("No of rows retrieved {0}", ds.Tables[0].Rows.Count);
                        */
                        //foreach (DataRow row in dt.Rows)
                        //{
                        //        invoices.Add( new DBInvoice { InvoiceNumber = row["InvoiceNumber"].ToString()
                        //                                    , CustomerId = Convert.ToInt32(row["CustomerID"])
                        //                                    , Country = row["Country"].ToString()
                        //                                    , State = row["State"].ToString()
                        //                                    , AdvancePaymentTax = Convert.ToDouble(row["AdvancePaymentTax"])
                        //                                    , DueDate = Convert.ToDateTime(row["DueDate"])
                        //        });
                        // }
                     }
                }
            }
            catch (Exception e)
            {
                string error = e.Message.ToString();
            }

            return dt;
        }

        public DataTable getInvoiceDetails(int invoiceid)
        {
            string sqlQuery = string.Empty;

            DataTable dt = new DataTable();

            sqlQuery = "SELECT [InvoiceID],[Description],[Quantity],[Price],[VAT],[Memo] FROM [dbo].[InvoiceDetails] WHERE [InvoiceID] = @InvoiceId";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@InvoiceId", invoiceid);

                try
                {
                    SqlDataReader rd = cmd.ExecuteReader();
                    dt.Load(rd);
                }
                catch
                {
                }
             }

            return dt;
        }

        public void InsertInvoice(DBInvoice invoice)
        {
            try
            {
                string sp_name = "[dbo].[sp_InsertInvoice]";

                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sp_name, cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = invoice.InvoiceNumber;
                        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = invoice.CustomerId;
                        cmd.Parameters.Add("@Country", SqlDbType.VarChar).Value = invoice.Country;
                        cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = invoice.State;
                        cmd.Parameters.Add("@AdvancePaymentTax", SqlDbType.Decimal).Value = invoice.AdvancePaymentTax;
                        cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = invoice.DueDate;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message.ToString();
                throw;
            }
        }

        /// <summary>
        /// Get the list of countries
        /// </summary>
        /// <returns></returns>
        public List<Country> GetCountry()
        {
            string sqlQuery = string.Empty;
            List<Country> countryList = new List<Country>();

            sqlQuery = "SELECT  [CountryCode], [CountryName], [Region], [SubRegion] FROM[InvoiceMaster].[dbo].[Country] ORDER BY [SortOrder], [CountryName]";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery,conn);
                try
                {
                    SqlDataReader rd = cmd.ExecuteReader(); 

                    DataTable dt = new DataTable();
                    dt.Load(rd);

                    countryList = (from DataRow dr in dt.Rows
                                   select new Country()
                                   {
                                       CountryCode = dr["CountryCode"].ToString(),
                                       CountryName = dr["CountryName"].ToString()
                                   }
                                   ).ToList();
                }
                catch(Exception e)
                {
                    string error = e.Message.ToString();
                }
            }

            return countryList;
        }

        /// <summary>
        /// Return the list of states for the country
        /// </summary>
        /// <param name="CountryCode"></param>
        /// <returns></returns>
        public List<State> GetState(string CountryCode)
        {
            string sqlQuery = string.Empty;

            List<State> stateList = new List<State>();

            sqlQuery = "SELECT [StateName], [StateCode] FROM [dbo].[State] WHERE [CountryCode] = @CountryCode ORDER BY [STATECODE] ASC";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@CountryCode", CountryCode);

                try
                {
                    SqlDataReader rd = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(rd);

                    stateList = (from DataRow dr in dt.Rows
                                   select new State()
                                   {
                                       StateCode = dr["StateCode"].ToString(),
                                       StateName = dr["StateName"].ToString()
                                   }
                                   ).ToList();
                }
                catch (Exception e)
                {
                    string error = e.Message.ToString();
                }
            }

            return stateList;
        }

        /// <summary>
        /// Add feedback from About us page
        /// </summary>
        /// <param name="fb"></param>
        /// <returns></returns>
        public void AddFeedback(Feedback fb)
        {
            string errorMessage = string.Empty;
            string sp_name = "[dbo].[sp_insertCustomerFeedback]";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sp_name, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", fb.Name);
                    cmd.Parameters.AddWithValue("@Email", fb.Email);
                    cmd.Parameters.AddWithValue("@Phone", fb.Phone);
                    cmd.Parameters.AddWithValue("@Feedback", fb.FeedbackComments);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                errorMessage = e.Message.ToString();
            }
        }
    }
}
