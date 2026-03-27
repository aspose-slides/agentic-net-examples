using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
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
            Presentation pres = new Presentation(inputPath);

            // Get the source slide (first slide)
            ISlide srcSlide = pres.Slides[0];

            // Find the first SmartArt shape on the source slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = null;
            int smartArtIndex = -1;
            for (int i = 0; i < srcSlide.Shapes.Count; i++)
            {
                if (srcSlide.Shapes[i] is Aspose.Slides.SmartArt.ISmartArt)
                {
                    smartArt = (Aspose.Slides.SmartArt.ISmartArt)srcSlide.Shapes[i];
                    smartArtIndex = i;
                    break;
                }
            }

            if (smartArt == null || smartArtIndex == -1)
            {
                Console.WriteLine("No SmartArt shape found on the source slide.");
                pres.Dispose();
                return;
            }

            // Create a blank layout slide for cloning
            ILayoutSlide blankLayout = pres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);

            // Add a new empty slide using the blank layout
            ISlide destSlide = pres.Slides.AddEmptySlide(blankLayout);

            // Clone the SmartArt shape onto the destination slide
            IShapeCollection destShapes = destSlide.Shapes;
            IShapeCollection srcShapes = srcSlide.Shapes;
            destShapes.AddClone(srcShapes[smartArtIndex], 0f, 0f);

            // Retrieve the cloned SmartArt shape
            Aspose.Slides.SmartArt.ISmartArt clonedSmartArt = destSlide.Shapes[0] as Aspose.Slides.SmartArt.ISmartArt;

            if (clonedSmartArt != null)
            {
                // Apply a solid fill with 50% opacity (alpha = 128)
                clonedSmartArt.FillFormat.FillType = FillType.Solid;
                clonedSmartArt.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 255, 0, 0);
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Placeholder: Use an external image diff utility to compare visual differences between original and modified slides
            // Example: ImageDiffUtility.Compare("original_slide.png", "modified_slide.png");

            // Clean up
            pres.Dispose();
        }
    }
}