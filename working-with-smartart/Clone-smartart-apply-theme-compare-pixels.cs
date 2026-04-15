using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneSmartArtApplyTheme
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string themePath = "theme.thmx";
            string outputPath = "output.pptx";

            // Verify that the input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }

            // Verify that the external theme file exists
            if (!File.Exists(themePath))
            {
                Console.WriteLine("Theme file not found: " + themePath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The presentation format is not supported.");
                return;
            }

            // Get the first slide (source slide)
            Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];

            // Locate the first SmartArt shape on the source slide
            Aspose.Slides.SmartArt.ISmartArt smartArtShape = null;
            foreach (Aspose.Slides.IShape shape in sourceSlide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    smartArtShape = (Aspose.Slides.SmartArt.ISmartArt)shape;
                    break;
                }
            }

            if (smartArtShape == null)
            {
                Console.WriteLine("No SmartArt shape found on the source slide.");
                presentation.Dispose();
                return;
            }

            // Create a blank layout slide to host the cloned SmartArt
            Aspose.Slides.ILayoutSlide blankLayout = presentation.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
            Aspose.Slides.ISlide clonedSlide = presentation.Slides.AddEmptySlide(blankLayout);

            // Clone the SmartArt shape onto the new slide using AddClone (shape collection cloning)
            clonedSlide.Shapes.AddClone(smartArtShape);

            // Apply an external theme to the master slide of the source slide
            try
            {
                Aspose.Slides.IMasterSlide masterSlide = sourceSlide.LayoutSlide.MasterSlide;
                masterSlide.ApplyExternalThemeToDependingSlides(themePath);
            }
            catch (Aspose.Slides.PptxReadException ex)
            {
                // Handle theme application errors (e.g., invalid theme file)
                Console.WriteLine("Failed to apply external theme: " + ex.Message);
            }

            // Render both slides to images for pixel comparison
            Aspose.Slides.IImage sourceImage = sourceSlide.GetImage(1f, 1f);
            Aspose.Slides.IImage clonedImage = clonedSlide.GetImage(1f, 1f);

            // Save images to memory streams in PNG format
            MemoryStream sourceStream = new MemoryStream();
            MemoryStream clonedStream = new MemoryStream();
            sourceImage.Save(sourceStream, Aspose.Slides.ImageFormat.Png);
            clonedImage.Save(clonedStream, Aspose.Slides.ImageFormat.Png);

            byte[] sourceBytes = sourceStream.ToArray();
            byte[] clonedBytes = clonedStream.ToArray();

            // Simple pixel comparison: compare byte arrays
            bool imagesAreIdentical = false;
            if (sourceBytes.Length == clonedBytes.Length)
            {
                imagesAreIdentical = true;
                for (int i = 0; i < sourceBytes.Length; i++)
                {
                    if (sourceBytes[i] != clonedBytes[i])
                    {
                        imagesAreIdentical = false;
                        break;
                    }
                }
            }

            Console.WriteLine("Images are identical: " + imagesAreIdentical);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            sourceImage.Dispose();
            clonedImage.Dispose();
            sourceStream.Dispose();
            clonedStream.Dispose();
            presentation.Dispose();
        }
    }
}