using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to input and output files
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Find the first picture shape on the slide
                Aspose.Slides.IShape pictureShape = null;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.PictureFrame)
                    {
                        pictureShape = shape;
                        break;
                    }
                }

                if (pictureShape != null)
                {
                    // Get the fill format of the shape
                    Aspose.Slides.IFillFormat fillFormat = pictureShape.FillFormat;

                    // Ensure the fill is solid to read the color
                    if (fillFormat != null && fillFormat.FillType == Aspose.Slides.FillType.Solid)
                    {
                        // Retrieve the color (includes alpha channel)
                        System.Drawing.Color color = fillFormat.SolidFillColor.Color;

                        // Calculate alpha transparency as a value between 0 and 1
                        float alphaTransparency = (float)color.A / 255f;

                        Console.WriteLine("Alpha transparency (0‑1): " + alphaTransparency);
                    }
                    else
                    {
                        Console.WriteLine("The shape does not have a solid fill.");
                    }
                }
                else
                {
                    Console.WriteLine("No picture shape found on the first slide.");
                }

                // Save the (potentially unchanged) presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}