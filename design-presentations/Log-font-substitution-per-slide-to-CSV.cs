using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string csvPath = "font_substitutions.csv";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Create CSV file and write header
                using (StreamWriter writer = new StreamWriter(csvPath, false))
                {
                    writer.WriteLine("SlideIndex,OriginalFont,SubstitutedFont");

                    // Iterate through slides (slide indexes start at 1)
                    int slideCount = pres.Slides.Count;
                    for (int i = 0; i < slideCount; i++)
                    {
                        int slideIndex = i + 1;
                        int[] targetSlides = new int[] { slideIndex };

                        // Get font substitutions for the current slide
                        foreach (FontSubstitutionInfo substitution in pres.FontsManager.GetSubstitutions(targetSlides))
                        {
                            string line = string.Format("{0},{1},{2}", slideIndex, substitution.OriginalFontName, substitution.SubstitutedFontName);
                            writer.WriteLine(line);
                        }
                    }
                }

                // Save the presentation before exiting
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}