using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.odp";
            string outputDir = "output_svg";
            Directory.CreateDirectory(outputDir);

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.Export.SVGOptions svgOptions = Aspose.Slides.Export.SVGOptions.WYSIWYG;

                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");
                    using (FileStream fileStream = new FileStream(svgPath, FileMode.Create, FileAccess.Write))
                    {
                        slide.WriteAsSvg(fileStream, svgOptions);
                    }
                }

                // Save the presentation to ensure all resources are flushed
                string tempPath = Path.Combine(outputDir, "temp.pptx");
                presentation.Save(tempPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}