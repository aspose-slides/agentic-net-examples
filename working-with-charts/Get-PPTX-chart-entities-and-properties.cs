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
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

                    // Process only chart shapes
                    if (chart != null)
                    {
                        Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1}: Chart");
                        Console.WriteLine($"  Type: {chart.Type}");
                        Console.WriteLine($"  Has Title: {chart.HasTitle}");
                        Console.WriteLine($"  Has Legend: {chart.HasLegend}");
                        Console.WriteLine($"  Style: {chart.Style}");
                        Console.WriteLine($"  Width: {chart.Width}, Height: {chart.Height}");

                        // Use ChartTypeCharacterizer to get additional info
                        bool is2D = Aspose.Slides.Charts.ChartTypeCharacterizer.Is2DChart(chart.Type);
                        bool is3D = Aspose.Slides.Charts.ChartTypeCharacterizer.Is3DChart(chart.Type);
                        Console.WriteLine($"  Is 2D: {is2D}");
                        Console.WriteLine($"  Is 3D: {is3D}");
                    }
                }
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}