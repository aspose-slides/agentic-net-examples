// -----------------------------------------------------------------------------
// Example: Optimize PPTX by Removing Unused Masters and Enabling ZIP64
//
// Description:
// This console program loads a PowerPoint PPTX file, removes master and layout
// slides that are not referenced, and saves the presentation with ZIP64 support
// to handle large files. It creates a sample PPTX if none exists and includes
// error handling for missing files and unsupported formats.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove Unused Masters, ZIP64
//
// Use Cases:
// - Reduce size of PPTX files before distribution.
// - Automate cleanup of presentations in CI/CD pipelines.
// - Ensure large PPTX files are saved with ZIP64 to avoid archive limits.
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

        if (!File.Exists(inputPath))
        {
            try
            {
                using (Aspose.Slides.Presentation createPres = new Aspose.Slides.Presentation())
                {
                    Aspose.Slides.IMasterSlide masterSlide = createPres.Masters[0];
                    Aspose.Slides.ILayoutSlide layoutSlide = masterSlide.LayoutSlides[0];
                    Aspose.Slides.ISlide blankSlide = createPres.Slides.AddEmptySlide(layoutSlide);
                    createPres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                Console.WriteLine("Sample input file created: " + inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample input file: " + ex.Message);
                Environment.Exit(1);
            }
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Remove unused master slides.
                Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
                // Remove unused layout slides.
                Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);

                // Note: Image compression is not demonstrated here due to lack of
                // documented API in the provided context.

                // Set ZIP64 mode for saving large files.
                Aspose.Slides.Export.PptxOptions saveOptions = new Aspose.Slides.Export.PptxOptions();
                saveOptions.Zip64Mode = Aspose.Slides.Export.Zip64Mode.IfNecessary;

                // Save the optimized presentation.
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, saveOptions);
                Console.WriteLine("Presentation optimized and saved to: " + outputPath);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            Console.WriteLine("The presentation format is not supported.");
            Environment.Exit(1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
