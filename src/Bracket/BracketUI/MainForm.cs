using Kompas6API5;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bracket
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            pictureBox1.Image = BracketUI.Properties.Resources.PlateLength;
            //pictureBox1.Image = Image.FromFile(@"C:\Users\Andrey\source\repos\Basics-of-CAD-development\src\Bracket\Bracket\img\MountingHoleDiameter.png");
            //// KompasObject kompasObject = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            //Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
            //KompasObject kompas = (KompasObject)Activator.CreateInstance(t);
            //if (kompas != null)
            //{
            //    kompas.Visible = true;
            //    kompas.ActivateControllerAPI();
            //    ksDocument3D iDocument3D = (ksDocument3D)kompas.Document3D();
            //    iDocument3D.Create(false /*видимый*/, true /*деталь*/);
            //}
        }
    }
}
