using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation from file
            Presentation presentation = new Presentation("input.pptx");

            // Get the first slide (adjust index as needed)
            ISlide slide = presentation.Slides[0];

            // Locate the first table shape on the slide
            Table table = null;
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is Table)
                {
                    table = (Table)shape;
                    break;
                }
            }

            // If a table is found, remove the desired row
            if (table != null)
            {
                // Remove the row at index 1 (second row) without deleting attached rows
                table.Rows.RemoveAt(1, false);
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