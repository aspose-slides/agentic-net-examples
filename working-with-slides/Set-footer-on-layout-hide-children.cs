// -----------------------------------------------------------------------------
// Example: Set Footer Visibility on Layout and Hide on Child Slides
//
// Description:
// This console program loads a PowerPoint PPTX file, makes the footer visible on a
// selected layout slide, then hides the footer on all slides that use this layout.
// It demonstrates controlling footer visibility across slide hierarchies using
// Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, footer visibility, layout slide, child slides
//
// Use Cases:
// - Ensure a corporate footer appears only on master layouts but not on individual slides.
// - Customize slide footers dynamically during automated report generation.
// - Apply consistent footer settings across a presentation while allowing overrides.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Create a sample presentation if the input file does not exist
        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
                Console.WriteLine("Sample input presentation created: " + inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample presentation: " + ex.Message);
                Environment.Exit(1);
            }
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            Environment.Exit(1);
        }

        // Verify that a master layout exists
        if (presentation.Masters.Count == 0 || presentation.Masters[0].LayoutSlides.Count == 0)
        {
            Console.WriteLine("Presentation does not contain any master layouts or layout slides.");
            presentation.Dispose();
            Environment.Exit(1);
        }

        // Select the first layout slide
        Aspose.Slides.ILayoutSlide layoutSlide = presentation.Masters[0].LayoutSlides[0];

        // Set footer visibility and text on the layout slide
        Aspose.Slides.IBaseSlideHeaderFooterManager layoutFooterMgr = layoutSlide.HeaderFooterManager;
        layoutFooterMgr.SetFooterVisibility(true);
        layoutFooterMgr.SetFooterText("Company Footer");

        // Hide footer on all child slides that use this layout
        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
        {
            if (slide.LayoutSlide == layoutSlide)
            {
                Aspose.Slides.IBaseSlideHeaderFooterManager slideFooterMgr = slide.HeaderFooterManager;
                slideFooterMgr.SetFooterVisibility(false);
            }
        }

        // Save the modified presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine("Presentation saved successfully to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
            presentation.Dispose();
            Environment.Exit(1);
        }

        presentation.Dispose();
    }
}
