using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteTableRow
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation presentation = new Presentation("input.pptx");

                // Get the first slide (adjust index as needed)
                ISlide slide = presentation.Slides[0];

                // Locate the first table shape on the slide
                IShape tableShape = null;
                for (int i = 0; i < slide.Shapes.Count; i++)
                {
                    if (slide.Shapes[i] is Table)
                    {
                        tableShape = slide.Shapes[i];
                        break;
                    }
                }

                if (tableShape != null)
                {
                    Table table = (Table)tableShape;
                    // Delete the row at index 1 (second row) without removing attached rows
                    table.Rows.RemoveAt(1, false);
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
}