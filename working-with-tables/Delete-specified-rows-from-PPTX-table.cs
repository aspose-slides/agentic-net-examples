using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string dataDir = "Path_To_Data_Directory\\";
            string inputFile = dataDir + "input.pptx";
            string outputFile = dataDir + "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFile);
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
                // Remove the second row (index 1) without deleting attached rows
                table.Rows.RemoveAt(1, false);
                // Example: remove the first column (index 0) without attached rows
                // table.Columns.RemoveAt(0, false);
            }

            // Save the modified presentation
            pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}