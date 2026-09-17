// -----------------------------------------------------------------------------
// Example: Validate Non-Empty Names for 3D Shapes in PowerPoint Presentation
//
// Description:
// This console application loads a PPTX file using Aspose.Slides for .NET,
// iterates through all slides and shapes, identifies 3‑D shapes via reflection,
// and checks that each 3‑D shape has a non‑empty Name property for proper identification.
// The program reports any missing names and saves the presentation after validation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D shape validation, shape name check
//
// Use Cases:
// - Ensure 3‑D objects in a corporate deck are properly labeled for later editing.
// - Automate quality checks on generated presentations before distribution.
// - Integrate into CI pipelines to enforce naming conventions on 3‑D content.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output_validated.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Error: Input file '" + inputPath + "' does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            Console.WriteLine("Error: The file format is not supported as PPTX. " + ex.Message);
            return;
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            Console.WriteLine("Error: The file format is not supported as PPT. " + ex.Message);
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: Failed to load presentation. " + ex.Message);
            return;
        }

        bool anyInvalid = false;

        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
        {
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                // Identify 3D shapes via reflection to avoid compile‑time dependency on Aspose.Slides.ThreeD
                Type shapeType = shape.GetType();
                if (shapeType.FullName != null && shapeType.FullName.Contains(".ThreeD."))
                {
                    string shapeName = shape.Name;
                    if (string.IsNullOrWhiteSpace(shapeName))
                    {
                        anyInvalid = true;
                        Console.WriteLine("Warning: 3D shape on slide " + (slide.SlideNumber) + " has an empty Name property.");
                    }
                }
            }
        }

        if (!anyInvalid)
        {
            Console.WriteLine("All 3D shapes have non‑empty names.");
        }

        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine("Presentation saved to '" + outputPath + "'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: Failed to save presentation. " + ex.Message);
        }
    }
}
