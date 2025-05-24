using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AshleyNunez_IronSoftware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the number of the button clicked in the TextBox named txt_texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showNumber(Object sender, EventArgs e)
        {
            var button =  (Button)sender;
            if (button.Text.ElementAt(0) == '0' )
            {
                if (!txt_texto.Text.EndsWith(" ") && txt_texto.Text.Length != 0)
                {
                    txt_texto.Text += " ";
                }
                
            } else
            {
                txt_texto.Text += button.Text.ElementAt(0);
            }
               
        }

        /// <summary>
        /// Makes the conversion from numbers to letters, with a dictionary
        /// </summary>
        /// <param name="input">The string with the combinations of numbers</param>
        /// <returns></returns>
        public static string OldPhonePad(string input)
        {
            Dictionary <int, string> PhonePadMap = new Dictionary<int, string>
            {
                {2, "A"}, {22, "B"}, {222, "C"},
                {3, "D"}, {33, "E"}, {333, "F"},
                {4, "G"}, {44, "H"}, {444, "I"},
                {5, "J"}, {55, "K"}, {555, "L"},
                {6, "M"}, {66, "N"}, {666, "O"},
                {7, "P"}, {77, "Q"}, {777, "R"}, {7777, "S"},
                {8, "T"}, {88, "U"}, {888, "V"},
                {9, "W"}, {99, "X"}, {999, "Y"}, {9999, "Z"}
            };
            var messageArray = input.Split(' ');
            string result = "";
            List<string> message = new List<string>();
            //Gets the numbers separated by space
            foreach (var item in messageArray)
            {
                StringBuilder messageNumber = new StringBuilder();
                for (global::System.Int32 i = 0; i < item.Length; i++)
                {
                    if (item[i].Equals('*'))
                    {
                        messageNumber.Clear();
                        continue;
                    }
                    if (i > 0 && item[i] != item[i - 1] && messageNumber.Length > 0)
                    {
                        message.Add(messageNumber.ToString());
                        messageNumber.Clear();
                    }
                    messageNumber.Append(item[i]);

                    if (i == item.Length - 1)
                    {
                        message.Add(messageNumber.ToString());
                    }
                }
            }
            //Gets the combination of each number from the dictionary
            foreach (var item in message)
            {
                int number = int.Parse(item.ToString());
                if (PhonePadMap.ContainsKey(number))
                {
                    result += PhonePadMap[number];
                }
            }
            return result;
        }

        /// <summary>
        /// Adds an asterisk after the last number written for it to be deleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string text = txt_texto.Text;
            if (text.Length != 0 && (!(text.EndsWith(" ") || text.EndsWith("*"))))
            {
                txt_texto.Text += "*";
            }
            
        }

        /// <summary>
        /// Sends the input written for it to be converted in letters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_send_Click(object sender, EventArgs e)
        {
            txt_result.Text = OldPhonePad(txt_texto.Text);
        }

        /// <summary>
        /// Clear the Text wirtten in the TextBox named txt_texto and txt_result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_texto.Text = "";
            txt_result.Text = "";
        }
    }
}
