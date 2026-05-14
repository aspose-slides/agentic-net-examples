using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "source.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load source presentation
                using (Presentation srcPres = new Presentation(inputPath))
                {
                    // Create destination presentation
                    using (Presentation destPres = new Presentation())
                    {
                        // Clone first slide along with its master slide
                        ISlide sourceSlide = srcPres.Slides[0];
                        IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                        IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                        destPres.Slides.AddClone(sourceSlide, destMaster, true);

                        // Remove unused master and layout slides from the destination presentation
                        Compress.RemoveUnusedMasterSlides(destPres);
                        Compress.RemoveUnusedLayoutSlides(destPres);

                        // Save the resulting presentation
                        destPres.Save(outputPath, SaveFormat.Pptx);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
            }
        }
    }
}