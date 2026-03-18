using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to input and output files
            string dataDir = "Data/";
            string inputFile = dataDir + "input.pptx";
            string outputFile = dataDir + "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFile);

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Locate the first table on the slide
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

                // Remove the third column (index 2) without deleting attached columns
                table.Columns.RemoveAt(2, false);
            }

            // Save the modified presentation
            pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}