using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load the presentation
            var presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            var slide = presentation.Slides[0];

            // Find the first table shape on the slide
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
                // Remove the second column (index 1) without deleting attached rows
                table.Columns.RemoveAt(1, false);
            }

            // Save the modified presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}