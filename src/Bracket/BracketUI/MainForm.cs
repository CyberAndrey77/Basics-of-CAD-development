using Bracket;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using Kompas;

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

        //TODO:
        /// <summary>
        /// Словарь с TextBoxs.
        /// </summary>
        private readonly Dictionary<TextBox, ParameterName> _textBoxs;

        /// <summary>
        /// Словарь с Label.
        /// </summary>
        private readonly Dictionary<ParameterName, Label> _labels;

        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _labels = new Dictionary<ParameterName, Label>()
            {
                { ParameterName.PlateLength, minMaxPlateLengthLabel},
                { ParameterName.PlateWidth, minMaxPlateWidthLabel},
                { ParameterName.OuterTubeDiameter, minMaxOuterTubeDiameterLabel},
                { ParameterName.MountingHoleRadius, minMaxMountingHoleDiameterLabel},
                { ParameterName.HoleHeight, minMaxHoleHeightLabel},
                { ParameterName.SideWallHeight, minMaxSideWallHeightLabel},
                { ParameterName.PlaneThickness, minMaxPlaneThicknessLabel },
                { ParameterName.TubeHeight, minMaxTubeHieghtLabel },
                { ParameterName.DistanceFromWall, minMaxDistanceFromWallLabel }
            };

            _textBoxs = new Dictionary<TextBox, ParameterName>
            {
                { plateLengthTextBox, ParameterName.PlateLength },
                { plateWidthTextBox, ParameterName.PlateWidth },
                { outerTubeDiameterTextBox, ParameterName.OuterTubeDiameter },
                { mountingHoleDiameterTextBox, ParameterName.MountingHoleRadius },
                { holeHeightTextBox, ParameterName.HoleHeight },
                { sideWallHeightTextBox, ParameterName.SideWallHeight },
                { planeThicknessTextBox, ParameterName.PlaneThickness },
                { tubeHeightTextBox, ParameterName.TubeHeight },
                { distanceFromWallTextBox, ParameterName.DistanceFromWall }
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
            //StressTesting();
        }

        /// <summary>
        /// Изменение label с максимальными и минимальными параметрами.
        /// </summary>
        /// <param name="parameterName">Имя параметра</param>
        private void ChangeLabel(ParameterName parameterName)
        {
            Control control = _labels[parameterName];
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
                { MessageLevel.Info, MessageBoxIcon.Information }
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
        /// <param name="textBox">Объект, который вызвал метод</param>
        private void ChangeParameter(TextBox textBox)
        {
            textBox.Text = textBox.Text.Replace('.', ',');
            _parameters.SetParameter(_textBoxs[textBox], double.Parse(textBox.Text));

            switch (_textBoxs[textBox])
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
                case ParameterName.PlaneThickness:
                    {
                        ChangeLabel(ParameterName.HoleHeight);
                    }
                    break;
            }
        }

        /// <summary>
        /// Обработка события покидания Textbox, заносит данные в параметры.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                var textBox = (TextBox)sender;
                ChangeParameter(textBox);
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
        
        /// <summary>
        /// Обработка события клика на Textbox, меняет картинку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Click(object sender, EventArgs e)
        {
            //TODO: RSDN
           pictureBox1.Image = (Image)Properties.Resources.
                ResourceManager.GetObject(_textBoxs[(TextBox)sender].ToString());
        }

        /// <summary>
        /// Обработка открытия клика на кнопку для открытия другой формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OpenDrawingButton_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Обработка события нажатия на кнопку построения детали.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildButton_Click(object sender, EventArgs e)
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

        private void StressTesting()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var builder = new BracketBuilder();

            int countModel = 0;
            using (StreamWriter writer = new StreamWriter("A:\\TestSAPR\\log.txt", true))
            {
                while (true)
                {
                    builder.CreateModel(_parameters);
                    var computerInfo = new ComputerInfo();
                    var usedMemory = computerInfo.TotalPhysicalMemory - 
                        computerInfo.AvailablePhysicalMemory;
                    countModel++;
                    writer.WriteLineAsync($"{countModel}\t{stopWatch.ElapsedMilliseconds}\t{usedMemory}");
                    writer.Flush();
                }
            }
        }
    }
}
