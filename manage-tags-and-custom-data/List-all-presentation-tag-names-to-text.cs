// -----------------------------------------------------------------------------
// Example: List all presentation tag names to text using C#
//
// Description:
// Demonstrates how to list all presentation tag names to a text file using C#
// and Aspose.Slides for .NET. The example shows the required presentation‑processing
// steps for PowerPoint files and produces the requested output in a standalone
// console application. Developers can use this pattern to automate PPTX workflows,
// extract custom tag information, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, List, Presentation, Tag Names,
// Text, Custom Data, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate listing all presentation tag names to a text file.
// - Build C# tools for extracting PowerPoint custom data tags.
// - Generate reports of tag names for validation or documentation.
// - Integrate tag extraction into .NET applications for PowerPoint automation.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TagLister
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "tags.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Access the tag collection
                    ITagCollection tagCollection = pres.CustomData.Tags;

                    // Retrieve all tag names
                    string[] tagNames = tagCollection.GetNamesOfTags();

                    // Write tag names to the output text file
                    using (StreamWriter writer = new StreamWriter(outputPath))
                    {
                        foreach (string tagName in tagNames)
                        {
                            writer.WriteLine(tagName);
                        }
                    }

                    // Save the presentation before exiting (no changes made)
                    pres.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // If the format is not supported, comment accordingly
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
