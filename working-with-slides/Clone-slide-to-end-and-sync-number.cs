using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputFile = "source.pptx";
        string outputFile = "cloned_output.pptx";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(inputFile))
            {
                using (Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation())
                {
                    // Clone slide with its master to the destination presentation
                    Aspose.Slides.ISlide sourceSlide = srcPres.Slides[0];
                    Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                    Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                    destPres.Slides.AddClone(sourceSlide, destMaster, true);

                    // Synchronize slide number with source presentation
                    destPres.FirstSlideNumber = srcPres.FirstSlideNumber;

                    // Save the destination presentation
                    destPres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
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