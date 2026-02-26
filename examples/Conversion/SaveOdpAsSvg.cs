using System;
using System.IO;
using Aspose.Slides;

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
            string svgFileName = $"slide_{i + 1}.svg";

            using (FileStream fileStream = File.Create(svgFileName))
            {
                slide.WriteAsSvg(fileStream);
            }
        }

        // Save the presentation before exiting (no modifications made)
        presentation.Save("output.odp", Aspose.Slides.Export.SaveFormat.Odp);

        // Release resources
        presentation.Dispose();
    }
}