using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputDir = Path.Combine(dataDir, "output");
            Directory.CreateDirectory(outputDir);

            // Load presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                    // Iterate through shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Process only picture frames
                        if (shape is Aspose.Slides.IPictureFrame)
                        {
                            Aspose.Slides.IPictureFrame picture = (Aspose.Slides.IPictureFrame)shape;

                            // Retrieve the image associated with the picture frame
                            Aspose.Slides.IPPImage ppImage = picture.PictureFormat.Picture.Image;

                            // Check if the image is an SVG vector image
                            if (ppImage != null && ppImage.SvgImage != null)
                            {
                                // Export the shape (vector image) as native SVG
                                string svgPath = Path.Combine(outputDir, $"slide{slideIndex + 1}_shape{shapeIndex + 1}.svg");
                                using (FileStream fs = new FileStream(svgPath, FileMode.Create, FileAccess.Write))
                                {
                                    shape.WriteAsSvg(fs);
                                }
                            }
                        }
                    }
                }

                // Save the (potentially unchanged) presentation before exiting
                string outPptxPath = Path.Combine(outputDir, "output.pptx");
                pres.Save(outPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}