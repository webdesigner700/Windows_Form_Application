using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Form2 : Form
    {

        string userName;
        string password1;
        string password2;
        string firstName;
        string lastName;
        string userType;
        string birthDate;

        // These class variables are used to store the information entered by the user

        string[] userDetails = new string[6]; // This is used to store all the user information entered in an array for a method implementation 


        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("View"); // The userType combobox items are initialized
            comboBox1.Items.Add("Edit");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            userType = comboBox1.SelectedItem.ToString(); // The usertype string entered from the user is stored in the userType variable 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            userName = textBox1.Text; // The usernamestring entered from the user is stored in the userName variable 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password1 = textBox2.Text; // The password string entered from the user is stored in the password1 variable 
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            firstName = textBox4.Text; // The firstname string entered from the user is stored in the firstName variable 
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            lastName = textBox5.Text; // The lastname string entered from the user is stored in the lsatName variable 
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime birthday = dateTimePicker1.Value; // The date selected from the user is stored in the birthday variable 
            birthDate = birthday.ToString(); // The birthday variable is changed from DateTimke format to string format and stored in the birthdate variable 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //infromation is added to a data structure 
            //all information is saved to login.txt

            if (Login.checkUserName(userName)) // The checkUserName method checks whether the username entered by the user is unique or not 
            {
                MessageBox.Show("The username already exists", "Username error");
                textBox1.Text = "";
                return;
            }

            if (password1 != password2) // This if clause checks whether the password entered twice matches or not.
            {
                MessageBox.Show("The password fields do not match. Re-enter the password again", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Text = "";
                textBox3.Text = "";
                return;
            }

            userDetails[0] = userName;
            userDetails[1] = password1;
            userDetails[2] = userType;
            userDetails[3] = firstName;
            userDetails[4] = lastName;
            userDetails[5] = birthDate; 

            // The array userDetails is used to store all the user information and send it as an parameter to the Login.newUser method 

            Login.newUser(userDetails); // This method stores the new user information in the login text file 
            MessageBox.Show("You have submitted your details successfully", "New user created");
            Form3 textEditor = new Form3(userDetails[0], userDetails[2]); // The text editor form is initiated and the constructor takes the username and usertype as parameters
            textEditor.Show(); // The text editor form is initiated and shown 
            this.Hide(); // The new user form is closed
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1(); // The login form is shown again
            loginForm.Show();
            this.Hide(); // The new user form is hid from the user 
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            password2 = textBox3.Text; // The password string entered from the user is stored in the password2 class variable 
        }
    }
}
