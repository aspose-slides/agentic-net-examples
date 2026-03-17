using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.xps";

                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Create XPS options (optional)
                    XpsOptions options = new XpsOptions();
                    // Include hidden slides in the output
                    options.ShowHiddenSlides = true;

                    // Save the presentation as XPS
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, options);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}