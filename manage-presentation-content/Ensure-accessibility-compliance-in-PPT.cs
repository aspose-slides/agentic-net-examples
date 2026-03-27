using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationAccessibilityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Input file not found: " + inputFilePath);
                return;
            }

            // Check presentation protection status without loading the full file
            Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputFilePath);
            bool isWriteProtected = presentationInfo.IsWriteProtected == Aspose.Slides.NullableBool.True;
            bool isPasswordProtected = presentationInfo.IsPasswordProtected;

            if (isWriteProtected)
            {
                // Example write protection password check
                bool writePasswordValid = presentationInfo.CheckWriteProtection("writePassword");
                Console.WriteLine("Write protection password valid: " + writePasswordValid);
            }

            if (isPasswordProtected)
            {
                // Example open password check
                bool openPasswordValid = presentationInfo.CheckPassword("openPassword");
                Console.WriteLine("Open password valid: " + openPasswordValid);
            }

            // Load the presentation (full load)
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFilePath);

            // Access and modify built‑in document properties for accessibility compliance
            Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;
            documentProperties.Author = "Accessibility Team";
            documentProperties.Title = "Accessible Presentation";
            documentProperties.Subject = "Demo of accessibility compliance";

            // Enable media controls in slide show settings
            presentation.SlideShowSettings.ShowMediaControls = true;

            // Save the modified presentation
            presentation.Save(outputFilePath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();

            Console.WriteLine("Presentation processed and saved to: " + outputFilePath);
        }
    }
}