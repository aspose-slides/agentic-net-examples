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
            // Input and output file paths
            string inputPath = "large_presentation.pptx";
            string outputPath = "converted_output.swf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Prepare load options to reduce memory consumption
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions
            {
                BlobManagementOptions = new Aspose.Slides.BlobManagementOptions
                {
                    IsTemporaryFilesAllowed = true,
                    // Limit memory usage for BLOBs (e.g., 200 MB)
                    MaxBlobsBytesInMemory = 200UL * 1024UL * 1024UL,
                    PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked
                }
            };

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation with the specified options
                presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

                // Monitor memory before conversion
                Process currentProcess = Process.GetCurrentProcess();
                long memoryBefore = currentProcess.WorkingSet64;
                Console.WriteLine("Memory usage before conversion: " + (memoryBefore / (1024 * 1024)) + " MB");

                // Set up SWF conversion options
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions
                {
                    // Example: disable viewer to reduce size
                    ViewerIncluded = false,
                    // Example: set JPEG quality
                    JpegQuality = 90
                };

                // Perform conversion and save as SWF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                // Monitor memory after conversion
                long memoryAfter = currentProcess.WorkingSet64;
                Console.WriteLine("Memory usage after conversion: " + (memoryAfter / (1024 * 1024)) + " MB");
                Console.WriteLine("Memory delta: " + ((memoryAfter - memoryBefore) / (1024 * 1024)) + " MB");
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
            finally
            {
                // Ensure the presentation is saved (if any changes) and disposed
                if (presentation != null)
                {
                    try
                    {
                        // Save again to ensure any modifications are persisted
                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, new Aspose.Slides.Export.SwfOptions());
                    }
                    catch
                    {
                        // Ignore any errors during final save
                    }
                    presentation.Dispose();
                }
            }
        }
    }
}