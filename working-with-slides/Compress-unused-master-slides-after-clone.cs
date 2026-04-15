using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

namespace SlideCloneExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputFile = Path.Combine(Environment.CurrentDirectory, "source.pptx");
            string outputFile = Path.Combine(Environment.CurrentDirectory, "cloned_output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist: " + inputFile);
                return;
            }

            try
            {
                // Load source presentation
                Presentation srcPres = new Presentation(inputFile);
                // Create destination presentation
                Presentation destPres = new Presentation();

                // Clone first slide and its master from source to destination
                ISlide sourceSlide = srcPres.Slides[0];
                IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                destPres.Slides.AddClone(sourceSlide, destMaster, true);

                // Remove any unused masters and layouts after cloning
                Compress.RemoveUnusedMasterSlides(destPres);
                Compress.RemoveUnusedLayoutSlides(destPres);

                // Save the resulting presentation
                destPres.Save(outputFile, SaveFormat.Pptx);

                // Clean up resources
                srcPres.Dispose();
                destPres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle format not supported or other exceptions
                // Format not supported: comment added for clarity
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}