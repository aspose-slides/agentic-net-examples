using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source ODP file
        string inputFile = "input.odp";

        // Load the ODP presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile))
        {
            // Save the presentation before exiting (as required by authoring rules)
            presentation.Save("saved_output.odp", SaveFormat.Odp);

            // Convert each slide to an individual SVG file
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[index];
                string svgFileName = $"slide_{index + 1}.svg";

                using (FileStream svgStream = File.Create(svgFileName))
                {
                    slide.WriteAsSvg(svgStream);
                }
            }
        }
    }
}