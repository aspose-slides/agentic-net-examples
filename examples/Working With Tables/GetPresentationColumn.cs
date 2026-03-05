using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputFile = "input.pptx";
        string outputFile = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

        // Access the first shape on the first slide as a table
        Aspose.Slides.ITable table = presentation.Slides[0].Shapes[0] as Aspose.Slides.ITable;

        if (table != null)
        {
            // Cast the first column to the concrete Column class to avoid conversion errors
            Aspose.Slides.Column column = (Aspose.Slides.Column)table.Columns[0];

            // Apply portion formatting to the column
            Aspose.Slides.PortionFormat portionFormat = new Aspose.Slides.PortionFormat();
            portionFormat.FontHeight = 12f;
            column.SetTextFormat(portionFormat);

            // Apply paragraph formatting to the column
            Aspose.Slides.ParagraphFormat paragraphFormat = new Aspose.Slides.ParagraphFormat();
            paragraphFormat.Alignment = Aspose.Slides.TextAlignment.Right;
            paragraphFormat.MarginRight = 5f;
            column.SetTextFormat(paragraphFormat);

            // Apply text frame formatting to the second column
            Aspose.Slides.Column secondColumn = (Aspose.Slides.Column)table.Columns[1];
            Aspose.Slides.TextFrameFormat textFrameFormat = new Aspose.Slides.TextFrameFormat();
            textFrameFormat.TextVerticalType = Aspose.Slides.TextVerticalType.Vertical;
            secondColumn.SetTextFormat(textFrameFormat);
        }

        // Save the modified presentation
        presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}