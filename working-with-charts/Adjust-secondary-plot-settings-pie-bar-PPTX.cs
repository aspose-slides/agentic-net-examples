using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AdjustSecondaryPlotSettings
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a Pie‑of‑Pie chart
            IChart pieOfPieChart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.PieOfPie,
                0f, 0f, 500f, 400f);

            // Configure secondary plot settings for the Pie‑of‑Pie chart
            IChartSeries pieSeries = pieOfPieChart.ChartData.Series[0];
            IChartSeriesGroup pieGroup = pieSeries.ParentSeriesGroup;
            pieGroup.SecondPieSize = (ushort)150; // 150% of the first pie
            pieGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
            pieGroup.PieSplitPosition = 30.0; // Split points with less than 30% go to the second pie

            // Add a Bar‑of‑Pie chart
            IChart barOfPieChart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.BarOfPie,
                0f, 420f, 500f, 400f);

            // Configure secondary plot settings for the Bar‑of‑Pie chart
            IChartSeries barSeries = barOfPieChart.ChartData.Series[0];
            IChartSeriesGroup barGroup = barSeries.ParentSeriesGroup;
            barGroup.SecondPieSize = (ushort)120; // 120% of the first bar
            barGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByValue;
            barGroup.PieSplitPosition = 20.0; // Split points with value less than 20 go to the second bar

            // Save the presentation
            pres.Save("AdjustSecondaryPlotSettings.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}