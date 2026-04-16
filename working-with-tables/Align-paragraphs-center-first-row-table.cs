using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableParagraphAlignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Get the first shape as a table
                Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;
                if (table == null)
                {
                    Console.WriteLine("No table found on the first slide.");
                    return;
                }

                // Create a paragraph format with center alignment
                Aspose.Slides.ParagraphFormat paragraphFormat = new Aspose.Slides.ParagraphFormat();
                paragraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

                // Apply the paragraph format to all cells in the first row
                table.Rows[0].SetTextFormat(paragraphFormat);

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: The presentation format may not be supported.
            }
        }
    }
}