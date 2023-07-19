using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Phone_Book
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnClear.BackColor = Color.FromArgb(65, 67, 106);
            btnEdit.BackColor = Color.FromArgb(152, 64, 99);
            btnDelete.BackColor = Color.FromArgb(246, 70, 105);
            btnAdd.BackColor = Color.FromArgb(254, 151, 119);
            dgvContactList.DefaultCellStyle.Font = new Font("Montserrat", 12);
            dgvContactList.DefaultCellStyle.BackColor = Color.FromArgb(21, 205, 202);
            textBoxName.TextAlign = HorizontalAlignment.Center;
            textBoxFamily.TextAlign = HorizontalAlignment.Center;
            textBoxEmail.TextAlign = HorizontalAlignment.Center;
            textBoxPhone.TextAlign = HorizontalAlignment.Center;
            textBoxAddress.TextAlign = HorizontalAlignment.Center;
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        public string conString = "Data Source=DESKTOP-DBTGOTI;Initial Catalog=PhoneBookEn;Integrated Security=True";

        

        public new DataTable Select()
        {
            SqlConnection Conn = new SqlConnection(conString);
            DataTable dt = new DataTable();
            try
            {

                string sql = "SELECT * FROM tblContact";
                SqlCommand cmd = new SqlCommand(sql, Conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                Conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
            return dt;
        }



        // Inserting Data into DataBase

        public bool Insert()
        {
            bool Issuccess = false;

            SqlConnection Conn = new SqlConnection(conString);

            try
            {

                string sql = "INSERT INTO tblContact (fName, lName, phoneNumber, Address, emailAddress) VALUES (@fName, @lName, @phoneNumber, @Address, @emailAddress)";
                SqlCommand cmd = new SqlCommand(sql, Conn);
                cmd.Parameters.AddWithValue("@fName", textBoxName.Text);
                cmd.Parameters.AddWithValue("@lName", textBoxFamily.Text);
                cmd.Parameters.AddWithValue("@emailAddress", textBoxEmail.Text);
                cmd.Parameters.AddWithValue("@phoneNumber", textBoxPhone.Text);
                cmd.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                



                Conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Issuccess = true;
                }
                else
                {
                    Issuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
            }

            return Issuccess;
        }


        // Updating Data of DataBase
        public bool UpdateTb()
        {
            bool Issuccess = false;
            SqlConnection Conn = new SqlConnection(conString);

            try
            {

                string sql = "UPDATE tblContact SET fName=@fName, lName=@lName, emailAddress=@emailAddress, phoneNumber=@phoneNumber, Address=@Address WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, Conn);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvContactList.SelectedRows[0].Cells[0].Value));

                cmd.Parameters.AddWithValue("@fName", textBoxName.Text);
                cmd.Parameters.AddWithValue("@lName", textBoxFamily.Text);
                cmd.Parameters.AddWithValue("@emailAddress", textBoxEmail.Text);
                cmd.Parameters.AddWithValue("@phoneNumber", textBoxPhone.Text);
                cmd.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                



                Conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Issuccess = true;
                }
                else
                {
                    Issuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
            return Issuccess;
        }


        // Deleting Data from DataBase
        public bool Delete()
        {
            bool Issuccess = false;
            SqlConnection Conn = new SqlConnection(conString);

            try
            {
                string sql = "DELETE FROM tblContact WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, Conn);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvContactList.SelectedRows[0].Cells[0].Value));

                Conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    Issuccess = true;
                }
                else
                {
                    Issuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
            return Issuccess;
        }



        public void clear()
        {
            textBoxName.Text = "";
            textBoxFamily.Text = "";
            textBoxPhone.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
            
        }





        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxName.TextAlign = HorizontalAlignment.Right;
            textBoxFamily.TextAlign = HorizontalAlignment.Right;
            textBoxPhone.TextAlign = HorizontalAlignment.Right;
            textBoxEmail.TextAlign = HorizontalAlignment.Right;
            

            dgvContactList.ReadOnly = true;
            dgvContactList.DataSource = Select();
            dgvContactList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

        }


        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://www.mohammadijoo.ir", UseShellExecute = true });
        }

        private void linkLabelStore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://abolfazlm.com", UseShellExecute = true });
        }

        private void linkLabelForum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://programmer-club.ir", UseShellExecute = true });
        }

        private void linkLabelPythonClub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://pythonclub.ir", UseShellExecute = true });
        }

        private void linkLabelDjangoClub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://django3.ir", UseShellExecute = true });
        }

        private void linkLabelBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://mohammadijoo.com/blog", UseShellExecute = true });
        }

        private void linkLabelAspClub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://aspclub.ir", UseShellExecute = true });
        }

        private void linkLabelGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/mohammadijoo", UseShellExecute = true });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool success = Insert();
            if (success == true)
            {
                MessageBox.Show("The contact has been added to Database successfully");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to add contact to Database");
            }
            DataTable dt = Select();
            dgvContactList.DataSource = dt;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool success = UpdateTb();
            if (success == true)
            {
                MessageBox.Show("Contact has successfully updated.");
                DataTable dt = Select();
                dgvContactList.DataSource = dt;
                clear();

            }
            else
            {
                MessageBox.Show("Updating failed. try again.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool success = Delete();
            if (success == true)
            {
                MessageBox.Show("Contact successfully deleted.");
                DataTable dt = Select();
                dgvContactList.DataSource = dt;
                clear();
            }
            else
            {
                MessageBox.Show("Failed to delete contact. Try again");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            
        }

        private void dgvContactList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                textBoxName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
                textBoxFamily.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
                textBoxPhone.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
                textBoxAddress.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();
                textBoxEmail.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            }
            
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0) ;
        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }
    }
}