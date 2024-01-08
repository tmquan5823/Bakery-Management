﻿using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace GUI
{
    public partial class UCQuanLyDoanhThu : UserControl
    {
        public UCQuanLyDoanhThu()
        {
            InitializeComponent();
        }

        private void UCQuanLyDoanhThu_Load(object sender, EventArgs e)
        {
            cartesianChart1.Series = new LiveCharts.SeriesCollection()
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 10),
                        new ObservablePoint(2, 4),
                        new ObservablePoint(4, 7),
                    },
                    PointGeometrySize = 15
                }
            };
            DateTime day = dateTimePicker1.Value;
        }
    }
}
