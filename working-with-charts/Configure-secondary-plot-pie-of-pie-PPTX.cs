using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ConfigureSecondaryPlot
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a Pie‑of‑Pie chart
                    IChart pieOfPieChart = slide.Shapes.AddChart(
                        ChartType.PieOfPie,
                        0f, 0f, 500f, 500f);

                    // Configure secondary plot settings for the Pie‑of‑Pie chart
                    IChartSeries pieSeries = pieOfPieChart.ChartData.Series[0];
                    IChartSeriesGroup pieGroup = pieSeries.ParentSeriesGroup;
                    pieGroup.SecondPieSize = (ushort)150; // 150% of the first pie
                    pieGroup.PieSplitBy = PieSplitType.ByValue;
                    pieGroup.PieSplitPosition = 30.0; // Split points with value less than 30 go to secondary pie

                    // Add a Bar‑of‑Pie chart
                    IChart barOfPieChart = slide.Shapes.AddChart(
                        ChartType.BarOfPie,
                        0f, 520f, 500f, 500f);

                    // Configure secondary plot settings for the Bar‑of‑Pie chart
                    IChartSeries barSeries = barOfPieChart.ChartData.Series[0];
                    IChartSeriesGroup barGroup = barSeries.ParentSeriesGroup;
                    barGroup.SecondPieSize = (ushort)120; // 120% of the first bar
                    barGroup.PieSplitBy = PieSplitType.ByPercentage;
                    barGroup.PieSplitPosition = 20.0; // Points with less than 20% go to secondary bar

                    // Save the presentation
                    pres.Save("ConfigureSecondaryPlot.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}