using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the PowerPoint presentation
            Presentation presentation = new Presentation("input.pptx");

            // Convert each slide to an SVG file
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                ISlide slide = presentation.Slides[i];
                string svgFileName = $"slide_{i + 1}.svg";
                using (FileStream fileStream = File.Create(svgFileName))
                {
                    slide.WriteAsSvg(fileStream);
                }
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}