// -----------------------------------------------------------------------------
// Example: Compute SHA256 checksum of hyperlink sound blob using C#
//
// Description:
// Demonstrates how to compute the SHA‑256 checksum of a hyperlink's embedded
// sound (binary BLOB) in a PowerPoint presentation using Aspose.Slides for .NET.
// The example loads a PPTX file, accesses the first shape's hyperlink, extracts
// the sound data, calculates its SHA‑256 hash, and outputs the checksum. It also
// saves the presentation after processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compute, SHA256, Checksum,
// Hyperlink, Sound, Blob, Presentation Processing, Office Automation
//
// Use Cases:
// - Verify integrity of embedded audio linked to a hyperlink.
// - Automate validation of hyperlink sound resources in PPTX files.
// - Build .NET tools for auditing or processing PowerPoint presentations.
// - Integrate checksum calculation into PowerPoint workflow automation.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input file path
        string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load presentation with exception handling for unsupported formats
        Presentation presentation = null;
        try
        {
            presentation = new Presentation(inputFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        try
        {
            // Access the first shape on the first slide
            ISlide slide = presentation.Slides[0];
            IShape shape = slide.Shapes[0];
            IHyperlink hyperlink = shape.HyperlinkClick;

            // Check if hyperlink contains a sound (BLOB) and compute SHA‑256 checksum
            if (hyperlink != null && hyperlink.Sound != null)
            {
                byte[] audioData = hyperlink.Sound.BinaryData;
                using (MemoryStream ms = new MemoryStream(audioData))
                {
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] hash = sha256.ComputeHash(ms);
                        string hashString = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                        Console.WriteLine("SHA-256 checksum of hyperlink sound: " + hashString);
                    }
                }
            }
            else
            {
                Console.WriteLine("No hyperlink sound data found.");
            }
        }
        catch (Exception ex)
        {
            // Handle errors while accessing hyperlink or computing checksum
            Console.WriteLine("Error processing hyperlink: " + ex.Message);
        }
        finally
        {
            // Save presentation before exit
            try
            {
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
