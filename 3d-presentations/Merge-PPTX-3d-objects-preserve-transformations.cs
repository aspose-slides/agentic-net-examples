using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string sourcePath1 = "source1.pptx";
        string sourcePath2 = "source2.pptx";
        string outputPath = "merged.pptx";

        // Verify that source files exist
        if (!File.Exists(sourcePath1) || !File.Exists(sourcePath2))
        {
            Console.WriteLine("One or more source files do not exist.");
            return;
        }

        try
        {
            // Load source presentations
            Aspose.Slides.Presentation srcPres1 = new Aspose.Slides.Presentation(sourcePath1);
            Aspose.Slides.Presentation srcPres2 = new Aspose.Slides.Presentation(sourcePath2);

            // Create destination presentation
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

            // Clone first slide from the first source presentation with its master
            Aspose.Slides.ISlide sourceSlide1 = srcPres1.Slides[0];
            Aspose.Slides.IMasterSlide sourceMaster1 = sourceSlide1.LayoutSlide.MasterSlide;
            Aspose.Slides.IMasterSlide destMaster1 = destPres.Masters.AddClone(sourceMaster1);
            destPres.Slides.AddClone(sourceSlide1, destMaster1, true);

            // Clone first slide from the second source presentation with its master
            Aspose.Slides.ISlide sourceSlide2 = srcPres2.Slides[0];
            Aspose.Slides.IMasterSlide sourceMaster2 = sourceSlide2.LayoutSlide.MasterSlide;
            Aspose.Slides.IMasterSlide destMaster2 = destPres.Masters.AddClone(sourceMaster2);
            destPres.Slides.AddClone(sourceSlide2, destMaster2, true);

            // Save the merged presentation
            destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose all presentations
            srcPres1.Dispose();
            srcPres2.Dispose();
            destPres.Dispose();
        }
        catch (Aspose.Slides.PptxEditException)
        {
            // Format not supported
            Console.WriteLine("One of the files has an unsupported format.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}