using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";
            var slideIndex = 0; // zero‑based index

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var slide = presentation.Slides[slideIndex]; // ISlide reference

                // Example operation: change background color to white
                slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.White;

                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}