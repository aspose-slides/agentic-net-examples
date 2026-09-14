// -----------------------------------------------------------------------------
// Example: Verify Presentation File Integrity After Export with Aspose.Slides
//
// Description:
// This console application loads a PowerPoint PPTX file using Aspose.Slides for
// .NET, exports it to PDF, and then verifies that the original PPTX file size
// and MD5 checksum remain unchanged after the export operation. It demonstrates
// file integrity validation, exception handling for unsupported formats, and
// proper resource cleanup.
//
// Keywords:
// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, file integrity, checksum, export
//
// Use Cases:
// - Ensure that automated slide export processes do not corrupt source files.
// - Validate that read-only operations on presentations preserve original data.
// - Integrate file integrity checks into CI pipelines for document processing.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Security.Cryptography;

namespace AsposeSlidesIntegrityCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (File.Exists(inputPath) == false)
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Compute original file size
            System.IO.FileInfo originalInfo = new System.IO.FileInfo(inputPath);
            long originalSize = originalInfo.Length;

            // Compute original MD5 checksum
            string originalChecksum = ComputeMd5Checksum(inputPath);

            try
            {
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Export to PDF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

                // Ensure presentation is saved (already done) and dispose
                presentation.Dispose();

                // Re‑compute file size and checksum after export
                System.IO.FileInfo postInfo = new System.IO.FileInfo(inputPath);
                long postSize = postInfo.Length;
                string postChecksum = ComputeMd5Checksum(inputPath);

                // Compare and report results
                bool sizeUnchanged = (originalSize == postSize);
                bool checksumUnchanged = (originalChecksum.Equals(postChecksum, StringComparison.OrdinalIgnoreCase));

                Console.WriteLine("Original Size:   {0} bytes", originalSize);
                Console.WriteLine("Post‑Export Size:{0} bytes", postSize);
                Console.WriteLine("Size unchanged: {0}", sizeUnchanged);

                Console.WriteLine("Original MD5:    {0}", originalChecksum);
                Console.WriteLine("Post‑Export MD5: {0}", postChecksum);
                Console.WriteLine("Checksum unchanged: {0}", checksumUnchanged);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private static string ComputeMd5Checksum(string filePath)
        {
            using (System.IO.FileStream stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
                }
            }
        }
    }
}
