using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

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
                // Specify zero‑based column and row indexes
                int columnIndex = 1; // second column
                int rowIndex = 2;    // third row

                // Retrieve the cell using the table indexer
                Aspose.Slides.ICell cell = table[columnIndex, rowIndex];

                // Output the cell's text if available
                if (cell != null && cell.TextFrame != null)
                {
                    Console.WriteLine("Cell text: " + cell.TextFrame.Text);
                }
                else
                {
                    Console.WriteLine("Cell is empty or has no text.");
                }
            }
            else
            {
                Console.WriteLine("No table found on the slide.");
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}