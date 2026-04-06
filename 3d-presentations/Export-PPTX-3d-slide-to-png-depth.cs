using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Export3DSlide
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputImagePath = Path.Combine(Directory.GetCurrentDirectory(), "slide3d.png");
            string outputPresentationPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Find the first slide that contains a shape with 3D formatting
                    int slideIndexWith3D = -1;
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[i];
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            if (shape.ThreeDFormat != null)
                            {
                                slideIndexWith3D = i;
                                break;
                            }
                        }
                        if (slideIndexWith3D != -1)
                            break;
                    }

                    if (slideIndexWith3D == -1)
                    {
                        Console.WriteLine("No slide with 3D content found.");
                    }
                    else
                    {
                        // Export the identified slide to a high‑resolution PNG preserving depth shading
                        Aspose.Slides.ISlide targetSlide = presentation.Slides[slideIndexWith3D];
                        float scaleX = 3f; // High‑resolution scaling factor
                        float scaleY = 3f;

                        using (Aspose.Slides.IImage image = targetSlide.GetImage(scaleX, scaleY))
                        {
                            image.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                        }

                        Console.WriteLine("Slide exported to PNG: " + outputImagePath);
                    }

                    // Save the presentation before exiting (as required)
                    presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested format is not supported by the current Aspose.Slides version.
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}