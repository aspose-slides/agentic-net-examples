using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyPresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the presentation file
            string inputPath = "sample.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Load the presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (ArgumentException)
            {
                // Format not supported or file is empty
                Console.WriteLine("File format not supported or file is empty.");
                return;
            }
            catch (Exception ex)
            {
                // Other loading errors
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // TODO: Add further processing of the presentation here

            // Save the presentation before exiting
            try
            {
                string outputPath = "output.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                // Dispose the presentation object
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}