using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the input PPTX file
        string inputPath = "input.pptx";

        // Verify that the file exists before proceeding
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("File not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Presentation pres = new Presentation(inputPath))
        {
            // Iterate through all slides
            foreach (ISlide slide in pres.Slides)
            {
                // Iterate through all shapes on the slide
                foreach (IShape shape in slide.Shapes)
                {
                    // Process only chart shapes
                    if (shape is IChart chart)
                    {
                        // Calculate actual layout values for the chart
                        chart.ValidateChartLayout();

                        // Access the vertical axis and retrieve its actual maximum value
                        IAxis verticalAxis = chart.Axes.VerticalAxis;
                        double maxValue = verticalAxis.ActualMaxValue;

                        Console.WriteLine($"Slide {slide.SlideNumber}: Chart max vertical value = {maxValue}");
                    }
                }
            }

            // Save the presentation before exiting
            string outputPath = "output.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}