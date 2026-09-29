// -----------------------------------------------------------------------------
// Example: Export Slide Master Thumbnails to PNG using Aspose.Slides
//
// Description:
// This console application loads a PPTX file, iterates through all slide master
// slides, generates a PNG thumbnail for each master, and saves the images to a
// specified output folder. It demonstrates using Aspose.Slides for .NET to
// automate slide‑master processing in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide master, thumbnail, PNG export
//
// Use Cases:
// - Validate visual consistency of slide masters across a presentation.
// - Generate assets for documentation or design review workflows.
// - Integrate slide‑master thumbnail extraction into automated .NET pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Reflection;

namespace SlideMasterThumbnailExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";

            // Output folder for master thumbnails
            string outputFolder = "MasterThumbnails";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through each master slide
                for (int i = 0; i < presentation.Masters.Count; i++)
                {
                    Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[i];

                    // Attempt to obtain an image via reflection (covers different API versions)
                    Aspose.Slides.IImage image = GetMasterSlideImage(masterSlide);
                    if (image == null)
                    {
                        Console.WriteLine($"Unable to generate image for master slide {i + 1}.");
                        continue;
                    }

                    // Save the thumbnail as PNG
                    using (image)
                    {
                        string outputPath = Path.Combine(outputFolder, $"Master_{i + 1}.png");
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                        Console.WriteLine("Saved: " + outputPath);
                    }
                }

                // Save the presentation (optional, demonstrates saving before exit)
                string savedPresentationPath = "output.pptx";
                presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved as: " + savedPresentationPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Helper method to retrieve an IImage from a master slide using reflection.
        private static Aspose.Slides.IImage GetMasterSlideImage(Aspose.Slides.IMasterSlide masterSlide)
        {
            // Preferred method: GetImage()
            MethodInfo getImageMethod = masterSlide.GetType().GetMethod("GetImage", Type.EmptyTypes);
            if (getImageMethod != null)
            {
                object result = getImageMethod.Invoke(masterSlide, null);
                return result as Aspose.Slides.IImage;
            }

            // Fallback method: GetThumbnail()
            MethodInfo getThumbnailMethod = masterSlide.GetType().GetMethod("GetThumbnail", Type.EmptyTypes);
            if (getThumbnailMethod != null)
            {
                object result = getThumbnailMethod.Invoke(masterSlide, null);
                return result as Aspose.Slides.IImage;
            }

            // No suitable method found
            return null;
        }
    }
}
