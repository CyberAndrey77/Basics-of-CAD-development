using Bracket;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace BracketUI
{
    /// <summary>
    /// Форма для задания параметров модели.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Поле параметров.
        /// </summary>
        private readonly BracketParameters _parameters;

        /// <summary>
        /// Словарь с TextBoxs.
        /// </summary>
        private readonly Dictionary<object, ParameterName> _textBoxs;

        public MainForm()
        {
            InitializeComponent();

            _textBoxs = new Dictionary<object, ParameterName>
            {
                { plateLengthTextBox, ParameterName.PlateLength },
                { plateWidthTextBox, ParameterName.PlateWidth },
                { outerTubeDiameterTextBox, ParameterName.OuterTubeDiameter },
                { mountingHoleDiameterTextBox, ParameterName.MountingHoleRadius },
                { holeHeightTextBox, ParameterName.HoleHeight },
                { sideWallHeightTextBox, ParameterName.SideWallHeight }
            };

            _parameters = new BracketParameters();

            foreach (var keyValuePair in _textBoxs)
            {
                TextBox textBox = (TextBox)keyValuePair.Key;
                textBox.Text = _parameters[_textBoxs[textBox]].Value.ToString();
            }

            foreach (var textBox in _textBoxs)
            {
                ChangeLabel(textBox.Value);
            }

            pictureBox1.Image = Properties.Resources.PlateWidth;
        }

        /// <summary>
        /// Изменение label с максимальными и минимальными параметрами.
        /// </summary>
        /// <param name="parameterName">Имя параметра</param>
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

                case ParameterName.MountingHoleRadius:
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

        /// <summary>
        /// Показывает сообщение пользователю.
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="level">Уровень сообщения</param>
        /// <param name="sender">Объект, который вызвал метод</param>
        private void ShowMessage(string message, MessageLevel level, object sender = null)
        {
            var messageBoxItemDictionary = new Dictionary<MessageLevel, MessageBoxIcon>()
            {
                { MessageLevel.Error, MessageBoxIcon.Error },
                { MessageLevel.Warning, MessageBoxIcon.Warning },
                {MessageLevel.Info, MessageBoxIcon.Information }
            };

            MessageBox.Show(message + "!", level.ToString(), MessageBoxButtons.OK,
                messageBoxItemDictionary[level]);

            if (sender != null)
            {
                ((Control)sender).Focus();
            }
        }

        /// <summary>
        /// Смена текущего значения у параметра.
        /// Также меняет максимальные и минимальные значения у зависимых параметров.
        /// </summary>
        /// <param name="sender">Объект, который вызвал метод</param>
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
                case ParameterName.MountingHoleRadius:
                    {
                        ChangeLabel(ParameterName.HoleHeight);
                        ChangeLabel(ParameterName.SideWallHeight);
                    }
                    break;
                case ParameterName.SideWallHeight:
                    {
                        ChangeLabel(ParameterName.HoleHeight);
                        ChangeLabel(ParameterName.MountingHoleRadius);
                    }
                    break;
                case ParameterName.HoleHeight:
                    {
                        ChangeLabel(ParameterName.SideWallHeight);
                        ChangeLabel(ParameterName.MountingHoleRadius);
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
                ShowMessage("The entered is not a number", MessageLevel.Warning, sender);
            }
            catch (ArgumentException exception)
            {
                ShowMessage(exception.Message, MessageLevel.Warning, sender);
            }
        }
        
        private void textBox_Click(object sender, EventArgs e)
        {
           pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject(_textBoxs[sender].ToString());
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
                foreach (var keyValuePair in _textBoxs)
                {
                    ChangeParameter((TextBox)keyValuePair.Key);
                }
                var bracketBuilder = new BracketBuilder();

                Task.Run(() => ShowMessage("Model will now begin construction", MessageLevel.Info));
                bracketBuilder.CreateModel(_parameters);
            }
            catch (FormatException)
            {
                ShowMessage("The entered is not a number", MessageLevel.Warning, sender);
            }
            catch (ArgumentException exception)
            {
                ShowMessage(exception.Message, MessageLevel.Warning, sender);
            }
            catch (COMException exception)
            {
                ShowMessage(exception.Message, MessageLevel.Error, sender);
            }
        }
    }
}
