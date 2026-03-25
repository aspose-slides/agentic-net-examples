using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Presentation presentation = new Presentation(inputPath))
        {
            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Assume the first shape on the slide is a chart
            IChart chart = slide.Shapes[0] as IChart;
            if (chart == null)
            {
                Console.WriteLine("No chart found on the first slide.");
                return;
            }

            // Access the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Get the marker of the series
            IMarker marker = series.Marker;

            // Set marker fill color
            marker.Format.Fill.FillType = FillType.Solid;
            marker.Format.Fill.SolidFillColor.Color = Color.Blue;

            // Set marker border (line) color and width
            marker.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;
            marker.Format.Line.Width = 2.0f;

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}