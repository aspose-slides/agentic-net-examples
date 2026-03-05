using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.gif";

        // Load the PowerPoint presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Configure GIF export options (optional)
            Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
            gifOptions.DefaultDelay = 2000; // 2 seconds per slide

            // Save the presentation as an animated GIF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);
        }
    }
}