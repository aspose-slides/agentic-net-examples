using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.xps";

            using (Presentation pres = new Presentation(inputPath))
            {
                XpsOptions options = new XpsOptions();
                options.SaveMetafilesAsPng = true;

                pres.Save(outputPath, SaveFormat.Xps, options);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}