// -----------------------------------------------------------------------------
// Example: Lazy load custom data for presentation using C#
//
// Description:
// Demonstrates how to lazily load a PowerPoint presentation while removing
// embedded binary objects, access presentation- and slide-level custom data
// tags only when needed, and save the modified file. The example uses
// Aspose.Slides for .NET to illustrate efficient handling of custom data in
// PPTX files within a console application.
//
// Keywords:
// C#, Aspose.Slides, PPTX, PowerPoint, Lazy Loading, Custom Data, Tags, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Load large PPTX files without loading embedded binary objects.
// - Retrieve and process custom data tags on presentations and slides on demand.
// - Build .NET tools that manipulate PowerPoint custom data efficiently.
// - Automate validation or transformation of PPTX files while minimizing memory usage.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation with embedded binary objects removed (lazy loading of custom data)
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.DeleteEmbeddedBinaryObjects = true;

        try
        {
            using (Presentation presentation = new Presentation(inputPath, loadOptions))
            {
                // Access presentation-level custom data tags only when needed
                ICustomData presentationCustomData = presentation.CustomData;
                if (presentationCustomData.Tags.Contains("Author"))
                {
                    string authorTag = presentationCustomData.Tags["Author"];
                    Console.WriteLine("Author tag: " + authorTag);
                }

                // Iterate through slides and lazily access each slide's custom data
                foreach (ISlide slide in presentation.Slides)
                {
                    ICustomData slideCustomData = slide.CustomData;
                    if (slideCustomData.Tags.Contains("SlideTag"))
                    {
                        string slideTag = slideCustomData.Tags["SlideTag"];
                        Console.WriteLine("Slide " + slide.SlideNumber + " tag: " + slideTag);
                    }
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Handle unsupported PPTX format
            Console.WriteLine("Unsupported PPTX format: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            // Handle unsupported PPT format
            Console.WriteLine("Unsupported PPT format: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
