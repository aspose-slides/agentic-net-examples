using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define column widths and row heights
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50, 50 };

            // Add a table shape to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Apply a built‑in table style to retain styling
            table.StylePreset = Aspose.Slides.TableStylePreset.LightStyle1Accent1;

            // Set background color for each cell to retain cell colors
            for (int row = 0; row < table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    table[row, col].CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    table[row, col].CellFormat.FillFormat.SolidFillColor.Color = Color.LightBlue;
                }
            }

            // Save the presentation as PDF
            string outputPath = "TablePresentation.pdf";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions
        }
    }
}