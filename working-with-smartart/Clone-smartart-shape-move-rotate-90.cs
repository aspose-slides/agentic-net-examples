using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];

        // Add a SmartArt shape to the source slide
        Aspose.Slides.SmartArt.ISmartArt smartArt = sourceSlide.Shapes.AddSmartArt(50, 50, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

        // Create a blank layout slide for the new slide
        Aspose.Slides.ILayoutSlide blankLayout = presentation.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

        // Add a new empty slide using the blank layout
        Aspose.Slides.ISlide destSlide = presentation.Slides.AddEmptySlide(blankLayout);

        // Clone the SmartArt shape to the new slide and position it
        Aspose.Slides.IShape clonedShape = destSlide.Shapes.AddClone(smartArt, 100, 100);

        // Apply a rotation of 90 degrees to the cloned SmartArt
        clonedShape.Rotation = 90;

        // Save the presentation
        presentation.Save("CloneSmartArt.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}