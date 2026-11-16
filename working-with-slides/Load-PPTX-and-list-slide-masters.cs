// -----------------------------------------------------------------------------
// Example: Load PPTX and List Slide Masters using C#
//
// Description:
// Demonstrates loading a PowerPoint PPTX file, enumerating its master slides,
// and printing each master slide's name using Aspose.Slides for .NET. The
// program creates a sample PPTX if none exists, then saves the presentation
// unchanged after inspection.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, List, Slide Masters
//
// Use Cases:
// - Retrieve and display master slide information from a PPTX file.
// - Build tools that analyze or validate slide master structures.
// - Automate reporting on presentation templates before further processing.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";

        // Ensure a sample PPTX exists
        if (!File.Exists(inputPath))
        {
            try
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                // Add an empty slide using the default master layout to guarantee a master exists
                samplePres.Slides.AddEmptySlide(samplePres.Slides[0].LayoutSlide);
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample PPTX: " + ex.Message);
                Environment.Exit(1);
            }
        }

        // Verify that the file exists before loading
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("File does not exist: " + inputPath);
            Environment.Exit(1);
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.IMasterSlideCollection masters = presentation.Masters;

            Console.WriteLine("Number of master slides: " + masters.Count);

            for (int i = 0; i < masters.Count; i++)
            {
                Aspose.Slides.IMasterSlide master = masters[i];
                Console.WriteLine("Master " + i + " Name: " + master.Name);
            }

            // Save the presentation unchanged
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
