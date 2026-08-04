// -----------------------------------------------------------------------------
// Example: Validate PPTX checksum after decryption using C#
//
// Description:
// Demonstrates how to validate the MD5 checksum of a password‑protected PPTX
// file after decryption using Aspose.Slides for .NET. The example opens a
// protected presentation, saves a decrypted copy, computes its checksum and
// compares it with an expected value. This pattern can be used to verify that
// decryption succeeded and the file integrity is intact.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Checksum, Decryption,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Verify integrity of decrypted PowerPoint files.
// - Automate validation of PPTX checksum after password removal.
// - Build .NET tools for secure presentation handling.
// - Ensure correct password and file integrity before further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesPasswordValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file name and password
            string pptFileName = "protected.pptx";
            string password = "myPassword";
            string expectedChecksum = "0123456789ABCDEF0123456789ABCDEF"; // replace with actual checksum

            // Build full path and verify existence
            string pptPath = Path.Combine(Directory.GetCurrentDirectory(), pptFileName);
            if (!File.Exists(pptPath))
            {
                Console.WriteLine("Input file does not exist: " + pptPath);
                return;
            }

            // Check if the provided password is correct using PresentationInfo
            Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(pptPath);
            bool isPasswordCorrect = presentationInfo.CheckPassword(password);
            if (!isPasswordCorrect)
            {
                Console.WriteLine("Password is incorrect.");
                return;
            }

            // Open the password‑protected presentation
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.Password = password;
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(pptPath, loadOptions);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("Error opening presentation: " + ex.Message);
                return;
            }

            // Save decrypted presentation to a temporary file
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Decrypted");
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            string decryptedPath = Path.Combine(outputDir, "decrypted.pptx");
            presentation.Save(decryptedPath, SaveFormat.Pptx);

            // Compute MD5 checksum of the decrypted file
            string actualChecksum;
            using (FileStream stream = File.OpenRead(decryptedPath))
            {
                MD5 md5 = MD5.Create();
                byte[] hash = md5.ComputeHash(stream);
                actualChecksum = BitConverter.ToString(hash).Replace("-", string.Empty);
            }

            // Compare checksums
            if (string.Equals(actualChecksum, expectedChecksum, StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("Checksum matches. Decryption successful.");
            else
                Console.WriteLine("Checksum does not match. Expected: " + expectedChecksum + ", Actual: " + actualChecksum);

            // Ensure presentation is saved before exit (already saved)
            presentation.Dispose();
        }
    }
}
