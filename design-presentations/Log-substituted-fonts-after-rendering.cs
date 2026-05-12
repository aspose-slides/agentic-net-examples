using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontSubstitutionAudit
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Retrieve and log font substitution information
                foreach (FontSubstitutionInfo fontSubstitution in pres.FontsManager.GetSubstitutions())
                {
                    Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
                }

                // Save the presentation before exiting
                pres.Save(outputPath, SaveFormat.Pptx);

                // Dispose the presentation object
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the format is not supported, you may log a specific comment here
                // Format not supported.
            }
        }
    }
}