// -----------------------------------------------------------------------------
// Example: Load PPTX presentation from stream for security using C#
//
// Description:
// Demonstrates how to load a PPTX presentation from a file stream, inspect
// its security settings (write protection and open password), optionally
// remove write protection, and save the modified presentation using Aspose.Slides
// for .NET. This pattern helps ensure secure handling of PowerPoint files in
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Stream, Presentation,
// Security, Write Protection, Password Protection, Office Automation
//
// Use Cases:
// - Load PPTX presentations securely from streams.
// - Detect and validate write protection and open passwords.
// - Remove write protection programmatically.
// - Automate secure PPTX processing in .NET tools.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input file path
        string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Open file stream for the presentation
            FileStream fileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            // Load presentation from the stream
            Presentation presentation = new Presentation(fileStream);
            fileStream.Close();

            // Get presentation info without loading the full presentation
            IPresentationInfo presentationInfo = PresentationFactory.Instance.GetPresentationInfo(inputFile);

            // Check write protection
            bool isWriteProtected = presentationInfo.IsWriteProtected == NullableBool.True;
            bool isWriteProtectedByPassword = false;
            if (isWriteProtected)
            {
                // Example write protection password
                string writePassword = "writePass";
                isWriteProtectedByPassword = presentationInfo.CheckWriteProtection(writePassword);
                Console.WriteLine("Write protection password valid: " + isWriteProtectedByPassword);
            }

            // Check open password protection
            bool isPasswordProtected = presentationInfo.IsPasswordProtected;
            if (isPasswordProtected)
            {
                // Example open password
                string openPassword = "openPass";
                bool isOpenPasswordCorrect = presentationInfo.CheckPassword(openPassword);
                Console.WriteLine("Open password correct: " + isOpenPasswordCorrect);
            }

            // Remove write protection if the loaded presentation is write protected
            if (presentation.ProtectionManager.IsWriteProtected)
            {
                presentation.ProtectionManager.RemoveWriteProtection();
                Console.WriteLine("Write protection removed.");
            }

            // Save the presentation before exiting
            string outputFile = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            presentation.Save(outputFile, SaveFormat.Pptx);
            presentation.Dispose();
            Console.WriteLine("Presentation saved to " + outputFile);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
