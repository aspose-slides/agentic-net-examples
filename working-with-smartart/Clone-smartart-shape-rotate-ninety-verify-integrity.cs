using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        var outputPath = "output.pptx";

        var pres = new Aspose.Slides.Presentation(inputPath);
        var srcSlide = pres.Slides[0];
        var srcShapes = srcSlide.Shapes;

        // Assume the first shape is a SmartArt diagram
        var srcSmartArt = srcShapes[0] as Aspose.Slides.SmartArt.ISmartArt;
        if (srcSmartArt == null)
        {
            Console.WriteLine("No SmartArt shape found on the source slide.");
            pres.Dispose();
            return;
        }

        var blankLayout = pres.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
        var destSlide = pres.Slides.AddEmptySlide(blankLayout);
        var destShapes = destSlide.Shapes;

        // Clone the SmartArt shape onto the new slide
        var clonedShape = destShapes.AddClone(srcShapes[0]);
        var clonedSmartArt = clonedShape as Aspose.Slides.SmartArt.ISmartArt;
        if (clonedSmartArt != null)
        {
            // Rotate the cloned SmartArt by 90 degrees
            clonedSmartArt.Rotation = 90f;
        }

        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}