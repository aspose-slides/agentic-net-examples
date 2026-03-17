using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputFolder = "output";

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    string svgPath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");
                    using (FileStream fileStream = File.Create(svgPath))
                    {
                        presentation.Slides[i].WriteAsSvg(fileStream);
                    }
                }

                string savedPath = Path.Combine(outputFolder, "saved.pptx");
                presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}