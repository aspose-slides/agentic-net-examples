using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesErrorConstants
{
    // Define error constant identifiers
    public static class ErrorCodes
    {
        public const int FileNotFound = 1001;
        public const int InvalidFormat = 1002;
        public const int CorruptFile = 1003;
        public const int UnknownError = 1999;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error ({0}): Input file does not exist.", ErrorCodes.FileNotFound);
                return;
            }

            // Load the presentation and handle possible errors
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
                // Perform any processing here (omitted for brevity)

                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully.");
            }
            catch (Aspose.Slides.PptxReadException ex)
            {
                Console.WriteLine("Error ({0}): Unable to read PPTX file. {1}", ErrorCodes.InvalidFormat, ex.Message);
            }
            catch (Aspose.Slides.PptCorruptFileException ex)
            {
                Console.WriteLine("Error ({0}): Corrupt presentation file. {1}", ErrorCodes.CorruptFile, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ({0}): An unexpected error occurred. {1}", ErrorCodes.UnknownError, ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}