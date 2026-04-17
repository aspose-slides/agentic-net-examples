using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string sourcePath = "source.pptx";
        string outputPath = "cloned_output.pptx";

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
                    // Get source slide and its master
                    ISlide sourceSlide = srcPres.Slides[0];
                    IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

                    // Clone master slide into destination presentation
                    IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);

                    // Clone source slide to the end of destination presentation
                    destPres.Slides.AddClone(sourceSlide, destMaster, true);

                    // Synchronize slide number with source presentation
                    destPres.FirstSlideNumber = srcPres.FirstSlideNumber;

                    // Save the destination presentation
                    destPres.Save(outputPath, SaveFormat.Pptx);
                }
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}