using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrencyParser
{
    public partial class PlotForm : Form
    {
        private readonly PlotView plotView;
        private readonly (double x, double y)[] function;

        public PlotForm((double x, double y)[] function)
        {
            InitializeComponent();
            this.function = function;

            this.Controls.Add(plotView = new PlotView()
            {
                Dock = DockStyle.Fill
            });
        }

        private void PlotForm_Load(object sender, EventArgs e)
        {
            var model = new PlotModel();

            model.Axes.Add(new DateTimeAxis() { Position = AxisPosition.Bottom, StringFormat = "dd.MM.yyyy HH:mm" });
            model.Axes.Add(new LinearAxis() { Position = AxisPosition.Left });

            var lineSeries1 = new OxyPlot.Series.LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White
            };

            foreach ((double x, double y) in function.Select(point => (x: point.x, y: point.y)).OrderBy(point => point.x))
            {
                lineSeries1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTimeOffset.FromUnixTimeMilliseconds((long)x).DateTime), y));
            }

            model.Series.Add(lineSeries1);

            plotView.Model = model;
        }
    }
}
