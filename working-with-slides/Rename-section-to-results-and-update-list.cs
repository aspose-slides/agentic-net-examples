// -----------------------------------------------------------------------------
// Example: Rename section to results and update list using C#
//
// Description:
// Demonstrates how to rename the third section of a PowerPoint presentation
// to "Results" and then output the names of all sections using C# and 
// Aspose.Slides for .NET. The example creates a sample presentation if none
// exists, performs the rename, lists section names to the console, and saves
// the modified file. This pattern can be used to automate section management
// in PPTX files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rename Section, Results, 
// Section List, Presentation Processing, Office Automation
//
// Use Cases:
// - Rename a specific section in a presentation to a desired name.
// - Retrieve and display all section names after modifications.
// - Build C# utilities for managing PPTX sections programmatically.
// - Integrate section renaming into larger PowerPoint automation workflows.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Ensure input file exists; if not, create a new presentation with sections
        if (!File.Exists(inputPath))
        {
            Presentation pres = new Presentation();
            ISlide slide1 = pres.Slides[0];
            ISlide slide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
            ISlide slide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
            ISlide slide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

            ISection section1 = pres.Sections.AddSection("Section 1", slide1);
            ISection section2 = pres.Sections.AddSection("Section 2", slide3);
            ISection section3 = pres.Sections.AppendEmptySection("Section 3");

            pres.Save(inputPath, SaveFormat.Pptx);
            pres.Dispose();
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);

            // Rename the third section (index 2) to "Results"
            ISection thirdSection = presentation.Sections[2];
            thirdSection.Name = "Results";

            // Display section names to verify the change
            for (int i = 0; i < presentation.Sections.Count; i++)
            {
                ISection sec = presentation.Sections[i];
                Console.WriteLine($"Section {i}: {sec.Name}");
            }

            // Save the updated presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
