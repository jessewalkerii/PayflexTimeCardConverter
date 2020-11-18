using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayflexTimeCardConverter
{
    public partial class frm_Main : Form
    {
        private SqlConnection sqlconnection;
        private string SourceFile;
        
        
        public frm_Main()
        {
            InitializeComponent();

            var appsettings = ConfigurationManager.AppSettings;

            sqlconnection = new SqlConnection(appsettings.Get("ConnectionString"));
            try
            {
                sqlconnection.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message,"Unable to connect to Database");
                //this.Close();
            }

            txt_Source.Text = appsettings.Get("SourcePath");
            txt_Output.Text = appsettings.Get("OutputPath");
        }

        private void cmd_Source_Click(object sender, EventArgs e)
        {
            ofd_SourceFile.InitialDirectory = txt_Source.Text;
            ofd_SourceFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            var dialogRespnse = ofd_SourceFile.ShowDialog();
            if (dialogRespnse == DialogResult.OK)
            {
                SourceFile = ofd_SourceFile.FileName;
                var SourcePath = Path.GetDirectoryName(SourceFile);
                txt_Source.Text = SourcePath;
                txt_SourceFile.Text = Path.GetFileName(SourceFile);
                var appSettings = ConfigurationManager.AppSettings;

                AddUpdateAppSettings("SourcePath", SourcePath);
                
                cmd_Convert.Enabled = true;
            }
        }

        private void cmd_Output_Click(object sender, EventArgs e)
        {
            fbd_picker.SelectedPath = txt_Output.Text;
            var dialogRespnse = fbd_picker.ShowDialog();
            if (dialogRespnse == DialogResult.OK)
            {
                var OutputPath = fbd_picker.SelectedPath;

                txt_Output.Text = OutputPath;
                AddUpdateAppSettings("OutputPath", OutputPath);
            }
        }

        private void cmd_Convert_Click(object sender, EventArgs e)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;

            DataTable dt = new DataTable("Stage_Timecard");
            dt.Columns.Add("EmployeeID", typeof(Int32));
            dt.Columns.Add("EntryDate", typeof(DateTime));
            dt.Columns.Add("EntryCode", typeof(String));
            dt.Columns.Add("ClockHours", typeof(decimal));
            dt.Columns.Add("LocationCode", typeof(String));
            dt.Columns.Add("OtherCode", typeof(String));

            lbl_Status.Text = "Importing TimeCard File";
            
            string[] lines = File.ReadAllLines(SourceFile);

            pb_Status.Maximum = lines.Length - 500;
            pb_Status.Step = 1;
            
            foreach (string line in lines)
            {
                pb_Status.PerformStep();

                DataRow dr = dt.NewRow();
                dr["EmployeeID"] = Int32.Parse(line.Substring(0,6).Trim());
                dr["EntryDate"] = DateTime.ParseExact(line.Substring(6, 8).Trim(),"yyyyMMdd",provider);
                dr["EntryCode"] = line.Substring(14, 4).Trim();
                dr["ClockHours"] = Decimal.Parse(line.Substring(18, 6).Trim());
                dr["LocationCode"] = line.Substring(24, 12).Trim();
                dr["OtherCode"] = line.Substring(36, 10).Trim();

                dt.Rows.Add(dr);

                //if(pb_Status.Value%2==0) 
                Thread.Sleep(1); 
             
            }
            pb_Status.Value = pb_Status.Maximum;
            Thread.Sleep(1);

            string Query = @"IF OBJECT_ID('Stage_Timecard', 'u') IS NOT NULL DROP TABLE [Stage_Timecard]";
            SqlCommand command = new SqlCommand(Query, sqlconnection);
            command.ExecuteNonQuery();
            Query = @"Create Table [Stage_Timecard](EmployeeID varchar(10), EntryDate datetime, EntryCode nvarchar(5),ClockHours decimal(6,2),LocationCode varchar(20),OtherCode varchar(20))";
            command = new SqlCommand(Query, sqlconnection);
            command.ExecuteNonQuery();

            lbl_Status.Text = "Write File to Database";
            
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlconnection))
            {
                sqlBulkCopy.DestinationTableName = dt.TableName;

                foreach (var column in dt.Columns)
                    sqlBulkCopy.ColumnMappings.Add(column.ToString(), column.ToString());

                sqlBulkCopy.WriteToServer(dt);
            }

            lbl_Status.Text = "Export Converted TimeCard Data";
            
            Query = "SELECT [CompanyID], [HeaderID], [OUTPUTDATA] FROM vw_TimecardMap"; //"ORDER BY [CompanyID], [EmployeeID], [TimeCard], [HEDNumber]";
            command = new SqlCommand(Query, sqlconnection);
            SqlDataReader reader = command.ExecuteReader();
            
            DataTable outputTable = new DataTable();
            outputTable.Load(reader);
            string CurrentCompany = "";
            StreamWriter sw = File.AppendText(txt_Output.Text + "\\TEST.DAT");
            string CurrentDate = DateTime.Now.ToString("yyMMdd");
            bool newFile = true;

            pb_Status.Maximum = outputTable.Rows.Count;
            pb_Status.Value = 1;

            foreach (DataRow record in outputTable.Rows)
            {
                var Company = record[0].ToString();
                if (CurrentCompany != Company)
                {
                    sw.Flush();
                    sw.Close();

                    String FileName = txt_Output.Text + "\\" + Company + "_TA_XTRNL.DAT";
                    newFile = !File.Exists(FileName); 
                    sw = File.AppendText(FileName);
                    if (newFile) sw.WriteLine("P" + CurrentDate + record[1].ToString());
               
                }
                sw.WriteLine(record[2].ToString());
                pb_Status.PerformStep();
                Thread.Sleep(1);

                CurrentCompany = Company;
            }
            
            sw.Flush();
            sw.Close();

            File.Delete(txt_Output.Text + "\\TEST.DAT");
            lbl_Status.Text = "Export Complete";
        }

        private void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

    }
}
