// -----------------------------------------------------------------------------
// Example: Hide slides without tag during slideshow using C#
//
// Description:
// Demonstrates how to hide slides that do not contain a specific custom tag 
// during a slideshow using C# and Aspose.Slides for .NET. The example loads a 
// PPTX file, checks each slide for the presence of a required tag in its 
// custom data collection, hides slides lacking the tag, and saves the result. 
// This pattern can be used to automate presentation filtering, prepare 
// slide decks for targeted audiences, or integrate tag‑based slide control 
// into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide, Slides, Tag, Custom Data, 
// Slideshow, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate hiding of slides that do not carry a specific custom tag.
// - Build C# tools for PowerPoint presentation processing based on metadata.
// - Generate or transform PPTX files in .NET applications with tag‑driven logic.
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
        // Paths for input and output presentations
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Tag that must be present on a slide to keep it visible
        string requiredTag = "MyTag";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];

                    // Hide the slide if it does not contain the required custom tag
                    // (Tags is a collection of key/value pairs attached to the slide)
                    if (!slide.Tags.ContainsKey(requiredTag))
                    {
                        slide.Hidden = true;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported file format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
