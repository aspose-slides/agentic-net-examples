// -----------------------------------------------------------------------------
// Example: Get slide by ID and set tags using C#
//
// Description:
// Demonstrates how to retrieve a slide by its persistent ID and assign custom
// tags to it using Aspose.Slides for .NET. The example loads a PPTX file,
// accesses the first slide via its ID, updates the slide's custom data tags,
// and saves the modified presentation. This pattern is useful for automating
// slide metadata management in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide, Tags, CustomData,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Retrieve a specific slide using its persistent ID.
// - Add or modify custom tags on a slide for metadata tracking.
// - Automate PPTX metadata updates in batch processing tools.
// - Integrate slide tag management into .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dataDir = "Data/";
        string inputPath = dataDir + "input.pptx";
        string outputPath = dataDir + "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Obtain the persistent ID of the first slide (example)
                System.UInt32 slideId = presentation.Slides[0].SlideId;

                // Access the slide by its persistent ID
                IBaseSlide slide = presentation.GetSlideById(slideId);

                // Update custom tags on the slide
                slide.CustomData.Tags["Tag1"] = "Value1";
                slide.CustomData.Tags.Add("Tag2", "Value2");

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // If the exception is due to an unsupported format, note it
            // (In a real scenario, check the exception type/message)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
