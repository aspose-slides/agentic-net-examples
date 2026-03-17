using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentationPath = "input.pptx";
            var outputPath = "output.gif";

            using (var presentation = new Aspose.Slides.Presentation(presentationPath))
            {
                var gifOptions = new Aspose.Slides.Export.GifOptions
                {
                    // Set delay between frames (in milliseconds)
                    DefaultDelay = 2000
                };

                // Save the presentation as an animated GIF with the specified options
                presentation.Save(outputPath, SaveFormat.Gif, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}