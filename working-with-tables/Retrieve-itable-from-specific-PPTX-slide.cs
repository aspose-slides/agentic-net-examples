using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentationPath = "input.pptx";
            using (var presentation = new Aspose.Slides.Presentation(presentationPath))
            {
                // Retrieve the first slide
                var slide = presentation.Slides[0] as Aspose.Slides.ISlide;

                // Locate the first table on the slide
                Aspose.Slides.ITable table = null;
                foreach (var shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.Table)
                    {
                        table = shape as Aspose.Slides.ITable;
                        break;
                    }
                }

                if (table != null)
                {
                    Console.WriteLine("Table found: Rows = " + table.Rows.Count + ", Columns = " + table.Columns.Count);
                }
                else
                {
                    Console.WriteLine("No table found on the specified slide.");
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