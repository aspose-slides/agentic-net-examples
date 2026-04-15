using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtCloneDemo
{
    class Program
    {
        static void Main()
        {
            // Paths for input presentation, custom theme, and output files
            string inputPath = "input.pptx";
            string themePath = "custom.thmx";
            string outputPath = "output.pptx";
            string originalPng = "original.png";
            string clonePng = "clone.png";

            // Verify that the input presentation exists; if not, create a new one
            Presentation pres;
            if (File.Exists(inputPath))
            {
                pres = new Presentation(inputPath);
            }
            else
            {
                // Create a new presentation with a single blank slide
                pres = new Presentation();
                // Add a SmartArt diagram to the first slide for demonstration
                ISlide slide = pres.Slides[0];
                ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
                // Optionally set a quick style
                smartArt.QuickStyle = SmartArtQuickStyleType.SubtleEffect;
            }

            // Access the first slide
            ISlide firstSlide = pres.Slides[0];

            // Locate the first SmartArt shape on the slide
            ISmartArt originalSmartArt = null;
            foreach (IShape shape in firstSlide.Shapes)
            {
                if (shape is ISmartArt)
                {
                    originalSmartArt = (ISmartArt)shape;
                    break;
                }
            }

            // If no SmartArt was found (unlikely after creation), exit
            if (originalSmartArt == null)
            {
                Console.WriteLine("No SmartArt shape found on the slide.");
                pres.Dispose();
                return;
            }

            // Clone the SmartArt shape using the AddClone method (rule: clone-shapes)
            IShape clonedShape = firstSlide.Shapes.AddClone((IShape)originalSmartArt);

            // Apply a custom external theme to all dependent slides (handle possible exception)
            if (File.Exists(themePath))
            {
                try
                {
                    // Apply the theme to the master slide; this updates dependent slides
                    IMasterSlide master = pres.Masters[0];
                    master.ApplyExternalThemeToDependingSlides(themePath);
                }
                catch (PptxReadException ex)
                {
                    // Handle theme application failure
                    Console.WriteLine("Failed to apply external theme: " + ex.Message);
                }
            }
            else
            {
                // Theme file not found; continue without applying a custom theme
                Console.WriteLine("Custom theme file not found. Skipping theme application.");
            }

            // Render the original SmartArt to PNG
            IImage originalImage = originalSmartArt.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);
            originalImage.Save(originalPng, ImageFormat.Png);

            // Render the cloned SmartArt to PNG
            IImage cloneImage = clonedShape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);
            cloneImage.Save(clonePng, ImageFormat.Png);

            // Save the modified presentation (ensure saving before exit)
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported comment
                // The specified format is not supported for saving.
            }

            // Clean up resources
            pres.Dispose();
        }
    }
}