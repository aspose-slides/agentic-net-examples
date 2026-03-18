using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Get the first table on the slide
            Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;
            if (table == null)
            {
                Console.WriteLine("No table found on the first slide.");
                return;
            }

            // Configure alignment for the first row cells
            Aspose.Slides.ParagraphFormat paragraphFormat = new Aspose.Slides.ParagraphFormat();
            paragraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
            table.Rows[0].SetTextFormat(paragraphFormat);

            // Configure right margin for the first row cells
            Aspose.Slides.TextFrameFormat textFrameFormat = new Aspose.Slides.TextFrameFormat();
            textFrameFormat.MarginRight = 20.0; // set desired right margin in points
            table.Rows[0].SetTextFormat(textFrameFormat);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}