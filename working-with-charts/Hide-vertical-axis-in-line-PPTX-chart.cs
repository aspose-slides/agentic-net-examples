using System;
using System.IO;
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

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                // Iterate through all shapes on the slide
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Check if the shape is a chart
                    Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                    if (chart != null)
                    {
                        // Process only line chart types
                        if (Aspose.Slides.Charts.ChartTypeCharacterizer.IsChartTypeLine(chart.Type))
                        {
                            // Hide the vertical axis using the correct IsVisible property
                            Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;
                            verticalAxis.IsVisible = false;
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}