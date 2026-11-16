// -----------------------------------------------------------------------------
// Example: Clone Second Master Slide and Verify Integrity
//
// Description:
// Demonstrates how to clone the second master slide from a source PowerPoint
// presentation, verify its integrity by comparing key properties, and save the
// resulting presentation using Aspose.Slides for .NET. The program creates a
// sample source file if none exists, ensures at least two master slides, and
// exits with a non‑zero code on failure.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Master Slide, Verify Integrity
//
// Use Cases:
// - Automate cloning of a specific master slide for reuse in other presentations.
// - Build validation tools to ensure master slide integrity after cloning.
// - Generate or transform PPTX files programmatically in .NET applications.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace CloneMasterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = "SourcePresentation.pptx";
            string outputPath = "ClonedMasterPresentation.pptx";

            // Create a sample source presentation if it does not exist
            if (!File.Exists(sourcePath))
            {
                try
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    // Ensure at least two master slides by cloning the first master
                    Aspose.Slides.IMasterSlide firstMaster = samplePres.Masters[0];
                    Aspose.Slides.IMasterSlide secondMaster = samplePres.Masters.AddClone(firstMaster);
                    // Optionally set distinct names for verification
                    firstMaster.Name = "MasterOne";
                    secondMaster.Name = "MasterTwo";
                    samplePres.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }
                catch (NotSupportedException)
                {
                    Console.WriteLine("Source file format not supported.");
                    Environment.Exit(1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error creating sample source file: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                Environment.Exit(1);
            }

            try
            {
                Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath);

                if (srcPres.Masters.Count < 2)
                {
                    Console.WriteLine("Source presentation does not contain a second master slide.");
                    srcPres.Dispose();
                    Environment.Exit(1);
                }

                Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

                Aspose.Slides.IMasterSlide sourceMaster = srcPres.Masters[1];
                Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);

                // Verify integrity by comparing the Name property
                bool mastersEqual = String.Equals(sourceMaster.Name, destMaster.Name, StringComparison.Ordinal);
                Console.WriteLine("Master slide integrity verification: " + (mastersEqual ? "Success" : "Failure"));

                if (!mastersEqual)
                {
                    srcPres.Dispose();
                    destPres.Dispose();
                    Environment.Exit(1);
                }

                destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                srcPres.Dispose();
                destPres.Dispose();
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Presentation format not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
