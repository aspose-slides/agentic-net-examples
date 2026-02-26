using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define column widths and row heights for the initial table
            double[] columnWidths = new double[] { 50, 50, 50 };
            double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

            // Insert a new column after the first column
            Aspose.Slides.IColumn templateColumn = table.Columns[0];
            // Insert a clone of the template column at index 1 (after the first column)
            table.Columns.InsertClone(1, templateColumn, true);

            // Save the presentation
            presentation.Save("InsertColumn.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}