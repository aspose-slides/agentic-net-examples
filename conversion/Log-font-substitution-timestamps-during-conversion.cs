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
            string outputPath = "output.pdf";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation and log font substitutions
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate over font substitution information
                foreach (FontSubstitutionInfo substitution in presentation.FontsManager.GetSubstitutions())
                {
                    string logEntry = string.Format("{0:O}: Font substitution - {1} -> {2}",
                                                    DateTime.Now,
                                                    substitution.OriginalFontName,
                                                    substitution.SubstitutedFontName);
                    Console.WriteLine(logEntry);
                }

                // Attempt to save the presentation in PDF format
                try
                {
                    presentation.Save(outputPath, SaveFormat.Pdf);
                }
                catch (NotSupportedException)
                {
                    // Comment: format not supported
                    Console.WriteLine("The specified save format is not supported.");
                }
            }
        }
    }
}