// -----------------------------------------------------------------------------
// Example: Extract embedded Flash objects and archive them into a ZIP using C#
//
// Description:
// Demonstrates how to locate ShockwaveFlash ActiveX controls in a PPTX file,
// extract their binary SWF data, and package the extracted files into a ZIP
// archive. The example also shows how to save the presentation using ZIP64
// mode with Aspose.Slides for .NET. This pattern can be used to automate PPTX
// workflows that involve handling legacy Flash content.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Flash, SWF, ZIP,
// Archive, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of embedded Flash (SWF) objects from PowerPoint files.
// - Create ZIP archives of extracted Flash assets for backup or analysis.
// - Save large presentations with ZIP64 support to avoid size limitations.
// - Integrate Flash extraction into .NET tools for presentation processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FlashExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            // Output ZIP archive path
            string outputZipPath = Path.Combine(Directory.GetCurrentDirectory(), "flash_archive.zip");
            // Temporary folder for extracted flash files (optional, not used for final zip)
            string tempFolder = Path.Combine(Directory.GetCurrentDirectory(), "temp_flash");
            
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure temporary folder exists
            if (!Directory.Exists(tempFolder))
                Directory.CreateDirectory(tempFolder);

            // Load presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
                return;
            }

            // Extract flash objects
            int flashIndex = 0;
            foreach (ISlide slide in presentation.Slides)
            {
                IControlCollection controls = slide.Controls;
                foreach (IControl control in controls)
                {
                    if (control.Name == "ShockwaveFlash1")
                    {
                        Control flashControl = (Control)control;
                        byte[] flashData = flashControl.ActiveXControlBinary;
                        if (flashData != null && flashData.Length > 0)
                        {
                            string entryName = $"flash_{flashIndex}.swf";
                            // Write to ZIP archive directly
                            using (FileStream zipStream = new FileStream(outputZipPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                            {
                                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Update, true))
                                {
                                    ZipArchiveEntry entry = archive.CreateEntry(entryName);
                                    using (Stream entryStream = entry.Open())
                                    {
                                        entryStream.Write(flashData, 0, flashData.Length);
                                    }
                                }
                            }
                            flashIndex++;
                        }
                    }
                }
            }

            // Save presentation before exit (using ZIP64 mode)
            string savedPath = Path.Combine(Directory.GetCurrentDirectory(), "saved_output.pptx");
            presentation.Save(savedPath, SaveFormat.Pptx, new PptxOptions()
            {
                Zip64Mode = Zip64Mode.Always
            });

            // Cleanup
            presentation.Dispose();
            Console.WriteLine("Extraction completed. Flash files archived to: " + outputZipPath);
        }
    }
}
