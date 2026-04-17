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
            string logPath = "font_substitutions.log";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Open log file for writing
                StreamWriter logWriter = new StreamWriter(logPath, false);

                // Record font substitution events
                foreach (Aspose.Slides.FontSubstitutionInfo substitution in presentation.FontsManager.GetSubstitutions())
                {
                    string logLine = substitution.OriginalFontName + " -> " + substitution.SubstitutedFontName;
                    Console.WriteLine(logLine);
                    logWriter.WriteLine(logLine);
                }

                logWriter.Flush();
                logWriter.Close();

                // Configure SWF options (default settings)
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                // Save presentation as SWF
                presentation.Save(outputSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                // Dispose presentation
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}