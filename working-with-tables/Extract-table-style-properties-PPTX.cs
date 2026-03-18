using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var presentation = new Aspose.Slides.Presentation(inputPath);

            var slideCount = presentation.Slides.Count;
            for (int i = 0; i < slideCount; i++)
            {
                var slide = presentation.Slides[i];
                var shapeCount = slide.Shapes.Count;
                for (int j = 0; j < shapeCount; j++)
                {
                    var shape = slide.Shapes[j];
                    if (shape is Aspose.Slides.Table)
                    {
                        var table = (Aspose.Slides.Table)shape;

                        // Table level effective formatting
                        var tableEffective = table.TableFormat.GetEffective();
                        var tableFill = tableEffective.FillFormat;
                        Console.WriteLine($"Slide {i + 1}, Table {j + 1}: Table Fill Type = {tableFill.FillType}");

                        // First row effective formatting
                        if (table.Rows.Count > 0)
                        {
                            var rowEffective = table.Rows[0].RowFormat.GetEffective();
                            var rowFill = rowEffective.FillFormat;
                            Console.WriteLine($"  First Row Fill Type = {rowFill.FillType}");
                        }

                        // First column effective formatting
                        if (table.Columns.Count > 0)
                        {
                            var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
                            var columnFill = columnEffective.FillFormat;
                            Console.WriteLine($"  First Column Fill Type = {columnFill.FillType}");
                        }

                        // First cell effective formatting
                        if (table.Rows.Count > 0 && table.Columns.Count > 0)
                        {
                            var cellEffective = table[0, 0].CellFormat.GetEffective();
                            var cellFill = cellEffective.FillFormat;
                            Console.WriteLine($"  Cell[0,0] Fill Type = {cellFill.FillType}");
                        }
                    }
                }
            }

            var outputPath = "output.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}