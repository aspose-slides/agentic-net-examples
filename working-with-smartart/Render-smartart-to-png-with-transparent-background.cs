using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        string sourcePath = "template.pptx";
        string outputImagePath = "smartart.png";
        string outputPresentationPath = "output.pptx";

        try
        {
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            using (Presentation pres = new Presentation(sourcePath))
            {
                ISlide slide = pres.Slides[0];
                // Add SmartArt diagram
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
                // Set transparent background for the SmartArt
                smartArt.FillFormat.FillType = FillType.NoFill;

                // Render SmartArt to PNG image
                IImage smartArtImage = smartArt.GetImage();
                smartArtImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);

                // Save the presentation
                pres.Save(outputPresentationPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}