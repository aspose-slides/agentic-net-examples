using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string sourcePath = "Source.pptx";
        string destinationPath = "Destination.pptx";

        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        try
        {
            using (Presentation srcPres = new Presentation(sourcePath))
            {
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
                    destPres.Save(destinationPath, SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}