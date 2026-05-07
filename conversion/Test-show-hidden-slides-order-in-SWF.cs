using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TestShowHiddenSlidesInSwf
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPathHiddenFalse = "output_showhidden_false.swf";
            string outputPathHiddenTrue = "output_showhidden_true.swf";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Save without hidden slides
                SwfOptions optionsFalse = new SwfOptions();
                optionsFalse.ShowHiddenSlides = false;
                presentation.Save(outputPathHiddenFalse, SaveFormat.Swf, optionsFalse);

                // Save with hidden slides
                SwfOptions optionsTrue = new SwfOptions();
                optionsTrue.ShowHiddenSlides = true;
                presentation.Save(outputPathHiddenTrue, SaveFormat.Swf, optionsTrue);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("SWF files generated successfully.");
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for conversion to SWF.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}