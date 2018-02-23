using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tisdale_Project_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            string[] employeeArray = DatabaseManager.getEmployeeNames();
            cbViewEmployee.DataSource = employeeArray;
            cbDeleteEmployee.DataSource = employeeArray;

            string[] customerArray = DatabaseManager.getCustomerNames();
            cbViewCustomer.DataSource = customerArray;
            cbDeleteCustomer.DataSource = customerArray;

            
        }
        
        private void lbEmployeeDateOfBirth_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnlModifyCustomer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bnAddCustomer_Click(object sender, EventArgs e)
        {
            Customer temp = null;
            bool legalCustomerValues = false;
            string dateString = "";

            try
            {
                
                temp = new Customer(tbCustomerFirstName.Text, tbCustomerLastName.Text, tbCustomerAddress.Text, dtpCustomerDateOfBirth.Value, tbCustomerFavoriteDepartment.Text);
                dateString = dtpCustomerDateOfBirth.Value.ToString("yyyy-MM-dd");
                legalCustomerValues = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (legalCustomerValues)
            {
                Console.WriteLine(temp.FirstName);
                DatabaseManager.addCustomer(temp.FirstName, temp.LastName, temp.Address, dateString, temp.FavoriteDepartment);
                //MessageBox.Show("Customer Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cbViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = cbViewCustomer.Text;
            if (selection != "")
            {
                string[] name = new string[1];

                selection = selection.Replace(",", "");
                name = selection.Split(' ');
                //name[0] = last name
                //name[1] = first name

                dgvViewCustomer.DataSource = DatabaseManager.viewCustomer(name[0], name[1]);
                
            }


        }

        private void cbViewEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

    }
}
