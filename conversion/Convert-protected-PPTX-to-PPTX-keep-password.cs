using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "protected.pptx";
        string outputPath = "output.pptx";
        string password = "myPassword";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.Password = password;

        try
        {
            using (Presentation presentation = new Presentation(inputPath, loadOptions))
            {
                // Re‑encrypt with the same password to retain protection
                presentation.ProtectionManager.Encrypt(password);
                presentation.Save(outputPath, SaveFormat.Pptx);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (InvalidPasswordException)
        {
            Console.WriteLine("Invalid password provided for the input file.");
        }
        catch (PptxUnsupportedFormatException)
        {
            // format not supported
            Console.WriteLine("The file format is not supported for conversion.");
        }
        catch (NotSupportedException ex)
        {
            // e.g., trying to save encrypted file in unsupported format
            Console.WriteLine("Operation not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}