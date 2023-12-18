using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07LabExer
{
    public partial class FrmUpdateMember : Form
    {
        private int ID, Age;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentId;

        private void cbStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection_1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\COMPUTER\source\repos\07LabExer\07LabExer\ClubDB.mdf;Integrated Security=True");
            connection_1.Open();
            SqlCommand command_1 = new SqlCommand("SELECT FirstName, MiddleName, LastName, Age, Gender, PRogram FROM ClubMembers WHERE StudentID = @StudentID", connection_1);
            command_1.Parameters.AddWithValue("@studentID", int.Parse(cbStudentID.Text));
            SqlDataReader reader_1 = command_1.ExecuteReader();
            while (reader_1.Read())
            {
                if(cbStudentID.SelectedIndex != null)
                {
                    txtLastName.Text = reader_1.GetValue(2).ToString();
                    txtFirstName.Text = reader_1.GetValue(0).ToString();
                    txtMiddleName.Text = reader_1.GetValue(1).ToString();
                    txtAge.Text = reader_1.GetValue(3).ToString();
                    cbGender.Text = reader_1.GetValue(4).ToString();
                    cbProgram.Text = reader_1.GetValue(5).ToString();
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            StudentId = long.Parse(cbStudentID.Text);
            FirstName = txtFirstName.Text;
            MiddleName = txtMiddleName.Text;
            LastName = txtLastName.Text;
            Age = int.Parse(txtAge.Text);
            Gender = cbGender.Text;
            Program = cbProgram.Text;

            SqlConnection connection_2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\COMPUTER\source\repos\07LabExer\07LabExer\ClubDB.mdf;Integrated Security=True");
            connection_2.Open();
            SqlCommand command_2 = new SqlCommand("UPDATE ClubMembers SET StudentID = @std, FirstName = @fn, MiddleName = @mn, LastName = @ln, Age = @age, Gender = @gn, Program = @pg WHERE StudentID = @std", connection_2);
            command_2.Parameters.Add("@std", SqlDbType.BigInt).Value = long.Parse(cbStudentID.Text);
            command_2.Parameters.Add("@ln", SqlDbType.VarChar).Value = txtLastName.Text;
            command_2.Parameters.Add("@mn", SqlDbType.VarChar).Value = txtMiddleName.Text;
            command_2.Parameters.Add("@fn", SqlDbType.VarChar).Value = txtFirstName.Text;
            command_2.Parameters.Add("@age", SqlDbType.Int).Value = int.Parse(txtAge.Text);
            command_2.Parameters.Add("@gn", SqlDbType.VarChar).Value = cbGender.Text;
            command_2.Parameters.Add("@pg", SqlDbType.VarChar).Value = cbProgram.Text;
            command_2.ExecuteNonQuery();

        }

        public FrmUpdateMember()
        {
            InitializeComponent();
        }

        string[] ListOfProgram = new string[]
            {
            "BS in Hospitality Management",
            "BS in Computer Science",
            "BS in Information Technology",
            "BS in Computer Engineering",
            "BS in Tourism Management"
            };
        string[] ListOfGender = new string[]
        {
            "Male",
            "Female"
        };

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\COMPUTER\source\repos\07LabExer\07LabExer\ClubDB.mdf;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM ClubMembers", connection);
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                cbStudentID.Items.Add(reader["StudentID"].ToString());
            }           

            for (int i = 0; i < 5; i++)
            {
                cbProgram.Items.Add(ListOfProgram[i].ToString());
            }

            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(ListOfGender[i].ToString());
            }


        }
    }
}
