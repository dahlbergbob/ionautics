﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hipster_Controller
{
    public partial class Hipster : UserControl
    {
        public event EventHandler CloseClick;

        public Hipster()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseClick?.Invoke(sender, e);
        }
    }
}
