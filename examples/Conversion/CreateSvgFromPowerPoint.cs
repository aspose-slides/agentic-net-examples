using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the PowerPoint presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through each slide in the presentation
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            // Get the current slide
            Aspose.Slides.ISlide slide = presentation.Slides[i];

            // Define the output SVG file name
            string svgFileName = $"slide_{i + 1}.svg";

            // Create a file stream for the SVG output
            using (Stream svgStream = File.Create(svgFileName))
            {
                // Save the slide as an SVG file
                slide.WriteAsSvg(svgStream);
            }
        }

        // Save the (unchanged) presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}