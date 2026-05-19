using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "CloneSmartArtRadial.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt shape with a basic layout
            Aspose.Slides.SmartArt.ISmartArt originalSmartArt = slide.Shapes.AddSmartArt(
                20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Get node count before cloning
            int originalNodeCount = originalSmartArt.AllNodes.Count;

            // Clone the SmartArt shape to a new position
            Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(originalSmartArt, 300, 0);
            Aspose.Slides.SmartArt.ISmartArt clonedSmartArt = clonedShape as Aspose.Slides.SmartArt.ISmartArt;

            // Change the layout of the cloned SmartArt to BasicRadial
            clonedSmartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicRadial;

            // Get node count after cloning (should be the same as original)
            int clonedNodeCount = clonedSmartArt.AllNodes.Count;

            // Output the node counts to the console
            Console.WriteLine("Original SmartArt node count: " + originalNodeCount);
            Console.WriteLine("Cloned SmartArt node count after layout change: " + clonedNodeCount);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}