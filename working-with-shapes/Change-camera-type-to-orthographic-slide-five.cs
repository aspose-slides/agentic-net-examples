using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ChangeCameraType
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Ensure slide five exists (zero‑based index)
                if (presentation.Slides.Count < 5)
                {
                    Console.WriteLine("Slide five does not exist in the presentation.");
                    presentation.Dispose();
                    return;
                }

                // Get slide five
                Aspose.Slides.ISlide slide = presentation.Slides[4];

                // Iterate through all shapes on the slide
                for (int i = 0; i < slide.Shapes.Count; i++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[i];

                    // Apply orthographic camera type to shapes that have 3‑D format
                    if (shape.ThreeDFormat != null)
                    {
                        shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}