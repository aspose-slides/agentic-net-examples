using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = "input.pptx";

        // Load the presentation
        Presentation presentation = new Presentation(inputPath);

        // Convert each slide to an SVG file
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            ISlide slide = presentation.Slides[i];
            string svgPath = $"slide_{i + 1}.svg";

            using (FileStream fileStream = File.Create(svgPath))
            {
                slide.WriteAsSvg(fileStream);
            }
        }

        // Save the presentation (optional, ensures it's saved before exit)
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}