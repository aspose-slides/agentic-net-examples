using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputFile = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file not found: " + inputFile);
            return;
        }

        // Get presentation info without loading the full presentation
        Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputFile);
        Aspose.Slides.LoadFormat loadFormat = presentationInfo.LoadFormat;
        Console.WriteLine("Presentation load format: " + loadFormat);

        // Check write protection status
        bool isWriteProtected = presentationInfo.IsWriteProtected == Aspose.Slides.NullableBool.True;
        if (isWriteProtected)
        {
            bool writeProtectionValid = presentationInfo.CheckWriteProtection("writePassword");
            Console.WriteLine("Write protection password valid: " + writeProtectionValid);
        }

        // Check if the presentation is password protected
        if (presentationInfo.IsPasswordProtected)
        {
            bool openPasswordValid = presentationInfo.CheckPassword("openPassword");
            Console.WriteLine("Open password valid: " + openPasswordValid);
        }

        // Load the presentation, perform any required processing, and save it
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFile))
        {
            // Save the presentation to maintain slide integrity
            pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }

        Console.WriteLine("Presentation saved to: " + outputFile);
    }
}