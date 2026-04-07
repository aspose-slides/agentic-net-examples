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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            // Save as SWF using default settings
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf);
            pres.Dispose();

            // Verify output file integrity
            if (File.Exists(outputPath))
            {
                FileInfo info = new FileInfo(outputPath);
                if (info.Length > 0)
                {
                    Console.WriteLine("Conversion successful. Output file size: " + info.Length + " bytes.");
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
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}