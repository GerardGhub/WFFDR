﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;

namespace WFFDR
{
    public class myclasses
    {
        public StoredProcedures g_objStoredProc = new StoredProcedures();
        public IStoredProcedures g_objStoredProcFill;

        public static string confirmPassword;
        public user_infos muser_infos = new user_infos();
        //public company_infos mcompany_infos = new company_infos();

        public DataSet getTable(string eTablename)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            return g_objStoredProcFill.sp_getMinorTables(eTablename, null);
        }
        public void ActivitiesLogs(string logs)
        {

            try
            {
                const string location = @"aActivities";

                if (!File.Exists(location))
                {
                    var createText = "New Activities Logs" + Environment.NewLine;
                    File.WriteAllText(location, createText);
                }
                var appendLogs = "Activities Logs: " + logs + " " + DateTime.Now + Environment.NewLine;
                File.AppendAllText(location, appendLogs);
            }
            catch (Exception ex)
            {
                const string location = @"aActivities";
                if (!File.Exists(location))
                {
                    TextWriter file = File.CreateText(@"C:\aActivities");
                    var createText = "New Activities Logs" + Environment.NewLine;

                    File.WriteAllText(location, createText);

                }
                var appendLogs = ex.Message + logs + DateTime.Now + Environment.NewLine;
                File.AppendAllText(location, appendLogs);

            }

        }
        public void fillListBox(ListBox eListBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null);

            eListBox.DataSource = dSet.Tables[0].DefaultView;

            eListBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
      
            //eListBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eListBox.ValueMember = dSet.Tables[0].Columns[0].ToString();
            g_objStoredProcFill = null;
        }
        public void fillListBox_Id(ListBox eListBox, string eTablename, DataSet dSet, int id, int userRightsId, int menuId)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMenu_by_user(eTablename, id, userRightsId, menuId);

            eListBox.DataSource = dSet.Tables[0];
            eListBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eListBox.ValueMember = dSet.Tables[0].Columns[0].ToString();
            g_objStoredProcFill = null;
        }

        public void fillListBox_Fedora(ListBox eListBox, string eTablename, DataSet dSet, int id, int userRightsId, int menuId)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMenu_by_user(eTablename, id, userRightsId, menuId);

            eListBox.DataSource = dSet.Tables[0];
            eListBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eListBox.DisplayMember = dSet.Tables[0].Columns[2].ToString();
          //  eListBox.DisplayMember = dSet.Tables[0].Columns[3].ToString();
            eListBox.ValueMember = dSet.Tables[0].Columns[0].ToString();
            g_objStoredProcFill = null;
        }



        public void fillComboBox(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();


            //if (eTablename == "workers")
            //    dSet.Clear();
            //dSet = g_objStoredProcFill.sp_getMinorTables("workers_selection", workId);
            //eComboBox.SelectedValue = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());

            //foreach (char item in eComboBox.ValueMember)
            //{
            //    if(item == '')      
            //}


            g_objStoredProcFill = null;
        }


        public void fillComboBoxRepacking(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[1].ToString();


            //if (eTablename == "workers")
            //    dSet.Clear();
            //dSet = g_objStoredProcFill.sp_getMinorTables("workers_selection", workId);
            //eComboBox.SelectedValue = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());

            //foreach (char item in eComboBox.ValueMember)
            //{
            //    if(item == '')      
            //}


            g_objStoredProcFill = null;
        }


        public void fillComboBoxFGReceipt(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[1].ToString();


            g_objStoredProcFill = null;
        }
        public void fillComboBoxWH(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[1].ToString();


            //if (eTablename == "workers")
            //    dSet.Clear();
            //dSet = g_objStoredProcFill.sp_getMinorTables("workers_selection", workId);
            //eComboBox.SelectedValue = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());

            //foreach (char item in eComboBox.ValueMember)
            //{
            //    if(item == '')      
            //}


            g_objStoredProcFill = null;
        }



        public void fillComboBoxFormula(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();


            //if (eTablename == "workers")
            //    dSet.Clear();
            //dSet = g_objStoredProcFill.sp_getMinorTables("workers_selection", workId);
            //eComboBox.SelectedValue = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());

            //foreach (char item in eComboBox.ValueMember)
            //{
            //    if(item == '')      
            //}


            g_objStoredProcFill = null;
        }



        public void fillComboBoxFormulaDescription(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[1].ToString();


            //if (eTablename == "workers")
            //    dSet.Clear();
            //dSet = g_objStoredProcFill.sp_getMinorTables("workers_selection", workId);
            //eComboBox.SelectedValue = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());

            //foreach (char item in eComboBox.ValueMember)
            //{
            //    if(item == '')      
            //}


            g_objStoredProcFill = null;
        }


        public void fillComboBox1(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[2].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[1].ToString();
            g_objStoredProcFill = null;
        }

        public void fillGridComboBox(DataGridViewComboBoxColumn eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();
            g_objStoredProcFill = null;
        }

        public void fillDataGridView(DataGridView eDataGrid, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null);
            eDataGrid.DataSource = dSet.Tables[0];
        }



        public void fillComboboxID(DataGridView eDataGrid, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMajorTables(eTablename);
            eDataGrid.DataSource = dSet.Tables[0];
        }


        public void datagridSort(DataTable dt, int ci, string so)
        {
            if ((ci > 0) && (so != ""))
            {
                DataView dv = dt.DefaultView;
                if (so == "Ascending")
                {
                    dv.Sort = dt.Columns[ci].ColumnName + " ASC";
                }
                else if (so == "Descending")
                {
                    dv.Sort = dt.Columns[ci].ColumnName + " DESC";
                }
            }
        }

        public bool CheckEmailAddress(string eadd)
        {
            string patternLenient = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex reLenient = new Regex(patternLenient);

            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
            + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
            + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
            + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
            + @"[a-zA-Z]{2,}))$";

            Regex reStrict = new Regex(patternStrict);

            bool isLenientMatch = reLenient.IsMatch(eadd);
            return isLenientMatch;
        }
        //UPDate ko muna etoj
        public void fillComboBoxFilter(ComboBox eComboBox, string eTablename, DataSet dSet, string eDescription, int Pk)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getFilterTables(eTablename, eDescription, Pk);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();
            g_objStoredProcFill = null;
        }

        public void fillComboBoxFilterFormulaqty(ComboBox eComboBox, string eTablename, DataSet dSet, string eDescription, int Pk)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getFilterTables(eTablename, eDescription, Pk);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[2].ToString();
            g_objStoredProcFill = null;
        }

        public void is_valid_phone_no(TextBox txtbox)
        {
            string str_phone_no = txtbox.Text;
            Regex matchRegex = new Regex(@"\d{3}-\d{3}-\d{4}$");
            MatchCollection matches = matchRegex.Matches(str_phone_no);
            if (matches.Count == 0)
            {
                MessageBox.Show("Wrong phone number format.");
                txtbox.Focus();
                return;
            }
        }
        public void is_valid_zip_code(TextBox txtbox)
        {
            string str_zip_code = txtbox.Text;
            Regex matchRegex = new Regex(@"\d{5}-\d{4}$");
            MatchCollection matches = matchRegex.Matches(str_zip_code);
            if (matches.Count == 0)
            {
                MessageBox.Show("Wrong Zip/Postal Code format.");
                txtbox.Focus();
                return;
            }
        }
        public void is_valid_url(TextBox txtbox)
        {
            string str_url = txtbox.Text;
            Regex matchRegex = new Regex(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?");
            MatchCollection matches = matchRegex.Matches(str_url);
            if (matches.Count == 0)
            {
                MessageBox.Show("Wrong URL format.");
                txtbox.Focus();
                return;
            }
        }
        public bool IsDataValidated(string strTextEntry)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strTextEntry)
                 && (strTextEntry != "");
        }
        public bool isNumberFormat(string val)
        {
            try
            {
                double xxx = Convert.ToDouble(val);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean isNumeric(string val)
        {
            try
            {
                double xval = Convert.ToDouble(val);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void clearTxt(Form myform)
        {
            foreach (Control txt in myform.Controls)
            {
                if (txt.GetType() == typeof(TextBox) || txt.GetType() == typeof(ComboBox) || txt.GetType() == typeof(MaskedTextBox))
                    txt.Text = "";
            }
        }
        public void clearTxt2(GroupBox myform)
        {
            foreach (Control txt in myform.Controls)
            {
                if (txt.GetType() == typeof(TextBox) || txt.GetType() == typeof(ComboBox) || txt.GetType() == typeof(MaskedTextBox))
                    txt.Text = "";
            }
        }
        public void enabledTxt(Form myform, int var)
        {
            foreach (Control txt in myform.Controls)
            {
                if (txt.GetType() == typeof(TextBox) || txt.GetType() == typeof(ComboBox) || txt.GetType() == typeof(MaskedTextBox))
                    if (Convert.ToBoolean(var == 1))
                        txt.Enabled = true;
                    else
                        txt.Enabled = false;
            }
        }
        public void disabledTxt(TextBox textbox)
        {
            textbox.ReadOnly = true;
        }





    }



}
public class ComputeEndDate
{


    public DateTime compute(DateTime startPayment, bool pattern1, bool pattern2, decimal numPayment1)
    {
        DateTime endPayment = DateTime.Today;


        if (pattern1 == true)
        {
            startPayment = startPayment.AddMonths(-1);
            endPayment = startPayment.AddMonths(Convert.ToInt32(numPayment1));

        }
        else if (pattern2 == true)
        {
            decimal paymentclass = numPayment1;

            DateTime date = new DateTime();
            date = startPayment;

            for (int i = 2; i <= paymentclass; i++)
            {


                date = date.AddDays(15);
                if ((int)date.Day >= 15 && (int)date.Day <= 30 + 1)
                {
                    var offset = 20 - (int)date.Day;
                    var datefinal = date + TimeSpan.FromDays(offset);
                    date = datefinal;


                }
                else if ((int)date.Day >= 1 && (int)date.Day <= 15)
                {
                    var offset = 5 - (int)date.Day;
                    var datefinal = date + TimeSpan.FromDays(offset);
                    date = datefinal;
                }


            }
            endPayment = date;
        }


        return endPayment;




    }
}
