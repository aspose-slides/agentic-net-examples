using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a plain line shape to the slide
        slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50f, 150f, 300f, 0f);

        // Retrieve the added line shape (last shape in the collection)
        Aspose.Slides.IShape lineShape = slide.Shapes[slide.Shapes.Count - 1];

        // Set the line weight to 0.5 points
        lineShape.LineFormat.Width = 0.5;

        // Save the presentation as PDF
        try
        {
            presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}