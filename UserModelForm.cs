using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagementSystem
{
    
    public partial class UserModelForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ASUS17\SQLEXPRESS01;Initial Catalog=PurchasingAndWarehousing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cm = new SqlCommand();
        public UserModelForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != txtRepass.Text)
                {
                    MessageBox.Show("كلمة المرور غير مطابقة !", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("هل انت متاكد من اضافة المستخدم ؟", "اضافة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO tbUser(userName,fullName,passWord,phoneNUmber)VALUES(@userName,@fullName,@passWord,@phoneNUmber)", con);
                    cm.Parameters.AddWithValue("@userName", txtUserName.Text);
                    cm.Parameters.AddWithValue("@fullName", txtFullName.Text);
                    cm.Parameters.AddWithValue("@password", txtPassword.Text);
                    cm.Parameters.AddWithValue("@phoneNUmber", txtPhoneNumber.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم اضافة المستخدم بنجاح ");
                    Clear();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        public void Clear()
        {
            txtUserName.Clear();
            txtFullName.Clear();
            txtPassword.Clear();
            txtRepass.Clear();
            txtPhoneNumber.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != txtRepass.Text)
                {
                    MessageBox.Show("كلمة المرور غير مطابقة !", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if (MessageBox.Show("هل انت متاكد من التعديل ؟", "تحديث", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE tbUser SET fullName = @fullName, passWord=@passWord, phoneNUmber=@phoneNUmber WHERE userName LIKE '" + txtUserName.Text + "' ", con);
                    cm.Parameters.AddWithValue("@fullName", txtFullName.Text);
                    cm.Parameters.AddWithValue("@passWord", txtPassword.Text);
                    cm.Parameters.AddWithValue("@phoneNUmber", txtPhoneNumber.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم التحديث بنجاح !");
                    this.Dispose();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void UserModelForm_Load(object sender, EventArgs e)
        {

        }
    }
}
