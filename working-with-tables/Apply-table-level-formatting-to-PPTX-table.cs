using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyTableLevelFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Get the first shape as a table
                ITable table = slide.Shapes[0] as ITable;
                if (table == null)
                {
                    Console.WriteLine("No table found on the first slide.");
                    return;
                }

                // ----- Portion (font) formatting -----
                PortionFormat portionFormat = new PortionFormat();
                portionFormat.FontHeight = 20f; // Set font size
                // Set font color via FillFormat
                portionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                // Apply to all cells in the table
                table.SetTextFormat(portionFormat);

                // ----- Paragraph formatting -----
                ParagraphFormat paragraphFormat = new ParagraphFormat();
                paragraphFormat.Alignment = TextAlignment.Right;
                paragraphFormat.MarginRight = 5f;
                table.SetTextFormat(paragraphFormat);

                // ----- Text frame formatting -----
                TextFrameFormat textFrameFormat = new TextFrameFormat();
                textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
                table.SetTextFormat(textFrameFormat);

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}