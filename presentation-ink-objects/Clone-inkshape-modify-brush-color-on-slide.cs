using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the source presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Source slide and its shapes
            Aspose.Slides.ISlide srcSlide = pres.Slides[0];
            Aspose.Slides.IShapeCollection srcShapes = srcSlide.Shapes;

            // Assume the first shape is an Ink shape
            Aspose.Slides.Ink.Ink srcInk = (Aspose.Slides.Ink.Ink)srcShapes[0];

            // Create a blank destination slide
            Aspose.Slides.ILayoutSlide blankLayout = pres.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
            Aspose.Slides.ISlide destSlide = pres.Slides.AddEmptySlide(blankLayout);
            Aspose.Slides.IShapeCollection destShapes = destSlide.Shapes;

            // Clone the Ink shape onto the destination slide
            Aspose.Slides.IShape clonedShape = destShapes.AddClone(srcShapes[0]);

            // Modify the brush color of the cloned Ink shape
            Aspose.Slides.Ink.Ink clonedInk = (Aspose.Slides.Ink.Ink)clonedShape;
            Aspose.Slides.Ink.IInkTrace[] traces = clonedInk.Traces;
            if (traces != null && traces.Length > 0)
            {
                Aspose.Slides.Ink.IInkBrush brush = traces[0].Brush;
                brush.Color = Color.Blue; // Set desired color
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}