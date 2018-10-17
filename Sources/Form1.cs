using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AVR_Commands
{
    public partial class Form1 : Form
    {
        char[] dec;
        
        StringBuilder sb = new StringBuilder();
        StringBuilder sbb = new StringBuilder();
        char[] bytes = "00000000".ToCharArray();
        String bit;
        StringBuilder bitbuilder = new StringBuilder();
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.Red)
            {
                button2.BackColor = Color.White;
                bytes[0] = '0';
            }
            else
            {
                button2.BackColor = Color.Red;
                bytes[0] = '1';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.Red)
            {
                button3.BackColor = Color.White;
                bytes[1] = '0';
            }
            else
            {
                button3.BackColor = Color.Red;
                bytes[1] = '1';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.Red)
            {
                button4.BackColor = Color.White;
                bytes[2] = '0';
            }
            else
            {
                button4.BackColor = Color.Red;
                bytes[2] = '1';
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.Red)
            {
                button5.BackColor = Color.White;
                bytes[3] = '0';
            }
            else
            {
                button5.BackColor = Color.Red;
                bytes[3] = '1';
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.Red)
            {
                button6.BackColor = Color.White;
                bytes[4] = '0';
            }
            else
            {
                button6.BackColor = Color.Red;
                bytes[4] = '1';
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.Red)
            {
                button7.BackColor = Color.White;
                bytes[5] = '0';
            }
            else
            {
                button7.BackColor = Color.Red;
                bytes[5] = '1';
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.Red)
            {
                button8.BackColor = Color.White;
                bytes[6] = '0';
            }
            else
            {
                button8.BackColor = Color.Red;
                bytes[6] = '1';
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.BackColor == Color.Red)
            {
                button9.BackColor = Color.White;
                bytes[7] = '0';
            }
            else
            {
                button9.BackColor = Color.Red;
                bytes[7] = '1';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || !(textBox1.Text.Length == 10))
            {
                bitbuilder.Append("0b");
                foreach (char ch in bytes)
                {
                    bitbuilder.Append(ch);
                }

                sb.AppendLine("PORTA = " + bitbuilder.ToString());
                bitbuilder.Clear();
            }
            else
            {
                sb.AppendLine("PORTA = " + textBox1.Text);
                textBox1.Clear();
            }
            richTextBox1.Text = sb.ToString();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""||! (textBox1.Text.Length == 10))
            {
                bitbuilder.Append("0b");
                foreach (char ch in bytes)
                {
                    bitbuilder.Append(ch);
                }
                listBox1.Items.Add(bitbuilder.ToString());
                bitbuilder.Clear();
            }
            else
            {
                
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                listBox2.Items.Add(textBox2.Text);
                int dc;
                int f = 0;
                sbb.Append("uint8_t " + textBox2.Text + "[] ={");

                foreach (string c in listBox1.Items)
                {
                    dc = BinaryToDec(c);
                    if (f == (listBox1.Items.Count - 1))
                    {
                        sbb.Append(dc.ToString());
                    }
                    else
                    {
                        sbb.Append(dc.ToString() + ",");
                    }
                    f++;

                }


                f = 0;
                sbb.Append("};");
                sb.AppendLine(sbb.ToString());
                sbb.Clear();
                richTextBox1.Text = sb.ToString();
                textBox2.Clear();
            }
        }
        static int BinaryToDec(string input)
        {
            char[] array = input.ToCharArray();
            // Reverse since 16-8-4-2-1 not 1-2-4-8-16. 
            Array.Reverse(array);
            /*
             * [0] = 1
             * [1] = 2
             * [2] = 4
             * etc
             */
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                    // Method uses raising 2 to the power of the index. 
                    if (i == 0)
                    {
                        sum += 1;
                    }
                    else
                    {
                        sum += (int)Math.Pow(2, i);
                    }
                }

            }

            return sum;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.Text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            sb.AppendLine("for(int "+ listBox2.Text+"intenger = 0;"+listBox2.Text+"intenger > tablength;"+listBox2.Text+"intenger++){");
            sb.AppendLine("PORTA= ~" + listBox2.Text + "["+listBox2.Text+"intenger]");
            sb.AppendLine("}");
            richTextBox1.Text = sb.ToString();
            
        }
    }
}
