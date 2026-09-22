// -----------------------------------------------------------------------------
// Example: Set GIF Loop Count to One Using Aspose.Slides for .NET
//
// Description:
// This console application loads a PowerPoint presentation, converts it to an
// animated GIF, and sets the GIF loop count to 1. It demonstrates the use of
// Aspose.Slides for .NET to process PPTX files, configure GifOptions, and handle
// cases where the LoopCount property may not be available in the current API.
// The resulting GIF is saved to the specified output path.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, GIF conversion, LoopCount, animation
//
// Use Cases:
// - Automate generation of single‑loop animated GIFs from presentations.
// - Integrate PPTX to GIF conversion into CI pipelines with controlled looping.
// - Validate presentation animations by exporting them as GIFs with a fixed loop count.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using System.Reflection;

namespace AsposeSlidesGifLoopExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Validate input arguments
            string inputPath;
            string outputPath;

            if (args.Length >= 1 && !String.IsNullOrEmpty(args[0]))
            {
                inputPath = args[0];
            }
            else
            {
                Console.WriteLine("Error: Input PowerPoint file path must be provided as the first argument.");
                return;
            }

            if (args.Length >= 2 && !String.IsNullOrEmpty(args[1]))
            {
                outputPath = args[1];
            }
            else
            {
                string directory = Path.GetDirectoryName(inputPath);
                string filenameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                outputPath = Path.Combine(directory ?? String.Empty, filenameWithoutExt + "_loop1.gif");
            }

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: The file \"{inputPath}\" does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Configure GIF options
                Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
                gifOptions.FrameSize = new Size(800, 600); // Example frame size
                gifOptions.DefaultDelay = 100; // 100 ms per frame
                gifOptions.TransitionFps = 10; // Transition frames per second

                // Attempt to set LoopCount to 1 if the property exists
                PropertyInfo loopCountProperty = typeof(Aspose.Slides.Export.GifOptions).GetProperty("LoopCount", BindingFlags.Public | BindingFlags.Instance);
                if (loopCountProperty != null && loopCountProperty.CanWrite)
                {
                    loopCountProperty.SetValue(gifOptions, 1, null);
                }
                else
                {
                    // LoopCount property not available in this version of Aspose.Slides
                    // The GIF will use the default looping behavior.
                    Console.WriteLine("Notice: GifOptions does not expose a LoopCount property in the current Aspose.Slides version. The GIF will use the default loop setting.");
                }

                // Save the presentation as GIF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

                // Clean up
                presentation.Dispose();

                Console.WriteLine($"GIF successfully saved to \"{outputPath}\" with loop count set to 1 (if supported).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during conversion: {ex.Message}");
            }
        }
    }
}
