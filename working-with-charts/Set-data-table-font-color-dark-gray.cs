using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
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
            Presentation pres = new Presentation(inputPath);
            ISlide slide = pres.Slides[0];

            // Get the first shape as a table
            ITable table = slide.Shapes[0] as ITable;
            if (table == null)
            {
                Console.WriteLine("No table found on the first slide.");
                pres.Dispose();
                return;
            }

            // Create a portion format with dark gray fill
            PortionFormat portionFormat = new PortionFormat();
            portionFormat.FillFormat.FillType = FillType.Solid;
            portionFormat.FillFormat.SolidFillColor.Color = Color.DarkGray;

            // Apply the format to all table cells
            table.SetTextFormat(portionFormat);

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}