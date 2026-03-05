using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the source presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        Aspose.Slides.ISlide srcSlide = pres.Slides[0];

        // Add a rectangle shape to the source slide
        Aspose.Slides.IShape shape = srcSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100f, 100f, 200f, 100f);

        // Move the shape
        shape.X = 150f;
        shape.Y = 150f;

        // Rotate the shape
        shape.Rotation = 45f;

        // Scale the shape (increase size by 1.5 times)
        shape.Width = shape.Width * 1.5f;
        shape.Height = shape.Height * 1.5f;

        // Create a blank layout slide for cloning
        Aspose.Slides.ILayoutSlide blankLayout = pres.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
        Aspose.Slides.ISlide destSlide = pres.Slides.AddEmptySlide(blankLayout);

        // Clone the transformed shape onto the new slide at a specific position
        Aspose.Slides.IShape clonedShape = destSlide.Shapes.AddClone(shape, 300f, 200f);

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}