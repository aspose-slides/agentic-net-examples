using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Load the ODP presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.odp");

        // Convert each slide to an SVG file
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];
            string svgPath = $"slide_{i + 1}.svg";

            using (FileStream fileStream = File.Create(svgPath))
            {
                slide.WriteAsSvg(fileStream);
            }
        }

        // Save the presentation (optional output format)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}