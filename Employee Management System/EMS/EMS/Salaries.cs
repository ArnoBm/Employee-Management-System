﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS
{
    public partial class Salaries : Form
    {
        Functions Con;
        public Salaries()
        {
            InitializeComponent();
            Con = new Functions();
            ShowSalaries();
            GetEmployees();
        }

        private void GetEmployees()
        {
            string Query = "Select * from EmployeeTbl";
            EmpCb.DisplayMember = Con.GetData(Query).Columns["EmpName"].ToString();
            EmpCb.ValueMember = Con.GetData(Query).Columns["Empid"].ToString();
            EmpCb.DataSource = Con.GetData(Query);
        }

        int DSal = 0;
        string Period = "";

        private void GetSalary()
        {
            string Query = "Select * from EmployeeTbl where Empid = {0}";
            Query = string.Format(Query, EmpCb.SelectedValue.ToString());
            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                DSal = Convert.ToInt32(dr["EmpSal"].ToString());
            }
            //MessageBox.Show(DSal + "");
            if(DaysTb.Text == "")
            {
                AmountTb.Text = "BDT " + (d * DSal);
            }
            else if(Convert.ToInt32(DaysTb.Text) > 31)
            {
                MessageBox.Show("Days Can Not Be Greater Then 31");
            }
            else
            {
                d = Convert.ToInt32(DaysTb.Text);
                AmountTb.Text = "BDT " + (d * DSal);
            }
        }

        private void ShowSalaries()
        {
            try
            {
                string Query = "Select * from SalaryTbl";
                SalaryList.DataSource = Con.GetData(Query);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SalaryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EmpCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetSalary();
        }

        int d = 1;

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(EmpCb.SelectedIndex == -1 || DaysTb.Text == "" || PeriodTb.Text == "" )
                {
                    MessageBox.Show("Missing Data. Please insert all data.");
                }
                else
                {
                    Period = PeriodTb.Value.Date.Month.ToString() + "-" + PeriodTb.Value.Date.Year.ToString(); ;
                    int Amount = DSal * Convert.ToInt32(DaysTb.Text);
                    int Days = Convert.ToInt32(DaysTb.Text);
                    string Query = "insert into SalaryTbl (Employee, Attendance, Period, Amount, PayDate) values ({0}, {1}, '{2}', {3}, '{4}')";
                    Query = string.Format(Query, EmpCb.SelectedValue.ToString(), Days, Period, Amount, DateTime.Today.Date);
                    Con.SetData(Query);
                    ShowSalaries();
                    MessageBox.Show("Salary Paid Successfully");
                    DaysTb.Text = "";
                }
            }
            catch (Exception Ex) 
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void DeptLbl_Click(object sender, EventArgs e)
        {
            Departments Obj = new Departments();
            Obj.Show();
            this.Hide();
        }

        private void EmpLbl_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
