using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesPasswordProtection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation path
            string inputFileName = "input.pptx";
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Define password that meets the policy (minimum 12 characters, mixed case)
            string password = "StrongPass123";

            // Validate password policy
            if (password.Length < 12 || password == password.ToLower() || password == password.ToUpper())
            {
                Console.WriteLine("Password must be at least 12 characters long and contain both upper and lower case letters.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Apply password protection
                presentation.ProtectionManager.Encrypt(password);

                // Prepare output directory
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Save the protected presentation
                string outputPath = Path.Combine(outputDir, "protected.pptx");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation saved with password protection at: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported or other error
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}