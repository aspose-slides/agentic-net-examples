using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MemoryMeasurementExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input PPTX and output TIFF
            string inputPath = "large_presentation.pptx";
            string outputPath = "large_presentation.tiff";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Measure memory before loading the presentation
            Process currentProcess = Process.GetCurrentProcess();
            long memoryBeforeLoad = currentProcess.PrivateMemorySize64;
            Console.WriteLine("Memory before load: " + memoryBeforeLoad / 1024 / 1024 + " MB");

            try
            {
                // Configure load options to keep the source file locked (reduces memory usage)
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.BlobManagementOptions.PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked;

                // Load the large presentation
                Presentation pres = new Presentation(inputPath, loadOptions);

                // Measure memory after loading
                long memoryAfterLoad = currentProcess.PrivateMemorySize64;
                Console.WriteLine("Memory after load: " + memoryAfterLoad / 1024 / 1024 + " MB");

                // Set high‑resolution TIFF options
                TiffOptions tiffOptions = new TiffOptions();
                tiffOptions.DpiX = 300; // Horizontal DPI
                tiffOptions.DpiY = 300; // Vertical DPI

                // Convert and save as TIFF
                pres.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                // Optionally save the presentation itself before exiting (as per authoring rule)
                string tempSavePath = "temp_save.pptx";
                pres.Save(tempSavePath, SaveFormat.Pptx);
                pres.Dispose();

                // Measure memory after conversion
                long memoryAfterSave = currentProcess.PrivateMemorySize64;
                Console.WriteLine("Memory after conversion: " + memoryAfterSave / 1024 / 1024 + " MB");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}