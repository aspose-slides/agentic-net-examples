// -----------------------------------------------------------------------------
// Example: Convert date strings in custom properties using C#
//
// Description:
// Demonstrates how to iterate through custom document properties of a PowerPoint
// presentation, detect string values that represent dates, convert them to
// DateTime objects, and save the updated presentation using Aspose.Slides for .NET.
// This console application shows the required steps for loading, processing,
// and saving PPTX files.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, custom properties, date conversion,
// DocumentProperties, presentation processing, Office automation
//
// Use Cases:
// - Convert string‑based date custom properties to proper DateTime types.
// - Prepare presentations for downstream processing that expects date values.
// - Automate validation and correction of metadata in PPTX files.
// - Integrate custom property handling into .NET PowerPoint workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
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
                Presentation presentation = new Presentation(inputPath);

                // Access document properties
                IDocumentProperties properties = presentation.DocumentProperties;

                // Iterate through custom properties
                for (int i = 0; i < properties.CountOfCustomProperties; i++)
                {
                    string propName = properties.GetCustomPropertyName(i);
                    object propValue = properties[propName];

                    // Check if the property value is a string that can be parsed as a date
                    if (propValue is string stringValue)
                    {
                        DateTime parsedDate;
                        if (DateTime.TryParse(stringValue, out parsedDate))
                        {
                            // Update the property with the DateTime object
                            properties[propName] = parsedDate;
                            Console.WriteLine($"Converted property '{propName}' to DateTime.");
                        }
                    }
                }

                // Save the updated presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., loading errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
