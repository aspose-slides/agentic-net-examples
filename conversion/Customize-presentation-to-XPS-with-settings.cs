using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "Convert_XPS_Options.pptx";
                string outputPath = "XPS_With_Options_out.xps";

                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Create XPS conversion options
                    Aspose.Slides.Export.XpsOptions options = new Aspose.Slides.Export.XpsOptions();
                    options.SaveMetafilesAsPng = true; // Custom setting

                    // Save the presentation as XPS with the specified options
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, options);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during conversion
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}