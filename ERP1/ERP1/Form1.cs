using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ERP1
{
    public partial class Form1 : Form
    {
        int flag = 0;
        String Pname;
        int Pprice;
        int Pqty;
        int Tamount;
        int flag1 = 0; //for administrator data view
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Text = "LOGIN";
            this.button1.Visible = false;
            this.menupanel.Hide();
            this.button1.Text = " ";
            this.button1.BackColor = Color.White;
            this.button7.Text = " ";
            this.button7.BackColor = Color.White;
            this.button2.Visible = false;
            this.button3.Visible = false;
            this.button4.Visible = false;
            this.button5.Visible = false;
            this.button6.Visible = false;
            this.button7.Visible = false;
            this.button7.BackgroundImageLayout = ImageLayout.Center;
            this.MaximizeBox = false;
            this.textBox1.Font = new Font("Arial", 15);
            this.textBox2.Font = new Font("Arial", 15);
            this.textBox2.PasswordChar = '*';
            this.textBox2.MaxLength = 10;
            this.button8.Text = "Login";
            this.label2.Text = "ID";
            this.label3.Text = "Password";
            this.label4.Visible = false;
            this.button9.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            this.button14.Text = "X";
            AcceptButton = this.button8;
            
            this.textBox30.Visible = false;
            this.panel7.Visible = false;
            this.button15.Visible = false;
            this.button16.Visible = false;
            this.button17.Visible = false;
            customerpanel.Visible = false;
            vendorpanel.Visible = false;
            this.adminpanel.Visible = false;
            this.popanel.Visible = false;
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.menupanel.Visible = true;
            this.button2.Visible = true;
            this.button3.Visible = true;
            this.button4.Visible = true;
            this.button5.Visible = true;
            this.button6.Visible = true;
            this.button1.Visible = false;
            this.button7.Visible = true;
            this.menupanel.BackColor = Color.White;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            this.menupanel.Visible = false;
            this.button2.Visible = false;
            this.button3.Visible = false;
            this.button4.Visible = false;
            this.button5.Visible = false;
            this.button6.Visible = false;
            this.button7.Visible = false;
            this.button1.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e) //login button
        {
            //for after login
            if (this.textBox1.Text == "admin" && this.textBox2.Text == "123")
            {
                loginpanel.Visible = false;
                this.label4.Text = textBox1.Text;
                this.button1.Visible = true;
                this.label4.Visible = true;
                this.label4.Font = new Font("Times New Roman", 15);
                this.button9.Visible = true;
                this.button14.Visible = false;
                this.label4.Text = "Hamza Siddiqui";
            }
            else
            {
                MessageBox.Show("Incorrect ID or Password");
            }



        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //for logout
            Form1 obj = new Form1();
            this.button14.Visible = true;


            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //administrator code            
           
            this.label17.Text = "Data Approval";
            this.button18.Text = "Approve";
            this.button19.Text = "Disapprove";
            this.button23.Text = "Customer";
            this.button24.Text = "Vendor";
            this.button25.Text="PO";
            this.button26.Text = "Invoice";
            this.button27.Text = "Sales Order";
            this.button28.Text = "SO Invoice";
            this.label5.Text = "ID";
            this.button18.Visible = true;
            this.button19.Visible = true;
           
           
            if (panel7.Visible == true || popanel.Visible == true)
            {
                this.popanel.Visible = false;
                this.panel7.Visible = false;
                this.adminpanel.Visible = true;


            }
            else
            {
                this.adminpanel.Visible = true;
            }
            this.button15.Visible = false;
            this.button16.Visible = false;
            this.button17.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //customer code
            this.button15.Visible = true;
            this.button16.Visible = true;
            this.button17.Visible = true;
            this.button15.Text = "Add Data";
            this.button16.Text = "Update Data";
            this.button17.Text = "View Data";
            flag = 1;
            if (panel7.Visible == true || this.popanel.Visible == true)
            {
                this.panel7.Visible = false;
                this.popanel.Visible = false;

            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Vendor code
            this.button15.Visible = true;
            this.button16.Visible = true;
            this.button17.Visible = true;
            this.button15.Text = "Add Data";
            this.button16.Text = "Update Data";
            this.button17.Text = "View Data";
            flag = 2;

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //for admin to check data 
            if (label17.Text == "Data Approval")
            {
                
            }
            //for view vendor data
            if (this.label17.Text == "Vendor Data" && this.button18.Text == "View Data")
            {
                
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //for approvals
            if (flag1 == 1)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("update customer set cstatus=@cstatus where cid='" +comboBox1.Text +"'",oleDbConnection1);
               cmd.Parameters.AddWithValue("@cstatus","Active");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                oleDbConnection1.Close();
                flag1=0;
            }
            if (flag1 == 2)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("update vendor set vstatus=@vstatus where vid='" +comboBox1.Text +"'",oleDbConnection1);
               cmd.Parameters.AddWithValue("@vstatus","Active");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                oleDbConnection1.Close();
                flag1=0;
            }
            if (flag1 == 3)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("update po set approve=@approve where poid='" +comboBox1.Text +"'",oleDbConnection1);
               cmd.Parameters.AddWithValue("@approve","Approve");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                oleDbConnection1.Close();
                flag1=0;
            }
            if (flag1 == 4)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("update invoice set approval = @approval where invoiceid='" +comboBox1.Text +"'",oleDbConnection1);
               cmd.Parameters.AddWithValue("@approval","Approve");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                oleDbConnection1.Close();
                flag1=0;
            }
            if (flag1 == 5)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("update so set approve=@approve where soid='" +comboBox1.Text +"'",oleDbConnection1);
               cmd.Parameters.AddWithValue("@approve","Approve");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                oleDbConnection1.Close();
                flag1=0;
            }
            if (flag1 == 6)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("update soinvoice set approval=@approval where soinvoiceid='" +comboBox1.Text +"'", oleDbConnection1);
                cmd.Parameters.AddWithValue("@approval", "Approve");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                oleDbConnection1.Close();
                flag1 = 0;
            }
        }


        

        
        
       
        public void grnreadtrue()
        {
            this.textBox23.ReadOnly = true;
            this.textBox24.ReadOnly = true;
            this.textBox25.ReadOnly = true;
            this.textBox26.ReadOnly = true;
            this.textBox27.ReadOnly = true;
            this.textBox28.ReadOnly = true;
            this.textBox29.ReadOnly = true;
            this.textBox30.ReadOnly = true;
            this.textBox31.ReadOnly = true;

        }
        public void giclear()
        {

            this.textBox23.Clear();
            this.textBox24.Clear();
            this.textBox25.Clear();
            this.textBox26.Clear();
            this.textBox27.Clear();
            this.textBox28.Clear();
            this.textBox29.Clear();
            this.textBox31.Clear();
            this.textBox32.Clear();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //for Admin not approval
            if (flag1 == 1)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("update customer set cstatus=@cstatus where cid='" + comboBox1.Text + "'", oleDbConnection1);
                cmd.Parameters.AddWithValue("@cstatus", "Inactive");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                oleDbConnection1.Close();
                flag1 = 0;
            }
            if (flag1 == 2)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("update vendor set vstatus=@vstatus where vid='" + comboBox1.Text + "'", oleDbConnection1);
                cmd.Parameters.AddWithValue("@vstatus", "Inactive");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                oleDbConnection1.Close();
                flag1 = 0;
            }
            if (flag1 == 3)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("update po set approve=@approve where poid='" + comboBox1.Text + "'", oleDbConnection1);
                cmd.Parameters.AddWithValue("@approve", "DisApprove");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                oleDbConnection1.Close();
                flag1 = 0;
            }
            if (flag1 == 4)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("update invoice set approval = @approval where invoiceid='" + comboBox1.Text + "'", oleDbConnection1);
                cmd.Parameters.AddWithValue("@approval", "DisApprove");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                oleDbConnection1.Close();
                flag1 = 0;
            }
            if (flag1 == 5)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("update so set approve=@approve where soid='" + comboBox1.Text + "'", oleDbConnection1);
                cmd.Parameters.AddWithValue("@approve", "DisApprove");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                oleDbConnection1.Close();
                flag1 = 0;
            }
            if (flag1 == 6)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("update soinvoice set approval=@approval where soinvoiceid='" + comboBox1.Text + "'", oleDbConnection1);
                cmd.Parameters.AddWithValue("@approval", "DisApprove");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                oleDbConnection1.Close();
                flag1 = 0;
            }
            
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (posolabel.Text == "Purchase Order")
            {
                int POID = 0;
                if (comboBox4.Text == "Consumer")
                {

                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select count(POID) from PO", oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        POID = Convert.ToInt32(dr[0]);
                        POID++;
                    }
                    oleDbConnection1.Close();
                    this.textBox15.Text = "POCon" + "-" + POID + "-" + System.DateTime.Today.Year;

                }
                if (comboBox4.Text == "HR")
                {

                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select count(POID) from PO", oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        POID = Convert.ToInt32(dr[0]);
                        POID++;
                    }
                    oleDbConnection1.Close();
                    this.textBox15.Text = "POHR" + "-" + POID + "-" + System.DateTime.Today.Year;
                }
                if (comboBox4.Text == "Marketing")
                {
                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select count(POID) from PO", oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        POID = Convert.ToInt32(dr[0]);
                        POID++;
                    }
                    oleDbConnection1.Close();
                    this.textBox15.Text = "POMR" + "-" + POID + "-" + System.DateTime.Today.Year;

                }
                if (comboBox4.Text == "Sales")
                {
                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select count(POID) from PO", oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        POID = Convert.ToInt32(dr[0]);
                        POID++;
                    }
                    oleDbConnection1.Close();
                    this.textBox15.Text = "POSL" + "-" + POID + "-" + System.DateTime.Today.Year;
                }

                comboBox5.Items.Clear();
                try
                {
                    oleDbConnection1.Open();
                    OleDbCommand cmd1 = new OleDbCommand("select vid from vendor where vgroup='" + comboBox4.Text + "'", oleDbConnection1);
                    OleDbDataReader dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        comboBox5.Items.Add(dr1["vid"].ToString());
                    }
                    oleDbConnection1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is some issue ");
                }
            }
            //for Sales order
            if (posolabel.Text == "Sales Order")
            {
                int POID = 0;
                if (comboBox4.Text == "Consumer")
                {

                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select count(SOID) from SO", oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        POID = Convert.ToInt32(dr[0]);
                        POID++;
                    }
                    oleDbConnection1.Close();
                    this.textBox15.Text = "SOCon" + "-" + POID + "-" + System.DateTime.Today.Year;

                }
                if (comboBox4.Text == "HR")
                {

                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select count(SOID) from SO", oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        POID = Convert.ToInt32(dr[0]);
                        POID++;
                    }
                    oleDbConnection1.Close();
                    this.textBox15.Text = "SOHR" + "-" + POID + "-" + System.DateTime.Today.Year;
                }
                if (comboBox4.Text == "Marketing")
                {
                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select count(SOID) from SO", oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        POID = Convert.ToInt32(dr[0]);
                        POID++;
                    }
                    oleDbConnection1.Close();
                    this.textBox15.Text = "SOMR" + "-" + POID + "-" + System.DateTime.Today.Year;

                }
                if (comboBox4.Text == "Sales")
                {
                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select count(SOID) from SO", oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        POID = Convert.ToInt32(dr[0]);
                        POID++;
                    }
                    oleDbConnection1.Close();
                    this.textBox15.Text = "SOSL" + "-" + POID + "-" + System.DateTime.Today.Year;
                }

                comboBox5.Items.Clear();
                try
                {
                    oleDbConnection1.Open();
                    OleDbCommand cmd1 = new OleDbCommand("select cid from customer where cgroup='" + comboBox4.Text + "'", oleDbConnection1);
                    OleDbDataReader dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        comboBox5.Items.Add(dr1["Cid"].ToString());
                    }
                    oleDbConnection1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is some issue ");
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Purchase order code
            this.button15.Visible = false;
            this.button16.Visible = false;
            this.button17.Visible = false;
            if (panel7.Visible == true || this.adminpanel.Visible == true || customerpanel.Visible == true || vendorpanel.Visible == true)
            {
                this.adminpanel.Visible = false;
                this.panel7.Visible = false;
                this.customerpanel.Visible = false;
                this.vendorpanel.Visible = false;
                this.popanel.Visible = true;

            }
            else
            {
                this.label21.Text = "Purchase Order Department";
                this.label22.Text = "Purchase Order ID";
                this.label23.Text = "Deliver Date";
                this.label24.Text = "Vendor ID";
                this.label25.Text = "Vendor Name";
                this.label26.Text = "Vendor Department";
                this.label27.Text = "Contact Person";
                this.label28.Text = "Phone";
                this.label29.Text = "Product Model";
                this.label30.Text = "Product Name";
                this.label31.Text = "Product Price";
                this.label32.Text = "Product Quantity";
                this.posolabel.Text = "Purchase Order";
                this.button11.Text = "Add PO";
                this.button12.Text = "Create PO";
                this.textBox16.ReadOnly = true;
                this.textBox17.ReadOnly = true;
                this.textBox18.ReadOnly = true;
                this.textBox19.ReadOnly = true;
                this.textBox20.ReadOnly = true;
                this.textBox21.ReadOnly = true;
                this.comboBox4.Items.Clear();
                this.popanel.Visible = true;
                String[] dept = { "Consumer", "HR", "Marketing", "Sales" };
                this.comboBox4.Items.AddRange(dept);
                this.textBox15.ReadOnly = true;


            }

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select pname,baseprice from products where pid='" + comboBox6.Text + "'", oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.textBox20.Text = dr["pname"].ToString();
                    this.textBox21.Text = dr["baseprice"].ToString();
                }
                oleDbConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is some issue");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //GRN Code
            
            
                this.button15.Visible = false;
                this.button16.Visible = false;
                this.button17.Visible = false;
                giclear();
                grnreadtrue();
                this.panel7.Visible = true;
                this.label34.Text = "GRN";
                this.label35.Text = "Purcase Order ID";
                this.label36.Text = "Product Model";
                this.label37.Text = "Product Price";
                this.label38.Text = "Product Quatity";
                this.label39.Text = "Total Price";
                this.label40.Text = "Vendor ID";
                this.label41.Text = "Vendor Name";
                this.label45.Text = "GRN ID";
                this.label44.Text = "Deliver Date";
                this.button13.Text = "Create GRN";
                this.textBox26.Visible = true;
                this.textBox30.Visible = false;
                this.textBox31.Visible = true;
                this.label39.Visible = true;
                this.label44.Visible = true;
                this.label43.Visible = false;
                this.label42.Visible = false;
                this.textBox29.Visible = false;
                this.textBox32.ReadOnly = true;
                this.comboBox7.Items.Clear();
                int GRNID = 0;
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select count(GRNID) from GRN", oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    GRNID = Convert.ToInt32(dr[0]);
                    GRNID++;
                }
                oleDbConnection1.Close();
                this.textBox32.Text = "GRN" + "-" + GRNID + "-" + System.DateTime.Today.Year;
                oleDbConnection1.Open();
                OleDbCommand icmd = new OleDbCommand("select POID from PO where status ='Open'", oleDbConnection1);
                OleDbDataReader idr = icmd.ExecuteReader();
                while (idr.Read())
                {
                    this.comboBox7.Items.Add(idr["POID"].ToString());

                }
                oleDbConnection1.Close();
            }
        
        private void button10_Click(object sender, EventArgs e)
        {
            //Invoice code
            gitbreadtrue();
            this.label42.Visible = true;
            this.textBox29.Visible = false;
            this.textBox32.ReadOnly = true;
            this.textBox30.Visible = false;
            this.textBox26.Visible = false;
            this.textBox31.Visible = false;
            this.label39.Visible = false;
            this.label44.Visible = false;
            this.label43.Visible = false;
            this.label42.Visible = false;
            this.panel7.Visible = true;
            
            this.label34.Text = "PO Invoice";
            this.label35.Text = "GRN ID";
            this.label36.Text = "Payable Amount";
            this.label37.Text = "Deliver Date";
            this.label38.Text = "GRN Date";
            this.label40.Text = "PO ID";
            this.label41.Text = "Vendor Name";
            
            this.label45.Text = "PO Invoice ID";
            this.button13.Text = "Create Invoice";
            
            this.comboBox7.Items.Clear();
            giclear();
            oleDbConnection1.Open();
            OleDbCommand icmd = new OleDbCommand("select GRNID from grn where status='Open'", oleDbConnection1);
            OleDbDataReader idr = icmd.ExecuteReader();
            while (idr.Read())
            {
                this.comboBox7.Items.Add(idr["grnid"].ToString());

            }
            oleDbConnection1.Close();
            int PID = 0;
            oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(InvoiceID) from Invoice", oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                PID = Convert.ToInt32(dr[0]);
                PID++;
            }
            oleDbConnection1.Close();
            this.textBox32.Text = "PO" + "-" + PID + "-" + System.DateTime.Today.Year;


        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            //show customer insert data panel
            if (flag == 1)
            {
                if (panel7.Visible == true || popanel.Visible == true || adminpanel.Visible == true || vendorpanel.Visible == true)
                {
                    this.popanel.Visible = false;
                    this.panel7.Visible = false;
                    this.adminpanel.Visible = false;
                    this.vendorpanel.Visible = false;
                    this.customerpanel.Visible = true;


                }
                else
                {
                    customertbreadfalse();
                    customertbclear();
                    this.customerpanel.Visible = true;
                    cgroup.Items.Clear();
                    this.textBox33.ReadOnly = true;
                    this.textBox33.Visible = true;
                    this.textBox44.Visible = false;
                    this.custbutton.Text = "Add Data";
                    this.cid.Visible = false;
                    this.cgroup.Visible = true;
                    String[] cb3 = { "Consumer", "HR", "Marketing", "Sales" };
                    int CID = 0;
                    try
                    {
                        oleDbConnection1.Open();
                        OleDbCommand cmd = new OleDbCommand("select count(CID) from customer", oleDbConnection1);
                        OleDbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            CID = Convert.ToInt32(dr[0]);
                            CID++;
                        }
                        oleDbConnection1.Close();

                        this.textBox33.Text = "COO" + "-" + CID + "-" + System.DateTime.Today.Year;
                        cgroup.Items.AddRange(cb3);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("correct data");
                    }
                }
                this.button15.Visible = false;
                this.button16.Visible = false;
                this.button17.Visible = false;


            }
            //show vendor insert data panel
            if (flag == 2)
            {
                if (panel7.Visible == true || popanel.Visible == true || adminpanel.Visible == true || customerpanel.Visible == true)
                {
                    this.popanel.Visible = false;
                    this.panel7.Visible = false;
                    customerpanel.Visible = false;
                    this.adminpanel.Visible = false;
                    this.vendorpanel.Visible = true;


                }
                else
                {
                    vendortbreadfalse();
                    this.vendorpanel.Visible = true;
                    this.vendid.Visible = false;
                    this.vgroup.Visible = true;
                    this.textBox34.Visible = true;
                    this.textBox34.ReadOnly = true;
                    this.textBox54.Visible = false;
                    this.vendbutton.Text = "Add Data";
                    String[] cbvgroup = { "Consumer", "HR", "Marketing", "Sales" };
                    this.vgroup.Items.Clear();
                    int VID = 0;
                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select count(VID) from vendor", oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        VID = Convert.ToInt32(dr[0]);
                        VID++;
                    }
                    oleDbConnection1.Close();
                    this.textBox34.Text = "V00" + "-" + VID + "-" + System.DateTime.Today.Year;
                    vgroup.Items.AddRange(cbvgroup);
                    this.button15.Visible = false;
                    this.button16.Visible = false;
                    this.button17.Visible = false;
                    flag = 0;
                }
            }
            //create PO if po click
            if (flag == 3)
            {

                this.button15.Visible = false;
                this.button16.Visible = false;
                this.button17.Visible = false;
                flag = 0;
            }


        }

        private void button16_Click(object sender, EventArgs e)
        {
            //show customer panel for update
            if (flag == 1)
            {
                if (panel7.Visible == true || popanel.Visible == true || adminpanel.Visible == true)
                {
                    this.popanel.Visible = false;
                    this.panel7.Visible = false;
                    this.adminpanel.Visible = false;
                    this.customerpanel.Visible = true;



                }
                else
                {
                    customertbclear();
                    customertbreadtrue();
                    this.customerpanel.Visible = true;
                    this.textBox33.Visible = false;
                    this.textBox44.Visible = true;
                    this.cid.Visible = true;
                    this.cgroup.Visible = false;
                    this.cid.Items.Clear();
                    this.custbutton.Text = "Update Data";
                    String[] cbgroup = { "Consumer", "HR", "Marketing", "Sales" };
                    cgroup.Items.AddRange(cbgroup);
                    try
                    {
                        oleDbConnection1.Open();
                        OleDbCommand cmd1 = new OleDbCommand("select cid from customer where cstatus='Inactive'", oleDbConnection1);
                        OleDbDataReader dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            this.cid.Items.Add(dr1["cid"].ToString());
                        }
                        oleDbConnection1.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Correct data");
                    }
                }
                this.button15.Visible = false;
                this.button16.Visible = false;
                this.button17.Visible = false;
                flag = 0;
            }


            //show vendor panel for update
            if (flag == 2)
            {
                if (panel7.Visible == true || popanel.Visible == true || adminpanel.Visible == true || customerpanel.Visible == true)
                {
                    this.popanel.Visible = false;
                    this.panel7.Visible = false;
                    this.adminpanel.Visible = false;
                    this.customerpanel.Visible = false;
                    this.vendorpanel.Visible = true;


                }
                else
                {
                    vendortbclear();
                    vendortbreadfalse();
                    this.vendorpanel.Visible = true;
                    this.vendid.Items.Clear();
                    this.vgroup.Items.Clear();
                    this.vendid.Visible = true;
                    this.vgroup.Visible = false;
                    this.textBox34.Visible = false;
                    this.textBox54.Visible = true;
                    this.vendbutton.Text = "Update Data";
                    String[] vgrp = { "Consumer", "HR", "Marketing", "Sales" };
                    vgroup.Items.AddRange(vgrp);
                    try
                    {
                        oleDbConnection1.Open();
                        OleDbCommand cmd1 = new OleDbCommand("select vid from vendor where vstatus='Inactive'", oleDbConnection1);
                        OleDbDataReader dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            this.vendid.Items.Add(dr1["vid"].ToString());
                        }
                        oleDbConnection1.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There is some issue to perform the Operation");
                    }


                    this.button15.Visible = false;
                    this.button16.Visible = false;
                    this.button17.Visible = false;
                    flag = 0;
                }
            }


        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            //show customer panel for view data
            if (flag == 1)
            {
                if (panel7.Visible == true || popanel.Visible == true || adminpanel.Visible == true)
                {
                    this.popanel.Visible = false;
                    this.panel7.Visible = false;
                    this.adminpanel.Visible = false;
                    customerpanel.Visible = true;


                }
                else
                {

                    this.cid.Items.Clear();
                    customertbreadtrue();
                    customerpanel.Visible = true;
                    this.textBox33.Visible = false;
                    this.textBox44.Visible = true;
                    this.cid.Visible = true;
                    this.cgroup.Visible = false;
                    this.custbutton.Text = "Clear Data";
                    try
                    {
                        oleDbConnection1.Open();
                        OleDbCommand cmd1 = new OleDbCommand("select cid from customer", oleDbConnection1);
                        OleDbDataReader dr = cmd1.ExecuteReader();
                        while (dr.Read())
                        {
                            this.cid.Items.Add(dr["cid"].ToString());
                        }
                        oleDbConnection1.Close();

                        oleDbConnection1.Open();
                        OleDbCommand cmd = new OleDbCommand("select * from customer where cid='" + cid.Text + "'", oleDbConnection1);
                        OleDbDataReader dr1 = cmd.ExecuteReader();
                        if (dr1.Read())
                        {
                            this.textBox35.Text = dr1["cname"].ToString();
                            this.textBox36.Text = dr1["caddress"].ToString();
                            this.textBox37.Text = dr1["city"].ToString();
                            this.textBox38.Text = dr1["ph1"].ToString();
                            this.textBox39.Text = dr1["ph2"].ToString();
                            this.textBox40.Text = dr1["contectperson"].ToString();
                            this.textBox41.Text = dr1["cpph"].ToString();
                            this.textBox42.Text = dr1["cemail"].ToString();
                            this.textBox43.Text = dr1["creditlimit"].ToString();
                            this.textBox44.Text = dr1["cstatus"].ToString();
                        }
                        oleDbConnection1.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("There is some Issue ");
                    }
                }
                this.button15.Visible = false;
                this.button16.Visible = false;
                this.button17.Visible = false;
                flag = 0;
            }


            //show vendor panel for view data
            if (flag == 2)
            {
                if (panel7.Visible == true || popanel.Visible == true || customerpanel.Visible == true || adminpanel.Visible == true)
                {
                    this.popanel.Visible = false;
                    this.panel7.Visible = false;
                    this.adminpanel.Visible = false;
                    this.customerpanel.Visible = false;
                    this.vendorpanel.Visible = true;


                }
                else
                {
                    this.vendorpanel.Visible = true;
                    vendortbreadtrue();
                    vendid.Items.Clear();
                    this.vendbutton.Text = "Clear";
                    this.vendid.Visible = true;
                    this.vgroup.Visible = false;
                    this.textBox34.Visible = false;
                    this.textBox54.Visible = true;
                    oleDbConnection1.Open();
                    OleDbCommand cmd1 = new OleDbCommand("select vid from vendor", oleDbConnection1);
                    OleDbDataReader dr = cmd1.ExecuteReader();
                    while (dr.Read())
                    {
                        this.vendid.Items.Add(dr["vid"].ToString());
                    }
                    oleDbConnection1.Close();



                    this.button15.Visible = false;
                    this.button16.Visible = false;
                    this.button17.Visible = false;
                    flag = 0;



                }
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.label34.Text == "GRN")
            {
                try
                {
                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select vname,vid,totalamount,ddate from po where poid='" + comboBox7.Text + "'", oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        this.textBox28.Text = dr["vname"].ToString();
                        this.textBox27.Text = dr["vid"].ToString();
                        this.textBox26.Text = dr["totalamount"].ToString();
                        this.textBox31.Text = dr["ddate"].ToString();
                    }
                    oleDbConnection1.Close();
                   /* oleDbConnection1.Open();
                    OleDbCommand cmd1 = new OleDbCommand("select pid,pqty from poproducts where poid='" + comboBox7.Text + "'", oleDbConnection1);
                    OleDbDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.Read())
                    {
                        this.textBox23.Text = dr["pid"].ToString();
                        this.textBox24.Text = dr["pqty"].ToString();
                    }
                    oleDbConnection1.Close();*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is Some Issue");
                }
            }
            //for PO invoice
            if (label34.Text == "PO Invoice")
            {
                oleDbConnection1.Open();
                OleDbCommand cmd1 = new OleDbCommand("select ddate,grdate,vname,poid from grn where grnid='" +comboBox7.Text +"'",oleDbConnection1);
                OleDbDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    this.textBox24.Text = dr1["ddate"].ToString();
                    this.textBox25.Text = dr1["grdate"].ToString();
                    this.textBox27.Text = dr1["poid"].ToString();
                    this.textBox28.Text=dr1["vname"].ToString();
                }
                oleDbConnection1.Close();
                oleDbConnection1.Open();
                OleDbCommand cmd2 = new OleDbCommand("select totalamount from po where poid='" +textBox27.Text +"'",oleDbConnection1);
                OleDbDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    this.textBox23.Text = dr2["totalamount"].ToString();
                }
                oleDbConnection1.Close();          
           }
            //for sochallan
            if (label34.Text == "SO Challan")
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select cname,cid,totalamount,rdate from so where soid='" + comboBox7.Text + "'", oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.textBox28.Text = dr["cname"].ToString();
                    this.textBox27.Text = dr["cid"].ToString();
                    this.textBox26.Text = dr["totalamount"].ToString();
                    this.textBox31.Text = dr["rdate"].ToString();
                }
                oleDbConnection1.Close();
            }
            //for SO Invoice
            if (label34.Text == "SO Invoice")
            {
                oleDbConnection1.Open();
                OleDbCommand cmd1 = new OleDbCommand("select rdate,sochallandate,cname,soid from sochallan where sochallanid='" + comboBox7.Text + "'", oleDbConnection1);
                OleDbDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    this.textBox24.Text = dr1["rdate"].ToString();
                    this.textBox25.Text = dr1["sochallandate"].ToString();
                    this.textBox27.Text = dr1["soid"].ToString();
                    this.textBox28.Text = dr1["cname"].ToString();
                }
                oleDbConnection1.Close();
                oleDbConnection1.Open();
                OleDbCommand cmd2 = new OleDbCommand("select totalamount from so where soid='" + textBox27.Text + "'", oleDbConnection1);
                OleDbDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    this.textBox23.Text = dr2["totalamount"].ToString();
                }
                oleDbConnection1.Close();  
            }
        }

        private void custbutton_Click(object sender, EventArgs e)
        {
            //for insert customer data 
            if (custbutton.Text == "Add Data")
            {
                try
                {
                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("insert into Customer(Cid,CName,CAddress,City,Ph1,Ph2,ContectPerson,CPPH,CEmail,CreditLimit,CStatus,CGroup) values(@CID,@CName,@CAddress,@City,@PH1,@PH2,@ContectPerson,@CPPH,@CEmail,@CreditLimit,@CStatus,@CGroup)", oleDbConnection1);
                    cmd.Parameters.AddWithValue("@CID", textBox33.Text);
                    cmd.Parameters.AddWithValue("@CName", textBox35.Text);
                    cmd.Parameters.AddWithValue("@CAddress", textBox36.Text);
                    cmd.Parameters.AddWithValue("@City", textBox37.Text);
                    cmd.Parameters.AddWithValue("@PH1", textBox38.Text);
                    cmd.Parameters.AddWithValue("@PH2", textBox39.Text);
                    cmd.Parameters.AddWithValue("@ContectPerson", textBox40.Text);
                    cmd.Parameters.AddWithValue("@CPPH", textBox41.Text);
                    cmd.Parameters.AddWithValue("@CEmail", textBox42.Text);
                    cmd.Parameters.AddWithValue("@CreditLimit", textBox43.Text);
                    cmd.Parameters.AddWithValue("@CStatus", "Inactive");
                    cmd.Parameters.AddWithValue("@CGroup", cgroup.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Has been Inserted");
                    oleDbConnection1.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("There is Some Issue to Perform the Operation");
                }
                customertbclear();
                flag = 0;
            }

            //for update customer data
            if (custbutton.Text == "Update Data")
            {
                try
                {
                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("update Customer set CName=@cname,CAddress=@caddress,City=@city,Ph1=@ph1,Ph2=@ph2,ContectPerson=@contectperson,CPPH=@cpph,CEmail=@cemail,CreditLimit=@creditlimit,CStatus=@cstatus,CGroup=@cgroup where cid='" + cid.Text + "'", oleDbConnection1);
                    //cmd.Parameters.AddWithValue("@CID", textBox33.Text);
                    cmd.Parameters.AddWithValue("@CName", textBox35.Text);
                    cmd.Parameters.AddWithValue("@CAddress", textBox36.Text);
                    cmd.Parameters.AddWithValue("@City", textBox37.Text);
                    cmd.Parameters.AddWithValue("@PH1", textBox38.Text);
                    cmd.Parameters.AddWithValue("@PH2", textBox39.Text);
                    cmd.Parameters.AddWithValue("@ContectPerson", textBox40.Text);
                    cmd.Parameters.AddWithValue("@CPPH", textBox41.Text);
                    cmd.Parameters.AddWithValue("@CEmail", textBox42.Text);
                    cmd.Parameters.AddWithValue("@CreditLimit", textBox43.Text);
                    cmd.Parameters.AddWithValue("@CStatus", "Inactive");
                    cmd.Parameters.AddWithValue("@CGroup", textBox44.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Has been Updated");
                    oleDbConnection1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Correct data");
                }
                customertbclear();
                flag = 0;

            }
            //for clear view data
            if (custbutton.Text == "Clear Data")
            {
                customertbclear();

            }
        }


        private void cid_SelectedIndexChanged(object sender, EventArgs e)
        {

            oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select * from customer where cid='" + cid.Text + "'", oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox35.Text = dr["cname"].ToString();
                this.textBox36.Text = dr["caddress"].ToString();
                this.textBox37.Text = dr["city"].ToString();
                this.textBox38.Text = dr["ph1"].ToString();
                this.textBox39.Text = dr["ph2"].ToString();
                this.textBox40.Text = dr["contectperson"].ToString();
                this.textBox41.Text = dr["cpph"].ToString();
                this.textBox42.Text = dr["cemail"].ToString();
                this.textBox43.Text = dr["creditlimit"].ToString();
                this.textBox44.Text = dr["cgroup"].ToString();


            }
            oleDbConnection1.Close();

            /* catch (Exception ex)
             {
                 MessageBox.Show("There is some error in your data");
             }*/
        }
        public void customertbclear()
        {
            textBox33.Clear();
            textBox35.Clear();
            textBox36.Clear();
            textBox37.Clear();
            textBox38.Clear();
            textBox39.Clear();
            textBox40.Clear();
            textBox41.Clear();
            textBox42.Clear();
            textBox43.Clear();
            textBox44.Clear();
        }
        public void customertbreadtrue()
        {
            textBox33.ReadOnly = true;
            textBox35.ReadOnly = true;
            textBox36.ReadOnly = true;
            textBox37.ReadOnly = true;
            textBox38.ReadOnly = true;
            textBox39.ReadOnly = true;
            textBox40.ReadOnly = true;
            textBox41.ReadOnly = true;
            textBox42.ReadOnly = true;
            textBox43.ReadOnly = true;
            textBox44.ReadOnly = true;
        }
        public void customertbreadfalse()
        {
            textBox33.ReadOnly = false;
            textBox35.ReadOnly = false;
            textBox36.ReadOnly = false;
            textBox37.ReadOnly = false;
            textBox38.ReadOnly = false;
            textBox39.ReadOnly = false;
            textBox40.ReadOnly = false;
            textBox41.ReadOnly = false;
            textBox42.ReadOnly = false;
            textBox43.ReadOnly = false;
            textBox44.ReadOnly = false;
        }

        public void vendortbreadfalse()
        {
            textBox45.ReadOnly = false;
            textBox46.ReadOnly = false;
            textBox47.ReadOnly = false;
            textBox48.ReadOnly = false;
            textBox49.ReadOnly = false;
            textBox50.ReadOnly = false;
            textBox51.ReadOnly = false;
            textBox52.ReadOnly = false;
            textBox53.ReadOnly = false;
            textBox54.ReadOnly = false;
            textBox55.ReadOnly = false;
        }
        public void vendortbreadtrue()
        {
            textBox45.ReadOnly = true;
            textBox46.ReadOnly = true;
            textBox47.ReadOnly = true;
            textBox48.ReadOnly = true;
            textBox49.ReadOnly = true;
            textBox50.ReadOnly = true;
            textBox51.ReadOnly = true;
            textBox52.ReadOnly = true;
            textBox53.ReadOnly = true;
            textBox54.ReadOnly = true;
            textBox55.ReadOnly = true;
        }
        public void vendortbclear()
        {
            textBox34.Clear();
            textBox45.Clear();
            textBox46.Clear();
            textBox47.Clear();
            textBox48.Clear();
            textBox49.Clear();
            textBox50.Clear();
            textBox51.Clear();
            textBox52.Clear();
            textBox53.Clear();
            textBox54.Clear();
            textBox55.Clear();
        }
        private void customerpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox48_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox51_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox54_TextChanged(object sender, EventArgs e)
        {

        }

        private void vendbutton_Click(object sender, EventArgs e)
        {
            //insert vendor data
            if (vendbutton.Text == "Add Data")
            {
                int tb48 = Convert.ToInt32(textBox48.Text);
                int tb49 = Convert.ToInt32(textBox49.Text);
                int tb51 = Convert.ToInt32(textBox51.Text);
                try
                {
                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("insert into vendor (vid,vName,vAddress,vcity,Ph1,Ph2,Cpname,CPPH,vEmail,vfax,vgroup,vcode,vstatus) values(@vID,@vName,@vAddress,@vcity,@PH1,@PH2,@Cpname,@CPPH,@vEmail,@vGroup,@vfax,@vcode,@vstatus)", oleDbConnection1);
                    cmd.Parameters.AddWithValue("@vID", textBox34.Text);
                    cmd.Parameters.AddWithValue("@vName", textBox45.Text);
                    cmd.Parameters.AddWithValue("@vAddress", textBox46.Text);
                    cmd.Parameters.AddWithValue("@vcity", textBox47.Text);
                    cmd.Parameters.AddWithValue("@PH1", Convert.ToInt32(textBox48.Text));
                    cmd.Parameters.AddWithValue("@PH2", Convert.ToInt32(textBox49.Text));
                    cmd.Parameters.AddWithValue("@Cpname", textBox50.Text);
                    cmd.Parameters.AddWithValue("@CPPH", Convert.ToInt32(textBox51.Text));
                    cmd.Parameters.AddWithValue("@vemail", textBox52.Text);
                    cmd.Parameters.AddWithValue("@vfax", textBox53.Text);
                    cmd.Parameters.AddWithValue("@vGroup", vgroup.Text);
                    cmd.Parameters.AddWithValue("@vcode", textBox55.Text);
                    cmd.Parameters.AddWithValue("@vStatus", "Inactive");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Has been Inserted");
                    vendortbclear();
                    oleDbConnection1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is some issue to insert data");
                }
                flag = 0;

            }
            //update vender data
            if (vendbutton.Text == "Update Data")
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("update vendor set vName=@vname,vAddress=@vaddress,vCity=@vcity,Ph1=@ph1,Ph2=@ph2,cpname=@cpname,CPPH=@cpph,vEmail=@vemail,vfax=@vfax,vGroup=@vgroup,vcode=@vcode,vStatus=@vstatus where vid='" + vendid.Text + "'", oleDbConnection1);

                cmd.Parameters.AddWithValue("@vName", textBox45.Text);
                cmd.Parameters.AddWithValue("@vAddress", textBox46.Text);
                cmd.Parameters.AddWithValue("@vCity", textBox47.Text);
                cmd.Parameters.AddWithValue("@PH1", textBox48.Text);
                cmd.Parameters.AddWithValue("@PH2", textBox49.Text);
                cmd.Parameters.AddWithValue("@CPname", textBox50.Text);
                cmd.Parameters.AddWithValue("@CPPH", textBox51.Text);
                cmd.Parameters.AddWithValue("@vEmail", textBox52.Text);
                cmd.Parameters.AddWithValue("@vfax", textBox53.Text);
                cmd.Parameters.AddWithValue("@vGroup", textBox54.Text);
                cmd.Parameters.AddWithValue("@vcode", textBox55.Text);
                cmd.Parameters.AddWithValue("@vStatus", "Inactive");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Has been Updated");
                vendortbclear();
                oleDbConnection1.Close();
            }
            flag = 0;
            // view vendor data
            if (vendbutton.Text == "Clear")
            {
                vendortbclear();
            }


        }

        private void vendid_SelectedIndexChanged(object sender, EventArgs e)
        {
            //for update vendor data
            if (vendbutton.Text == "Update Data")
            {
                try
                {
                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select * from vendor where vid='" + vendid.Text + "'", oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        this.textBox45.Text = dr["vname"].ToString();
                        this.textBox46.Text = dr["vaddress"].ToString();
                        this.textBox47.Text = dr["vcity"].ToString();
                        this.textBox48.Text = dr["ph1"].ToString();
                        this.textBox49.Text = dr["ph2"].ToString();
                        this.textBox50.Text = dr["cpname"].ToString();
                        this.textBox51.Text = dr["cpph"].ToString();
                        this.textBox52.Text = dr["vemail"].ToString();
                        this.textBox53.Text = dr["vfax"].ToString();
                        this.textBox54.Text = dr["vgroup"].ToString();
                        this.textBox55.Text = dr["vcode"].ToString();
                    }
                    oleDbConnection1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is some issue ");
                }
            }
            //for view vednor data
            if (vendbutton.Text == "Clear")
            {

                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select * from vendor where vid='" + vendid.Text + "'", oleDbConnection1);
                OleDbDataReader dr1 = cmd.ExecuteReader();
                if (dr1.Read())
                {
                    this.textBox45.Text = dr1["vname"].ToString();
                    this.textBox46.Text = dr1["vaddress"].ToString();
                    this.textBox47.Text = dr1["vcity"].ToString();
                    this.textBox48.Text = dr1["ph1"].ToString();
                    this.textBox49.Text = dr1["ph2"].ToString();
                    this.textBox50.Text = dr1["cpname"].ToString();
                    this.textBox51.Text = dr1["cpph"].ToString();
                    this.textBox52.Text = dr1["vemail"].ToString();
                    this.textBox53.Text = dr1["vfax"].ToString();
                    this.textBox54.Text = dr1["vgroup"].ToString();
                    this.textBox55.Text = dr1["vcode"].ToString();
                }
                oleDbConnection1.Close();

            }


        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (posolabel.Text == "Purchase Order")
            {
                try
                {
                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select vname,vgroup,cpname,cpph from vendor where vid='" + comboBox5.Text + "'", oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        this.textBox16.Text = dr["vname"].ToString();
                        this.textBox17.Text = dr["vgroup"].ToString();
                        this.textBox18.Text = dr["cpname"].ToString();
                        this.textBox19.Text = dr["cpph"].ToString();
                    }
                    oleDbConnection1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is some is issue");
                }
                comboBox6.Items.Clear();
                try
                {
                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("select pid from products", oleDbConnection1);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        this.comboBox6.Items.Add(dr["pid"].ToString());
                    }
                    oleDbConnection1.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("There is some is issue");
                }
            }
                //for sales order

                 if (posolabel.Text == "Sales Order")
                {
                    
                        oleDbConnection1.Open();
                        OleDbCommand cmd = new OleDbCommand("select cname,cgroup,contectperson,cpph from customer where cid='" + comboBox5.Text + "'", oleDbConnection1);
                        OleDbDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            this.textBox16.Text = dr["cname"].ToString();
                            this.textBox17.Text = dr["cgroup"].ToString();
                            this.textBox18.Text = dr["contectperson"].ToString();
                            this.textBox19.Text = dr["cpph"].ToString();
                        }
                        oleDbConnection1.Close();
                    
                  /*  catch (Exception ex)
                    {
                        MessageBox.Show("There is some is issue");
                    }*/
                    comboBox6.Items.Clear();
                    
                        oleDbConnection1.Open();
                        OleDbCommand cmd1 = new OleDbCommand("select pid from products", oleDbConnection1);
                        OleDbDataReader dr1 = cmd1.ExecuteReader();
                        while (dr1.Read())
                        {
                            this.comboBox6.Items.Add(dr1["pid"].ToString());
                        }
                        oleDbConnection1.Close();
                    

                   /* catch (Exception ex)
                    {
                        MessageBox.Show("There is some is issue");
                    }*/



                }
            }
        

        private void button21_Click(object sender, EventArgs e)
        {
            this.button15.Visible = false;
            this.button16.Visible = false;
            this.button17.Visible = false;
            giclear();
            grnreadtrue();
            this.panel7.Visible = true;
            this.label34.Text = "SO Challan";
            this.label35.Text = "SO ID";
            this.label36.Text = "Product Model";
            this.label37.Text = "Product Price";
            this.label38.Text = "Product Quatity";
            this.label39.Text = "Total Price";
            this.label40.Text = "Customer ID";
            this.label41.Text = "Customer Name";
            this.label45.Text = "SO ID";
            this.label44.Text = "Recive Date";
            this.button13.Text = "Create SO";
            this.textBox26.Visible = true;
            this.textBox31.Visible = true;
            this.label39.Visible = true;
            this.label44.Visible = true;
            this.label43.Visible = false;
            this.label42.Visible = false;
            this.textBox30.Visible = false;
            this.textBox29.Visible = false;
            this.textBox32.ReadOnly = true;
            this.comboBox7.Items.Clear();
            int SOCID = 0;
            oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(SOChallanID) from SOChallan", oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                SOCID = Convert.ToInt32(dr[0]);
                SOCID++;
            }
            oleDbConnection1.Close();
            this.textBox32.Text = "SOC" + "-" + SOCID + "-" + System.DateTime.Today.Year;
            oleDbConnection1.Open();
            OleDbCommand icmd = new OleDbCommand("select SOID from SO where status ='Open'", oleDbConnection1);
            OleDbDataReader idr = icmd.ExecuteReader();
            while (idr.Read())
            {
                this.comboBox7.Items.Add(idr["SOID"].ToString());

            }
            oleDbConnection1.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {

            //sales order code

            this.button15.Visible = false;
            this.button16.Visible = false;
            this.button17.Visible = false;
            if (panel7.Visible == true || this.adminpanel.Visible == true || customerpanel.Visible == true || vendorpanel.Visible == true)
            {
                this.adminpanel.Visible = false;
                this.panel7.Visible = false;
                this.customerpanel.Visible = false;
                this.vendorpanel.Visible = false;
                this.popanel.Visible = true;

            }
            else
            {
                posoclear();
                this.label21.Text = "Sales Order Department";
                this.label22.Text = "Sales Order ID";
                this.label23.Text = "Sales Date";
                this.label24.Text = "Customer ID";
                this.label25.Text = "Customer Name";
                this.label26.Text = "Customer Department";
                this.label27.Text = "Contact Person";
                this.label28.Text = "Phone";
                this.label29.Text = "Product Model";
                this.label30.Text = "Product Name";
                this.label31.Text = "Product Price";
                this.label32.Text = "Product Quantity";
                this.posolabel.Text = "Sales Order";
                this.button11.Text = "Add SO";
                this.button12.Text = "Create SO";
                this.textBox16.ReadOnly = true;
                this.textBox17.ReadOnly = true;
                this.textBox18.ReadOnly = true;
                this.textBox19.ReadOnly = true;
                this.textBox20.ReadOnly = true;
                this.textBox21.ReadOnly = true;
                this.comboBox4.Items.Clear();
                this.popanel.Visible = true;
                String[] dept = { "Consumer", "HR", "Marketing", "Sales" };
                this.comboBox4.Items.AddRange(dept);
                this.textBox15.ReadOnly = true;
            }
        }


        private void button22_Click(object sender, EventArgs e)
        {
            //SO Invoice
            gitbreadtrue();
            this.label42.Visible = true;
            this.textBox29.Visible = false;
            this.textBox32.ReadOnly = true;
            this.textBox30.Visible = false;
            this.textBox26.Visible = false;
            this.textBox31.Visible = false;
            this.label39.Visible = false;
            this.label44.Visible = false;
            this.label43.Visible = false;
            this.label42.Visible = false;           
            this.panel7.Visible = true;
            this.label34.Text = "SO Invoice";
            this.label35.Text = "SO Challan ID";
            this.label36.Text = "Recive Amount";
            this.label37.Text = "Recive Date";
            this.label38.Text = "SO Challan Date";
            this.label40.Text = "Customer ID";
            this.label41.Text = "Customer Name";
            this.label42.Text = "Product Model";
            this.label43.Text = "Product Quantity";           
            this.button13.Text = "Create Invoice";
            this.comboBox7.Items.Clear();
            giclear();
            this.comboBox7.Items.Clear();
            giclear();
            oleDbConnection1.Open();
            OleDbCommand icmd = new OleDbCommand("select SOChallanID from SOChallan where status='Open'", oleDbConnection1);
            OleDbDataReader idr = icmd.ExecuteReader();
            while (idr.Read())
            {
                this.comboBox7.Items.Add(idr["SOChallanid"].ToString());

            }
            oleDbConnection1.Close();
            int SOID = 0;
            oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(SOInvoiceID) from SOInvoice", oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                SOID = Convert.ToInt32(dr[0]);
                SOID++;
            }
            oleDbConnection1.Close();
            this.textBox32.Text = "SOI" + "-" + SOID + "-" + System.DateTime.Today.Year;
        }
        public void posoclear()
        {
            this.textBox15.Clear();
            this.textBox16.Clear();
            this.textBox17.Clear();
            this.textBox18.Clear();
            this.textBox19.Clear();
            this.textBox20.Clear();
            this.textBox21.Clear();
            this.textBox22.Clear();
            this.comboBox5.Items.Clear();
            this.comboBox6.Items.Clear();

        }
        public void gitbreadtrue()
        {
            this.textBox23.ReadOnly = true;
            this.textBox24.ReadOnly = true;
            this.textBox25.ReadOnly = true;
            this.textBox26.ReadOnly = true;
            this.textBox27.ReadOnly = true;
            this.textBox28.ReadOnly = true;
            this.textBox29.ReadOnly = true;
            this.textBox30.ReadOnly = true;
            this.textBox31.ReadOnly = true;
            this.textBox32.ReadOnly = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //for Purchase order
            if (button11.Text == "Add PO")
            {
                Pname = this.textBox20.Text;
                Pprice = Convert.ToInt32(this.textBox21.Text);
                Pqty = Convert.ToInt32(this.textBox22.Text);
                Tamount = Pprice * Pqty;

                this.textBox56.Text = "Product Name = " + Pname + Environment.NewLine + "Product Price= " + Pprice + Environment.NewLine + "Product Quantity= " + Pqty + Environment.NewLine + "Total Amount= " + Tamount;
            }
            //for Sales Order
            if (button11.Text == "Add SO")
            {
                
                Pname = this.textBox20.Text;
                Pprice = Convert.ToInt32(this.textBox21.Text);
                Pqty = Convert.ToInt32(this.textBox22.Text);
                Tamount = Pprice * Pqty;

                this.textBox56.Text = "Product Name = " + Pname + Environment.NewLine + "Product Price= " + Pprice + Environment.NewLine + "Product Quantity= " + Pqty + Environment.NewLine + "Total Amount= " + Tamount;            
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //for create PO
            if (button12.Text == "Create PO")
            {
                try
                {
                    oleDbConnection1.Open();
                    OleDbCommand cmd = new OleDbCommand("insert into po (poid,podate,ddate,vdept,vname,vid,vcontectperson,vcpph,totalamount,status,approve)values(@poid,@podate,@ddate,@vdept,@vname,@vid,@vcontectperson,@vcpph,@totalamount,@status,@approve)", oleDbConnection1);
                    cmd.Parameters.AddWithValue("@poid", textBox15.Text);
                    cmd.Parameters.AddWithValue("@podate", System.DateTime.Today);
                    cmd.Parameters.AddWithValue("@ddate", dateTimePicker1);
                    cmd.Parameters.AddWithValue("@vdept", textBox17.Text);
                    cmd.Parameters.AddWithValue("@vname", textBox16.Text);
                    cmd.Parameters.AddWithValue("@vid", comboBox5.Text);
                    cmd.Parameters.AddWithValue("@vcontectperson", textBox18.Text);
                    cmd.Parameters.AddWithValue("@vcpph", textBox19.Text);
                    cmd.Parameters.AddWithValue("@totalamount", Tamount);
                    cmd.Parameters.AddWithValue("@status","Open");
                    cmd.Parameters.AddWithValue("@approve","applied");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data  Inserted");
                    oleDbConnection1.Close();
                    oleDbConnection1.Open();
                    OleDbCommand cmd1 = new OleDbCommand("insert into poproducts (poid,pid,pqty) values(@poid,@pid,@pqty)", oleDbConnection1);
                    cmd1.Parameters.AddWithValue("@poid", textBox15.Text);
                    cmd1.Parameters.AddWithValue("@pid", comboBox6.Text);
                    cmd1.Parameters.AddWithValue("@pqty", Pqty);
                    cmd1.ExecuteNonQuery();
                    oleDbConnection1.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("There Is some issue");
                }
            }
                //for Sales Order
                if (button12.Text == "Create SO")
                {
                    
                        oleDbConnection1.Open();
                        OleDbCommand cmd = new OleDbCommand("insert into so (soid,sodate,rdate,cdept,cname,cid,ccontectperson,ccpph,totalamount,status,approve)values(@soid,@sodate,@rdate,@cdept,@cname,@cid,@ccontectperson,@ccpph,@totalamount,@status,@approve)", oleDbConnection1);
                        cmd.Parameters.AddWithValue("@soid", textBox15.Text);
                        cmd.Parameters.AddWithValue("@sodate", System.DateTime.Today);
                        cmd.Parameters.AddWithValue("@rdate", dateTimePicker1);
                        cmd.Parameters.AddWithValue("@cdept", textBox17.Text);
                        cmd.Parameters.AddWithValue("@cname", textBox16.Text);
                        cmd.Parameters.AddWithValue("@cid", comboBox5.Text);
                        cmd.Parameters.AddWithValue("@ccontectperson", textBox18.Text);
                        cmd.Parameters.AddWithValue("@ccpph", textBox19.Text);
                        cmd.Parameters.AddWithValue("@totalamount", Tamount);
                        cmd.Parameters.AddWithValue("@status", "Open");
                        cmd.Parameters.AddWithValue("@approve", "applied");
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data  Inserted");
                        oleDbConnection1.Close();
                        oleDbConnection1.Open();
                        OleDbCommand cmd1 = new OleDbCommand("insert into soproducts (soid,pid,pqty) values(@soid,@pid,@pqty)", oleDbConnection1);
                        cmd1.Parameters.AddWithValue("@soid", textBox15.Text);
                        cmd1.Parameters.AddWithValue("@pid", comboBox6.Text);
                        cmd1.Parameters.AddWithValue("@pqty", Pqty);
                        cmd1.ExecuteNonQuery();
                        oleDbConnection1.Close();
                    

                    /*catch (Exception ex)
                    {
                        MessageBox.Show("There Is some issue");
                    }*/

                }                                  
            }
        

        private void button13_Click(object sender, EventArgs e)
        {
            if (label34.Text == "GRN")
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("insert into grn (grnid,poid,vname,ddate,grdate,status) values(@grnid,@poid,@vname,@ddate,@grdate,@status)",oleDbConnection1);
                cmd.Parameters.AddWithValue("@grnid",textBox32.Text);
               cmd.Parameters.AddWithValue("@poid",comboBox7.Text);
                cmd.Parameters.AddWithValue("@vname",textBox28.Text);
                cmd.Parameters.AddWithValue("@ddate",textBox31.Text);
                cmd.Parameters.AddWithValue("grdate",System.DateTime.Today);
                cmd.Parameters.AddWithValue("@status","Open");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data inserted");
                oleDbConnection1.Close();
                this.textBox32.Clear();
                oleDbConnection1.Open();
                OleDbCommand cmd1 = new OleDbCommand("update po set status='Close' where poid='" +comboBox7.Text +"'",oleDbConnection1);
                cmd1.ExecuteNonQuery();
                oleDbConnection1.Close();
            }
            if (label34.Text == "PO Invoice") {
                oleDbConnection1.Open();
                OleDbCommand cmd2 = new OleDbCommand("insert into invoice (invoiceid,poid,vendorname,ddate,grndate,invoicedate,amountpayable,grnid,approval) values(@invoiceid,@poid,@vendorname,@ddate,@grndate,@invoicedate,@amountpayable,@grnid,@approval)",oleDbConnection1);
                cmd2.Parameters.AddWithValue("@invoiceid",textBox32.Text);
                cmd2.Parameters.AddWithValue("@poid",textBox27.Text);
                cmd2.Parameters.AddWithValue("@vendorname",textBox28.Text);
                cmd2.Parameters.AddWithValue("@ddate",textBox24.Text);
                cmd2.Parameters.AddWithValue("@grndate",textBox25.Text);
                cmd2.Parameters.AddWithValue("@invoicedate",System.DateTime.Today);
                cmd2.Parameters.AddWithValue("@amountpayable",textBox23.Text);
                cmd2.Parameters.AddWithValue("@grnid",comboBox7.Text);
                cmd2.Parameters.AddWithValue("@approval", "Applied");
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Data inserted");
                oleDbConnection1.Close();          
            }
            if (label34.Text == "SO Challan")
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("insert into sochallan (sochallanid,soid,cname,rdate,sochallandate,status) values(@sochallanid,@soid,@cname,@rdate,@sochallandate,@status)", oleDbConnection1);
                cmd.Parameters.AddWithValue("@sochallanid", textBox32.Text);
                cmd.Parameters.AddWithValue("@soid", comboBox7.Text);
                cmd.Parameters.AddWithValue("@cname", textBox28.Text);
                cmd.Parameters.AddWithValue("@rdate", textBox31.Text);
                cmd.Parameters.AddWithValue("@sochallandate", System.DateTime.Today);
                cmd.Parameters.AddWithValue("@status", "Open");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data inserted");
                oleDbConnection1.Close();
                this.textBox32.Clear();
                oleDbConnection1.Open();
                OleDbCommand cmd1 = new OleDbCommand("update so set status='Close' where soid='" + comboBox7.Text + "'", oleDbConnection1);
                cmd1.ExecuteNonQuery();
                oleDbConnection1.Close();
            }
            if (label34.Text == "SO Invoice")
            {
                oleDbConnection1.Open();
                OleDbCommand cmd2 = new OleDbCommand("insert into soinvoice (soinvoiceid,soid,customername,rdate,sochallandate,soinvoicedate,amountrecive,sochallanid) values(@soinvoiceid,@soid,@customername,@rdate,@sochallandate,@soinvoicedate,@amountrecive,@sochallanid)", oleDbConnection1);
                cmd2.Parameters.AddWithValue("@soinvoiceid", textBox32.Text);
                cmd2.Parameters.AddWithValue("@soid", textBox27.Text);
                cmd2.Parameters.AddWithValue("@customername", textBox28.Text);
                cmd2.Parameters.AddWithValue("@rdate", textBox24.Text);
                cmd2.Parameters.AddWithValue("@sochallandate", textBox25.Text);
                cmd2.Parameters.AddWithValue("@soinvoicedate", System.DateTime.Today);
                cmd2.Parameters.AddWithValue("@amountrecive", textBox23.Text);
                cmd2.Parameters.AddWithValue("@sochallanid", comboBox7.Text);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Data inserted");
                oleDbConnection1.Close();
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            flag1 = 1;
            this.comboBox1.Items.Clear();
            if (flag1 == 1)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select cid from customer where cstatus='Inactive'",oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["cid"].ToString());
                }
                oleDbConnection1.Close();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            flag1 = 2;
            this.comboBox1.Items.Clear();
            if (flag1 == 2)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select vid from vendor where vstatus='Inactive'", oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["vid"].ToString());
                }
                oleDbConnection1.Close();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //for po approve
            flag1 = 3;
            this.comboBox1.Items.Clear();
            if (flag1 == 3)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select poid from po where approve='applied'", oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["poid"].ToString());
                }
                oleDbConnection1.Close();
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //for invoice approve
            flag1 = 4;
            this.comboBox1.Items.Clear();
            if (flag1 == 4)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select invoiceid from invoice where approval ='Applied'", oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["invoiceid"].ToString());
                }
                oleDbConnection1.Close();
            }

        }

        private void button27_Click(object sender, EventArgs e)
        {
            //for SO approve
            flag1 = 5;
            this.comboBox1.Items.Clear();
            if (flag1 == 5)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select soid from so where approve='Applied'", oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["soid"].ToString());
                }
                oleDbConnection1.Close();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            //for SO Invoice
            flag1 = 6;
            this.comboBox1.Items.Clear();
            if (flag1 == 6)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select soinvoiceid from soinvoice where approval='Applied'", oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    this.comboBox1.Items.Add(dr["soinvoiceid"].ToString());
                }
                oleDbConnection1.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (flag1 == 1)
            {
                
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select * from customer where cid='" +comboBox1.Text +"'",oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                oleDbConnection1.Close();
    
            }

            if (flag1 == 2)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select * from vendor where vid='" + comboBox1.Text + "'", oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                oleDbConnection1.Close();
            }

            if (flag1 == 3)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select * from po where poid='" + comboBox1.Text + "'", oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                oleDbConnection1.Close();
            }
            if (flag1 == 4)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select * from invoice where invoiceid='" + comboBox1.Text + "'", oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                oleDbConnection1.Close();
            }

            if (flag1 == 5)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select * from so where soid='" + comboBox1.Text + "'", oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                oleDbConnection1.Close();
            }

            if (flag1 == 6)
            {
                oleDbConnection1.Open();
                OleDbCommand cmd = new OleDbCommand("select * from soinvoice where soinvoiceid='" + comboBox1.Text + "'", oleDbConnection1);
                OleDbDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                oleDbConnection1.Close();
            }
        }
    }
}



