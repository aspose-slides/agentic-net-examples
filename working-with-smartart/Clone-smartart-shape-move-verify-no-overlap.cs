using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneSmartArtExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "CloneSmartArt.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt shape to the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                0,          // x-coordinate
                0,          // y-coordinate
                400,        // width
                400,        // height
                Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Clone the SmartArt shape and move the clone to (100, 200)
            Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(smartArt, 100, 200);

            // Verify that the original and cloned shapes do not overlap
            bool overlap = !(smartArt.X + smartArt.Width <= clonedShape.X ||
                             clonedShape.X + clonedShape.Width <= smartArt.X ||
                             smartArt.Y + smartArt.Height <= clonedShape.Y ||
                             clonedShape.Y + clonedShape.Height <= smartArt.Y);

            if (overlap)
            {
                Console.WriteLine("The cloned SmartArt overlaps with the original.");
            }
            else
            {
                Console.WriteLine("The cloned SmartArt does not overlap with the original.");
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}