using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Presentation presentation = new Presentation("input.pptx");

        // Access the first slide (adjust index as needed)
        ISlide slide = presentation.Slides[0];

        // Locate the first table shape on the slide
        IShape tableShape = null;
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                tableShape = shape;
                break;
            }
        }

        // If a table was found, remove it from the slide
        if (tableShape != null)
        {
            slide.Shapes.Remove(tableShape);
        }

        // Save the modified presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}