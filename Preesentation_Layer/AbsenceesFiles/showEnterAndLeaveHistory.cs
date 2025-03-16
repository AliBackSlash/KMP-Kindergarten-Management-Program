using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using K_M_S_PROGRAM.GlobalClasses;
using MyBusinessLayer;
using static System.Net.Mime.MediaTypeNames;

namespace K_M_S_PROGRAM.Resources
{
    public partial class ShowEnterAndLeaveHistory : Form
    {
        public ShowEnterAndLeaveHistory()
        {
            InitializeComponent();
        }

        enum enWhoEnter { Employee, worker, child }
        enWhoEnter whoEnter = enWhoEnter.child;

        DataTable data = null;

        private void ShowKidsEnterAndLeaveHistory(char Kind, string Code = "")
        {
            if (rdAM.Checked)
            {
                dgvEnterAndLeaveHistory.Rows.Clear();
                if (ckDateTo.Checked)
                    data = clsAbsences.GetEnterAndLeaveHistoryBetweenTowDates(Kind, DTPDateFrom.Value, DTPDateTo.Value);
                else
                    data = clsAbsences.GetEnterHistory(Kind);
                ShowKidsEnterHistory(Code);
            }
            else
            {
                dgvEnterAndLeaveHistory.Rows.Clear();
                if (ckDateTo.Checked)
                    data = clsAbsences.GetLeaveHistoryBetweenTowDates(Kind, DTPDateFrom.Value, DTPDateTo.Value);
                else
                    data = clsAbsences.GetLeaveHistory(Kind);
                ShowKidsLeaveHistory(Code);
            }
            lbTotalRecords.Text = dgvEnterAndLeaveHistory.Rows.Count.ToString();

        }
        void ShowKidsEnterHistory(string Code)
        {
            System.Drawing.Image image = null;
            string Period = "";
            if (ckDateTo.Checked && txSearsh.Text == "")
            {
                foreach (DataRow row in data.Rows)
                {
                    image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                    Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                    dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                        Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                        row["Time"], row["Class"], Period, row["Late"]);
                }
                return;
            }
            if (Code != "" && ckDateTo.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                            row["Time"], row["Class"], Period, row["Late"]);


                    }


                }
            }
            else if (Code == "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {

                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                            row["Time"], row["Class"], Period, row["Late"]);

                    }


                }
            }
            else if (Code != "" && ckDate.Checked == false)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                            row["Time"], row["Class"], Period, row["Late"]);
                    }
                }
            }
            else if (Code != "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)
                    {

                        if (row["ID"].ToString() == Code)
                        {
                            image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                            Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                            dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                                Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                                row["Time"], row["Class"], Period, row["Late"]);
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow row in data.Rows)
                {
                    image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                    Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                    dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                        Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                        row["Time"], row["Class"], Period, row["Late"]);

                }
            }
            //lbTotalRecords.Text = dgvEnterAndLeaveHistory.Rows.Count.ToString();

        }
        void ShowKidsLeaveHistory(string Code)
        {
            System.Drawing.Image image = null;
            string Period = "";
            if (ckDateTo.Checked && txSearsh.Text == "")
            {
                foreach (DataRow row in data.Rows)
                {
                    image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                    Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                    dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                        Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                        row["Time"], row["Class"], Period);
                }
                return;
            }
            if (Code != "" && ckDateTo.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                            row["Time"], row["Class"], Period);


                    }


                }
            }
            else if (Code == "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {

                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)
                    {

                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                            row["Time"], row["Class"], Period);

                    }


                }
            }
            else if (Code != "" && ckDate.Checked == false)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                            row["Time"], row["Class"], Period);

                    }
                }
            }
            else if (Code != "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)
                    {

                        if (row["ID"].ToString() == Code)
                        {
                            image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                            Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                            dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                                Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                                row["Time"], row["Class"], Period);

                        }
                    }
                }
            }
            else
            {
                foreach (DataRow row in data.Rows)
                {

                    image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                    Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                    dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                        Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                        row["Time"], row["Class"], Period);

                }
            }
            //lbTotalRecords.Text = dgvEnterAndLeaveHistory.Rows.Count.ToString();

        }

        private void ShowEmployeesEnterAndLeaveHistory(char Kind, string Code = "")
        {

            if (rdAM.Checked)
            {
                dgvEnterAndLeaveHistory.Rows.Clear();
                if (ckDateTo.Checked)
                    data = clsAbsences.GetEnterAndLeaveHistoryBetweenTowDates(Kind, DTPDateFrom.Value, DTPDateTo.Value);
                else
                    data = clsAbsences.GetEnterHistory(Kind);
                ShowEmployeesEnterHistory(Code);
            }
            else
            {
                dgvEnterAndLeaveHistory.Rows.Clear();
                if (ckDateTo.Checked)
                    data = clsAbsences.GetLeaveHistoryBetweenTowDates(Kind, DTPDateFrom.Value, DTPDateTo.Value);
                else
                    data = clsAbsences.GetLeaveHistory(Kind);
                ShowEmployeesLeaveHistory(Code);
            }
            lbTotalRecords.Text = dgvEnterAndLeaveHistory.Rows.Count.ToString();


        }
        void ShowEmployeesEnterHistory(string Code)
        {
            System.Drawing.Image image = null;
            string Period = "";
            if (ckDateTo.Checked && txSearsh.Text == "")
            {
                foreach (DataRow row in data.Rows)
                {
                    image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                    Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                    dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                        Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                        row["Time"], row["Class"], Period, row["Late"]);
                }
                return;
            }
            if (Code != "" && ckDateTo.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                            row["Time"], row["Class"], Period, row["Late"]);


                    }


                }
            }
            else if (Code == "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                            row["Time"], row["Class"], Period, row["Late"]);


                    }


                }
            }
            else if (Code != "" && ckDate.Checked == false)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                            row["Time"], row["Class"], Period, row["Late"]);
                    }
                }
            }
            else if (Code != "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)

                    {
                        if (row["ID"].ToString() == Code)
                        {
                            image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                            Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                            dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                                Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                                row["Time"], row["Class"], Period, row["Late"]);
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow row in data.Rows)
                {
                    image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.boy : Properties.Resources.girl;
                    Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                    dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                        Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                        row["Time"], row["Class"], Period, row["Late"]);
                }
            }
        }
        void ShowEmployeesLeaveHistory(string Code)
        {
            System.Drawing.Image image = null;
            string Period = "";
            if (ckDateTo.Checked && txSearsh.Text == "")
            {
                foreach (DataRow row in data.Rows)
                {
                    image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                    Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                    dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                        Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                        row["Time"], row["Class"], Period);
                }
                return;
            }
            if (Code != "" && ckDateTo.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                            row["Time"], row["Class"], Period);


                    }


                }
            }
            else if (ckDateTo.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                    Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                    dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                        Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                        row["Time"], row["Class"], Period);
                }
                return;
            }

            if (Code == "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                            row["Time"], row["Class"], Period);
                    }


                }
            }
            else if (Code != "" && ckDate.Checked == false)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                            row["Time"], row["Class"], Period);

                    }
                }
            }
            else if (Code != "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)

                    {
                        if (row["ID"].ToString() == Code)
                        {
                            image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                            Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                            dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                                Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                                row["Time"], row["Class"], Period);
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow row in data.Rows)
                {
                    image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                    Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                    dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                        Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat),
                        row["Time"], row["Class"], Period);
                }
            }
        }

        private void ShowWorkerEnterAndLeaveHistory(char Kind, string Code = "")
        {

            if (rdAM.Checked)
            {
                dgvEnterAndLeaveHistory.Rows.Clear();
                if (ckDateTo.Checked)
                    data = clsAbsences.GetEnterAndLeaveHistoryBetweenTowDates(Kind, DTPDateFrom.Value, DTPDateTo.Value);
                else
                    data = clsAbsences.GetEnterHistory(Kind);
                ShowWorkersEnterHistory(Code);
            }
            else
            {
                dgvEnterAndLeaveHistory.Rows.Clear();
                if (ckDateTo.Checked)
                    data = clsAbsences.GetLeaveHistoryBetweenTowDates(Kind, DTPDateFrom.Value, DTPDateTo.Value);
                else
                    data = clsAbsences.GetLeaveHistory(Kind);
                ShowWorkersLeaveHistory(Code);

            }

            lbTotalRecords.Text = dgvEnterAndLeaveHistory.Rows.Count.ToString();

        }
        void ShowWorkersEnterHistory(string Code)
        {
            System.Drawing.Image image = null;
            string Period = "";
            if (ckDateTo.Checked && txSearsh.Text == "")
            {
                foreach (DataRow row in data.Rows)
                {
                    image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                    Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                    dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                        Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Time"], "", Period, row["Late"]);

                }
                return;
            }
            if (Code != "" && ckDateTo.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)

                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Time"], "", Period, row["Late"]);
                    }

                }
            }
            else if (Code == "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Time"], "", Period, row["Late"]);
                    }


                }
            }
            else if (Code != "" && ckDate.Checked == false)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Time"], "", Period, row["Late"]);

                    }
                }
            }
            else if (Code != "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if ((DateTime)row["Date"] == DTPDateFrom.Value.Date)
                    {
                        if (row["ID"].ToString() == Code)
                        {
                            image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                            Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                            dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                                Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Time"], "", Period, row["Late"]);

                        }

                    }
                }
            }
            else
            {
                foreach (DataRow row in data.Rows)
                {
                    image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                    Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                    dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                        Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Time"], "", Period, row["Late"]);

                }
            }
        }
        void ShowWorkersLeaveHistory(string Code)
        {
            System.Drawing.Image image = null;
            string Period = "";
            if (ckDateTo.Checked && txSearsh.Text == "")
            {
                foreach (DataRow row in data.Rows)
                {
                    image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                    Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                    dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                        Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Time"], "", Period);

                }
                return;
            }

            if (Code != "" && ckDateTo.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Time"], "", Period);
                    }
                }
            }
            else if (Code == "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["Date"].ToString() == DTPDateFrom.Value.Date.ToString("dd-MM-yyyy"))
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Time"], "", Period);

                    }


                }
            }
            else if (Code != "" && ckDate.Checked == false)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["ID"].ToString() == Code)
                    {
                        image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                        Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                        dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                            Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Time"], "", Period);
                    }
                }
            }
            else if (Code != "" && ckDate.Checked)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["Date"].ToString() == DTPDateFrom.Value.Date.ToString("dd-MM-yyyy"))
                    {
                        if (row["ID"].ToString() == Code)
                        {
                            image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                            Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                            dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                                Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Time"], "", Period);
                        }

                    }
                }
            }
            else
            {
                foreach (DataRow row in data.Rows)
                {
                    image = (Convert.ToBoolean(row["Gendor"])) ? Properties.Resources.man : Properties.Resources.woman;
                    Period = (Convert.ToBoolean(row["Period"])) ? "صباحي" : "مسائي";
                    dgvEnterAndLeaveHistory.Rows.Add(image, row["ID"], row["Name"],
                        Convert.ToDateTime(row["Date"]).ToString(clsUtil.DateFormat), row["Time"], "", Period);
                }
            }
        }
        private void rdPM_CheckedChanged(object sender, EventArgs e)
        {
            dgvEnterAndLeaveHistory.Rows.Clear();

            ShowEnterAndLeaveHistoryData();

        }

        private void rdAM_CheckedChanged(object sender, EventArgs e)
        {
            dgvEnterAndLeaveHistory.Rows.Clear();

            ShowEnterAndLeaveHistoryData();
        }


        private void ClearBackColorForButtons()
        {
            btKids.BackColor = Color.Transparent;
            btTeacher.BackColor = Color.Transparent;
            btWorker.BackColor = Color.Transparent;

        }
        private void btKids_Click(object sender, EventArgs e)
        {
            ClearBackColorForButtons();
            btKids.BackColor = Color.Black;

            txSearsh.Text = "";
            whoEnter = enWhoEnter.child;
            dgvEnterAndLeaveHistory.Rows.Clear();
            ShowEnterAndLeaveHistoryData();

        }

        private void btWorker_Click(object sender, EventArgs e)
        {
            ClearBackColorForButtons();
            btWorker.BackColor = Color.Black;

            txSearsh.Text = "";
            whoEnter = enWhoEnter.worker;
            dgvEnterAndLeaveHistory.Rows.Clear();
            ShowEnterAndLeaveHistoryData();

        }

        private void btTeacher_Click(object sender, EventArgs e)
        {
            ClearBackColorForButtons();
            btTeacher.BackColor = Color.Black;

            txSearsh.Text = "";
            whoEnter = enWhoEnter.Employee;
            dgvEnterAndLeaveHistory.Rows.Clear();
            ShowEnterAndLeaveHistoryData();
        }

        private void ShowDateToControlWithDrivedControls()
        {
            lbTo.Visible = ckDate.Checked;
            lbFrom.Visible = ckDate.Checked;
            DTPDateTo.Visible = ckDate.Checked;
            ckDateTo.Visible = ckDate.Checked;
            if (ckDate.Checked)
            {
                btDelete.Location = new Point(462, 19);
                btKids.Location = new Point(419, 19);
                btWorker.Location = new Point(368, 19);
                btTeacher.Location = new Point(323, 19);
            }
            else
            {
                btDelete.Location = new Point(308, 19);
                btKids.Location = new Point(265, 19);
                btWorker.Location = new Point(214, 19);
                btTeacher.Location = new Point(169, 19);
                ckDateTo.Checked = false;
            }

        }
        private void txSearsh__TextChanged(object sender, EventArgs e)
        {
            ShowEnterAndLeaveHistoryData();
        }
        private void codeeloDateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            ShowEnterAndLeaveHistoryData();
            DTPDateTo.MinDate = DTPDateFrom.Value;
        }

        private void rdDate_CheckedChanged(object sender, EventArgs e)
        {
            ShowEnterAndLeaveHistoryData();
            ShowDateToControlWithDrivedControls();
        }

        private void btDalete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("هل متأكد من أنك تريد مسح جميع السجل ؟", "تنبيه", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == DialogResult.OK)
            {
                if (rdAM.Checked)
                {
                    if (clsAbsences.DeleteEnterHistory())
                    {
                        clsUtil.Show("تم مسح سجل الحضور بنجاح");
                        dgvEnterAndLeaveHistory.Rows.Clear();
                        return;
                    }
                    else
                        clsUtil.Show("يبدو أن البيانات مشغولة حاول لاحقا", false);
                }
                else if (rdPM.Checked)
                {
                    if (clsAbsences.DeleteAllLeaveHistory())
                    {
                        clsUtil.Show("تم مسح سجل الإنصراف بنجاح");
                        dgvEnterAndLeaveHistory.Rows.Clear();
                        return;
                    }
                    else
                        clsUtil.Show("يبدو أن البيانات مشغولة حاول لاحقا", false);
                }

            }
        }

        public void ShowEnterAndLeaveHistoryData()
        {

            switch (whoEnter)
            {
                case enWhoEnter.child:
                    ShowKidsEnterAndLeaveHistory('C', txSearsh.Text);
                    break;

                case enWhoEnter.Employee:
                    ShowEmployeesEnterAndLeaveHistory('T', txSearsh.Text);
                    break;

                case enWhoEnter.worker:
                    ShowWorkerEnterAndLeaveHistory('W', txSearsh.Text);
                    break;
            }

        }

        private void ShowEnterAndLeaveHistory_Load(object sender, EventArgs e)
        {

            DTPDateFrom.MaxDate = DateTime.Now;
            DTPDateTo.MaxDate = DateTime.Now;
            ShowEnterAndLeaveHistoryData();
        }

        private void ckDateTo_CheckedChanged(object sender, EventArgs e)
        {
            ShowEnterAndLeaveHistoryData();

        }

        private void DTPDateTo_ValueChanged(object sender, EventArgs e)
        {
            ShowEnterAndLeaveHistoryData();
        }
    }
}
