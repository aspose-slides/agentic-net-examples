using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputCsv = "traces.csv";
        string outputPptx = "output.pptx";

        // Check if the CSV file exists
        if (!File.Exists(inputCsv))
        {
            Console.WriteLine("Input CSV file does not exist.");
            return;
        }

        // Create a new presentation
        Presentation presentation = null;
        try
        {
            presentation = new Presentation();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to create presentation: " + ex.Message);
            return;
        }

        ISlide slide = presentation.Slides[0];

        // Add a placeholder shape (using rectangle as Ink placeholder)
        IShape inkShape = null;
        try
        {
            inkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 500, 400);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to add shape: " + ex.Message);
        }

        // Read CSV and apply brush settings to the placeholder shape
        try
        {
            string[] lines = File.ReadAllLines(inputCsv);
            foreach (string line in lines)
            {
                // Expected CSV format: R,G,B,Size
                string[] parts = line.Split(',');
                if (parts.Length < 4) continue;

                int r = int.Parse(parts[0]);
                int g = int.Parse(parts[1]);
                int b = int.Parse(parts[2]);
                float size = float.Parse(parts[3]);

                if (inkShape != null && inkShape.LineFormat != null && inkShape.LineFormat.FillFormat != null)
                {
                    inkShape.LineFormat.FillFormat.FillType = FillType.Solid;
                    inkShape.LineFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(r, g, b);
                    inkShape.LineFormat.Width = size;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading CSV: " + ex.Message);
        }

        // Save the presentation
        try
        {
            presentation.Save(outputPptx, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle format not supported or other save errors
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
                presentation.Dispose();
        }
    }
}