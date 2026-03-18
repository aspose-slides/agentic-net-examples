using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                var slide = presentation.Slides[0];

                // Find the first table on the slide
                Aspose.Slides.ITable table = null;
                foreach (var shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.ITable)
                    {
                        table = (Aspose.Slides.ITable)shape;
                        break;
                    }
                }

                if (table != null)
                {
                    // Iterate through rows and columns
                    for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                        {
                            var cell = table.Rows[rowIndex][colIndex];

                            // Set cell text
                            cell.TextFrame.Text = $"R{rowIndex + 1}C{colIndex + 1}";

                            // Apply a solid fill color to the cell
                            cell.CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                            cell.CellFormat.FillFormat.SolidFillColor.Color = Color.LightBlue;
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}