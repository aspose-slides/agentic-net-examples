using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideMasterReorder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_reordered.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load source presentation
                Presentation sourcePres = new Presentation(inputPath);

                // Create destination presentation
                Presentation destPres = new Presentation();

                // Predefined priority list of master slide indices (example order)
                int[] priority = new int[] { 2, 0, 1 };

                // Clone masters to destination presentation according to priority
                foreach (int index in priority)
                {
                    if (index >= 0 && index < sourcePres.Masters.Count)
                    {
                        IMasterSlide sourceMaster = sourcePres.Masters[index];
                        destPres.Masters.AddClone(sourceMaster);
                    }
                }

                // Clone all slides; masters will be cloned automatically as needed
                foreach (ISlide slide in sourcePres.Slides)
                {
                    destPres.Slides.AddClone(slide);
                }

                // Save the reordered presentation
                destPres.Save(outputPath, SaveFormat.Pptx);

                // Dispose presentations
                sourcePres.Dispose();
                destPres.Dispose();

                Console.WriteLine("Presentation saved successfully.");
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}