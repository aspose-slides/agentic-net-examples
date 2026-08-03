// -----------------------------------------------------------------------------
// Example: Create master slide tag collection with defaults using C#
//
// Description:
// Demonstrates how to create a master slide tag collection with default
// entries using C# and Aspose.Slides for .NET. The example shows the required
// presentation-processing steps for PowerPoint files, adds default tags to
// the master slide's custom data, and saves the resulting presentation.
// Developers can use this pattern to automate PPTX workflows, embed metadata,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Master Slide, Tag Collection,
// Custom Data, Defaults, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding default metadata tags to a master slide.
// - Build C# tools for PowerPoint presentation processing and tagging.
// - Generate or transform PPTX files with embedded custom data in .NET.
// - Validate and enrich presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesTagExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Ensure there is at least one master slide
                if (presentation.Masters.Count > 0)
                {
                    // Get the first master slide
                    Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

                    // Access the tag collection of the master slide's custom data
                    Aspose.Slides.ITagCollection tagCollection = masterSlide.CustomData.Tags;

                    // Add default tags
                    tagCollection.Add("Author", "Default Author");
                    tagCollection.Add("Company", "Default Company");
                    tagCollection.Add("Category", "Default Category");
                }

                // Save the presentation
                try
                {
                    presentation.Save("MasterTagExample_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., file I/O)
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
