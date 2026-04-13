using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                int totalTraceCount = 0;

                // Iterate through all slides and shapes to find Ink objects
                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        Ink inkShape = shape as Ink;
                        if (inkShape != null)
                        {
                            IInkTrace[] traces = inkShape.Traces;
                            totalTraceCount += traces.Length;
                        }
                    }
                }

                Console.WriteLine("Total number of Trace objects in Ink shapes: " + totalTraceCount);

                // Save the presentation before exiting
                string outputPath = "output.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported comment
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}