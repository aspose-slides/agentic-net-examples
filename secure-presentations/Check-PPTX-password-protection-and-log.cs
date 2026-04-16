using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Define the PPTX file name
        string inputFileName = "sample.pptx";

        // Build the full path to the file
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);

        // Check if the file exists
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist: " + filePath);
            return;
        }

        try
        {
            // Get presentation information without loading the whole presentation
            IPresentationInfo presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

            // Determine if the presentation is password protected
            bool isPasswordProtected = presentationInfo.IsPasswordProtected;

            if (isPasswordProtected)
            {
                Console.WriteLine("The presentation '" + filePath + "' is protected by password to open.");
            }
            else
            {
                Console.WriteLine("The presentation '" + filePath + "' is not password protected.");
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