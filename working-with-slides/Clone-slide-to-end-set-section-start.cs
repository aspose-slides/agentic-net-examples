// -----------------------------------------------------------------------------
// Example: Clone Slide to End of Section and Set First Slide Number
//
// Description:
// This console program loads a PPTX file (or creates one if missing), adds a
// rectangle shape, creates two sections, clones the first slide into the second
// section, sets the presentation's first slide number, and saves the result.
// It demonstrates slide cloning, section handling, and slide numbering using
// Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slide, Section, First Slide Number
//
// Use Cases:
// - Automate cloning a slide into a specific section of a presentation.
// - Manage sections and customize slide numbering programmatically.
// - Build .NET utilities for PowerPoint content manipulation.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace CloneSlideToSection
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Ensure input file exists; create a simple one if it does not.
            if (!File.Exists(inputPath))
            {
                try
                {
                    using (Aspose.Slides.Presentation tempPres = new Aspose.Slides.Presentation())
                    {
                        tempPres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
                catch (Exception createEx)
                {
                    Console.WriteLine("Failed to create sample input file: " + createEx.Message);
                    Environment.Exit(1);
                }
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Add a rectangle shape to the first slide.
                    presentation.Slides[0].Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 200, 50, 300, 100);

                    // Create the first section starting with the first slide.
                    Aspose.Slides.ISection section1 = presentation.Sections.AddSection(
                        "Section 1", presentation.Slides[0]);

                    // Append an empty second section.
                    Aspose.Slides.ISection section2 = presentation.Sections.AppendEmptySection(
                        "Section 2");

                    // Clone the first slide and add it to the end of the presentation,
                    // which places it within the newly created second section.
                    Aspose.Slides.ISlide clonedSlide = presentation.Slides.AddClone(presentation.Slides[0]);

                    // Set the presentation's first slide number (affects numbering of all slides).
                    presentation.FirstSlideNumber = 5;

                    // Save the modified presentation.
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation processed and saved to: " + outputPath);
            }
            catch (Aspose.Slides.PptxEditException)
            {
                // Format not supported.
                Console.WriteLine("The file format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
