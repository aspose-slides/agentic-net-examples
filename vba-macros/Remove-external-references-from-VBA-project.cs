// -----------------------------------------------------------------------------
// Example: Remove external references from VBA project using C#
//
// Description:
// Demonstrates how to remove all external references from a VBA project in a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// loads an existing PPTX file, replaces its VBA project with an empty one,
// and saves the result, effectively clearing any external library references.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, External, References, VBA,
// Project, Presentation Processing, Office Automation
//
// Use Cases:
// - Clean VBA projects by removing external library references.
// - Prepare presentations for distribution without dependency issues.
// - Automate VBA reference management in batch processing pipelines.
// - Integrate VBA cleanup into .NET PowerPoint manipulation tools.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

namespace RemoveVbaReferences
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            var inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            var outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                var pres = new Presentation(inputPath);

                // Replace existing VBA project with a new empty one (removes all external references)
                pres.VbaProject = new VbaProject();

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation
                pres.Dispose();

                Console.WriteLine("Presentation saved without external VBA references to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL loading issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
