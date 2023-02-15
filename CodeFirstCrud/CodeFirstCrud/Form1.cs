using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstCrud
{
    public partial class frmStudentinfo : Form
    {

        int a = 0;
        int studentid = 0;
        Student studentinfo = new Student();
        Databasecontext db = new Databasecontext();

        public frmStudentinfo()
        {
            InitializeComponent();
            LoadGrid();
            clearscreen();
        }

        void LoadGrid()
        {
            //Dbcontext.StudentDetail.ToList<StudentModel>();
            gridviewstudent.DataSource = db.StudentDetail.ToList<Student>();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            studentinfo.FirstName = txtFirstname.Text.Trim();
            studentinfo.LastName = txtLastname.Text.Trim();
            studentinfo.age = txtage.Text.Trim();
            studentinfo.EmailAddress = txtemailAddress.Text.Trim();
            studentinfo.DOB = txtDobdate.Value;
            studentinfo.Phoneno = txtPhone.Text.Trim();

            db.StudentDetail.Add(studentinfo);


            a = db.SaveChanges();
            if (a > 0)
            {
                MessageBox.Show("Saved Record Successfully", "Record Save Alert",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
                clearscreen();
            }
            else
            {
                MessageBox.Show("data no Saved", "Not Saving data Alert", MessageBoxButtons.OK,
             MessageBoxIcon.Information);
            }
        }

        void clearscreen()
        {
            txtage.Text = "";
            txtaddress.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";



        }

        private void gridviewstudent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            enablecontrol();
            btnsave.Enabled = false;
            btnNew.Enabled = false;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;
            


            studentid = Convert.ToInt32(gridviewstudent.CurrentRow.Cells[0].Value);
            studentinfo = db.StudentDetail.Where(x => x.id == studentid).FirstOrDefault();
            txtFirstname.Text = studentinfo.FirstName;
            txtLastname.Text = studentinfo.LastName;
            txtemailAddress.Text = studentinfo.EmailAddress;
            txtage.Text = studentinfo.age;
            txtDobdate.Value = studentinfo.DOB;






        }

        private void button2_Click(object sender, EventArgs e)
        {

            studentinfo.id = studentid;
            studentinfo.FirstName = txtFirstname.Text.Trim();
            studentinfo.LastName = txtLastname.Text.Trim();
            studentinfo.age = txtage.Text.Trim();
            studentinfo.EmailAddress = txtemailAddress.Text.Trim();
            studentinfo.DOB = txtDobdate.Value;
            studentinfo.Phoneno = txtPhone.Text.Trim();
            db.StudentDetail.Add(studentinfo);

            db.Entry(studentinfo).State = EntityState.Modified;

            a = db.SaveChanges();

            if (a > 0)
            {
                MessageBox.Show(" udpated Successfully", "Record Save Alert",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
                clearscreen();
            }
            else
            {
                MessageBox.Show("data not updated", "Not Saving data Alert", MessageBoxButtons.OK,
             MessageBoxIcon.Information);
            }

            btnupdate.Enabled = false;
            btnNew.Enabled = true;
            btndelete.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to deleted the record", "Deleted Reford",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                // student ID variable you have declared on above of constructor class
                studentinfo.id = studentid;
                db.Entry(studentinfo).State = EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    MessageBox.Show("For your selected Record deleted Successfully", "Deleted Alert",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();

                }
                else
                {
                    MessageBox.Show("data no Saved", "Not Saving data Alert", MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
                }
            }
        }
            

        void enablecontrol()
        {
            txtFirstname.Enabled = true;
            txtLastname.Enabled = true;
            txtemailAddress.Enabled = true;
            txtDobdate.Enabled = true;
            txtPhone.Enabled = true;
            txtaddress.Enabled = true;
            txtage.Enabled = true;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            enablecontrol();
            btnsave.Enabled = true;

        }
    }
}

