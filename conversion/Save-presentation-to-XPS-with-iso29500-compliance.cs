using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesXpsExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.xps";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();
                    // If XpsOptions has a Compliance property, set it to ISO29500 here.
                    // xpsOptions.Compliance = Aspose.Slides.Export.XpsCompliance.ISO29500;
                    xpsOptions.SaveMetafilesAsPng = true;

                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}