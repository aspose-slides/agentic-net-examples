using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the input and output PPTX files
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Load the presentation
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                var slide = presentation.Slides[0];

                // Assume the first shape on the slide is a chart
                var chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                // Get the first series of the chart
                var series = chart.ChartData.Series[0];

                // Retrieve the automatically assigned series fill color
                var automaticColor = series.GetAutomaticSeriesColor();

                // Output the color (ARGB format)
                Console.WriteLine($"Automatic series color: A={automaticColor.A}, R={automaticColor.R}, G={automaticColor.G}, B={automaticColor.B}");

                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}