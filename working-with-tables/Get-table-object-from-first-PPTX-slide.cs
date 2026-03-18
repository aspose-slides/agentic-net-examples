using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = @"C:\Data\";
            string inputFile = "input.pptx";
            string outputFile = "output.pptx";

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(dataDir + inputFile);
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.ITable table = null;

            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.ITable)
                {
                    table = (Aspose.Slides.ITable)shape;
                    break;
                }
            }

            if (table != null)
            {
                // Example: set first row as header
                table.FirstRow = true;

                // Access table data: print each cell's text
                for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                    {
                        Aspose.Slides.ICell cell = table[rowIndex, colIndex];
                        string text = cell.TextFrame?.Text ?? string.Empty;
                        Console.WriteLine($"Row {rowIndex + 1}, Column {colIndex + 1}: {text}");
                    }
                }
            }

            pres.Save(dataDir + outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}