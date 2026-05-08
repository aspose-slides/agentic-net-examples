using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetChartDataLabelBackgroundTransparent
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Enable data labels for the first series
                IChartSeries series = chart.ChartData.Series[0];
                series.Labels.DefaultDataLabelFormat.ShowValue = true;

                // Set data label background to transparent (no fill)
                // DataLabelFormat.Format returns IFormat, which has Fill property
                series.Labels.DefaultDataLabelFormat.Format.Fill.FillType = FillType.NoFill;

                // Save the presentation
                try
                {
                    pres.Save("ChartDataLabelTransparent.pptx", SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format exception
                    // Format not supported
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}