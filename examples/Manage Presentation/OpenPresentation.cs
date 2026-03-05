using System;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Path to the password‑protected presentation
        string inputPath = "protected.pptx";
        // Path where the decrypted presentation will be saved
        string outputPath = "unprotected.pptx";
        // Password to open the presentation
        string password = "YOUR_PASSWORD";

        // Retrieve information about the presentation
        Aspose.Slides.IPresentationInfo info = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath);
        if (info.IsPasswordProtected)
        {
            Console.WriteLine("The presentation is protected by a password.");
        }

        // Set load options with the password
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.Password = password;

        // Open the presentation using the load options
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))
        {
            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }

        Console.WriteLine("Presentation saved to " + outputPath);
    }
}