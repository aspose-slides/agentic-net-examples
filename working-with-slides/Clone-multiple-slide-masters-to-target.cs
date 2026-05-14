using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for source template and destination presentation
        string sourcePath = "Template.pptx";
        string destinationPath = "ClonedMasters.pptx";

        // Verify that the source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist: " + sourcePath);
            return;
        }

        try
        {
            // Load the source presentation
            using (Presentation srcPres = new Presentation(sourcePath))
            {
                // Create a new empty destination presentation
                using (Presentation destPres = new Presentation())
                {
                    // Clone all master slides from the source to the destination
                    for (int i = 0; i < srcPres.Masters.Count; i++)
                    {
                        IMasterSlide sourceMaster = srcPres.Masters[i];
                        destPres.Masters.AddClone(sourceMaster);
                    }

                    // Optionally clone a slide to demonstrate usage of the cloned masters
                    if (srcPres.Slides.Count > 0 && destPres.Masters.Count > 0)
                    {
                        ISlide sourceSlide = srcPres.Slides[0];
                        IMasterSlide destMaster = destPres.Masters[0];
                        destPres.Slides.AddClone(sourceSlide, destMaster, true);
                    }

                    // Save the destination presentation
                    destPres.Save(destinationPath, SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}