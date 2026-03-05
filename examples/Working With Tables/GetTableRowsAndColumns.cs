using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Define column widths and row heights
        double[] cols = new double[] { 50, 50, 50 };
        double[] rows = new double[] { 50, 30, 30, 30, 30 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, cols, rows);

        // Access and display row and column information
        Console.WriteLine("Row count: " + table.Rows.Count);
        Console.WriteLine("Column count: " + table.Columns.Count);

        // Iterate through rows
        foreach (Aspose.Slides.IRow row in table.Rows)
        {
            Console.WriteLine("Row minimal height: " + row.MinimalHeight);
        }

        // Iterate through columns
        foreach (Aspose.Slides.IColumn column in table.Columns)
        {
            Console.WriteLine("Column width: " + column.Width);
        }

        // Save the presentation
        pres.Save("TableRowsColumns.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
    }
}