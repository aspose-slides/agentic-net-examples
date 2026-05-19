using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                0, 0, 400, 400,
                Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Clone the SmartArt shape and move the clone to (100, 200)
            Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(smartArt, 100, 200);

            // Verify that the cloned shape does not overlap the original
            float originalRight = smartArt.X + smartArt.Width;
            float originalBottom = smartArt.Y + smartArt.Height;
            float cloneRight = clonedShape.X + clonedShape.Width;
            float cloneBottom = clonedShape.Y + clonedShape.Height;

            bool noOverlap = (clonedShape.X >= originalRight) ||
                             (smartArt.X >= cloneRight) ||
                             (clonedShape.Y >= originalBottom) ||
                             (smartArt.Y >= cloneBottom);

            Console.WriteLine("No overlap: " + noOverlap);

            // Save the presentation
            presentation.Save("CloneSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}