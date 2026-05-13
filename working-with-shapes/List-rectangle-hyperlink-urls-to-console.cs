using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

public class Program
{
    public static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Load the presentation (load rule)
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format exception
            Console.WriteLine("Failed to load presentation. Format may not be supported.");
            Console.WriteLine("Error: " + ex.Message);
            return;
        }

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes in the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                // Check if the shape is a rectangle auto shape
                if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.ShapeType == Aspose.Slides.ShapeType.Rectangle)
                {
                    // Check if the shape has a hyperlink click assigned
                    Aspose.Slides.IHyperlink hyperlink = shape.HyperlinkClick;
                    if (hyperlink != null && hyperlink.ExternalUrl != null)
                    {
                        Console.WriteLine("Slide " + (slideIndex + 1) + ", Shape " + (shapeIndex + 1) + " URL: " + hyperlink.ExternalUrl);
                    }
                }
            }
        }

        try
        {
            // Save the presentation before exit (save rule)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle save exceptions (e.g., unsupported format)
            Console.WriteLine("Failed to save presentation. Format may not be supported.");
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            // Dispose the presentation
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}