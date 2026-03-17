using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputPath = "largePresentation.pptx";
                var outputPath = "output.pdf";

                using (var presentation = new Presentation(inputPath))
                {
                    using (var outputStream = new MemoryStream())
                    {
                        presentation.Save(outputStream, Aspose.Slides.Export.SaveFormat.Pdf);
                        File.WriteAllBytes(outputPath, outputStream.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}