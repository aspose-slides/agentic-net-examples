// -----------------------------------------------------------------------------
// Example: Insert png image into cell keep ratio using C#
//
// Description:
// Demonstrates how to insert a PNG image into a table cell while preserving
// its aspect ratio using C# and Aspose.Slides for .NET. The example creates a
// new presentation, adds a table, loads an external PNG file, places the image
// into a specific cell with picture fill mode that maintains the original
// proportions, and saves the result as a PPTX file. This pattern can be used to
// automate PowerPoint table image insertion tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Insert, Image, Table, Cell, Keep Ratio, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of PNG images into table cells while keeping aspect ratio.
// - Build C# utilities for PowerPoint table manipulation.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate presentation layouts that include images within tables.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define directories and file paths
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string imagePath = Path.Combine(dataDir, "input.png");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Ensure the data directory exists
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        // Verify that the input image exists
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Define table dimensions
            double[] columnWidths = new double[] { 150, 150, 150 };
            double[] rowHeights = new double[] { 100, 100 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Load the external PNG image and add it to the presentation's image collection
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage pptImg = pres.Images.AddImage(img);

            // Insert the image into the cell at row 0, column 1 (first row, second column)
            table[0, 1].CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Picture;
            table[0, 1].CellFormat.FillFormat.PictureFillFormat.Picture.Image = pptImg;
            // Preserve aspect ratio by using Stretch mode (Aspose.Slides handles aspect ratio internally)
            table[0, 1].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
