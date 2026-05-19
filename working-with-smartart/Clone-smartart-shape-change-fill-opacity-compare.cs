using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace CloneSmartArtExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string originalImagePath = "original.png";
            string clonedImagePath = "cloned.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Access the first slide
                    Aspose.Slides.ISlide slide = pres.Slides[0];

                    // Locate the first SmartArt shape on the slide
                    Aspose.Slides.IShape smartArtShape = null;
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.SmartArt.ISmartArt)
                        {
                            smartArtShape = shape;
                            break;
                        }
                    }

                    if (smartArtShape == null)
                    {
                        Console.WriteLine("No SmartArt shape found on the first slide.");
                        return;
                    }

                    // Clone the SmartArt shape using the shape collection AddClone method
                    // Place the clone below the original shape
                    Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(
                        smartArtShape,
                        smartArtShape.X,
                        smartArtShape.Y + smartArtShape.Height);

                    // Change fill opacity of the cloned SmartArt shape
                    // Set solid fill and adjust alpha (opacity) to 50%
                    clonedShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    clonedShape.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;
                    clonedShape.FillFormat.SolidFillColor.ColorTransform.Add(
                        Aspose.Slides.ColorTransformOperation.MultiplyAlpha,
                        0.5f);

                    // Export original slide image for visual comparison
                    using (Aspose.Slides.IImage originalImage = slide.GetImage())
                    {
                        originalImage.Save(originalImagePath, Aspose.Slides.ImageFormat.Png);
                    }

                    // Export modified slide image for visual comparison
                    using (Aspose.Slides.IImage clonedImage = slide.GetImage())
                    {
                        clonedImage.Save(clonedImagePath, Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external resources, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}