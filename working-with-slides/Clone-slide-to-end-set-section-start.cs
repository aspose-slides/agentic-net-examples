// -----------------------------------------------------------------------------
// Example: Clone slide to end set section start using C#
//
// Description:
// Demonstrates how to clone a slide to the end of a newly created section,
// set the presentation's first slide number, and work with sections using
// Aspose.Slides for .NET. The example loads an existing PPTX, adds shapes,
// creates sections, clones a slide into a section, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Slide, Section, Start,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning a slide into a specific section.
// - Manage sections and slide numbering in PowerPoint files.
// - Build .NET tools for presentation manipulation and automation.
// - Validate and transform PPTX content programmatically.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneSlideToSection
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Add a rectangle shape to the first slide (demonstration purpose)
                    presentation.Slides[0].Shapes.AddAutoShape(
                        ShapeType.Rectangle, 200, 50, 300, 100);

                    // Add first section starting from the first slide
                    presentation.Sections.AddSection("Section 1", presentation.Slides[0]);

                    // Append an empty second section
                    ISection section2 = presentation.Sections.AppendEmptySection("Section 2");

                    // Clone the first slide into the second section
                    presentation.Slides.AddClone(presentation.Slides[0], section2);

                    // Set the presentation's first slide number (affects numbering of sections)
                    presentation.FirstSlideNumber = 5; // Example start number for the section

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxEditException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
