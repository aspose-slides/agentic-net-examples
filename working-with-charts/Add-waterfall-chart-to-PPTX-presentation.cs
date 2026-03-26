using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ComprehensiveOverview
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define source and output file paths
            string sourcePath = "SourcePresentation.pptx";
            string outputPath = "ComprehensiveOverview.pptx";

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source presentation not found: " + sourcePath);
                return;
            }

            // Load the source presentation
            using (Presentation srcPres = new Presentation(sourcePath))
            {
                // Create a new destination presentation
                using (Presentation destPres = new Presentation())
                {
                    // Get the first slide from the source presentation
                    ISlide sourceSlide = srcPres.Slides[0];

                    // Get the master slide associated with the source slide's layout
                    IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

                    // Clone the source master slide into the destination presentation
                    IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);

                    // Clone the source slide into the destination presentation using the cloned master
                    destPres.Slides.AddClone(sourceSlide, destMaster, true);

                    // Save the destination presentation
                    destPres.Save(outputPath, SaveFormat.Pptx);
                }
            }

            Console.WriteLine("Comprehensive overview created at: " + outputPath);
        }
    }
}