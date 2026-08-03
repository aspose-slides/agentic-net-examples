// -----------------------------------------------------------------------------
// Example: Prefix tag names with project id using C#
//
// Description:
// Demonstrates how to prefix custom tag names with a project identifier using
// C# and Aspose.Slides for .NET. The example loads a PowerPoint presentation,
// iterates through its custom data tags, adds the specified project id as a
// prefix to each tag name, and saves the updated presentation. This pattern
// helps maintain consistent naming conventions across presentation assets.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Prefix, Tag Names, Project ID,
// Custom Data, Presentation Processing, Office Automation
//
// Use Cases:
// - Standardize custom tag names with a project-specific prefix.
// - Automate tag management in PowerPoint files during CI/CD pipelines.
// - Build .NET tools for bulk updating presentation metadata.
// - Ensure tag naming consistency before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PrefixTagNames
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            // Project identifier to prefix tag names
            string projectId = "Proj123_";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Access the presentation's custom tags
                    Aspose.Slides.ITagCollection tags = pres.CustomData.Tags;

                    // Collect existing tag names
                    List<string> existingNames = new List<string>();
                    foreach (string name in tags.GetNamesOfTags())
                    {
                        existingNames.Add(name);
                    }

                    // Prefix each tag name with the project identifier
                    foreach (string oldName in existingNames)
                    {
                        string value = tags[oldName];
                        string newName = projectId + oldName;

                        // Add the new prefixed tag
                        tags.Add(newName, value);
                        // Remove the old tag
                        tags.Remove(oldName);
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
