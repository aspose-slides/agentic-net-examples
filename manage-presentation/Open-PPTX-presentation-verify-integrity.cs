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
                presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
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