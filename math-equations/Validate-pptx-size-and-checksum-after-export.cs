using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Compute original file size and checksum
            var originalSize = new FileInfo(inputPath).Length;
            var originalHash = ComputeHash(inputPath);

            // Load presentation and save to output path
            using (var pres = new Presentation(inputPath))
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }

            // Compute exported file size and checksum
            var exportedSize = new FileInfo(outputPath).Length;
            var exportedHash = ComputeHash(outputPath);

            // Compare size and checksum
            var sizeEqual = originalSize == exportedSize;
            var hashEqual = StructuralComparisons.StructuralEqualityComparer.Equals(originalHash, exportedHash);
            Console.WriteLine($"Size unchanged: {sizeEqual}");
            Console.WriteLine($"Checksum unchanged: {hashEqual}");
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static byte[] ComputeHash(string filePath)
    {
        using (var fs = File.OpenRead(filePath))
        using (var sha = SHA256.Create())
        {
            return sha.ComputeHash(fs);
        }
    }
}