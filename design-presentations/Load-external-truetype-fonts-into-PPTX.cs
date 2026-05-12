using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontLoadingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths (adjust as needed)
            string inputPath = @"C:\Presentations\input.pptx";
            string outputPath = @"C:\Presentations\output.pptx";
            string networkFontFolder = @"\\networkshare\fonts";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Configure load options to include network font folder
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.DocumentLevelFontSources.FontFolders = new string[] { networkFontFolder };

                // Load presentation with the specified font sources
                using (Presentation presentation = new Presentation(inputPath, loadOptions))
                {
                    // Perform any presentation manipulation here if needed

                    // Save the presentation before exiting
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}