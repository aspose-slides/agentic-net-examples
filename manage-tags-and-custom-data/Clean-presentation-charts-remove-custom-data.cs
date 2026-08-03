// -----------------------------------------------------------------------------
// Example: Clean presentation charts remove custom data using C#
//
// Description:
// Demonstrates how to clean a PowerPoint presentation by removing all custom
// XML parts (custom data) using C# and Aspose.Slides for .NET. The example
// loads a PPTX file, deletes any embedded custom XML data, and saves the
// cleaned presentation. This pattern helps prepare presentations for
// distribution or compliance by stripping proprietary or unwanted metadata.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clean, Presentation, Charts,
// Remove, Custom Data, XML Parts, Office Automation
//
// Use Cases:
// - Remove custom XML data from presentations before sharing.
// - Clean up chart-related custom data to ensure privacy.
// - Automate preparation of PPTX files for compliance or archiving.
// - Integrate presentation sanitization into .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCustomDataFromCharts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Remove all custom XML parts (custom data) from the presentation
                    foreach (ICustomXmlPart part in pres.AllCustomXmlParts)
                    {
                        part.Remove();
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
