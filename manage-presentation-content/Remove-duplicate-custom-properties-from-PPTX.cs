// -----------------------------------------------------------------------------
// Example: Remove duplicate custom properties from PPTX using C#
//
// Description:
// Demonstrates how to remove duplicate custom properties from PPTX files using
// C# and Aspose.Slides for .NET. The example processes all presentations in a
// specified directory, identifies custom property name/value pairs that have
// already been encountered, and removes subsequent duplicates. The modified
// presentations are saved back to their original locations. This pattern can be
// used to clean up metadata across multiple PowerPoint files in automated
// workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Duplicate, Custom,
// Properties, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of duplicate custom properties from a batch of PPTX files.
// - Build C# tools for cleaning up PowerPoint presentation metadata.
// - Integrate presentation metadata validation into .NET applications.
// - Prepare PPTX files for publishing by ensuring unique custom properties.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides.Export;

namespace RemoveDuplicateCustomProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input directory containing presentations
            string inputDirectory = args.Length > 0 ? args[0] : "Presentations";

            // Verify directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Get all files in the directory
            string[] presentationFiles = Directory.GetFiles(inputDirectory);

            // Keep track of seen custom property name/value pairs
            HashSet<string> seenProperties = new HashSet<string>();

            foreach (string filePath in presentationFiles)
            {
                try
                {
                    // Load presentation
                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath);
                    Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

                    // Collect custom property names (cannot modify collection while iterating)
                    List<string> propertyNames = new List<string>();
                    for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
                    {
                        string propName = documentProperties.GetCustomPropertyName(i);
                        propertyNames.Add(propName);
                    }

                    // Remove duplicates
                    foreach (string propName in propertyNames)
                    {
                        object propValue = documentProperties[propName];
                        string key = propName + ":" + (propValue != null ? propValue.ToString() : "null");

                        if (seenProperties.Contains(key))
                        {
                            documentProperties.RemoveCustomProperty(propName);
                        }
                        else
                        {
                            seenProperties.Add(key);
                        }
                    }

                    // Save presentation (overwrites original)
                    presentation.Save(filePath, SaveFormat.Pptx);
                    presentation.Dispose();
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other errors
                    Console.WriteLine("Error processing file: " + filePath);
                    Console.WriteLine("Exception: " + ex.Message);
                    // If format not supported, comment accordingly
                    // Format not supported.
                }
            }
        }
    }
}
