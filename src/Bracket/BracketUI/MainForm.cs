using Bracket;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BracketUI
{
    public partial class MainForm : Form
    {
        private BracketParameters _parameters;
        private Dictionary<object, ParameterName> _textBoxs;
        private bool _isError;
        public MainForm()
        {
            InitializeComponent();

            _textBoxs = new Dictionary<object, ParameterName>
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
                    textBox.Text = _parameters[_textBoxs[textBox]].ToString();
                }
            }
            foreach (var name in Enum.GetValues(typeof(ParameterName)).Cast<ParameterName>())
            {
                ChangeLabel(name);
            }
            

            pictureBox1.Image = Properties.Resources.PlateWidth;
        }

        private void ChangeLabel(ParameterName parameterName)
        {
            Control control;
            switch (parameterName)
            {
                case ParameterName.PlateWidth:
                    {
                        control = minMaxPlateWidthLabel;
                    }
                    break;

                case ParameterName.PlateLength:
                    {
                        control = minMaxPlateLengthLabel;
                    }
                    break;

                case ParameterName.OuterTubeDiameter:
                    {
                        control = minMaxOuterTubeDiameterLabel;
                    }
                    break;

                case ParameterName.MountingHoleDiameter:
                    {
                        control = minMaxMountingHoleDiameterLabel;
                    }
                    break;

                case ParameterName.HoleHeight:
                    {
                        control = minMaxHoleHeightLabel;
                    }
                    break;

                case ParameterName.SideWallHeight:
                    {
                        control = minMaxSideWallHeightLabel;
                    }
                    break;
                default:
                    {
                        control = minMaxPlateWidthLabel;
                    }
                    break;
            }
            control.Text = $"from {_parameters[parameterName, "min"]} mm " +
                $"to {_parameters[parameterName, "max"]} mm";
        }

        private void ShowError(object sender, string message)
        {
            //((TextBox)sender).BackColor = System.Drawing.Color.FromArgb(240, 128, 128);
            //_isError = true;
            MessageBox.Show(message + "!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ((TextBox)sender).Focus();
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            try
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.Replace('.', ',');
                _parameters[_textBoxs[sender]] = double.Parse(((TextBox)sender).Text);
                switch(_textBoxs[sender])
                {
                    case ParameterName.PlateWidth:
                        {
                            ChangeLabel(ParameterName.OuterTubeDiameter);
                        }
                        break;

                    case ParameterName.OuterTubeDiameter:
                        {
                            ChangeLabel(ParameterName.PlateWidth);
                        }
                        break;
                    case ParameterName.MountingHoleDiameter:
                        {
                            ChangeLabel(ParameterName.HoleHeight);
                            ChangeLabel(ParameterName.SideWallHeight);
                        }
                        break;
                    case ParameterName.SideWallHeight:
                        {
                            ChangeLabel(ParameterName.HoleHeight);
                            ChangeLabel(ParameterName.MountingHoleDiameter);
                        }
                        break;
                    case ParameterName.HoleHeight:
                        {
                            ChangeLabel(ParameterName.SideWallHeight);
                            ChangeLabel(ParameterName.MountingHoleDiameter);
                        }
                        break;
                }

                //if (_isError)
                //{
                //    ((TextBox)sender).BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                //    _isError = false;
                //}
            }
            catch (FormatException)
            {
                ShowError(sender, "The entered is not a number");
            }
            catch (ArgumentException exception)
            {
                ShowError(sender, exception.Message);
            }
        }
        
        private void textBox_Click(object sender, EventArgs e)
        {
            switch(_textBoxs[sender])
            {
                case ParameterName.PlateWidth:
                    {
                        pictureBox1.Image = Properties.Resources.PlateWidth;
                    }
                    break;

                case ParameterName.PlateLength:
                    {
                        pictureBox1.Image = Properties.Resources.PlateLength;
                    }
                    break;

                case ParameterName.OuterTubeDiameter:
                    {
                        pictureBox1.Image = Properties.Resources.OuterTubeDiameter;
                    }
                    break;

                case ParameterName.MountingHoleDiameter:
                    {
                        pictureBox1.Image = Properties.Resources.MountingHoleDiameter;
                    }
                    break;

                case ParameterName.HoleHeight:
                    {
                        pictureBox1.Image = Properties.Resources.HoleHeight;
                    }
                    break;

                case ParameterName.SideWallHeight:
                    {
                        pictureBox1.Image = Properties.Resources.SideWallHeight;
                    }
                    break;
            }
        }

        private async void openDrawingButton_Click(object sender, EventArgs e)
        {
            openDrawingButton.Enabled = false;
            var drawingForm = new DrawingForm();
            await Task.Run(() =>
            {
                if (drawingForm.ShowDialog() == DialogResult.Cancel)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        openDrawingButton.Enabled = true;
                    }));
                }
            });
        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            foreach (Control textBox in Controls)
            {
                if (textBox is TextBox)
                {
                    textBox_Leave(textBox, e);
                }
            }
        }
    }
}
