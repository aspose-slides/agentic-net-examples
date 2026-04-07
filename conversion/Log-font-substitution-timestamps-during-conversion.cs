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
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate over font substitution information and log with timestamp
                foreach (FontSubstitutionInfo substitution in pres.FontsManager.GetSubstitutions())
                {
                    string timestamp = DateTime.Now.ToString("o");
                    Console.WriteLine($"{timestamp}: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
                }

                // Save the presentation before exiting
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred during processing: " + ex.Message);
                // Format not supported comment
                // Note: If the file format is not supported, an exception will be thrown.
            }
        }
    }
}