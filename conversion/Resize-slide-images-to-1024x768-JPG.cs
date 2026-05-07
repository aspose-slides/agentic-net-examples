using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDir = "output";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    using (Aspose.Slides.IImage image = slide.GetImage(new System.Drawing.Size(1024, 768)))
                    {
                        string outputPath = Path.Combine(outputDir, $"Slide_{slide.SlideNumber}.jpg");
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                    }
                }

                // Save the presentation before exiting (even if unchanged)
                string presOutput = Path.Combine(outputDir, "ModifiedPresentation.pptx");
                presentation.Save(presOutput, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}