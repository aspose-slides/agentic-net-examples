using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "large.pptx";
        string outputPath = "output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Memory before loading the presentation
            long memoryBeforeLoad = Process.GetCurrentProcess().PrivateMemorySize64;

            // Load options for large presentations
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.BlobManagementOptions.PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked;
            loadOptions.BlobManagementOptions.IsTemporaryFilesAllowed = true;

            // Load the presentation with the specified options
            Presentation pres = new Presentation(inputPath, loadOptions);

            // Memory after loading
            long memoryAfterLoad = Process.GetCurrentProcess().PrivateMemorySize64;
            Console.WriteLine($"Memory used after loading: {memoryAfterLoad - memoryBeforeLoad} bytes");

            // Configure high‑resolution TIFF options
            TiffOptions tiffOptions = new TiffOptions();
            tiffOptions.DpiX = 300;
            tiffOptions.DpiY = 300;

            // Memory before saving
            long memoryBeforeSave = Process.GetCurrentProcess().PrivateMemorySize64;

            // Save the presentation as a multi‑page TIFF
            pres.Save(outputPath, SaveFormat.Tiff, tiffOptions);

            // Memory after saving
            long memoryAfterSave = Process.GetCurrentProcess().PrivateMemorySize64;
            Console.WriteLine($"Memory used during saving: {memoryAfterSave - memoryBeforeSave} bytes");

            // Dispose the presentation
            pres.Dispose();

            // Final memory usage
            long memoryFinal = Process.GetCurrentProcess().PrivateMemorySize64;
            Console.WriteLine($"Final memory usage: {memoryFinal} bytes");
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
}