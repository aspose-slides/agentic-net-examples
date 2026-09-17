// -----------------------------------------------------------------------------
// Example: Export 3D Slide to High-Resolution PNG with Depth Shading
//
// Description:
// This console application loads a PowerPoint PPTX file, locates the first slide
// that contains 3‑D objects, and exports that slide to a high‑resolution PNG image
// while preserving depth shading. It uses Aspose.Slides for .NET to render the
// slide at double scale and saves both the image and the original presentation.
// The program checks for file existence and handles any runtime exceptions.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D slide export, high‑resolution PNG, depth shading
//
// Use Cases:
// - Generate high‑quality thumbnails of 3‑D slides for documentation.
// - Create assets for marketing materials that require detailed slide imagery.
// - Automate batch conversion of presentation slides containing 3‑D content.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesExport3D
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputImagePath = "slide_3d.png";
            string outputPresentationPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file \"{0}\" does not exist.", inputPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                try
                {
                    Aspose.Slides.ISlide targetSlide = null;

                    // Find the first slide that contains at least one 3‑D shape.
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.ThreeDFormat != null)
                            {
                                targetSlide = slide;
                                break;
                            }
                        }
                        if (targetSlide != null)
                        {
                            break;
                        }
                    }

                    // If no 3‑D slide is found, fall back to the first slide.
                    if (targetSlide == null && presentation.Slides.Count > 0)
                    {
                        targetSlide = presentation.Slides[0];
                        Console.WriteLine("Warning: No 3‑D content found. Exporting the first slide instead.");
                    }

                    if (targetSlide == null)
                    {
                        Console.WriteLine("Error: Presentation contains no slides.");
                        return;
                    }

                    // Export the slide to a high‑resolution PNG (2× scale).
                    using (Aspose.Slides.IImage slideImage = targetSlide.GetImage(2.0f, 2.0f))
                    {
                        slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the (potentially unchanged) presentation.
                    presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Console.WriteLine("Slide exported successfully to \"{0}\".", outputImagePath);
                }
                finally
                {
                    presentation.Dispose();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("An error occurred: {0}", ex.Message);
            }
        }
    }
}
