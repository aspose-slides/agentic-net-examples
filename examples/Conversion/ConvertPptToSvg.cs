using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        string inputPath = "input.pptx";

        // Directory where SVG files will be saved
        string outputDirectory = "output_svgs";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the presentation from the file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through each slide in the presentation
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                // Get the current slide
                Aspose.Slides.ISlide slide = presentation.Slides[index];

                // Build the SVG file path for the current slide
                string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");

                // Create a file stream to write the SVG content
                using (FileStream svgStream = File.Create(svgFilePath))
                {
                    // Save the slide as SVG
                    slide.WriteAsSvg(svgStream);
                }
            }

            // Save the presentation before exiting (as required)
            string savedPresentationPath = "saved_output.pptx";
            presentation.Save(savedPresentationPath, SaveFormat.Pptx);
        }
    }
}