// -----------------------------------------------------------------------------
// Example: Remove null custom properties from PPTX using C#
//
// Description:
// Demonstrates how to remove null custom properties from PPTX using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Null, Custom, 
// Properties, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate remove null custom properties from PPTX.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: program <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

                    int count = documentProperties.CountOfCustomProperties;
                    // Iterate backwards because removal changes the collection
                    for (int i = count - 1; i >= 0; i--)
                    {
                        string propertyName = documentProperties.GetCustomPropertyName(i);
                        object propertyValue = documentProperties[propertyName];
                        if (propertyValue == null)
                        {
                            bool removed = documentProperties.RemoveCustomProperty(propertyName);
                            if (removed)
                            {
                                Console.WriteLine("Removed null custom property: " + propertyName);
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
                // Format not supported.
            }
        }
    }
}
