using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace CloneSmartArtRotate
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first (default) slide
                    ISlide originalSlide = presentation.Slides[0];

                    // Add a SmartArt diagram to the original slide
                    ISmartArt smartArt = originalSlide.Shapes.AddSmartArt(50f, 50f, 400f, 300f, SmartArtLayoutType.BasicBlockList);

                    // Create a new blank slide
                    ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
                    ISlide newSlide = presentation.Slides.AddEmptySlide(blankLayout);

                    // Clone the SmartArt shape onto the new slide and position it at (0,0)
                    IShape clonedShape = newSlide.Shapes.AddClone(smartArt, 0f, 0f);

                    // Rotate the cloned SmartArt by 90 degrees
                    clonedShape.Rotation = 90f;

                    // Save the presentation
                    presentation.Save("CloneSmartArtRotated.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}