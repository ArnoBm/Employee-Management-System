using System;
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
    public partial class Departments : Form
    {
        Functions Con;
        public Departments()
        {
            InitializeComponent();
            Con = new Functions();
            ShowDepartments();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowDepartments()
        {
            string Query = "Select * from DepartmentTbl";
            DeptList.DataSource = Con.GetData(Query);
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(DeptNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data. Please insert all data.");
                }
                else
                {
                    string Dept = DeptNameTb.Text;
                    string Query = "insert into DepartmentTbl values('{0}')";
                    Query = string.Format(Query, DeptNameTb.Text);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Added Successfully");
                    DeptNameTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int Key = 0;
        private void DeptList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DeptNameTb.Text = DeptList.SelectedRows[0].Cells[1].Value.ToString();
            if(DeptNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DeptList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeptNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data. Please insert all data.");
                }
                else
                {
                    string Dept = DeptNameTb.Text;
                    string Query = "Update DepartmentTbl set DeptName = '{0}' where deptid = '{1}'";
                    Query = string.Format(Query, DeptNameTb.Text, Key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Updated Successfully");
                    DeptNameTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeptNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data. Please insert all data.");
                }
                else
                {
                    string Dept = DeptNameTb.Text;
                    string Query = "Delete from DepartmentTbl where deptid = '{0}'";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Successfully Deleted");
                    DeptNameTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void SalaryLbl_Click(object sender, EventArgs e)
        {
            Salaries Obj = new Salaries();
            Obj.Show();
            this.Hide();
        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
