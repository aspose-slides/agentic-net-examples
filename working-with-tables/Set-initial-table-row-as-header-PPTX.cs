using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Define data directory and output file name
            string dataDir = "Data/";
            string outputFile = "SetHeaderTable_out.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Define column widths and row heights for the table
            double[] colWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 30, 30, 30 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, colWidths, rowHeights);

            // Set the first row as the header row
            table.FirstRow = true;

            // Save the presentation
            pres.Save(dataDir + outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}