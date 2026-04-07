using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output SWF file path
            string outputPath = "output.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Set a custom solid background color for the first slide (corporate style)
                int slideIndex = 0;
                presentation.Slides[slideIndex].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                presentation.Slides[slideIndex].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                presentation.Slides[slideIndex].Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(0, 120, 215);

                // Configure SWF export options
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                swfOptions.ViewerIncluded = true; // include the integrated viewer

                // Save the presentation as SWF with the specified options
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                // Dispose the presentation object
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}