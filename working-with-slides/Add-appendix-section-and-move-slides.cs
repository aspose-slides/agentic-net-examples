// -----------------------------------------------------------------------------
// Example: Add Appendix Section and Reorder Slides in PowerPoint using C#
// 
// Description:
// This console program loads a PPTX file, creates an "Appendix" section starting
// at slide 12, optionally reorders slides, and saves the modified presentation.
// It demonstrates section management with Aspose.Slides for .NET.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, section management, appendix
// 
// Use Cases:
// - Automate adding a new section to existing presentations.
// - Programmatically organize slides into logical groups.
// - Prepare presentations with standardized appendix sections.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        try
        {
            // Ensure input file exists; create a sample presentation if missing.
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                // Ensure we have at least 12 slides.
                Aspose.Slides.ISlide referenceSlide = samplePres.Slides[0];
                for (int i = 1; i < 12; i++)
                {
                    samplePres.Slides.AddEmptySlide(referenceSlide.LayoutSlide);
                }
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            // Load the presentation.
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Verify there are enough slides for the requested start index.
            if (presentation.Slides.Count < 12)
            {
                Console.Error.WriteLine("The presentation does not contain at least 12 slides.");
                presentation.Dispose();
                Environment.Exit(1);
            }

            // Add an "Appendix" section starting at slide 12 (index 11).
            Aspose.Slides.ISlide startSlide = presentation.Slides[11];
            presentation.Sections.AddSection("Appendix", startSlide);

            // Optional: reorder the newly added section to the end.
            // Retrieve the newly added section.
            Aspose.Slides.ISection appendixSection = null;
            for (int i = 0; i < presentation.Sections.Count; i++)
            {
                if (presentation.Sections[i].Name == "Appendix")
                {
                    appendixSection = presentation.Sections[i];
                    break;
                }
            }
            if (appendixSection != null)
            {
                // Move the section to the last position.
                presentation.Sections.ReorderSectionWithSlides(appendixSection, presentation.Sections.Count - 1);
            }

            // Save the modified presentation.
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Presentation updated successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
