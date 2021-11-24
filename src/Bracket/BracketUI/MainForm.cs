using Bracket;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BracketUI
{
    public partial class MainForm : Form
    {
        private BracketParameters _parameters;
        private Dictionary<object, ParameterName> _textBoxs;
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
                    textBox.Text = _parameters[_textBoxs[textBox]].Value.ToString();
                }
            }

            foreach (var textBox in _textBoxs)
            {
                ChangeLabel(textBox.Value);
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
            control.Text = $"from {_parameters[parameterName].Min} mm " +
                $"to {_parameters[parameterName].Max} mm";
        }

        private void ShowMessage(string message, object sender, MessageLevel level)
        {
            MessageBox.Show(message + "!", level.ToString(), MessageBoxButtons.OK, 
                level == MessageLevel.Error ? MessageBoxIcon.Error : 
                level == MessageLevel.Warning ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            ((Control)sender).Focus();
        }

        private void ChangeParameter(object sender)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Replace('.', ',');
            _parameters.SetParameter(_textBoxs[sender], double.Parse(((TextBox)sender).Text));
            switch (_textBoxs[sender])
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
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            try
            {
                ChangeParameter(sender);
            }
            catch (FormatException)
            {
                ShowMessage("The entered is not a number", sender, MessageLevel.Warning);
            }
            catch (ArgumentException exception)
            {
                ShowMessage(exception.Message, sender, MessageLevel.Warning);
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
            try
            {
                foreach (Control textBox in Controls)
                {
                    if (textBox is TextBox)
                    {
                         ChangeParameter(textBox);   
                    }
                }
                var bracketBuilder = new BracketBuilder();
                ShowMessage("Model will now begin construction", sender, MessageLevel.Info);
                bracketBuilder.CreateModel(_parameters);
            }
            catch (FormatException)
            {
                ShowMessage("The entered is not a number", sender, MessageLevel.Warning);
            }
            catch (ArgumentException exception)
            {
                ShowMessage(exception.Message, sender, MessageLevel.Warning);
            }
            catch (COMException exception)
            {
                ShowMessage(exception.Message, sender, MessageLevel.Error);
            }
        }
    }
}
