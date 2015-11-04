using Microsoft.Expression.Shapes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sampleproject
{
	/// <summary>
	/// PieChartControl.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class PieChartControl : UserControl
	{
        private DoubleCollection _chartItemCollection;

        public DoubleCollection ChartItemCollection
        {
            get { return _chartItemCollection; }
            set
            {
                _chartItemCollection = value;
                SetData();
            }
        }

        Color[] colorList = new Color[] {
            Colors.Red,Colors.Pink,Colors.Green,Colors.Yellow,Colors.Violet,Colors.YellowGreen,Colors.Black, Colors.Silver
        };

		public PieChartControl()
		{
			this.InitializeComponent();
		}

        public void SetData()
        {

            gd_ChartItemArea.Children.Clear();
            gd_ChartItemArea.Children.Add(MakeArea(0, ChartItemCollection[0], colorList[0]));
            for (int i = 1; i < ChartItemCollection.Count; i++)
            {
                gd_ChartItemArea.Children.Add(MakeArea(ChartItemCollection[i - 1], ChartItemCollection[i], colorList[i]));

            }
        }

        private static Arc MakeArea(double startAngle, double endAngle, Color fillColor)
        {
            Arc arc = new Arc();
            arc.Stretch = Stretch.None;
            arc.Width = 200;
            arc.Height = 200;

            arc.StartAngle = startAngle;
            arc.EndAngle = endAngle;
            arc.ArcThickness = 20;
            arc.StrokeThickness = 0.5;
            arc.Stroke = new SolidColorBrush(Colors.Black);
            arc.Fill = new SolidColorBrush(fillColor);
            return arc;
        }
	}
}