using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesGifConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation pres = new Presentation("input.pptx");

                // Create GIF export options (optional, can be customized)
                GifOptions gifOptions = new GifOptions();

                // Save the presentation as an animated GIF
                pres.Save("output.gif", SaveFormat.Gif, gifOptions);

                // Dispose the presentation
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}