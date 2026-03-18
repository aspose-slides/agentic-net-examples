using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            using (Presentation presentation = new Presentation(inputPath))
            {
                var totalSlides = presentation.Slides.Count;
                Console.WriteLine($"Total slides: {totalSlides}");
                for (int i = 0; i < totalSlides; i++)
                {
                    var slide = presentation.Slides[i];
                    var slideNumber = slide.SlideNumber;
                    var slideName = slide.Name;
                    var isHidden = slide.Hidden;
                    var shapeCount = slide.Shapes.Count;
                    Console.WriteLine($"Slide {slideNumber}: Name=\"{slideName}\", Hidden={isHidden}, Shapes={shapeCount}");
                }
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}