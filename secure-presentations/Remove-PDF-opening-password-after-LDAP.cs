using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputFileName = "protected.pptx";
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        bool isUserAuthorized = false;
        try
        {
            // LDAP authentication placeholder
            // Replace with actual LDAP verification logic.
            isUserAuthorized = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("LDAP verification failed: " + ex.Message);
            return;
        }

        if (!isUserAuthorized)
        {
            Console.WriteLine("User not authorized.");
            return;
        }

        string password = "userPassword";

        Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath);
        bool isPasswordCorrect = presentationInfo.CheckPassword(password);
        if (!isPasswordCorrect)
        {
            Console.WriteLine("Incorrect password.");
            return;
        }

        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.Password = password;
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("File format not supported.");
            return;
        }

        // Remove opening password
        presentation.ProtectionManager.RemoveEncryption();

        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }
        string outputPath = Path.Combine(outputDir, "unprotected.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();

        Console.WriteLine("Password removed and file saved to: " + outputPath);
    }
}