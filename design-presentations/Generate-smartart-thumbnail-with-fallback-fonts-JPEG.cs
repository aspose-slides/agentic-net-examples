using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDir = "output";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            using (Presentation pres = new Presentation(inputPath))
            {
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Add a SmartArt diagram to the first slide
                Aspose.Slides.SmartArt.ISmartArt smartArt = pres.Slides[0].Shapes.AddSmartArt(
                    50f, 50f, 400f, 300f, SmartArtLayoutType.BasicBlockList);

                // Set rendering options with a fallback font
                RenderingOptions renderingOpts = new RenderingOptions();
                renderingOpts.DefaultRegularFont = "Arial Black";

                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];
                    IImage thumbnail = slide.GetImage(renderingOpts, 1f, 1f);
                    string outPath = Path.Combine(outputDir, $"slide_{i + 1}.jpg");
                    thumbnail.Save(outPath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Save the modified presentation
                string savedPath = Path.Combine(outputDir, "result.pptx");
                pres.Save(savedPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("Unsupported file format: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}