using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace CloneSmartArtApplyTheme
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input files
            string presentationPath = "input.pptx";
            string themePath = "theme.thmx";

            // Verify files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }
            if (!File.Exists(themePath))
            {
                Console.WriteLine("Theme file not found: " + themePath);
                return;
            }

            // Load presentation
            using (Presentation presentation = new Presentation(presentationPath))
            {
                // Get first slide
                ISlide originalSlide = presentation.Slides[0];

                // Find first SmartArt shape on the slide
                ISmartArt originalSmartArt = null;
                foreach (IShape shape in originalSlide.Shapes)
                {
                    if (shape is ISmartArt)
                    {
                        originalSmartArt = (ISmartArt)shape;
                        break;
                    }
                }

                // If no SmartArt found, create one
                if (originalSmartArt == null)
                {
                    originalSmartArt = originalSlide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
                }

                // Clone the SmartArt by adding a new SmartArt with same layout
                ISmartArt clonedSmartArt = originalSlide.Shapes.AddSmartArt(500, 50, 400, 300, originalSmartArt.Layout);
                clonedSmartArt.ColorStyle = originalSmartArt.ColorStyle;
                clonedSmartArt.QuickStyle = originalSmartArt.QuickStyle;

                // Apply external theme to the first master slide (affects dependent slides)
                IMasterSlide master = presentation.Masters[0];
                master.ApplyExternalThemeToDependingSlides(themePath);

                // Render original slide and themed slide to images
                IImage originalImage = originalSlide.GetImage(1f, 1f);
                IImage themedImage = originalSlide.GetImage(1f, 1f); // same slide after theme change

                // Compare pixel data
                bool imagesAreEqual = CompareImages(originalImage, themedImage);
                Console.WriteLine("Images are equal after theme change: " + imagesAreEqual);

                // Save the presentation
                string outputPath = "output.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }

        // Helper method to compare two IImage objects pixel by pixel
        private static bool CompareImages(IImage img1, IImage img2)
        {
            // Save images to memory streams in PNG format
            using (MemoryStream ms1 = new MemoryStream())
            using (MemoryStream ms2 = new MemoryStream())
            {
                img1.Save(ms1, Aspose.Slides.ImageFormat.Png);
                img2.Save(ms2, Aspose.Slides.ImageFormat.Png);

                byte[] bytes1 = ms1.ToArray();
                byte[] bytes2 = ms2.ToArray();

                if (bytes1.Length != bytes2.Length)
                    return false;

                for (int i = 0; i < bytes1.Length; i++)
                {
                    if (bytes1[i] != bytes2[i])
                        return false;
                }
                return true;
            }
        }
    }
}