using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths for source and output presentations
                string sourcePath = "source.pptx";
                string outputPath = "result.pptx";

                // Load the source presentation
                using (Presentation sourcePres = new Presentation(sourcePath))
                {
                    // Access the first slide and its first shape (assumed to contain a paragraph)
                    ISlide sourceSlide = sourcePres.Slides[0];
                    IShape sourceShape = sourceSlide.Shapes[0];

                    // Generate a scaled image of the shape (scale factor 2)
                    using (IImage shapeImage = sourceShape.GetImage(ShapeThumbnailBounds.Shape, 2f, 2f))
                    {
                        // Create a new presentation to embed the image
                        using (Presentation destPres = new Presentation())
                        {
                            // Add the image to the presentation's image collection
                            IPPImage ippImage = destPres.Images.AddImage(shapeImage);

                            // Add a picture frame containing the image to the first slide
                            ISlide destSlide = destPres.Slides[0];
                            destSlide.Shapes.AddPictureFrame(
                                ShapeType.Rectangle,
                                50f,
                                50f,
                                shapeImage.Width,
                                shapeImage.Height,
                                ippImage);

                            // Save the resulting presentation
                            destPres.Save(outputPath, SaveFormat.Pptx);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}