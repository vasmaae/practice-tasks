using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1;

public partial class FormPractise4 : Form
{
    public FormPractise4()
    {
        InitializeComponent();
    }
    static double firstSum  = 100000;
    static double secondSum = 200000;
    static double firstPercent = 0.1;
    static double secondPercent = 0.02;
    static int year = 1;
    private void button1_Click(object sender, EventArgs e)
    {
        while (true)
        {
            if (firstSum > secondSum) break;
            dataGridView1.Rows.Add(year++, firstSum, secondSum);
            firstSum  += firstSum * firstPercent;
            secondSum += secondSum * secondPercent;
        }
    }
}
