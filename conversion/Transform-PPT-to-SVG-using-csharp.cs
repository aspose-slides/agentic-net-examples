using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PowerPointToSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputDirectory = "output_svgs";

                Directory.CreateDirectory(outputDirectory);

                using (Presentation presentation = new Presentation(inputPath))
                {
                    SVGOptions svgOptions = new SVGOptions();
                    svgOptions.VectorizeText = true;

                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        string svgPath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");

                        using (FileStream fileStream = File.Create(svgPath))
                        {
                            slide.WriteAsSvg(fileStream, svgOptions);
                        }
                    }

                    // Save the presentation before exiting (optional)
                    presentation.Save("output_saved.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}