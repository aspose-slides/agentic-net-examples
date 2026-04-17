using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Set3DCameraView
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape has 3D formatting
                            if (shape is IThreeDFormat threeDFormat && threeDFormat.Camera != null)
                            {
                                // Set a predefined camera view using rotation (view matrix equivalent)
                                // Example: rotate 30 degrees around X, 45 degrees around Y, 0 degrees around Z
                                threeDFormat.Camera.SetRotation(30f, 45f, 0f);

                                // Optionally set the camera type to a perspective preset
                                // threeDFormat.Camera.CameraType = CameraPresetType.PerspectiveFront;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Handle unsupported file format
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}