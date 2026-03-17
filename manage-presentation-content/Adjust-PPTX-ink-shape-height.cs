using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Assume an Ink shape already exists on the slide at index 0
            // Cast the shape to the Ink type
            Aspose.Slides.Ink.Ink inkShape = slide.Shapes[0] as Aspose.Slides.Ink.Ink;

            if (inkShape != null)
            {
                // Adjust the height of the Ink shape (value in points)
                inkShape.Height = 200f;
            }

            // Save the modified presentation
            presentation.Save("AdjustedInkShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}