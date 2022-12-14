using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace InventoryManagementSystem
{
    public partial class CustomerModelForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ASUS17\SQLEXPRESS01;Initial Catalog=PurchasingAndWarehousing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cm = new SqlCommand();
        public CustomerModelForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("هل انت متاكد من اضافة مقدم الطلب ؟", "اضافة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("INSERT INTO tbCustomer(cname,cphone,csection)VALUES(@cname,@cphone,@csection)", con);
                    cm.Parameters.AddWithValue("@cname", txtCName.Text);
                    cm.Parameters.AddWithValue("@cphone", txtCPhone.Text);
                    cm.Parameters.AddWithValue("csection", txtsection.Text);

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
        public void Clear()
        {
            txtCName.Clear();
            txtCPhone.Clear();


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل انت متاكد من تعديل العنصر ؟", "تعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE tbCustomer SET cname = @cname,cphone=@cphone,csection=@csection WHERE cid LIKE '" + lblCId.Text + "' ", con);
                    cm.Parameters.AddWithValue("@cname", txtCName.Text);
                    cm.Parameters.AddWithValue("@cphone", txtCPhone.Text);
                    cm.Parameters.AddWithValue("@csection", txtsection.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم التعديل بنجاح !");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CustomerModelForm_Load(object sender, EventArgs e)
        {
            txtCName.Focus();
        }

        private void txtCName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtCPhone.Focus();
            }
        }

        private void txtCPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtsection.Focus();
            }
        }

        private void txtsection_KeyDown(object sender, KeyEventArgs e)
        {
            btnSave.PerformClick();
        }
    }
}
