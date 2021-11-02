using Kompas6API5;
using Bracket;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace BracketUI
{
    public partial class MainForm : Form
    {
        private BracketParameters _parameters;
        private Dictionary<object, ParameterName> _textBoxControls;
        public MainForm()
        {
            InitializeComponent();

            _textBoxControls = new Dictionary<object, ParameterName>
            {
                { plateLengthTextBox, ParameterName.PlateLength },
                { plateWidthTextBox, ParameterName.PlateWidth },
                { outerTubeDiameterTextBox, ParameterName.OuterTubeDiameter },
                { mountingHoleDiameterTextBox, ParameterName.MountingHoleDiameter },
                { holeHeightTextBox, ParameterName.HoleHeight },
                { sideWallHeightTextBox, ParameterName.SideWallHeight }
            };

            _parameters = new BracketParameters();
            foreach (Control textBox in Controls)
            {
                if (textBox is TextBox)
                {
                    textBox.Text = _parameters[_textBoxControls[textBox]].ToString();
                }
            }

            pictureBox1.Image = Properties.Resources.PlateWidth;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            try
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.Replace('.', ',');
                _parameters[_textBoxControls[sender]] = double.Parse(((TextBox)sender).Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("The entered is not a number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ((TextBox)sender).Focus();
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message + "!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ((TextBox)sender).Focus();
            }
        }
        
        private void textBox_Click(object sender, EventArgs e)
        {
            switch(_textBoxControls[sender])
            {
                case ParameterName.PlateWidth:
                    {
                        pictureBox1.Image = Properties.Resources.PlateWidth;
                    }
                    break;

                case ParameterName.PlateLength:
                    {
                        pictureBox1.Image = BracketUI.Properties.Resources.PlateLength;
                    }
                    break;

                case ParameterName.OuterTubeDiameter:
                    {
                        pictureBox1.Image = BracketUI.Properties.Resources.OuterTubeDiameter;
                    }
                    break;

                case ParameterName.MountingHoleDiameter:
                    {
                        pictureBox1.Image = BracketUI.Properties.Resources.MountingHoleDiameter;
                    }
                    break;

                case ParameterName.HoleHeight:
                    {
                        pictureBox1.Image = BracketUI.Properties.Resources.HoleHeight;
                    }
                    break;

                case ParameterName.SideWallHeight:
                    {
                        pictureBox1.Image = BracketUI.Properties.Resources.SideWallHeight;
                    }
                    break;
            }
        }

        private void openDrawingButton_Click(object sender, EventArgs e)
        {
            var drawingForm = new DrawingForm();
            drawingForm.Show();
        }
    }
}
