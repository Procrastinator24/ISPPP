using ISPPP;
using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ScottPlot.Plottable;
using System.Net.NetworkInformation;
using System.IO;

namespace ISPPP
{
    public partial class MainForm : Form
    {
        private Workpiece[] _currentData;
        private Workpiece[] _modifiedData;
        private Workpiece[] _tmpData;

        int c = 0;
        private bool _arrHasExtendedSums;
        private MethodType _currentMethod = MethodType.Empty;
        private Dictionary<int, Color> _colorsPool;
        private Random _rnd = new Random(12);
        private OnOrderChangeHandler OrderChangedEvent;
        private OnOrderChangeHandler WorkpiecesChangedEvent;
        private delegate void OnOrderChangeHandler(MethodApplyEventArgs eventArgs);

		double[] values = { 40, 30, 20, 10 };
		string[] labels = { "A", "B", "C", "D", "E"};

	/*	private void OrderChangedHandler(MethodApplyEventArgs eventArgs)
        {
            if (richTextBox1.Text != "")
            {
                string message = "";
                message += "Выбранный алгоритм : " + eventArgs.method.ToString();
                message += Environment.NewLine;
                for (int i = 0; i < eventArgs.workpieces.Length; i++)
                {
                    message += eventArgs.workpieces[i].number.ToString() + " ";
                }
                message += Environment.NewLine;


                message += "Время до изготовления всех деталей : ";

                Workpiece[] tmpData = Workpiece.Copy(eventArgs.workpieces);
                tmpData = PetrovSokolicinMethod.Petrov_Sokolicin(tmpData, eventArgs.has_extended_sum);

                int delta = eventArgs.has_extended_sum == true ? 3 : 0;
                message += tmpData[tmpData.Length - 1].times[tmpData[0].times.Length - delta - 1] + Environment.NewLine;

                richTextBox1.AppendText(message);
            }
        }*/
       /* private void WorkpiecesChangedHandler(MethodApplyEventArgs eventArgs)
        {
            if (richTextBox1.Text != "")
            {
                string message = "";
                message += "Выбранный алгоритм : " + eventArgs.method.ToString();
                message += Environment.NewLine;
                for (int i = 0; i < eventArgs.workpieces.Length; i++)
                {
                    message += eventArgs.workpieces[i].number.ToString() + " ";
                }
                message += Environment.NewLine;

                message += "Время до изготовления всех деталей : ";

                Workpiece[] tmpData = Workpiece.Copy(eventArgs.workpieces);
                tmpData = PetrovSokolicinMethod.Petrov_Sokolicin(tmpData, eventArgs.has_extended_sum);

                int delta = eventArgs.has_extended_sum == true ? 3 : 0;
                message += tmpData[tmpData.Length - 1].times[tmpData[0].times.Length - delta - 1] + Environment.NewLine;


				richTextBox1.Text = message;
           }
        }*/
        public MainForm()
        {
          //  WorkpiecesChangedEvent += WorkpiecesChangedHandler;

            InitializeComponent();
            Initializate();
          //  OrderChangedEvent += OrderChangedHandler;
        }
        private void Initializate()
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog2.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            UpdateFormsPlots();
        }
      
        private void UpdateFormsPlots()
        {
            formsPlot1.Refresh();
            formsPlot3.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

		}
        
        #region sceneMethods
        public Dictionary<int, Color> GenerateColorPoolArray(Workpiece[] workpieces)
        {
            Dictionary<int, Color> color_pool = new Dictionary<int, Color>();
            for (int i = 0; i < workpieces.Length; i++)
            {
                color_pool.Add(workpieces[i].number, Color.FromArgb((byte)_rnd.Next(0, 255), (byte)_rnd.Next(0, 255), (byte)_rnd.Next(0, 255)));
            }

            return color_pool;
        }
        private bool TryFindPolygonUnderMouse((double x, double y) mousePos, out ScottPlot.Plottable.Polygon polygon, out (int machine_index, int part_index) indexes)
        {
            polygon = null;
            indexes = (0, 0);
            if (_tmpData != null)
            {
                int delta = _arrHasExtendedSums ? 3 : 0;
                int n = (int)(mousePos.y + 0.25);
                if (n > 0 && n <= (_tmpData[0].times.Length - delta))
                {
                    var plottables = formsPlot1.plt.GetPlottables();
                    for (int i = 0; i < _tmpData.Length; i++)
                    {
                        int ni = (_tmpData[0].times.Length - delta - n);
                        int mi = i;
                        int index = (_tmpData[0].times.Length - delta) * mi + ni;
                        if (IsMouseUnderPolygon(mousePos.x, (ScottPlot.Plottable.Polygon)plottables[index]) == true)
                        {
                            polygon = (ScottPlot.Plottable.Polygon)plottables[index];
                            indexes = (ni, i);
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        private bool IsMouseUnderPolygon(double x, ScottPlot.Plottable.Polygon polygon)
        {
            if (x >= polygon.Xs[0] && x <= polygon.Xs[3])
            {
                return true;
            }
            return false;
        }

        private void Draw(Workpiece[] workpieces_counted_times, FormsPlot name, bool has_sum_columns = false)
        {
            int delta = 0;
            if (has_sum_columns == true)
            {
                delta = 3;
            }

            double[] xs;
            double[] ys;

            double prevT = 0;
            double pos = workpieces_counted_times[0].times.Length - delta;

          
            for (int i = 0; i < workpieces_counted_times.Length; i++)
            {
                for (int j = 0; j < workpieces_counted_times[0].times.Length - delta; j++)
                {
                    if (i == 0)
                    {
                        pos = workpieces_counted_times[0].times.Length - delta - j;
                        if (j == 0)
                        {
                            prevT = 0;
                        }
                        else
                        {
                            prevT = workpieces_counted_times[0].times[j - 1];
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            pos = workpieces_counted_times[0].times.Length - delta;
                            prevT = workpieces_counted_times[i - 1].times[0];
                        }
                        else
                        {
                            pos = workpieces_counted_times[0].times.Length - delta - j;
                            prevT = Math.Max(workpieces_counted_times[i].times[j - 1], workpieces_counted_times[i - 1].times[j]);
                        }
                    }

                    xs = new double[] { prevT, prevT, workpieces_counted_times[i].times[j], workpieces_counted_times[i].times[j] };
                    ys = new double[] { pos - 0.25, pos + 0.25, pos + 0.25, pos - 0.25 };

                    

                    var polygon = name.plt.AddPolygon(xs, ys, _colorsPool[workpieces_counted_times[i].number]);
                    if (j == 0)
                    {
                        polygon.Label = $"деталь {workpieces_counted_times[i].number}";
                    }
                }
            }

            //Нужно отрисовать всё по строкам, чтобы plt были заполнены последовательно. 

            double[] yPositions = new double[workpieces_counted_times[0].times.Length - delta];
            string[] yLabels = new string[workpieces_counted_times[0].times.Length - delta];
            for (int i = 0; i < workpieces_counted_times[0].times.Length - delta; i++)
            {
                yPositions[i] = workpieces_counted_times[0].times.Length - delta - i;
                yLabels[i] = $"станок №{ i + 1}";
            }

            name.plt.Legend(true);
            name.plt.YAxis.ManualTickPositions(yPositions, yLabels);
        }
        private void UpdateFormPlot(FormsPlot name)
        {
            name.Refresh();
        }
      
        (int machine_index, int part_index) last_indexes = (-1, -1);
        private void formsPlot1_LeftClicked(object sender, EventArgs e)
        {
            if (_currentData != null)
            {
                ScottPlot.Plottable.Polygon polygon;
                (int machine_index, int part_index) indexes;
                if (TryFindPolygonUnderMouse(formsPlot1.GetMouseCoordinates(), out polygon, out indexes) == true)
                {
                    //TMP 
                    if (last_indexes.part_index != -1)
                    {
                        setPartTimePolygonColorByIndex(last_indexes.part_index, _colorsPool[_tmpData[last_indexes.part_index].number]);
                    }
                    setPartTimePolygonColorByIndex(indexes.part_index, Color.Black);
                    last_indexes = indexes;

                    formsPlot3.plt.Title($"станок: {indexes.machine_index + 1}   деталь {_tmpData[indexes.part_index].number}");
                    formsPlot3.Refresh();
                }
                else
                {
                    formsPlot3.plt.Title("");
                    if (last_indexes.part_index != -1)
                    {
                        setPartTimePolygonColorByIndex(last_indexes.part_index, _colorsPool[_tmpData[last_indexes.part_index].number]);
                        formsPlot3.Refresh();
                    }
                    last_indexes = (-1, -1);
                }
            }
        }
        private void setPartTimePolygonColorByIndex(int part_index, Color color)
        {
            for (int i = 0; i < _currentData[0].times.Length; i++)
            {
                GetPolygonByIndexes(part_index, i).Color = color;
            }
        }
        private ScottPlot.Plottable.Polygon GetPolygonByIndexes(int part_index, int machine_index)
        {
            int mach_i = (_currentData[0].times.Length - machine_index) - 1;
            int part_i = part_index;
            int index = (_currentData[0].times.Length) * part_i + mach_i;

            return (ScottPlot.Plottable.Polygon)formsPlot3.plt.GetPlottables()[index];
        }
        #endregion sceneMethods

		#region menuItems
		private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
		private void данныеToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			FormData formData = new FormData(_currentData);
			if (formData.ShowDialog() == DialogResult.Yes)
			{
				formsPlot3.plt.Clear();
				formsPlot3.plt.YAxis.AutomaticTickPositions();
				formsPlot3.plt.Legend(false);
                formsPlot1.plt.Clear();
                formsPlot1.plt.YAxis.AutomaticTickPositions();
                formsPlot1.plt.Legend(false);
                UpdateFormsPlots();

				this._currentData = formData.Workpieces;
				_currentMethod = MethodType.Empty;
				if (_currentData.Length != 0)
				{
					if (_currentData[0].times.Length > 1)
					{
						_colorsPool = GenerateColorPoolArray(_currentData);

						OpenMethods();
					}
				}

				WorkpiecesChangedEvent?.Invoke(new MethodApplyEventArgs() { workpieces = _currentData });
			}
		}
		private void Jonson_Обощение_Click(int number, FormsPlot name)
        {
            if (_currentData != null)
            {
                _arrHasExtendedSums = false;

                name.plt.Clear();

                _tmpData = Workpiece.Copy(_currentData);
                _modifiedData = JonsonsMethod.Jonson(_tmpData, number);

                _tmpData = Workpiece.Copy(_modifiedData);
                _tmpData = PetrovSokolicinMethod.Petrov_Sokolicin(_tmpData, false);

                Draw(_tmpData, name,false);

                name.plt.SetAxisLimits(yMin: 0.75, yMax: _tmpData[0].times.Length + 0.5, xMin: 0, xMax: _tmpData[_tmpData.Length - 1].times[_tmpData[0].times.Length - 1]);

                UpdateFormPlot(name);

                OrderChangedEvent?.Invoke(new MethodApplyEventArgs() { workpieces = _modifiedData, method = _currentMethod, has_extended_sum = false });

				//richTextBox1.Text = "";
                ShowCriteriaInfoForAlgorithm(_currentData, _currentMethod, name);
            }
        }
        private void обобщение1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentMethod = MethodType.Jonson_1;
            FormsPlot name = formsPlot1;
            Jonson_Обощение_Click(1, name);
        }
        private void обобщение2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentMethod = MethodType.Jonson_2;
            FormsPlot name = formsPlot1;
            Jonson_Обощение_Click(2, name);
        }
        private void обобщение3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentMethod = MethodType.Jonson_3;
            FormsPlot name = formsPlot1;
            Jonson_Обощение_Click(3, name);
        }
        private void обобщение4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentMethod = MethodType.Jonson_4;
            FormsPlot name = formsPlot1;
            Jonson_Обощение_Click(4, name);
        }
        private void обобщение5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentMethod = MethodType.Jonson_5;
            FormsPlot name = formsPlot1;
            Jonson_Обощение_Click(5, name);
        }
        private void джонсонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormsPlot name = formsPlot1;
            _currentMethod = MethodType.Jonson_1;
           Jonson_Обощение_Click(1, name);
             _currentMethod = MethodType.Jonson_2;
            Jonson_Обощение_Click(2, name);
            _currentMethod = MethodType.Jonson_3;
            Jonson_Обощение_Click(3, name);
            _currentMethod = MethodType.Jonson_4;
            Jonson_Обощение_Click(4, name);
            _currentMethod = MethodType.Jonson_5;
            Jonson_Обощение_Click(5, name);

            /*if (_currentData[0].times.Length == 2)
            {
                _currentMethod = MethodType.Jonson_0;
                Jonson_Обощение_Click(1);
            }*/
        }
        private void джонсонToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if (_currentData != null)
            {
                if (_currentData[0].times.Length == 2)
                {
                    обобщение1ToolStripMenuItem.Enabled = false;
                    обобщение2ToolStripMenuItem.Enabled = false;
                    обобщение3ToolStripMenuItem.Enabled = false;
                    обобщение4ToolStripMenuItem.Enabled = false;
                    обобщение5ToolStripMenuItem.Enabled = false;
                }
                else
                {
                    обобщение1ToolStripMenuItem.Enabled = true;
                    обобщение2ToolStripMenuItem.Enabled = true;
                    обобщение3ToolStripMenuItem.Enabled = true;
                    обобщение4ToolStripMenuItem.Enabled = true;
                    обобщение5ToolStripMenuItem.Enabled = true;
                }
            }
        }
        private void сумма1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentMethod = MethodType.Petrov_sum_1;
            var name = formsPlot3;
            ПетровСоколицын_Click(1, name);
        }
        private void сумма2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentMethod = MethodType.Petrov_sum_2;
            var name = formsPlot3;
            ПетровСоколицын_Click(2, name);
        }
        private void сумма3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentMethod = MethodType.Petrov_difference;
            var name = formsPlot3;
            ПетровСоколицын_Click(3, name);
        }
        private void ПетровСоколицын_Click(int sum_number , FormsPlot name)
        {
            if (_currentData != null)
            {
                _arrHasExtendedSums = true;

                name.plt.Clear();

                _tmpData = Workpiece.Copy(_currentData);
                switch (sum_number)
                {
                    case 1:
                        {
                            _modifiedData = PetrovSokolicinMethod.GetSum1Workpieces(_tmpData);
                            break;
                        }
                    case 2:
                        {
                            _modifiedData = PetrovSokolicinMethod.GetSum2Workpieces(_tmpData);
                            break;
                        }
                    case 3:
                        {
                            _modifiedData = PetrovSokolicinMethod.GetDifferenceWorkpieces(_tmpData);
                            break;
                        }
                }

                _tmpData = Workpiece.Copy(_modifiedData);
                _tmpData = PetrovSokolicinMethod.Petrov_Sokolicin(_tmpData, true);

                Draw(_tmpData, name, true);

                name.plt.SetAxisLimits(yMin: 0.75, yMax: _tmpData[0].times.Length - 3 + 0.5, xMin: 0, xMax: _tmpData[_tmpData.Length - 1].times[_tmpData[0].times.Length - 4]);
                UpdateFormPlot(name);

                OrderChangedEvent?.Invoke(new MethodApplyEventArgs() { workpieces = _modifiedData, method = _currentMethod, has_extended_sum = true });

				//richTextBox1.Text = "";
                ShowCriteriaInfoForAlgorithm(_currentData, _currentMethod, name);
            }
        }
        private void загрузитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Save save = FileWork.Save(openFileDialog1.FileName);
                    _currentData = save.workpieces;
                    _currentMethod = save.method;
                    _colorsPool = GenerateColorPoolArray(_currentData);
                    FormsPlot name;
                    if(  new List<MethodType>() { MethodType.Jonson_0, MethodType.Jonson_1, MethodType.Jonson_2,
                    MethodType.Jonson_3,MethodType.Jonson_4,MethodType.Jonson_5}.Contains(_currentMethod))
                    {
                        name = formsPlot1;
                    }
                    else { name = formsPlot3; }
                    switch (save.method)
                    {
                        case MethodType.Empty:
                            {
                                break;
                            }
                        case MethodType.Jonson_0:
                            {
                                Jonson_Обощение_Click(1, name);
                                break;
                            }
                        case MethodType.Jonson_1:
                            {
                                Jonson_Обощение_Click(1, name);
                                break;
                            }
                        case MethodType.Jonson_2:
                            {
                                Jonson_Обощение_Click(2, name);
                                break;
                            }
                        case MethodType.Jonson_3:
                            {
                                Jonson_Обощение_Click(3, name);
                                break;
                            }
                        case MethodType.Jonson_4:
                            {
                                Jonson_Обощение_Click(4, name);
                                break;
                            }
                        case MethodType.Jonson_5:
                            {
                                Jonson_Обощение_Click(5, name);
                                break;
                            }
                        case MethodType.Petrov_sum_1:
                            {
                                ПетровСоколицын_Click(1, name);
                                break;
                            }
                        case MethodType.Petrov_sum_2:
                            {
                                ПетровСоколицын_Click(2, name);
                                break;
                            }
                        case MethodType.Petrov_difference:
                            {
                                ПетровСоколицын_Click(3, name);
                                break;
                            }
                    }

                    OpenMethods();
                    WorkpiecesChangedEvent?.Invoke(new MethodApplyEventArgs()
                    {
                        workpieces = save.method == MethodType.Empty ? _currentData : _modifiedData,
                        method = save.method
                    });
                }
                catch (Exception es)
                {
                    MessageBox.Show(
                                  es.Message,
                                  "Ошибка"/*"Файл имеет неправильный формат"*/,
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }


            }
        }
        private void ДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentData != null)
            {
                Save toSaveWorkpiece = new Save()
                {
                    workpieces = _currentData,
                    method = _currentMethod
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
					FileWork.Load(toSaveWorkpiece, saveFileDialog1.FileName);
                }
            }
        }
        private void ГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                formsPlot1.plt.SaveFig(saveFileDialog2.FileName);
                formsPlot3.plt.SaveFig(saveFileDialog2.FileName);
            }
        }
        private void OpenMethods()
        {
            АлгоритмToolStripMenuItem.Enabled = true;
        }
        #endregion menuItems

        private string DisplayWorkpieces(Workpiece[] workpieces, string message)
        {
            string info = "";

            info = message;
            info += Environment.NewLine;
            for (int i = 0; i < workpieces.Length; i++)
            {
                info += workpieces[i].number + " ";
            }

            return info;
        } 
        private void ShowCriteriaInfoForAlgorithm(Workpiece[] workpieces, MethodType method, FormsPlot name)
        {
            Workpiece[] tmpData = Workpiece.Copy(workpieces);

            int delta = 0;
            string message = "";
            switch (method)
            {
                case MethodType.Empty:
                    {
                        richTextBox1.AppendText(DisplayWorkpieces(workpieces, message));
                        break;
                    }
                case MethodType.Jonson_0:
                    {
                        tmpData = JonsonsMethod.JonsonClassic(tmpData);
                        break;
                    }
                case MethodType.Jonson_1:
                    {
                        tmpData = JonsonsMethod.Jonson(tmpData, 1);
                        break;
                    }
                case MethodType.Jonson_2:
                    {
                        tmpData = JonsonsMethod.Jonson(tmpData, 2);
                        break;
                    }
                case MethodType.Jonson_3:
                    {
                        tmpData = JonsonsMethod.Jonson(tmpData, 3);
                        break;
                    }
                case MethodType.Jonson_4:
                    {
                        tmpData = JonsonsMethod.Jonson(tmpData, 4);
                        break;
                    }
                case MethodType.Jonson_5:
                    {
                        tmpData = JonsonsMethod.Jonson(tmpData, 5);
                        break;
                    }
                case MethodType.Petrov_sum_1:
                    {
                        tmpData = PetrovSokolicinMethod.GetSum1Workpieces(tmpData);
                        break;
                    }
                case MethodType.Petrov_sum_2:
                    {
                        tmpData = PetrovSokolicinMethod.GetSum2Workpieces(tmpData);
                        break;
                    }
                case MethodType.Petrov_difference:
                    {
                        tmpData = PetrovSokolicinMethod.GetDifferenceWorkpieces(tmpData);
                        break;
                    }
            }
            message = MethodTypeExtensions.GetPlanMethodDescriptionByEnumType(method);

            richTextBox1.AppendText(DisplayWorkpieces(tmpData, message) + "\n");
           

            if (!((int)method >= 21 && (int)method <= 23) == false)
            {
                delta = 3;
                tmpData = PetrovSokolicinMethod.Petrov_Sokolicin(tmpData, true);
            }
            else
            {
                tmpData = PetrovSokolicinMethod.Petrov_Sokolicin(tmpData, false);
            }

            ICriteria[] criterias = CriteriesMethods.GetAllCriteries();
            for (int i = 0; i < criterias.Length; i++)
            {
                richTextBox1.AppendText("");
                if (i == 0)
                {
                    double[] sum = (double[])criterias[i].CountCriteria(tmpData, delta);

					Color[] colors = new Color[sum.Length];

					for (int j = 0; j < sum.Length; j++)
					{
						int red = (j * 70) % 256; 
						int green = (j * 100) % 256; 
						int blue = (j * 150) % 256; 
						colors[j] = Color.FromArgb(red, green, blue);
					}
					
					var plt = new ScottPlot.Plot(600, 400);
					string[] labels = new string[sum.Length]; 

					for (int j = 0; j < sum.Length; j++)
					{
						labels[j] = $"#{j + 1}";
					}

					string[] labels2 = new string[sum.Length];

					for (int j = 0; j < sum.Length; j++)
					{
						labels2[j] = $"станок #{j + 1}";
					}

					var pie = plt.AddPie(sum);

                    pie.SliceLabels = labels;

					
                    pie.ShowValues = true;
					pie.Explode = true;

                    pie.LegendLabels = labels2;

                    plt.Legend();
                    plt.SaveFig($"pie_legend{c}.png");
					pie.ShowLabels = true;
					//formsPlot2.Plot.Add(pie);
					//formsPlot2.Plot.SetAxisLimits(-1, 1, -1, 1);
					//formsPlot2.Render();

					if (System.IO.File.Exists($"pie_legend{c}.png"))
					{
						System.Drawing.Image image = System.Drawing.Image.FromFile($"pie_legend{c}.png");
                        var picture = name == formsPlot3 ? pictureBox3 : pictureBox1;
						picture.Image = image;
					}
                    c++;
				}
                if (i == 1)
                {
                    richTextBox1.AppendText(criterias[i].GetInfo(tmpData, delta) + "\n");
                }
            }
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void formsPlot3_Load(object sender, EventArgs e)
        {

        }

        private void петровСоколицынToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                _currentMethod = MethodType.Jonson_1;
                FormsPlot name = formsPlot1;
                Jonson_Обощение_Click(1, name);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                _currentMethod = MethodType.Jonson_2;
                FormsPlot name = formsPlot1;
                Jonson_Обощение_Click(2, name);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked) { 
                _currentMethod = MethodType.Jonson_3;
                FormsPlot name = formsPlot1;
                Jonson_Обощение_Click(3, name);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton4.Checked)
            { 
                _currentMethod = MethodType.Jonson_4;
                FormsPlot name = formsPlot1;
                Jonson_Обощение_Click(4, name);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                _currentMethod = MethodType.Jonson_5;
                FormsPlot name = formsPlot1;
                Jonson_Обощение_Click(5, name);
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                _currentMethod = MethodType.Petrov_sum_1;
                var name = formsPlot3;
                ПетровСоколицын_Click(1, name);
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                _currentMethod = MethodType.Petrov_sum_2;
                var name = formsPlot3;
                ПетровСоколицын_Click(2, name);
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                _currentMethod = MethodType.Petrov_difference;
                var name = formsPlot3;
                ПетровСоколицын_Click(3, name);
            }
        }

        private void АлгоритмToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newWindow = new Form1();
            newWindow.Show();
        }
    }
}
