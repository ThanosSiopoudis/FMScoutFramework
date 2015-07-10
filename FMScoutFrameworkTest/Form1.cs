using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using FMScoutFramework.Core;

namespace FMScoutFrameworkTest
{
    public partial class Form1 : Form
    {
        public FMCore fmCore = new FMCore(FMScoutFramework.Core.Entities.DatabaseModeEnum.Realtime);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fmCore.GameLoaded += new Action(GameLoaded);
            new Action(() => fmCore.LoadData()).BeginInvoke((s) => { }, null);
        }

        public void GameLoaded()
        {
            Debug.WriteLine("Load Done");
        }
    }
}
