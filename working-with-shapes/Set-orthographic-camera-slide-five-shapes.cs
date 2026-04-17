using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetOrthographicCamera
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(sourcePath))
                {
                    // Ensure slide five (index 4) exists
                    if (presentation.Slides.Count < 5)
                    {
                        Console.WriteLine("The presentation does not contain a fifth slide.");
                    }
                    else
                    {
                        // Get slide five
                        ISlide slide = presentation.Slides[4];

                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Check if the shape has 3‑D formatting and a camera
                            if (shape.ThreeDFormat != null && shape.ThreeDFormat.Camera != null)
                            {
                                // Set the camera type to orthographic front
                                shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL or web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}