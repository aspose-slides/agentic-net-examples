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
            string sourcePath = "source.pptx";
            string destPath = "cloned_master.pptx";

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            try
            {
                // Load the source presentation
                using (Presentation sourcePres = new Presentation(sourcePath))
                {
                    // Ensure there is a second master slide to clone
                    if (sourcePres.Masters.Count < 2)
                    {
                        Console.WriteLine("Source presentation does not contain a second master slide.");
                        return;
                    }

                    // Get the second master slide (index 1)
                    IMasterSlide sourceMaster = sourcePres.Masters[1];

                    // Create a new destination presentation
                    using (Presentation destPres = new Presentation())
                    {
                        // Clone the second master slide into the destination presentation
                        IMasterSlide clonedMaster = destPres.Masters.AddClone(sourceMaster);

                        // Verify master integrity by comparing the original and cloned masters
                        bool areEqual = sourceMaster.Equals(clonedMaster);
                        Console.WriteLine("Cloned master integrity check: " + (areEqual ? "Equal" : "Not equal"));

                        // Save the destination presentation
                        destPres.Save(destPath, SaveFormat.Pptx);
                    }
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported file format
                Console.WriteLine("The presentation format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}