using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneSmartArtExample
{
    class Program
    {
        static void Main()
        {
            string inputPath = "SmartArtSource.pptx";
            string outputPath = "SmartArtCloned.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Ensure there is at least one slide
                Aspose.Slides.ISlide srcSlide = pres.Slides[0];
                Aspose.Slides.IShapeCollection srcShapes = srcSlide.Shapes;

                // Add a SmartArt shape to the source slide (if not already present)
                Aspose.Slides.SmartArt.ISmartArt smartArt = srcShapes.AddSmartArt(0f, 0f, 400f, 400f, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                // Create a blank layout slide for the destination slide
                Aspose.Slides.ILayoutSlide blankLayout = pres.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
                Aspose.Slides.ISlide destSlide = pres.Slides.AddEmptySlide(blankLayout);
                Aspose.Slides.IShapeCollection destShapes = destSlide.Shapes;

                // Clone the SmartArt shape (index 0) to the new slide, retaining formatting
                destShapes.AddClone(srcShapes[0], 50f, 50f);

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Aspose.Slides.PptxEditException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}