using System;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Find the first table on the slide
        Aspose.Slides.ITable table = null;
        for (int i = 0; i < slide.Shapes.Count; i++)
        {
            Aspose.Slides.IShape shape = slide.Shapes[i];
            if (shape is Aspose.Slides.ITable)
            {
                table = (Aspose.Slides.ITable)shape;
                break;
            }
        }

        if (table != null)
        {
            // Get the columns collection of the table
            Aspose.Slides.IColumnCollection columns = table.Columns;

            // Use the first column as a template for the new column
            Aspose.Slides.IColumn templateColumn = columns[0];

            // Specify the index where the new column should be inserted
            int insertIndex = 1; // example: insert after the first column

            // Insert a clone of the template column at the specified index
            Aspose.Slides.IColumn[] newColumns = columns.InsertClone(insertIndex, templateColumn, false);
        }

        // Save the modified presentation
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}