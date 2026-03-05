using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a table with 2 columns and 2 rows
        double[] columnWidths = new double[] { 150, 150 };
        double[] rowHeights = new double[] { 50, 50 };
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights) as Aspose.Slides.ITable;

        if (table != null)
        {
            // Create a PortionFormat and set font height
            Aspose.Slides.PortionFormat portionFormat = new Aspose.Slides.PortionFormat();
            portionFormat.FontHeight = 24f;

            // Apply the portion format to the first column
            table.Columns[0].SetTextFormat(portionFormat);

            // Create a ParagraphFormat and set alignment and right margin
            Aspose.Slides.ParagraphFormat paragraphFormat = new Aspose.Slides.ParagraphFormat();
            paragraphFormat.Alignment = Aspose.Slides.TextAlignment.Right;
            paragraphFormat.MarginRight = 5f;

            // Apply the paragraph format to the first column
            table.Columns[0].SetTextFormat(paragraphFormat);

            // Create a TextFrameFormat and set vertical text type
            Aspose.Slides.TextFrameFormat textFrameFormat = new Aspose.Slides.TextFrameFormat();
            textFrameFormat.TextVerticalType = Aspose.Slides.TextVerticalType.Vertical;

            // Apply the text frame format to the second column
            table.Columns[1].SetTextFormat(textFrameFormat);
        }

        // Add an AutoShape to demonstrate correct usage of read‑only PortionFormat
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 300, 50, 200, 100);
        autoShape.AddTextFrame("Sample FAQ");

        // Access the first portion of the text frame
        Aspose.Slides.IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];

        // Modify properties of the read‑only PortionFormat (the object itself is mutable)
        portion.PortionFormat.FontHeight = 18f;
        portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
        portion.PortionFormat.LanguageId = "en-US";

        // Save the presentation in PPTX format
        presentation.Save("FAQ_Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}