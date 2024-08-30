using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("You selected this folder " + openFileDialog1.FileName);
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            if(textBox1.Text == string.Empty)
            {
                textBox1.Clear();
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to save changes ? ", "Correction", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                    saveFileDialog1.DefaultExt = "txt";
                    saveFileDialog1.AddExtension = true;
                    File.WriteAllText(@"C:\Users\Giorgi\Desktop\Untitled.txt", textBox1.Text);
                }
                if(result == DialogResult.No)
                {
                  textBox1.Clear(); 
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.AddExtension = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\Users\Giorgi\Desktop\Untitled.txt" , textBox1.Text);
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Everythings gonna be fine ");
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
          textBox1.SelectAll();
        }
    }
}
