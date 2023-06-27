using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Form1 : Form
    {

        public string username; // This is to store the username entered in the username textfield
        public string password; // This is to store the password entered in the password textfield

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            username = userNameTextBox.Text; // The text from the username textbox is stored in the class variable username
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = passwordTextBox.Text; // The text from the password textbox is stored in the class variable password
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newUserform = new Form2(); // The form for creating a new user is created 
            newUserform.Show(); // The form for creating a new user is shown 
            this.Hide(); // the login form is hid from the user
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (loginButton.Enabled == true) // This if clause runs if the login button is clicked
            {
                checkLogin(); // The check login method is run which checks whether the username and password entered exists in the login text file 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkLogin()
        {
            Login login = new Login();
            
            if (login.checkLogin(username, password)) // This if clause runs if the login details exist in the login text file  
            {
                failedLogin.Text = "The details you have entered are correct";
                Form3 textEditor = new Form3(login.Username, login.UserType); // The text editor form instance created and shown 
                textEditor.Show();
                this.Hide();
            }
            else // This clause runs if the username or password do not exist and the text fields are reset 
            {
                MessageBox.Show("The details you have entered are wrong!", "Failed Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userNameTextBox.ResetText();
                passwordTextBox.ResetText();
                return;

            }

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

    

}
