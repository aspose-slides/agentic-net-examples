using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define paths
        string dataDir = "Data";
        string inputFile = "input.pptx";
        string outputFile = "output.pptx";

        string inputPath = Path.Combine(dataDir, inputFile);
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Find the first table on the slide
            Aspose.Slides.ITable table = null;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.ITable)
                {
                    table = (Aspose.Slides.ITable)shape;
                    break;
                }
            }

            if (table != null)
            {
                // Mark first row as header
                table.FirstRow = true;

                // Create a portion format with bold text
                Aspose.Slides.PortionFormat portionFormat = new Aspose.Slides.PortionFormat();
                portionFormat.FontBold = Aspose.Slides.NullableBool.True;

                // Apply bold formatting to all cells in the first row
                Aspose.Slides.IRow firstRow = table.Rows[0];
                firstRow.SetTextFormat(portionFormat);
            }

            // Save the modified presentation
            pres.Save(Path.Combine(dataDir, outputFile), Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}