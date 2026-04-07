using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideConversionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input files can be passed as command line arguments or defined here
            string[] inputFiles = args.Length > 0 ? args : new string[] { "input1.pptx", "input2.pptx" };
            List<TimeSpan> conversionTimes = new List<TimeSpan>();
            int processedCount = 0;

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("File not found: " + inputPath);
                    continue;
                }

                string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), Path.GetFileNameWithoutExtension(inputPath) + "_converted.pdf");
                Stopwatch stopwatch = new Stopwatch();
                try
                {
                    stopwatch.Start();
                    using (Presentation pres = new Presentation(inputPath))
                    {
                        // Example operation: set slide transition duration for each slide
                        foreach (ISlide slide in pres.Slides)
                        {
                            slide.SlideShowTransition.Duration = 2000; // 2 seconds
                        }

                        // Save as PDF
                        pres.Save(outputPath, SaveFormat.Pdf);
                    }
                    stopwatch.Stop();
                    conversionTimes.Add(stopwatch.Elapsed);
                    processedCount++;
                    Console.WriteLine("Converted '{0}' to PDF in {1} seconds.", inputPath, stopwatch.Elapsed.TotalSeconds);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("The format of file '{0}' is not supported.", inputPath);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., external URLs or web services)
                    Console.WriteLine("Error processing file '{0}': {1}", inputPath, ex.Message);
                }
            }

            // Summary statistics
            if (processedCount > 0)
            {
                TimeSpan totalTime = new TimeSpan();
                foreach (TimeSpan ts in conversionTimes)
                {
                    totalTime = totalTime.Add(ts);
                }
                double averageSeconds = totalTime.TotalSeconds / processedCount;
                Console.WriteLine("Processed {0} files.", processedCount);
                Console.WriteLine("Total conversion time: {0} seconds.", totalTime.TotalSeconds);
                Console.WriteLine("Average conversion time per file: {0:F2} seconds.", averageSeconds);
            }
            else
            {
                Console.WriteLine("No files were processed.");
            }
        }
    }
}