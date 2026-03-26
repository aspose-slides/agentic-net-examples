using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SecondaryPlotExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a Pie-of-Pie chart
            IChart pieOfPieChart = presentation.Slides[0].Shapes.AddChart(
                ChartType.PieOfPie, 50, 50, 400, 300);

            // Configure secondary plot options for the Pie-of-Pie chart
            pieOfPieChart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            pieOfPieChart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = (ushort)150; // 150%
            pieOfPieChart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = PieSplitType.ByPercentage;
            pieOfPieChart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 30.0; // 30%

            // Add a Bar-of-Pie chart (if supported)
            IChart barOfPieChart = presentation.Slides[0].Shapes.AddChart(
                ChartType.BarOfPie, 50, 400, 400, 300);

            // Configure secondary plot options for the Bar-of-Pie chart
            barOfPieChart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            barOfPieChart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = (ushort)120; // 120%
            barOfPieChart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = PieSplitType.ByPercentage;
            barOfPieChart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 25.0; // 25%

            // Save the presentation
            string outputPath = "SecondaryPlotChart.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}