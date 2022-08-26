using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD_Stats_Rolling_ultra_mega_super_version_0._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] Rolling4(Random random)
        {
            int[] rollResults = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if(silaradar.Checked)
                {
                    rollResults[i] = random.Next(1, 4);
                }
                else if (pidoradar.Checked)
                {
                    rollResults[i] = random.Next(4, 7);
                }
                else 
                {
                    rollResults[i] = random.Next(1, 7);
                }
            }
            return rollResults;
        }
        static string GetResult(int[] rollResults)
        {
            string result;
            int min = 7, rollsSum = 0;
            foreach (int rollRes in rollResults)
            {
                rollsSum += rollRes;
                if (rollRes < min)
                {
                    min = rollRes;
                }
            }
            result = "Значение: " + (rollsSum - min);
            return result;
        }
        static string GetRollResults(int[] rollResults)
        {
            int rollSum = 0;
            foreach(int rollRes in rollResults)
            {
                rollSum += rollRes;
            }
            string rollingResults = "Рулоны: " + rollResults[0] + " + " + rollResults[1] + " + " + rollResults[2] + " + " + rollResults[3] + " = " + rollSum;
            return rollingResults;
        }
        private void rollButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            Label[] rollingFields = { rollings1, rollings2, rollings3, rollings4, rollings5, rollings6 };
            Label[] resultFields = { result1, result2, result3, result4, result5, result6 };
            for (int i = 0; i < 6; i++)
            {
                if (d20radar.Checked)
                {
                    int d20 = random.Next(1, 21);
                    rollingFields[i].Text = "D20";
                    resultFields[i].Text = "Значение: " + d20;
                }
                else
                {
                    var rollRes = Rolling4(random);
                    rollingFields[i].Text = GetRollResults(rollRes);
                    resultFields[i].Text = GetResult(rollRes);
                }
            }
        }

        static int GetDiceType(string str)
        {
            int dice;
            if (str != null) str = str.Substring(1);
            else return 20;
            return dice = Convert.ToInt32(str);
        }
        private void diceRoll_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int result = 0, dice = GetDiceType((string)listDiceBox.SelectedItem)+1;
            string resultString = "Хлоп-поп и получаем: ";

            for(int i = 0; i < countUpDown.Value; i++)
            {
                int rnd = random.Next(1, dice);
                result += rnd;
                resultString += rnd + " + ";
            }
            result += (int)bonusUpDown.Value;
            resultString += bonusUpDown.Value + " = ";
            diceRollResult.Text = resultString + result;
            resultLabel.Text = "rezulto: " + Convert.ToString(result);
        }
    }
}
