using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptxToSwf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Disable all audio frames by hiding them
                    foreach (ISlide slide in presentation.Slides)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            IAudioFrame audioFrame = shape as IAudioFrame;
                            if (audioFrame != null)
                            {
                                audioFrame.Hidden = true;
                            }
                        }
                    }

                    // Configure SWF export options (audio is already hidden)
                    SwfOptions swfOptions = new SwfOptions();
                    // Example: disable the integrated viewer to reduce size further
                    swfOptions.ViewerIncluded = false;

                    // Save the presentation as SWF with the specified options
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }

                Console.WriteLine("Presentation exported successfully to: " + outputPath);
            }
            catch (NotSupportedException ex)
            {
                // Handle unsupported format exception
                Console.WriteLine("Format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}