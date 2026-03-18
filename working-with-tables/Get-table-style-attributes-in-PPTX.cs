using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the input and output PPTX files
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Retrieve the first table on the first slide
            Aspose.Slides.ITable table = presentation.Slides[0].Shapes[0] as Aspose.Slides.ITable;
            if (table == null)
            {
                Console.WriteLine("No table found on the first slide.");
                return;
            }

            // Get effective formatting for the table itself
            Aspose.Slides.ITableFormatEffectiveData tableEff = table.TableFormat.GetEffective();
            Aspose.Slides.IFillFormatEffectiveData tableFill = tableEff.FillFormat;

            // Get effective formatting for the first row
            Aspose.Slides.IRowFormatEffectiveData rowEff = table.Rows[0].RowFormat.GetEffective();
            Aspose.Slides.IFillFormatEffectiveData rowFill = rowEff.FillFormat;

            // Get effective formatting for the first column
            Aspose.Slides.IColumnFormatEffectiveData colEff = table.Columns[0].ColumnFormat.GetEffective();
            Aspose.Slides.IFillFormatEffectiveData colFill = colEff.FillFormat;

            // Get effective formatting for the first cell (row 0, column 0)
            Aspose.Slides.ICellFormatEffectiveData cellEff = table[0, 0].CellFormat.GetEffective();
            Aspose.Slides.IFillFormatEffectiveData cellFill = cellEff.FillFormat;

            // Output some effective style attributes
            Console.WriteLine("Table Fill Type: " + tableFill.FillType);
            Console.WriteLine("Table Transparency: " + tableEff.Transparency);
            Console.WriteLine("Row Fill Type: " + rowFill.FillType);
            Console.WriteLine("Column Fill Type: " + colFill.FillType);
            Console.WriteLine("Cell Fill Type: " + cellFill.FillType);

            // Save the presentation (even if unchanged)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}