using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input and output presentations
            string presentationPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            using (Presentation pres = new Presentation(presentationPath))
            {
                // Get the first slide and the first shape on it
                ISlide slide = pres.Slides[0];
                IShape shape = slide.Shapes[0];

                // Apply a horizontal flip by creating a new ShapeFrame with FlipH = True
                shape.Frame = new ShapeFrame(
                    shape.X,
                    shape.Y,
                    shape.Width,
                    shape.Height,
                    Aspose.Slides.NullableBool.True,   // Flip horizontally
                    Aspose.Slides.NullableBool.False,  // No vertical flip
                    shape.Rotation);

                // To apply a vertical flip instead, uncomment the following line:
                // shape.Frame = new ShapeFrame(shape.X, shape.Y, shape.Width, shape.Height, Aspose.Slides.NullableBool.False, Aspose.Slides.NullableBool.True, shape.Rotation);

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}