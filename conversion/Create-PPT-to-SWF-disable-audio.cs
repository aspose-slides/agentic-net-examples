using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Mute all audio frames to effectively disable audio tracks
                    foreach (ISlide slide in presentation.Slides)
                    {
                        for (int i = 0; i < slide.Shapes.Count; i++)
                        {
                            IShape shape = slide.Shapes[i];
                            IAudioFrame audioFrame = shape as IAudioFrame;
                            if (audioFrame != null)
                            {
                                // Set volume to zero
                                audioFrame.VolumeValue = 0f;
                            }
                        }
                    }

                    // Configure SWF export options
                    SwfOptions swfOptions = new SwfOptions();
                    // Exclude the integrated viewer to reduce file size
                    swfOptions.ViewerIncluded = false;
                    // Hide UI elements to further reduce size
                    swfOptions.ShowBottomPane = false;
                    swfOptions.ShowFullScreen = false;
                    swfOptions.ShowLeftPane = false;
                    swfOptions.ShowPageBorder = false;
                    swfOptions.ShowPageStepper = false;
                    swfOptions.ShowSearch = false;
                    swfOptions.ShowTopPane = false;

                    // Save the presentation as SWF
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}