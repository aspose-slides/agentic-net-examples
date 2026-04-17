using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

namespace InkTraceCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

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

                // Assume the first shape on the first slide is an Ink shape
                ISlide slide = pres.Slides[0];
                IShape shape = slide.Shapes[0];
                IInk ink = shape as IInk;

                if (ink == null)
                {
                    Console.WriteLine("The first shape is not an Ink shape.");
                }
                else
                {
                    // Threshold for point count
                    int pointThreshold = 100;

                    // Iterate over traces and identify those exceeding the threshold
                    IInkTrace[] traces = ink.Traces;
                    for (int i = 0; i < traces.Length; i++)
                    {
                        int pointCount = traces[i].Points.Length;
                        if (pointCount > pointThreshold)
                        {
                            // Removal of individual traces is not supported directly via the API.
                            // This placeholder demonstrates where such logic would be applied.
                            Console.WriteLine($"Trace at index {i} has {pointCount} points and exceeds the threshold.");
                            // Example: custom logic to recreate the Ink shape without this trace could be implemented here.
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the format is not supported, comment accordingly
                // Format not supported.
            }
        }
    }
}