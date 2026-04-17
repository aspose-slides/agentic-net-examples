using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionExample
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
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Disable all audio frames to reduce file size
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                            Aspose.Slides.IAudioFrame audioFrame = shape as Aspose.Slides.IAudioFrame;
                            if (audioFrame != null)
                            {
                                audioFrame.Hidden = true;
                            }
                        }
                    }

                    // Configure SWF options (disable integrated viewer to further reduce size)
                    Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                    swfOptions.ViewerIncluded = false;

                    // Save the presentation as SWF
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}