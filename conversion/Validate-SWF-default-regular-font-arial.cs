using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "test.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.Export.SwfOptions swfOpts = new Aspose.Slides.Export.SwfOptions();

            // Verify the default regular font
            string defaultFont = swfOpts.DefaultRegularFont;
            if (defaultFont == "Arial")
            {
                Console.WriteLine("DefaultRegularFont is Arial as expected.");
            }
            else
            {
                Console.WriteLine("DefaultRegularFont is not Arial. Actual: " + defaultFont);
            }

            string outputPath = "output.swf";
            pres.Save(outputPath, SaveFormat.Swf, swfOpts);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}