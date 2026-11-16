// -----------------------------------------------------------------------------
// Example: Batch replace rectangle fills with solid blue using C#
// 
// Description:
// This console program creates a sample PPTX if missing, loads a presentation,
// iterates through all slides and shapes, identifies rectangle auto shapes, and
// replaces their fill with a solid blue color using Aspose.Slides for .NET.
// The modified presentation is saved as a new file.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, rectangle fill, solid blue, batch processing
// 
// Use Cases:
// - Uniformly apply a corporate blue fill to all rectangle shapes in a deck.
// - Automate visual style updates across multiple presentations.
// - Integrate shape styling into CI pipelines for document consistency.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "sample_input.pptx";
        string outputPath = "sample_output.pptx";

        // Ensure sample input exists; create if missing
        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide sampleSlide = samplePresentation.Slides[0];
                Aspose.Slides.IAutoShape rectangle = sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 300, 150);
                rectangle.TextFrame.Text = "Sample Rectangle";
                rectangle.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                rectangle.FillFormat.SolidFillColor.Color = Color.LightGray;
                samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePresentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating sample input: " + ex.Message);
                Environment.Exit(1);
            }
        }

        // Verify input file existence
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            Environment.Exit(1);
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The file format is not supported.");
            Environment.Exit(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading presentation: " + ex.Message);
            Environment.Exit(1);
        }

        try
        {
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
                            autoShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                            autoShape.FillFormat.SolidFillColor.Color = Color.Blue;
                        }
                    }
                }
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing presentation: " + ex.Message);
            Environment.Exit(1);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
