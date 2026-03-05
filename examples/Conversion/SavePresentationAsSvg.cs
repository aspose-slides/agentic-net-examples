using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through each slide and export it as an SVG file
        int slideIndex = 0;
        while (slideIndex < presentation.Slides.Count)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
            string svgFileName = $"slide_{slideIndex + 1}.svg";

            using (FileStream svgStream = File.Create(svgFileName))
            {
                slide.WriteAsSvg(svgStream);
            }

            slideIndex++;
        }

        // Save the presentation before exiting (optional output file)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}