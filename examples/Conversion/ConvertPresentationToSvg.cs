using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PowerPointToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the PowerPoint presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Convert each slide to an SVG file
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[index];
                string svgPath = $"slide_{index + 1}.svg";

                using (FileStream fileStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(fileStream);
                }
            }

            // Save the presentation (required before exiting)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}