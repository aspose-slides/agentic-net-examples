using System;
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
                var slideIndex1 = 0;
                var slideIndex2 = 1;
                var slide1 = presentation.Slides[slideIndex1];
                var slide2 = presentation.Slides[slideIndex2];
                var areEqual = slide1.Equals(slide2);
                Console.WriteLine($"Slide {slideIndex1 + 1} and Slide {slideIndex2 + 1} are {(areEqual ? "identical" : "different")}.");
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}