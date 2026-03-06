using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ClearSpecificDataPointValues
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide and the first shape (assumed to be a chart)
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.IShape shape = slide.Shapes[0];

            // Cast the shape to a chart
            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

            // Clear data points of the first series if the chart exists and has series
            if (chart != null && chart.ChartData.Series.Count > 0)
            {
                chart.ChartData.Series[0].DataPoints.Clear();
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            pres.Dispose();
        }
    }
}