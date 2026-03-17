using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load the presentation from a file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Retrieve the slide by its zero‑based index
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // (Optional) Perform operations on the slide here

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}