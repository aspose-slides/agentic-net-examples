using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentationPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(presentationPath))
            {
                var master = presentation.Masters[0];
                var layoutSlides = master.LayoutSlides;
                var layout = layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Title) ?? layoutSlides[0];
                var slideCount = presentation.Slides.Count;
                presentation.Slides.InsertEmptySlide(slideCount, layout);
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}