using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BracketUI
{
    public partial class DrawingForm : Form
    {
        public DrawingForm()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.BracketDrawing;
        }

        private void DrawingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
