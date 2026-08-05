// -----------------------------------------------------------------------------
// Example: Replace group alttext with id PPTX using C#
//
// Description:
// Demonstrates how to replace the AlternativeText of each group shape in a
// PowerPoint presentation with a generated unique identifier using C# and
// Aspose.Slides for .NET. The example loads an existing PPTX file, iterates
// through all slides and shapes, assigns a new alt text to every group shape,
// and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Group, Alttext, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate replacement of group shape alt text with unique IDs in PPTX files.
// - Build C# utilities for PowerPoint presentation metadata management.
// - Generate or transform PPTX files programmatically in .NET applications.
// - Validate and standardize group shape identifiers before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceGroupShapeAltText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported
                return;
            }

            // Iterate through all slides and shapes to replace group shape AlternativeText
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];
                    if (shape is IGroupShape)
                    {
                        IGroupShape groupShape = (IGroupShape)shape;
                        // Generate a unique identifier for the group shape
                        string newAltText = "GroupShape_" + slideIndex + "_" + shapeIndex;
                        groupShape.AlternativeText = newAltText;
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}
