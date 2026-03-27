using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Get the source slide
            Aspose.Slides.ISlide srcSlide = pres.Slides[0];

            // Add a SmartArt diagram to the source slide
            Aspose.Slides.SmartArt.ISmartArt srcSmart = srcSlide.Shapes.AddSmartArt(0, 0, 400, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Create a blank layout slide for the destination slide
            Aspose.Slides.ILayoutSlide blankLayout = pres.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

            // Add a new empty slide using the blank layout
            Aspose.Slides.ISlide destSlide = pres.Slides.AddEmptySlide(blankLayout);

            // Clone the SmartArt shape onto the destination slide
            Aspose.Slides.IShapeCollection destShapes = destSlide.Shapes;
            Aspose.Slides.IShape clonedShape = destShapes.AddClone(srcSmart, 50, 50);
            Aspose.Slides.SmartArt.ISmartArt clonedSmart = (Aspose.Slides.SmartArt.ISmartArt)clonedShape;

            // Change the layout of the cloned SmartArt to RadialCycle
            clonedSmart.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.RadialCycle;

            // Compare node distribution between original and cloned SmartArt
            int originalNodeCount = srcSmart.AllNodes.Count;
            int clonedNodeCount = clonedSmart.AllNodes.Count;
            Console.WriteLine("Original SmartArt node count: " + originalNodeCount);
            Console.WriteLine("Cloned SmartArt node count after layout change: " + clonedNodeCount);

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            pres.Dispose();
        }
    }
}