using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var filePath = args.Length > 0 ? args[0] : "input.pptx";
            using (var presentation = new Aspose.Slides.Presentation(filePath))
            {
                for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    var slide = presentation.Slides[slideIndex];
                    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        var shape = slide.Shapes[shapeIndex];
                        if (shape is Aspose.Slides.ITable table)
                        {
                            for (var rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                            {
                                var row = table.Rows[rowIndex];
                                for (var colIndex = 0; colIndex < row.Count; colIndex++)
                                {
                                    var cell = row[colIndex];
                                    // Attempt to read RowSpan and ColumnSpan via reflection (if available)
                                    var rowSpanObj = cell.GetType().GetProperty("RowSpan")?.GetValue(cell);
                                    var colSpanObj = cell.GetType().GetProperty("ColumnSpan")?.GetValue(cell);
                                    var rowSpan = rowSpanObj != null ? (int)rowSpanObj : 1;
                                    var colSpan = colSpanObj != null ? (int)colSpanObj : 1;
                                    if (rowSpan > 1 || colSpan > 1)
                                    {
                                        Console.WriteLine($"Slide {slideIndex + 1}, Table shape {shapeIndex + 1}, Cell [{rowIndex}, {colIndex}] is merged (RowSpan={rowSpan}, ColumnSpan={colSpan}).");
                                    }
                                }
                            }
                        }
                    }
                }
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}