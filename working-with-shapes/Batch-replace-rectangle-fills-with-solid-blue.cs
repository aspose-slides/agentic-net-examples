// -----------------------------------------------------------------------------
// Example: Batch replace rectangle fills with solid blue using C#
//
// Description:
// Shows how to load a PPTX file, iterate through all slides and shapes, 
// identify rectangle auto shapes, and replace their fill with a solid blue 
// color using Aspose.Slides for .NET. The example includes basic error handling 
// for missing files and unsupported formats, and saves the modified presentation.
//
// Keywords:
// C#, .NET, Aspose.Slides, PowerPoint, PPTX, rectangle, fill, solid blue, batch processing, automation
//
// Use Cases:
// - Convert all rectangle shapes in a presentation to a uniform solid blue fill.
// - Create automated tools for bulk styling of PowerPoint files.
// - Integrate shape fill updates into CI pipelines or document generation workflows.
// - Ensure visual consistency across multiple presentations programmatically.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Load the presentation
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Iterate through all slides and shapes
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                if (shape is Aspose.Slides.IAutoShape)
                {
                    Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                    if (autoShape.ShapeType == Aspose.Slides.ShapeType.Rectangle)
                    {
                        // Apply solid blue fill to rectangle shapes
                        autoShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        autoShape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
                    }
                }
            }
        }

        try
        {
            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            // Dispose the presentation object
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
