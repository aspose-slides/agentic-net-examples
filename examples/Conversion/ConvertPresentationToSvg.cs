using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Verify that a source file path is provided
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the path to a PPT or PPTX file as an argument.");
            return;
        }

        string sourcePath = args[0];

        // Load the presentation from the specified file
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath))
        {
            // Convert each slide to an individual SVG file
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                string svgFileName = Path.GetFileNameWithoutExtension(sourcePath) + "_slide_" + (i + 1) + ".svg";
                string svgFullPath = Path.Combine(Path.GetDirectoryName(sourcePath), svgFileName);

                using (FileStream svgStream = File.Create(svgFullPath))
                {
                    pres.Slides[i].WriteAsSvg(svgStream);
                }
            }

            // Save the presentation before exiting (optional, as per authoring rule)
            string savedPath = Path.Combine(Path.GetDirectoryName(sourcePath), Path.GetFileNameWithoutExtension(sourcePath) + "_saved.pptx");
            pres.Save(savedPath, SaveFormat.Pptx);
        }
    }
}