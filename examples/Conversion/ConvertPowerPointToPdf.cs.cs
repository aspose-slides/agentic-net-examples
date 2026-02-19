using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path
        string inputPath;
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            inputPath = args[0];
        }
        else
        {
            inputPath = "sample.pptx"; // default input file
        }

        // Determine output file path
        string directory = System.IO.Path.GetDirectoryName(inputPath);
        string filenameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(inputPath);
        string outputPath = System.IO.Path.Combine(directory ?? "", filenameWithoutExt + ".pdf");

        // Load the presentation and convert to PDF
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
        {
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
        }
    }
}