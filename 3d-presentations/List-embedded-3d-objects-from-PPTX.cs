// -----------------------------------------------------------------------------
// Example: Enumerate Embedded 3D Objects in a PowerPoint Presentation
//
// Description:
// This console application loads a PPTX file, checks for its existence, and
// iterates through all slides to list shapes that contain 3‑D models. It uses
// Aspose.Slides for .NET to access the presentation and shape information,
// handling unsupported formats and other exceptions gracefully. The
// presentation is saved before the program exits.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D models, enumerate shapes, embedded 3D objects
//
// Use Cases:
// - Identify and report all 3‑D objects in a corporate presentation for review.
// - Validate that a PPTX file contains the expected number of 3‑D models before publishing.
// - Generate a summary report of 3‑D content for compliance or asset management.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath;
        if (args != null && args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
        {
            inputPath = args[0];
        }
        else
        {
            inputPath = "input.pptx";
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Error: File not found - " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

            int threeDCount = 0;
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    if (shape.ThreeDFormat != null)
                    {
                        threeDCount++;
                        Console.WriteLine("Slide {0}, Shape {1}: 3D object detected (Name: {2})",
                            slideIndex + 1,
                            shapeIndex + 1,
                            shape.Name);
                    }
                }
            }

            Console.WriteLine("Total 3D objects found: {0}", threeDCount);

            // Save the presentation (no modifications made, but required by specification)
            string outputPath = "output.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine("Presentation saved to: " + outputPath);
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // The provided file format is not supported by Aspose.Slides.
            Console.WriteLine("Error: The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling for unexpected errors.
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
