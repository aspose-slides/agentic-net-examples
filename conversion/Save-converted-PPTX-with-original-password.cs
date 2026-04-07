using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output configuration
        string inputPath = "input.pptx";
        string outputDir = "output";
        string outputFileName = "converted.pptx";
        string password = "myPassword";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Get presentation info to determine if it is password protected
            IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(inputPath);

            if (info.IsPasswordProtected)
            {
                // Load the presentation using the original password
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.Password = password;
                Presentation presentation = new Presentation(inputPath, loadOptions);

                // Re‑apply the same password to preserve protection
                presentation.ProtectionManager.Encrypt(password);

                // Save the presentation
                string outputPath = Path.Combine(outputDir, outputFileName);
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved with original password preserved.");
            }
            else
            {
                // No password protection; simply load and save
                Presentation presentation = new Presentation(inputPath);
                string outputPath = Path.Combine(outputDir, outputFileName);
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved without password.");
            }
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}