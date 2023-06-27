using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Assignment2
{

    public partial class Form3 : Form
    {

        public string username; // This is to store the username from the constructor
        public string userType; // This is to store the usertype from the constructor 
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(string username, string userType)
        {
            InitializeComponent();
            this.username = username;
            this.userType = userType;
            toolStripTextBox1.Text = "User Name: " + this.username; // The username is displayed on the form 
            if (this.userType == "View") 
            {
                richTextBox1.Enabled = false;
            }
            else if (this.userType == "Edit")
            {
                richTextBox1.Enabled = true;
            }

            // Depending on the value of the userType variable, the richtextbox is either editable or not 
        }


        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void openCtrlOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog(); //creates an instance of the OpenFileDialog
            openFileDialog1.Title = "Open a text file"; // The title of the DialogBox is set 
            openFileDialog1.Filter = "Text Files (*.txt) | *.txt | All Files(*.*) | *.*";

            DialogResult dr = openFileDialog1.ShowDialog(); // The showDialog() method shows the dialog box 

            if (dr == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName; //filename contains the full path to the text file 

                string[] fileLines = System.IO.File.ReadAllLines(fileName); // The lines from the file are read into an array

                foreach (string line in fileLines)
                {
                    richTextBox1.AppendText(line); // Each line from the array are appended to the richtextbox
                }
                
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Open a text file";
            openFileDialog1.Filter = "Text Files (*.txt) | *.txt | All Files(*.*) | *.*";

            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName; //filename contains the full path to the text file 

                MessageBox.Show("The file selected is" + fileName);

                string[] fileLines = System.IO.File.ReadAllLines(fileName);

                foreach (string line in fileLines)
                {
                    richTextBox1.AppendText(line);
                }

            }
        }

        private void saveCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); // An instance of the SaveFileDialog is created 
            saveFileDialog.Title = "Save information from rich Text Box"; // The ttiel for the dialog box is set
            saveFileDialog.Filter = "RTF Files (*.rtf) | *.rtf | All Files(*.*) | *.*";

            DialogResult saver = saveFileDialog.ShowDialog(); // The showDialog() method shows the dialog box

            if (saver == DialogResult.OK)
            {

                string fileName = saveFileDialog.FileName; // The filename selected to save is stored in fileName
                richTextBox1.SaveFile(fileName); // The contents of the richtextbox are stored in teh file in the rtf format 
                MessageBox.Show("The file " + fileName + "has been saved");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save information from rich Text Box";
            saveFileDialog.Filter = "RTF Files (*.rtf) | *.rtf | All Files(*.*) | *.*";

            DialogResult saver = saveFileDialog.ShowDialog();

            if (saver == DialogResult.OK)
            {

                string fileName = saveFileDialog.FileName;
                richTextBox1.SaveFile(fileName);
                MessageBox.Show("The file " + fileName + "has been saved");
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save information from rich Text Box";
            saveFileDialog.Filter = "RTF Files (*.rtf) | *.rtf | All Files(*.*) | *.*";

            DialogResult saver = saveFileDialog.ShowDialog();

            if (saver == DialogResult.OK)
            {

                string fileName = saveFileDialog.FileName;
                richTextBox1.SaveFile(fileName);
                MessageBox.Show("The file " + fileName + "has been saved");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save information from rich Text Box";
            saveFileDialog.Filter = "RTF Files (*.rtf) | *.rtf | All Files(*.*) | *.*";

            DialogResult saver = saveFileDialog.ShowDialog();

            if (saver == DialogResult.OK)
            {

                string fileName = saveFileDialog.FileName;
                richTextBox1.SaveFile(fileName);
                MessageBox.Show("The file " + fileName + "has been saved");
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold); // The fontstyle of the selected text is set to bold
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic); // The fontstyle of the selected text is set to Italic
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Underline); // The fontstyle of the selected text is set to Underlined
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            int fontSize = toolStripComboBox1.SelectedIndex + 8; // indexes of the selected item from the combobox is stored and 8 is added to it 
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, fontSize, richTextBox1.SelectionFont.Style); 
            // The fontSize variable initialized is used to set the font size of the selected text 
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = ""; // The selected text in teh richtextbox is cut
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText); // The selected text is copied to clipboard
            MessageBox.Show("The selected text is saved to the clipboard", "Copied Text");
            
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(Clipboard.GetText()); // The copied text is pasted to the richtextbox 
        }

        private void cutCtrlXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void copyCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }

        private void pasteCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(Clipboard.GetText());
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1(); // The login form is shown to the user
            loginForm.Show();
            this.Hide(); // the text editor form is hid from the user 

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 aboutForm = new Form4(); // The about form is shown to the user
            aboutForm.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
