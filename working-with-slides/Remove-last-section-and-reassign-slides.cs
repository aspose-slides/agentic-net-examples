// -----------------------------------------------------------------------------
// Example: Remove Last Section and Reassign Slides in PowerPoint using C#
//
// Description:
// Demonstrates how to remove the last section from a PowerPoint presentation
// and automatically reassign its slides using Aspose.Slides for .NET. The program
// creates a sample PPTX if none exists, removes the final section, reports slide
// and section counts before and after removal, and saves the updated file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove Section, Reassign Slides
//
// Use Cases:
// - Automate removal of the final section in a PPTX file.
// - Update slide counts after section modifications.
// - Integrate section management into .NET PowerPoint processing tools.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

        // Ensure input file exists; create a sample presentation if missing
        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();

                // Add two additional empty slides using the layout of the first slide
                Aspose.Slides.ILayoutSlide layout = samplePresentation.Slides[0].LayoutSlide;
                samplePresentation.Slides.AddEmptySlide(layout);
                samplePresentation.Slides.AddEmptySlide(layout);

                // Create two sections: first includes first two slides, second includes the last slide
                Aspose.Slides.ISlide firstSlide = samplePresentation.Slides[0];
                Aspose.Slides.ISlide thirdSlide = samplePresentation.Slides[2];
                samplePresentation.Sections.AddSection("First Section", firstSlide);
                samplePresentation.Sections.AddSection("Second Section", thirdSlide);

                samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePresentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample input file: " + ex.Message);
                Environment.Exit(1);
                return;
            }
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            int originalSlideCount = presentation.Slides.Count;
            int originalSectionCount = presentation.Sections.Count;

            if (originalSectionCount > 0)
            {
                int lastSectionIndex = originalSectionCount - 1;
                Aspose.Slides.ISection lastSection = presentation.Sections[lastSectionIndex];
                presentation.Sections.RemoveSectionWithSlides(lastSection);
            }
            else
            {
                Console.WriteLine("No sections found in the presentation.");
            }

            int newSlideCount = presentation.Slides.Count;
            int newSectionCount = presentation.Sections.Count;

            Console.WriteLine("Original slide count: " + originalSlideCount);
            Console.WriteLine("New slide count after removal: " + newSlideCount);
            Console.WriteLine("Original section count: " + originalSectionCount);
            Console.WriteLine("New section count after removal: " + newSectionCount);

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
