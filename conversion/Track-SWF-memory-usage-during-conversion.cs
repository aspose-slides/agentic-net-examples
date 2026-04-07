using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string sourcePath = "large_presentation.pptx";
            string outputPath = "converted_output.swf";

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            try
            {
                // Configure load options to reduce memory consumption for large files
                LoadOptions loadOptions = new LoadOptions
                {
                    BlobManagementOptions = new BlobManagementOptions
                    {
                        IsTemporaryFilesAllowed = true,
                        MaxBlobsBytesInMemory = 200UL * 1024UL * 1024UL, // 200 MB
                        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked
                    }
                };

                // Open the presentation with the specified load options
                Presentation presentation = new Presentation(sourcePath, loadOptions);

                // Capture memory usage before conversion
                Process currentProcess = Process.GetCurrentProcess();
                long memoryBefore = currentProcess.PrivateMemorySize64;

                // Set up SWF conversion options (default options)
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                // Perform the conversion to SWF format
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Capture memory usage after conversion
                long memoryAfter = currentProcess.PrivateMemorySize64;

                // Output memory usage information
                Console.WriteLine("Memory usage before conversion: " + (memoryBefore / (1024 * 1024)) + " MB");
                Console.WriteLine("Memory usage after conversion: " + (memoryAfter / (1024 * 1024)) + " MB");
                Console.WriteLine("Conversion completed successfully.");

                // Save presentation before exiting (as per requirement)
                string tempSavePath = Path.Combine(Path.GetDirectoryName(sourcePath), "temp_save.pptx");
                presentation.Save(tempSavePath, SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();

                // Optionally delete temporary file
                if (File.Exists(tempSavePath))
                {
                    File.Delete(tempSavePath);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}