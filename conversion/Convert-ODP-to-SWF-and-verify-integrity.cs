using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.odp";
        string outputPath = "output.swf";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation pres = new Presentation(inputPath);
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf);
            if (File.Exists(outputPath))
            {
                FileInfo info = new FileInfo(outputPath);
                if (info.Length > 0)
                {
                    Console.WriteLine("Conversion successful. Output file size: " + info.Length);
                }
                else
                {
                    Console.WriteLine("Output file is empty.");
                }
            }
            else
            {
                Console.WriteLine("Output file was not created.");
            }
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // format not supported
            Console.WriteLine("The format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}