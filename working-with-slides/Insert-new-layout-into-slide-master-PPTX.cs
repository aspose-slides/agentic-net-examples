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
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first master slide
                var masterSlide = presentation.Masters[0];

                // Add a new layout slide to the master
                var newLayout = masterSlide.LayoutSlides.Add(Aspose.Slides.SlideLayoutType.TitleOnly, "Custom Title Only");

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}