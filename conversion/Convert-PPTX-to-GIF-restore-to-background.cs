using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Configure GIF options
                    GifOptions gifOptions = new GifOptions();
                    // Set disposal method to restore-to-background if supported
                    // (Assuming a property exists; placeholder for actual implementation)
                    // gifOptions.DisposalMethod = Aspose.Slides.Export.GifDisposalMethod.RestoreToBackground;

                    // Save as GIF with options
                    pres.Save(outputPath, SaveFormat.Gif, gifOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for GIF conversion.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}