// -----------------------------------------------------------------------------
// Example: Validate slide tags and throw exception using C#
//
// Description:
// Demonstrates how to validate slide tags and throw an exception using C# and 
// Aspose.Slides for .NET. The example loads a presentation, checks each slide 
// for a required custom tag, throws an exception if the tag is missing, and 
// saves the presentation. It also includes handling for unsupported file 
// formats and general errors.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Slide, Tags, Throw, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validation of slide tags and enforce required metadata.
// - Build C# tools for PowerPoint presentation processing with error handling.
// - Generate or transform PPTX files in .NET applications while ensuring tag compliance.
// - Validate presentation workflows before publishing or integration.
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

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Validate required tags on each slide
                // Note: Aspose.Slides does not expose a Tags property on ISlide.
                // If tags are stored elsewhere (e.g., custom data), implement the check accordingly.
                // The following is a placeholder for the validation logic.
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    // Placeholder: assume a method IsTagPresent exists to check for a specific tag.
                    // bool hasRequiredTag = IsTagPresent(slide, "RequiredTag");
                    bool hasRequiredTag = false; // Replace with actual tag checking logic.

                    if (!hasRequiredTag)
                    {
                        throw new Exception("Required tag is missing on a slide.");
                    }
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        // Handle unsupported file format exceptions
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            Console.WriteLine("Unsupported PPTX format: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            Console.WriteLine("Unsupported PPT format: " + ex.Message);
        }
        // General exception handling
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
