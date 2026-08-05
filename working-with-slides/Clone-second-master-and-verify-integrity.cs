// -----------------------------------------------------------------------------
// Example: Clone second master and verify integrity using C#
//
// Description:
// Demonstrates how to clone the second master slide from a source PowerPoint
// presentation and verify its integrity by comparing the cloned master with the
// original using Aspose.Slides for .NET. The example loads a PPTX file, checks
// for the presence of at least two master slides, clones the second master into
// a new presentation, validates the clone, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Second Master, Verify,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of a specific master slide for reuse in other presentations.
// - Build validation tools to ensure master slide integrity after cloning.
// - Generate or transform PPTX files programmatically in .NET applications.
// - Verify presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneMasterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "SourcePresentation.pptx";
            string outputPath = "ClonedMasterPresentation.pptx";

            // Verify that the source file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Source file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the source presentation
                Presentation srcPres = new Presentation(inputPath);

                // Create a new destination presentation
                Presentation destPres = new Presentation();

                // Ensure the source presentation has at least two master slides
                if (srcPres.Masters.Count < 2)
                {
                    Console.WriteLine("Source presentation does not contain a second master slide.");
                    srcPres.Dispose();
                    destPres.Dispose();
                    return;
                }

                // Clone the second master slide (index 1) into the destination presentation
                IMasterSlide sourceMaster = srcPres.Masters[1];
                IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);

                // Verify that the cloned master slide is equal to the source master slide
                bool mastersEqual = sourceMaster.Equals(destMaster);
                Console.WriteLine("Master slide integrity verification: " + (mastersEqual ? "Success" : "Failure"));

                // Save the destination presentation
                destPres.Save(outputPath, SaveFormat.Pptx);

                // Clean up resources
                srcPres.Dispose();
                destPres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues, Aspose.Slides errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
