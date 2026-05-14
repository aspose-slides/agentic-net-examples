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
                // Format not supported
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