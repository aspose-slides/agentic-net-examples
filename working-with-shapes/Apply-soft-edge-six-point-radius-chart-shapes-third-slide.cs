using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths (can be overridden by command‑line arguments)
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (args.Length > 0)
        {
            inputPath = args[0];
        }
        if (args.Length > 1)
        {
            outputPath = args[1];
        }

        Aspose.Slides.Presentation presentation = null;

        try
        {
            if (File.Exists(inputPath))
            {
                // Load existing presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                // Create a new presentation with three slides
                presentation = new Aspose.Slides.Presentation();

                // Ensure there are at least three slides
                while (presentation.Slides.Count < 3)
                {
                    presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                }

                // Add a sample chart to the third slide for demonstration
                Aspose.Slides.Charts.IChart sampleChart = presentation.Slides[2].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f,
                    50f,
                    400f,
                    300f);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
            return;
        }
        catch (Exception ex)
        {
            // Handle other unexpected errors (e.g., I/O issues)
            Console.WriteLine("Error: " + ex.Message);
            return;
        }

        // Ensure the presentation has at least three slides
        while (presentation.Slides.Count < 3)
        {
            presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        }

        // Get the third slide (zero‑based index)
        Aspose.Slides.ISlide thirdSlide = presentation.Slides[2];

        // Apply soft edge with six‑point radius to every chart on the third slide
        for (int i = 0; i < thirdSlide.Shapes.Count; i++)
        {
            Aspose.Slides.Charts.IChart chartShape = thirdSlide.Shapes[i] as Aspose.Slides.Charts.IChart;
            if (chartShape != null)
            {
                // Enable soft edge effect
                chartShape.EffectFormat.EnableSoftEdgeEffect();

                // Set the radius to 6 points
                chartShape.EffectFormat.SoftEdgeEffect.Radius = 6.0;
            }
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}