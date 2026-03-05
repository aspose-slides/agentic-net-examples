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
        Presentation presentation = new Presentation(inputFile);

        // Convert each slide to an SVG file
        for (int index = 0; index < presentation.Slides.Count; index++)
        {
            ISlide slide = presentation.Slides[index];
            string svgFile = $"slide_{index + 1}.svg";

            using (FileStream fileStream = File.Create(svgFile))
            {
                slide.WriteAsSvg(fileStream);
            }
        }

        // Save the presentation before exiting (optional re-save)
        presentation.Save("output.odp", SaveFormat.Odp);

        // Release resources
        presentation.Dispose();
    }
}