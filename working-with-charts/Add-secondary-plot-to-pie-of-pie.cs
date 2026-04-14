using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddSecondaryPlotToPieOfPie
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a Pie of Pie chart with float literals for position and size
                    IChart chart = slide.Shapes.AddChart(ChartType.PieOfPie, 0f, 0f, 500f, 400f);

                    // Access the first series (the primary series)
                    IChartSeries series = chart.ChartData.Series[0];

                    // Adjust the size of the secondary pie (percentage of the first pie)
                    // Use the ParentSeriesGroup to set the writable property
                    IChartSeriesGroup group = series.ParentSeriesGroup;
                    group.SecondPieSize = (ushort)150; // 150% of the first pie size

                    // Optionally, set the split position to define which points go to the secondary pie
                    group.PieSplitBy = PieSplitType.ByValue;
                    group.PieSplitPosition = 30.0; // values less than 30 go to the secondary pie

                    // Save the presentation
                    pres.Save("PieOfPie_SecondaryPlot.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, external resources)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}