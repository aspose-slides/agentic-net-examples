using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.odp";
                string outputFolder = "output_svg";
                Directory.CreateDirectory(outputFolder);

                Presentation presentation = new Presentation(inputPath);

                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    string svgPath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");
                    using (FileStream fileStream = File.Create(svgPath))
                    {
                        slide.WriteAsSvg(fileStream);
                    }
                }

                // Save the presentation before exiting
                presentation.Save("output.odp", SaveFormat.Odp);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}