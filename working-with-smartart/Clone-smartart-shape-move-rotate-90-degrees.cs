using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];

                // Add a SmartArt shape to the source slide
                Aspose.Slides.SmartArt.ISmartArt smartArt = sourceSlide.Shapes.AddSmartArt(0f, 0f, 400f, 400f, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                // Get a blank layout slide from the master
                Aspose.Slides.ILayoutSlide blankLayout = presentation.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

                // Add a new empty slide using the blank layout
                Aspose.Slides.ISlide destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

                // Get shape collections
                Aspose.Slides.IShapeCollection sourceShapes = sourceSlide.Shapes;
                Aspose.Slides.IShapeCollection destinationShapes = destinationSlide.Shapes;

                // Clone the SmartArt shape to the new slide
                destinationShapes.AddClone(sourceShapes[0]);

                // Retrieve the cloned shape (it will be the last shape in the collection)
                Aspose.Slides.IShape clonedShape = destinationShapes[destinationShapes.Count - 1];

                // Apply a rotation of 90 degrees to the cloned SmartArt shape
                clonedShape.Rotation = 90f;

                // Save the presentation
                presentation.Save("ClonedSmartArt.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}