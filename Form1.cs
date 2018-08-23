using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessingGame
{
    public partial class Form1 : Form
    {
        public class Variables
        {
            public static int count = 0;
        }
        
        public Form1()
        {
            MessageBox.Show("Guess a number from 1 to 100 \n Have fun!");
            InitializeComponent();
            label3.Text = "Guess Below";
            label3.BackColor = Color.Green;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Variables.count++;
            string inValue1;
            double number;
            if (double.TryParse(textBox1.Text, out number) == false)
            {
                MessageBox.Show("Value entered must be numeric");
                textBox1.Text = "0.0";
                textBox1.Focus();
            }
            else
            {
                inValue1 = textBox1.Text;
                number = double.Parse(inValue1);
                label2.Text = Variables.count.ToString();
                //higher
                if(number > target)
                {
                    //MessageBox.Show("Too High");
                    //label 3 is red
                    label3.BackColor = Color.Red;
                    label3.Text = "Too High";
                    
                }
                //lower
                if(number < target)
                {
                    //MessageBox.Show("Too Low");
                    //label 3 is blue
                    label3.BackColor = Color.Blue;
                    label3.Text = "Too Low";
                }
                //guessed correct
                if(number == target)
                {
                    label3.BackColor = Color.Green;
                    label3.Text = "BINGO!";
                    MessageBox.Show("Correct! \n You made "+Variables.count+" guesses");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
