using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneSmartArtAndCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string themePath = "theme.thmx";
            string outputPath = "output.pptx";
            string originalImagePath = "original.png";
            string clonedImagePath = "cloned.png";

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }
            if (!File.Exists(themePath))
            {
                Console.WriteLine("Theme file not found: " + themePath);
                return;
            }

            // Load presentation
            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Get source slide and shapes
            Aspose.Slides.ISlide srcSlide = pres.Slides[0];
            Aspose.Slides.IShapeCollection srcShapes = srcSlide.Shapes;

            // Find a SmartArt shape (assume first shape is SmartArt for demo)
            Aspose.Slides.SmartArt.SmartArt smartArt = srcShapes[0] as Aspose.Slides.SmartArt.SmartArt;
            if (smartArt == null)
            {
                Console.WriteLine("No SmartArt shape found on the first slide.");
                pres.Dispose();
                return;
            }

            // Create a blank layout slide and add a new slide
            Aspose.Slides.ILayoutSlide blankLayout = pres.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
            Aspose.Slides.ISlide destSlide = pres.Slides.AddEmptySlide(blankLayout);
            Aspose.Slides.IShapeCollection destShapes = destSlide.Shapes;

            // Clone the SmartArt shape to the new slide (using AddClone as per clone-shapes rule)
            destShapes.AddClone(srcShapes[0], 100f, 100f);

            // Apply external theme to the master slide of the destination slide
            Aspose.Slides.IMasterSlide destMaster = destSlide.LayoutSlide.MasterSlide;
            try
            {
                destMaster.ApplyExternalThemeToDependingSlides(themePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to apply external theme: " + ex.Message);
                // Continue without theme change
            }

            // Render original slide to image
            using (Aspose.Slides.IImage originalImage = srcSlide.GetImage())
            {
                originalImage.Save(originalImagePath, Aspose.Slides.ImageFormat.Png);
            }

            // Render cloned slide to image
            using (Aspose.Slides.IImage clonedImage = destSlide.GetImage())
            {
                clonedImage.Save(clonedImagePath, Aspose.Slides.ImageFormat.Png);
            }

            // Compare images pixel by pixel
            bool imagesAreIdentical = true;
            try
            {
                using (MemoryStream msOriginal = new MemoryStream())
                using (MemoryStream msCloned = new MemoryStream())
                {
                    using (Aspose.Slides.IImage originalImg = srcSlide.GetImage())
                    {
                        originalImg.Save(msOriginal, Aspose.Slides.ImageFormat.Png);
                    }
                    using (Aspose.Slides.IImage clonedImg = destSlide.GetImage())
                    {
                        clonedImg.Save(msCloned, Aspose.Slides.ImageFormat.Png);
                    }

                    byte[] bytesOriginal = msOriginal.ToArray();
                    byte[] bytesCloned = msCloned.ToArray();

                    if (bytesOriginal.Length != bytesCloned.Length)
                    {
                        imagesAreIdentical = false;
                    }
                    else
                    {
                        for (int i = 0; i < bytesOriginal.Length; i++)
                        {
                            if (bytesOriginal[i] != bytesCloned[i])
                            {
                                imagesAreIdentical = false;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during image comparison: " + ex.Message);
                imagesAreIdentical = false;
            }

            Console.WriteLine("Images are identical: " + imagesAreIdentical);

            // Save the modified presentation
            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Clean up
            pres.Dispose();
        }
    }
}