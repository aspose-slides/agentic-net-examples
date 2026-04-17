using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesPasswordDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the input presentation file name
            string inputFileName = "input.pptx";
            // Build the full path to the presentation
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);

            // Check if the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File does not exist: " + inputPath);
                return;
            }

            try
            {
                // Get presentation information without opening the file
                Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath);
                bool isPasswordProtected = presentationInfo.IsPasswordProtected;

                if (isPasswordProtected)
                {
                    Console.WriteLine("The presentation '" + inputPath + "' is protected by a password to open.");
                }
                else
                {
                    Console.WriteLine("The presentation '" + inputPath + "' is not password protected.");

                    // Open the presentation (since it is not password protected)
                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                    // Save the presentation before exiting (as per authoring rule)
                    presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    presentation.Dispose();
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}