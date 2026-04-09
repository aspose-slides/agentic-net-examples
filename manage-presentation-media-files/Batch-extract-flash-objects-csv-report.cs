using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FlashExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output CSV report path
            string csvPath = "flash_report.csv";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);
                try
                {
                    // Create CSV writer
                    StreamWriter csvWriter = new StreamWriter(csvPath, false);
                    try
                    {
                        // Write CSV header
                        csvWriter.WriteLine("Name,Size");

                        // Iterate through slides and extract flash objects
                        for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                        {
                            ISlide slide = pres.Slides[slideIndex];
                            IControlCollection controls = slide.Controls;
                            foreach (IControl control in controls)
                            {
                                // Flash objects are ActiveX controls
                                byte[] binaryData = control.ActiveXControlBinary;
                                if (binaryData != null && binaryData.Length > 0)
                                {
                                    string name = control.Name ?? "UnnamedFlash";
                                    int size = binaryData.Length;
                                    csvWriter.WriteLine($"{name},{size}");
                                }
                            }
                        }
                    }
                    finally
                    {
                        csvWriter.Flush();
                        csvWriter.Dispose();
                    }

                    // Save presentation (no modifications, but required by rules)
                    string savedPath = "output_saved.pptx";
                    pres.Save(savedPath, SaveFormat.Pptx);
                }
                finally
                {
                    pres.Dispose();
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}