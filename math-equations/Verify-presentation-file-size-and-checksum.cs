// -----------------------------------------------------------------------------
// Example: Verify presentation file size and checksum using C#
//
// Description:
// Demonstrates how to verify a PowerPoint presentation's file size and SHA‑256
// checksum before and after loading and saving it with Aspose.Slides for .NET.
// The example loads an existing PPTX, saves it to a new file, and compares the
// original and exported file sizes and checksums, outputting the results to the
// console. This pattern helps ensure that presentation processing does not
// unintentionally alter file content.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Verify, Presentation, File Size,
// Checksum, SHA256, Presentation Processing, Office Automation
//
// Use Cases:
// - Validate that saving a presentation does not change its size or content.
// - Build automated tests for PowerPoint file integrity after processing.
// - Create tools that compare original and exported presentations for compliance.
// - Ensure reliable PPTX workflows in .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Slides.Export;

namespace PresentationChecksumVerifier
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Compute original file size
                FileInfo inputInfo = new FileInfo(inputPath);
                long originalSize = inputInfo.Length;

                // Compute original SHA256 checksum
                byte[] originalHash;
                using (FileStream inputStream = File.OpenRead(inputPath))
                using (SHA256 sha256 = SHA256.Create())
                {
                    originalHash = sha256.ComputeHash(inputStream);
                }

                // Load presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Save presentation to output path (same format)
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                // Compute exported file size
                FileInfo outputInfo = new FileInfo(outputPath);
                long exportedSize = outputInfo.Length;

                // Compute exported SHA256 checksum
                byte[] exportedHash;
                using (FileStream outputStream = File.OpenRead(outputPath))
                using (SHA256 sha256 = SHA256.Create())
                {
                    exportedHash = sha256.ComputeHash(outputStream);
                }

                // Compare size and checksum
                bool sizeUnchanged = originalSize == exportedSize;
                bool checksumUnchanged = BitConverter.ToString(originalHash) == BitConverter.ToString(exportedHash);

                Console.WriteLine("Original Size: " + originalSize);
                Console.WriteLine("Exported Size: " + exportedSize);
                Console.WriteLine("Size unchanged: " + sizeUnchanged);
                Console.WriteLine("Checksum unchanged: " + checksumUnchanged);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
