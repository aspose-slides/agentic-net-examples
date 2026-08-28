// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Process multiple PowerPoint files in parallel and export slides to SVG with thread logs using C#

//

// Description:

// Demonstrates how to load several PPTX files concurrently, export each slide to an SVG file, 

// save a processed copy of the presentation, and write a per‑thread log file. The example uses 

// Aspose.Slides for .NET and the Parallel.ForEach construct to achieve parallel processing in a 

// console application. It shows typical steps such as file existence checks, slide iteration, 

// SVG export, presentation saving, and thread‑specific logging.

//

// Keywords:

// C#, Aspose.Slides for .NET, PowerPoint, PPTX, SVG export, Parallel processing, Thread logging, Batch conversion, Office automation

//

// Use Cases:

// - Batch convert PPTX slides to SVG files in parallel to improve performance.

// - Generate per‑thread logs for monitoring and debugging parallel presentation processing.

// - Automate saving processed copies of presentations after applying transformations.

// - Integrate high‑throughput PowerPoint workflows into .NET applications.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Threading;

using System.Threading.Tasks;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string[] inputFiles = new string[] { "input1.pptx", "input2.pptx", "input3.pptx" };

        Parallel.ForEach(inputFiles, (inputFile) =>

        {

            try

            {

                if (!File.Exists(inputFile))

                {

                    Console.WriteLine("File not found: " + inputFile);

                    return;

                }



                // Load the presentation

                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFile);



                // Export each slide to SVG (using export-convert-slides-to-svg-stream rule)

                for (int index = 0; index < pres.Slides.Count; index++)

                {

                    Aspose.Slides.ISlide slide = pres.Slides[index];

                    string svgPath = Path.Combine(Path.GetDirectoryName(inputFile), Path.GetFileNameWithoutExtension(inputFile) + $"_slide_{index}.svg");

                    using (FileStream stream = new FileStream(svgPath, FileMode.Create, FileAccess.Write))

                    {

                        slide.WriteAsSvg(stream);

                    }

                }



                // Save a copy of the processed presentation

                string outputPresPath = Path.Combine(Path.GetDirectoryName(inputFile), Path.GetFileNameWithoutExtension(inputFile) + "_processed.pptx");

                try

                {

                    pres.Save(outputPresPath, Aspose.Slides.Export.SaveFormat.Pptx);

                }

                catch (NotSupportedException)

                {

                    // Format not supported

                }



                // Write a log file specific to this thread

                int threadId = Task.CurrentId ?? Thread.CurrentThread.ManagedThreadId;

                string logPath = Path.Combine(Path.GetDirectoryName(inputFile), $"log_thread_{threadId}.txt");

                File.WriteAllText(logPath, $"Processed {inputFile} on thread {threadId}");



                // Dispose the presentation

                pres.Dispose();

            }

            catch (Exception ex)

            {

                // Handle exceptions (e.g., external URL or web service errors)

                Console.WriteLine("Error processing file " + inputFile + ": " + ex.Message);

            }

        });

    }

}

