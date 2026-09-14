// -----------------------------------------------------------------------------
// Example: Export MathML from PowerPoint Slides with Diagnostic Console Output
//
// Description:
// This console application loads a PowerPoint PPTX file using Aspose.Slides for .NET,
// iterates through each slide and auto shape, extracts the text content (assumed to
// contain MathML), and writes each MathML string to the console for debugging.
// It demonstrates handling missing input files, format‑unsupported exceptions,
// and saves the presentation after processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML export, diagnostic output
//
// Use Cases:
// - Debugging MathML extraction from presentation slides during development.
// - Verifying that each slide contains correctly formatted MathML strings.
// - Automating batch processing of presentations to log MathML content.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesMathMLExport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!System.IO.File.Exists(inputPath))
            {
                System.Console.WriteLine("Error: Input file '" + inputPath + "' does not exist.");
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                System.Console.WriteLine("Error: The file format is not supported. " + ex.Message);
                return;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: Failed to load presentation. " + ex.Message);
                return;
            }

            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                System.Console.WriteLine("Slide " + (slideIndex + 1) + ":");

                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Process only AutoShape objects that contain a TextFrame.
                    if (shape is Aspose.Slides.AutoShape)
                    {
                        Aspose.Slides.AutoShape autoShape = (Aspose.Slides.AutoShape)shape;
                        if (autoShape.TextFrame != null)
                        {
                            string textContent = autoShape.TextFrame.Text;
                            if (!string.IsNullOrEmpty(textContent))
                            {
                                // Assume the text content holds MathML.
                                System.Console.WriteLine("  Shape " + (shapeIndex + 1) + " MathML:");
                                System.Console.WriteLine(textContent);
                            }
                        }
                    }
                }
            }

            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                System.Console.WriteLine("Presentation saved to '" + outputPath + "'.");
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                System.Console.WriteLine("Error: Unable to save presentation. " + ex.Message);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: Unexpected exception during save. " + ex.Message);
            }
        }
    }
}
