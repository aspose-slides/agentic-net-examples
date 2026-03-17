using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            using (Presentation pres = new Presentation(inputPath))
            {
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];
                    string outputPath = $"slide_{i + 1}.svg";
                    using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        SVGOptions options = new SVGOptions();
                        options.VectorizeText = true;
                        slide.WriteAsSvg(fs, options);
                    }
                }
                // Save the presentation before exiting
                pres.Save("output_saved.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}