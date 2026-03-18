using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            var presentation = new Aspose.Slides.Presentation(inputPath);
            var slide = presentation.Slides[0];

            Aspose.Slides.ITable table = null;
            foreach (var shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.ITable)
                {
                    table = (Aspose.Slides.ITable)shape;
                    break;
                }
            }

            if (table != null)
            {
                int columnIndexToDelete = 1; // zero-based index of the column to remove
                bool withAttachedRows = false; // set true to delete attached rows as well
                table.Columns.RemoveAt(columnIndexToDelete, withAttachedRows);
            }
            else
            {
                Console.WriteLine("No table found on the first slide.");
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}