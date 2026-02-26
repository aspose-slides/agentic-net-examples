using System;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Assume the first shape on the slide is a table
        Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;
        if (table != null)
        {
            // Access the first column (index 0) and cast to the concrete Column type
            Aspose.Slides.Column column = (Aspose.Slides.Column)table.Columns[0];

            // Example: read the width of the column (read‑only property)
            double columnWidth = column.Width;
            Console.WriteLine("Column width: " + columnWidth);
        }

        // Save the presentation before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}