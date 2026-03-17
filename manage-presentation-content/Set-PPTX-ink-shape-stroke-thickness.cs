using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation("input.pptx"))
            {
                // Get the first shape on the first slide and cast it to Ink
                Aspose.Slides.Ink.Ink inkShape = presentation.Slides[0].Shapes[0] as Aspose.Slides.Ink.Ink;
                if (inkShape != null && inkShape.LineFormat != null)
                {
                    // Configure the stroke thickness (line width) of the ink shape
                    inkShape.LineFormat.Width = 5f; // thickness in points
                }

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}