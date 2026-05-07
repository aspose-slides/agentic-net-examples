using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontSubstitutionLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputSwfPath = "output.swf";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle loading exceptions (e.g., unsupported format)
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            try
            {
                // Log font substitution information
                foreach (Aspose.Slides.FontSubstitutionInfo substitution in presentation.FontsManager.GetSubstitutions())
                {
                    Console.WriteLine("Font substitution: {0} -> {1}", substitution.OriginalFontName, substitution.SubstitutedFontName);
                }

                // Configure SWF options (default options)
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                // Save the presentation as SWF
                presentation.Save(outputSwfPath, SaveFormat.Swf, swfOptions);
            }
            catch (Exception ex)
            {
                // Handle exceptions related to SWF generation or saving
                Console.WriteLine("Error during SWF generation: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is saved before exit (optional, saves original PPTX)
                try
                {
                    string tempSavePath = "temp_saved.pptx";
                    presentation.Save(tempSavePath, SaveFormat.Pptx);
                }
                catch
                {
                    // Ignore any errors during the final save
                }

                // Dispose the presentation object
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}