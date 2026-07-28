// -----------------------------------------------------------------------------
// Example: Open PPTX presentation verify integrity using C#
//
// Description:
// Demonstrates how to verify the integrity of a PPTX presentation, check its
// load format and password protection status, and optionally modify its
// protection settings using Aspose.Slides for .NET. The example opens the file
// only for metadata inspection first, then loads the full presentation to set
// a read‑only recommendation and save the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Open, Verify, Integrity, 
// Presentation, Protection, ReadOnly, Password, PresentationInfo, 
// PresentationFactory
//
// Use Cases:
// - Verify PPTX file integrity and load format without full loading.
// - Detect and validate password protection on a presentation.
// - Apply read‑only recommendation to a PPTX file.
// - Automate PPTX validation and protection adjustments in .NET applications.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file does not exist: " + inputFile);
            return;
        }

        try
        {
            // Verify presentation information without loading the full presentation
            IPresentationInfo presentationInfo = PresentationFactory.Instance.GetPresentationInfo(inputFile);
            Console.WriteLine("Load format: " + presentationInfo.LoadFormat);

            bool isPasswordProtected = presentationInfo.IsPasswordProtected;
            Console.WriteLine("Password protected: " + isPasswordProtected);

            if (isPasswordProtected)
            {
                // Example password check (replace with actual password if needed)
                bool isPasswordCorrect = presentationInfo.CheckPassword("openPassword");
                Console.WriteLine("Password correct: " + isPasswordCorrect);
            }

            // Open the presentation for modifications
            using (Presentation presentation = new Presentation(inputFile))
            {
                // Example modification: set read‑only recommendation
                presentation.ProtectionManager.ReadOnlyRecommended = true;

                // Save the modified presentation
                string outputFile = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                presentation.Save(outputFile, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
