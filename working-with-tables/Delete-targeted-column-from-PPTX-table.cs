using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation("input.pptx");

            // Get the first slide
            var slide = presentation.Slides[0];

            // Find the first table shape on the slide
            var table = (Aspose.Slides.ITable)null;
            for (var i = 0; i < slide.Shapes.Count; i++)
            {
                if (slide.Shapes[i] is Aspose.Slides.ITable)
                {
                    table = (Aspose.Slides.ITable)slide.Shapes[i];
                    break;
                }
            }

            if (table != null)
            {
                // Delete the second column (index 1) and also remove attached rows
                table.Columns.RemoveAt(1, true);
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}