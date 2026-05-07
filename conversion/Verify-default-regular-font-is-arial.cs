using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TestSwfDefaultFont
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "sample.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                // Verify that DefaultRegularFont defaults to "Arial"
                string defaultFont = swfOptions.DefaultRegularFont;
                if (defaultFont == "Arial")
                {
                    Console.WriteLine("DefaultRegularFont defaults to Arial as expected.");
                }
                else
                {
                    Console.WriteLine("DefaultRegularFont default is not Arial. Actual: " + defaultFont);
                }

                string outputPath = "output.swf";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                // Save presentation before exit (already saved)
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}