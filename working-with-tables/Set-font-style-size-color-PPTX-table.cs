using Aspose.Slides.Export;
using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Define column widths and row heights
            double[] colWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, colWidths, rowHeights);

            // Iterate through each cell to set text and format
            for (int r = 0; r < table.Rows.Count; r++)
            {
                for (int c = 0; c < table.Rows[r].Count; c++)
                {
                    Aspose.Slides.ICell cell = table.Rows[r][c];
                    cell.TextFrame.Text = $"R{r + 1}C{c + 1}";

                    // Access the first portion of the cell's text
                    Aspose.Slides.IPortion portion = cell.TextFrame.Paragraphs[0].Portions[0];

                    // Set font size, style, and color
                    portion.PortionFormat.FontHeight = 20;
                    portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                    portion.PortionFormat.FontItalic = Aspose.Slides.NullableBool.False;
                    portion.PortionFormat.FontUnderline = Aspose.Slides.TextUnderlineType.Single;
                    portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                }
            }

            // Save the presentation
            pres.Save("TableFormatted.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}