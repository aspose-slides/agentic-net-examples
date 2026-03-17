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
                        Aspose.Slides.Export.SVGOptions options = new Aspose.Slides.Export.SVGOptions();
                        options.VectorizeText = true;
                        slide.WriteAsSvg(fileStream, options);
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