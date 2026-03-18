using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyTextFormattingToRows
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputFile = "input.pptx";
                string outputFile = "output.pptx";

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Get the first shape as a table
                Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;
                if (table == null)
                {
                    Console.WriteLine("No table found on the first slide.");
                    return;
                }

                // ----- Row 0: Portion formatting (font height and underline) -----
                Aspose.Slides.PortionFormat portionFormat = new Aspose.Slides.PortionFormat();
                portionFormat.FontHeight = 20f; // Set font height
                portionFormat.FontUnderline = Aspose.Slides.TextUnderlineType.Single; // Correctly set underline type
                table.Rows[0].SetTextFormat(portionFormat);

                // ----- Row 0: Paragraph formatting (alignment and right margin) -----
                Aspose.Slides.ParagraphFormat paragraphFormat = new Aspose.Slides.ParagraphFormat();
                paragraphFormat.Alignment = Aspose.Slides.TextAlignment.Right;
                paragraphFormat.MarginRight = 5f;
                table.Rows[0].SetTextFormat(paragraphFormat);

                // ----- Row 1: Text frame formatting (vertical text) -----
                Aspose.Slides.TextFrameFormat textFrameFormat = new Aspose.Slides.TextFrameFormat();
                textFrameFormat.TextVerticalType = Aspose.Slides.TextVerticalType.Vertical;
                table.Rows[1].SetTextFormat(textFrameFormat);

                // Save the modified presentation
                presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}