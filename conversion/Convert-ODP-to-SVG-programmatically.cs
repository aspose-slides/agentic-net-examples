using System;
using System.IO;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.odp";
                string outputDir = "output_svgs";

                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    int slideCount = presentation.Slides.Count;
                    for (int i = 0; i < slideCount; i++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[i];
                        string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                        using (FileStream fileStream = File.Create(svgPath))
                        {
                            slide.WriteAsSvg(fileStream);
                        }
                    }

                    string savedPath = "saved_output.pptx";
                    presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}