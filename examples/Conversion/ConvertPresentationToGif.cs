using System;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.gif";

        // Load the presentation from the PPTX file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Create GIF export options (optional custom settings)
            Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
            // Set the default delay between frames (in milliseconds)
            gifOptions.DefaultDelay = 2000;

            // Save the presentation as an animated GIF using the specified options
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);
        }
    }
}