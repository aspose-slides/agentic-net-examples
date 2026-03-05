using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Assume the first shape on the slide is a table
            Aspose.Slides.ITable table = (Aspose.Slides.ITable)slide.Shapes[0];

            // Get the rows collection of the table
            Aspose.Slides.IRowCollection rows = table.Rows;

            // Use the first row as a template for the new row
            Aspose.Slides.IRow templateRow = rows[0];

            // Index at which to insert the new row (e.g., insert as the second row)
            int insertIndex = 1;

            // Insert a clone of the template row at the specified index
            rows.InsertClone(insertIndex, templateRow, false);

            // Save the modified presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}