using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace CloneSmartArtOpacity
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    ISlide slide = pres.Slides[0];

                    // Add a SmartArt diagram if none exists
                    ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

                    // Get the first shape inside the SmartArt
                    ISmartArtNode firstNode = smartArt.Nodes[0];
                    ISmartArtShape originalShape = firstNode.Shapes[0];

                    // Clone the SmartArt shape to a new position
                    IShape clonedShape = slide.Shapes.AddClone(originalShape, 500, 50);

                    // Set fill opacity for the original shape (80%)
                    originalShape.FillFormat.FillType = FillType.Solid;
                    originalShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;
                    originalShape.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyAlpha, 0.8f);

                    // Set fill opacity for the cloned shape (30%)
                    ISmartArtShape clonedSmartArtShape = (ISmartArtShape)clonedShape;
                    clonedSmartArtShape.FillFormat.FillType = FillType.Solid;
                    clonedSmartArtShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;
                    clonedSmartArtShape.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyAlpha, 0.3f);

                    // Export slide images for visual comparison (use external diff tool)
                    IImage slideImage = slide.GetImage(1f, 1f);
                    slideImage.Save("slide_original.png", Aspose.Slides.ImageFormat.Png);
                    slideImage.Save("slide_cloned.png", Aspose.Slides.ImageFormat.Png);

                    // Save the modified presentation
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}