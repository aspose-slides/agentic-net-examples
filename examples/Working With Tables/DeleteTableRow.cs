using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Presentation pres = new Presentation("input.pptx");

        // Access the first slide in the presentation
        ISlide slide = pres.Slides[0];

        // Locate the first table shape on the slide
        ITable table = null;
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                table = (ITable)shape;
                break;
            }
        }

        // If a table was found, remove the row at the specified index
        if (table != null)
        {
            // Remove the row at index 1 (second row) without deleting attached rows
            table.Rows.RemoveAt(1, false);
        }

        // Save the modified presentation
        pres.Save("output.pptx", SaveFormat.Pptx);
    }
}