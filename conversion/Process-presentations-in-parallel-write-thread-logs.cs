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
        // Input presentation files
        string[] inputFiles = new string[] { "input1.pptx", "input2.pptx" };

        // Process each file in parallel
        Parallel.ForEach(inputFiles, (inputFile) =>
        {
            try
            {
                // Check if the input file exists
                if (!File.Exists(inputFile))
                {
                    Console.WriteLine("File not found: " + inputFile);
                    return;
                }

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

                // Example modification: add a text shape to the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                shape.TextFrame.Text = "Processed by thread " + Thread.CurrentThread.ManagedThreadId;

                // Prepare output path
                string outputDirectory = Path.Combine("output");
                Directory.CreateDirectory(outputDirectory);
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputFile) + "_processed.pptx");

                // Save the presentation to a file stream (using the provided rule)
                FileStream stream = new FileStream(outputPath, FileMode.Create);
                presentation.Save(stream, Aspose.Slides.Export.SaveFormat.Pptx);
                stream.Close();

                // Write a log file specific to the current thread
                string logDirectory = Path.Combine("logs");
                Directory.CreateDirectory(logDirectory);
                string logPath = Path.Combine(logDirectory,
                    "log_thread_" + Thread.CurrentThread.ManagedThreadId + ".txt");
                File.AppendAllText(logPath,
                    $"Processed {inputFile} -> {outputPath}{Environment.NewLine}");

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Unsupported format for file: " + inputFile);
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., web service errors)
                Console.WriteLine("Error processing file: " + inputFile + " - " + ex.Message);
            }
        });
    }
}