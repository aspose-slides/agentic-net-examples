using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var filePath = "input.pptx";
            using (var presentation = new Aspose.Slides.Presentation(filePath))
            {
                // Index of the slide to inspect
                var slideIndex = 0;
                var slide = presentation.Slides[slideIndex]; // ISlide

                Aspose.Slides.ITable table = null;
                foreach (var shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.Table)
                    {
                        table = (Aspose.Slides.Table)shape;
                        break;
                    }
                }

                if (table != null)
                {
                    Console.WriteLine("Table found. Rows: " + table.Rows.Count + ", Columns: " + table.Columns.Count);
                }
                else
                {
                    Console.WriteLine("Table not found on the specified slide.");
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}