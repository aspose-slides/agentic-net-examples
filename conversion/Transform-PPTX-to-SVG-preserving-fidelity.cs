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
            string outputDirectory = "output_svg";
            Directory.CreateDirectory(outputDirectory);

            using (Presentation presentation = new Presentation(inputPath))
            {
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");
                    using (FileStream fileStream = File.Create(svgFilePath))
                    {
                        SVGOptions options = SVGOptions.WYSIWYG;
                        slide.WriteAsSvg(fileStream, options);
                    }
                }

                // Save the presentation before exiting
                string savedPresentationPath = Path.Combine(outputDirectory, "saved.pptx");
                presentation.Save(savedPresentationPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}