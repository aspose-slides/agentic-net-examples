// -----------------------------------------------------------------------------
// Example: Merge multiple PPTX presentations into SVG using C#
//
// Description:
// Demonstrates how to merge multiple PPTX presentations into a single presentation
// and then convert each slide of the merged presentation to SVG files using
// Aspose.Slides for .NET. The example creates an output folder, combines the
// source PPTX files, saves the combined PPTX, and generates individual SVG images
// for each slide.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Merge, Multiple, Presentations,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate merging of several PPTX files and exporting the result as SVG.
// - Build .NET tools for batch conversion of PowerPoint slides to scalable graphics.
// - Integrate PPTX merging and SVG export into document processing pipelines.
// - Validate and preview combined presentations before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation files (modify as needed)
        string[] inputFiles = new string[] { "input1.pptx", "input2.pptx" };

        // Output directory
        string outputDir = Path.Combine(Environment.CurrentDirectory, "Output");
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        // Path for the combined presentation
        string combinedPath = Path.Combine(outputDir, "Combined.pptx");

        // Create a new presentation to hold combined slides
        Presentation combinedPres = new Presentation();

        try
        {
            // Iterate over each input file and clone its slides into the combined presentation
            foreach (string inputFile in inputFiles)
            {
                if (!File.Exists(inputFile))
                {
                    // Input file does not exist; skip or handle as needed
                    continue;
                }

                // Load source presentation
                Presentation srcPres = new Presentation(inputFile);

                // Clone each slide from source to combined presentation
                for (int i = 0; i < srcPres.Slides.Count; i++)
                {
                    combinedPres.Slides.AddClone(srcPres.Slides[i]);
                }

                srcPres.Dispose();
            }

            // Save the combined presentation
            combinedPres.Save(combinedPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions as needed
        }

        // Convert combined slides to SVG files
        string svgFormatString = Path.Combine(outputDir, "slide_{0}.svg");
        try
        {
            for (int index = 0; index < combinedPres.Slides.Count; index++)
            {
                ISlide slide = combinedPres.Slides[index];
                using (FileStream stream = new FileStream(string.Format(svgFormatString, index + 1), FileMode.Create, FileAccess.Write))
                {
                    slide.WriteAsSvg(stream);
                }
            }
        }
        catch (Exception)
        {
            // Handle conversion exceptions as needed
        }

        // Save the combined presentation before exiting (already saved above)
        combinedPres.Dispose();
    }
}
