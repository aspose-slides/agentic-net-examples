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
            string outputDirectory = "output_svgs";

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            using (Presentation presentation = new Presentation(inputPath))
            {
                int slideCount = presentation.Slides.Count;
                for (int index = 0; index < slideCount; index++)
                {
                    string svgFilePath = Path.Combine(outputDirectory, $"slide_{index + 1}.svg");
                    using (FileStream fileStream = new FileStream(svgFilePath, FileMode.Create, FileAccess.Write))
                    {
                        presentation.Slides[index].WriteAsSvg(fileStream);
                    }
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}