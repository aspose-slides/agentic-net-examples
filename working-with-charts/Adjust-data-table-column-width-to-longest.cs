using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.ITable table = null;

            // Find the first table on the slide
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.ITable)
                {
                    table = (Aspose.Slides.ITable)shape;
                    break;
                }
            }

            if (table == null)
            {
                Console.WriteLine("No table found on the first slide.");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                return;
            }

            // Adjust column widths based on longest text in each column
            int columnCount = table.Columns.Count;
            double[] newWidths = new double[columnCount];
            double charWidth = 7.0; // Approximate width per character in points

            for (int col = 0; col < columnCount; col++)
            {
                int maxLength = 0;
                foreach (Aspose.Slides.IRow row in table.Rows)
                {
                    Aspose.Slides.ICell cell = row[col];
                    string text = cell.TextFrame != null ? cell.TextFrame.Text : string.Empty;
                    if (text != null && text.Length > maxLength)
                    {
                        maxLength = text.Length;
                    }
                }

                // Add some padding
                newWidths[col] = maxLength * charWidth + 10;
                table.Columns[col].Width = newWidths[col];
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs, I/O errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}