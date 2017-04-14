using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFDb.Model;

namespace WCFDb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DbOperation : IDbOperation
    {
        public DataTable GetTableFromPro()
        {
            DataTable dt = new DataTable();
            string vwlbs = "exec sqlProcedures";

            SqlCommand cmd = new SqlCommand(vwlbs, new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CoreDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(dt);
            //  dt.TableName = "viewLabs";
            //dt.TableName = "Labs";
            dt.TableName = "Practical_Sessions";

            return dt;

        }
        public bool UpdateTable(int id, string userName)
        {
            bool isUpdated=false;
            try
            {
                new System.Threading.Thread(()=> {
                    TestDbEntities testDb = new TestDbEntities();
                    tblUser tblUserRecord = testDb.tblUsers.SingleOrDefault(u => u.Id == id);
                    tblUserRecord.UserName = userName;
                    testDb.SaveChanges();
                }).Start();
                isUpdated = true;
            }
            catch (Exception)
            {
                isUpdated = false;                
            }
            return isUpdated;
        }
        public string GetData(int value)
        {
            
            return string.Format("You entered: {0}", value);
        }
        public DataTable GetTable()
        {
            MakeParentTable();
            DataTable dt = dataSet.Tables[0];
            return dt;
        }
        private System.Data.DataSet dataSet;
        private void MakeParentTable()
        {
            // Create a new DataTable.
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ParentItem";
            // Add the column to the table.
            table.Columns.Add(column);

            // Instantiate the DataSet variable.
            dataSet = new DataSet();
            // Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);

            // Create three new DataRow objects and add 
            // them to the DataTable
            for (int i = 0; i <= 2; i++)
            {
                row = table.NewRow();
                row["id"] = i;
                row["ParentItem"] = "ParentItem " + i;
                table.Rows.Add(row);
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
