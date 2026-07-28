// -----------------------------------------------------------------------------
// Example: Hide ruler show grid on each slide using C#
//
// Description:
// Demonstrates how to hide the ruler (where supported) and show the grid on each
// slide using C# and Aspose.Slides for .NET. The example creates a new presentation
// if the input file does not exist, or modifies an existing one, by setting the
// grid spacing to enable the grid. Hiding the ruler is not directly exposed via
// the Aspose.Slides API, and the code includes placeholders where such a setting
// would be applied if it becomes available. This pattern can be used to automate
// PPTX workflows, validate results, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide, Ruler, Show, Grid,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate hiding the ruler and showing the grid on each slide.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                // If the file does not exist, create a new presentation
                using (Presentation newPres = new Presentation())
                {
                    // Enable grid by setting a positive grid spacing (e.g., 72 points)
                    newPres.ViewProperties.GridSpacing = 72f;

                    // Note: Hiding the ruler is not directly exposed via the Aspose.Slides API.
                    // This placeholder demonstrates where such a setting would be applied if available.

                    // Save the newly created presentation
                    newPres.Save(outputPath, SaveFormat.Pptx);
                }
                return;
            }

            try
            {
                // Load the existing presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Enable grid on each slide by setting grid spacing
                    pres.ViewProperties.GridSpacing = 72f;

                    // Note: Hiding the ruler is not directly supported by the current API.
                    // If a property becomes available, it should be set here.

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other exceptions
                // Format not supported comment
                // Console.WriteLine("The file format is not supported: " + ex.Message);
            }
        }
    }
}
