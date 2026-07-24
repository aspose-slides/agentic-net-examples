// -----------------------------------------------------------------------------
// Example: Validate PPTX 3d texture formats using C#
//
// Description:
// Demonstrates how to validate the texture file formats used by 3‑D objects 
// in a PPTX presentation with Aspose.Slides for .NET. The example loads a 
// presentation, iterates through all slides and shapes, checks each shape that 
// has a ThreeDFormat, and provides a placeholder where texture format validation 
// can be performed. The presentation is then saved, allowing integration into 
// automated validation pipelines.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, 3D, Texture, Formats, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validation of texture formats used by 3‑D objects in PPTX files.
// - Build .NET tools that enforce texture‑format compliance before publishing.
// - Integrate texture‑format checks into CI/CD pipelines for PowerPoint assets.
// - Extend the placeholder to enforce specific corporate image standards.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Validate that all 3D objects use supported texture file formats
                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        IThreeDFormat threeDFormat = shape.ThreeDFormat;
                        if (threeDFormat != null)
                        {
                            // Placeholder for texture format validation.
                            // For example, if the shape uses a picture fill, you could inspect the image format here.
                            // Supported formats could be .png, .jpg, .jpeg, .bmp, etc.
                        }
                    }
                }

                // Save the presentation before exiting
                string outputPath = "output.pptx";
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Handle unsupported PPTX format
            Console.WriteLine("Unsupported PPTX format: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            // Handle unsupported PPT format
            Console.WriteLine("Unsupported PPT format: " + ex.Message);
        }
        catch (NotSupportedException ex)
        {
            // Handle other format-related errors
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
