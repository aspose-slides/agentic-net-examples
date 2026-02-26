using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Assume the first shape on the slide is a table
            Aspose.Slides.ITable table = (Aspose.Slides.ITable)slide.Shapes[0];

            // Delete the column at index 1 (second column) without removing attached rows
            table.Columns.RemoveAt(1, false);

            // Save the modified presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}