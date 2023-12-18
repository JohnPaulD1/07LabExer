using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07LabExer
{
    public partial class FrmClubRegistration : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentId;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmUpdateMember frmUpdateMember = new FrmUpdateMember();
            frmUpdateMember.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Age = int.Parse(txtAge.Text);           
            FirstName = txtFirstName.Text;
            MiddleName = txtMiddleName.Text;
            LastName = txtLastName.Text;           
            Gender = cbGender.SelectedItem.ToString();
            Program = cbProgram.SelectedItem.ToString();
            StudentId = long.Parse(txtStudentID.Text);
            ID = RegistrationID();

            clubRegistrationQuery.RegisterStudent(ID, StudentId, FirstName, MiddleName, LastName, Age, Gender, Program);
            
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        public FrmClubRegistration()
        {
            InitializeComponent();
            clubRegistrationQuery = new ClubRegistrationQuery();
            count = 0;
        }

        public void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView.DataSource = clubRegistrationQuery.GetBindingSource();
        }

        public int RegistrationID()
        {
            count++;
            return count;
        }


    }
}
