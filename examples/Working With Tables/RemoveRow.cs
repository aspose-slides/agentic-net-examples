using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the first slide in the presentation
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Locate the first table shape on the slide
        Aspose.Slides.ITable table = null;
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            if (shape is Aspose.Slides.ITable)
            {
                table = (Aspose.Slides.ITable)shape;
                break;
            }
        }

        // If a table is found, remove the first row (index 0) without deleting attached rows
        if (table != null)
        {
            table.Rows.RemoveAt(0, false);
        }

        // Save the modified presentation to a new file
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}