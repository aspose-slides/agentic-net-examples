using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "ChartPresentation.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a Pie chart with sample data
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

                // Configure the first series data point (custom slice)
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
                series.DataPoints[0].Explosion = 30; // Explode first slice by 30%

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}