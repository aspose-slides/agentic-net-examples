using System;
using System.IO;
using Aspose.Slides.Export;

namespace ConvertPptToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputDir = "output_svgs";

                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[i];
                        string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                        using (FileStream fileStream = File.Create(svgPath))
                        {
                            slide.WriteAsSvg(fileStream);
                        }
                    }

                    // Save the presentation before exiting
                    string savedPath = Path.Combine(outputDir, "saved.pptx");
                    presentation.Save(savedPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}