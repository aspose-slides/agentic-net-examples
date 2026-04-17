using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string sourcePath = "source.pptx";
        string destinationPath = "cloned.pptx";

        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath))
            using (Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation())
            {
                // Clone slide with its master
                Aspose.Slides.ISlide sourceSlide = srcPres.Slides[0];
                Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                destPres.Slides.AddClone(sourceSlide, destMaster, true);

                // Rename title of the destination presentation
                destPres.DocumentProperties.Title = "Cloned Slide Presentation";

                // Save the destination presentation
                destPres.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors
            Console.WriteLine(ex.Message);
        }
    }
}