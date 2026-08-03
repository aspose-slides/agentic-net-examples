// -----------------------------------------------------------------------------
// Example: Add tag to slide and save presentation using C#
//
// Description:
// Demonstrates how to add a custom tag to a slide and save the presentation 
// using C# and Aspose.Slides for .NET. The example loads an existing PPTX file, 
// adds a tag to the first slide, and saves the modified presentation to an 
// output folder.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide, Tag, CustomData, Save, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding custom metadata to slides.
// - Build tools for PowerPoint presentation processing in .NET.
// - Generate or modify PPTX files with custom tags.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            System.String inputPath = "input.pptx";
            System.String outputDir = "output";
            System.String outputFileName = "output.pptx";

            // Check if input file exists
            if (!System.IO.File.Exists(inputPath))
            {
                System.Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Add a custom tag to the first slide (index 0)
                Aspose.Slides.ITagCollection slideTags = pres.Slides[0].CustomData.Tags;
                slideTags["CustomTag"] = "CustomValue";

                // Ensure output directory exists
                if (!System.IO.Directory.Exists(outputDir))
                    System.IO.Directory.CreateDirectory(outputDir);

                // Combine output path
                System.String outPath = System.IO.Path.Combine(outputDir, outputFileName);

                // Save the presentation
                pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                System.Console.WriteLine("The file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external resources)
                System.Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
