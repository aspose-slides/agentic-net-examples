using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            double[] columnWidths = new double[] { 150, 150, 150 };
            double[] rowHeights = new double[] { 100, 100, 100, 100 };

            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Configure right alignment and right margin for the first column
            Aspose.Slides.ParagraphFormat paragraphFormat = new Aspose.Slides.ParagraphFormat();
            paragraphFormat.Alignment = Aspose.Slides.TextAlignment.Right;
            paragraphFormat.MarginRight = 10; // set desired right margin

            table.Columns[0].SetTextFormat(paragraphFormat);

            // Save the presentation
            presentation.Save("AlignedFirstColumn.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}