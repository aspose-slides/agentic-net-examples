using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation (or create a new one if the file does not exist)
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Find an existing table on the slide; if none, create a sample table
            Aspose.Slides.ITable table = null;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.ITable)
                {
                    table = (Aspose.Slides.ITable)shape;
                    break;
                }
            }

            if (table == null)
            {
                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 50, 50 };
                table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Populate the table with sample text
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        table[row, col].TextFrame.Text = $"R{row}C{col}";
                    }
                }
            }

            // Duplicate the first column (index 0) and insert it after the original (at index 1)
            Aspose.Slides.IColumn templateColumn = table.Columns[0];
            // InsertClone creates a copy of the template column preserving formatting and content
            table.Columns.InsertClone(1, templateColumn, false);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}