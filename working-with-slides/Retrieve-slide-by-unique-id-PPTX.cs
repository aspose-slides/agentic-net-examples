using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var filePath = "input.pptx";
            var presentation = new Aspose.Slides.Presentation(filePath);
            var slideId = 5u; // replace with the actual slide ID
            var slide = (Aspose.Slides.ISlide)presentation.GetSlideById(slideId);
            Console.WriteLine("Slide Number: " + slide.SlideNumber);
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}