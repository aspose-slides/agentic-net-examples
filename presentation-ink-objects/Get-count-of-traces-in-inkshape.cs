using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("File does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Ensure there is at least one slide and one shape
                if (pres.Slides.Count > 0 && pres.Slides[0].Shapes.Count > 0)
                {
                    // Try to cast the first shape to an Ink object
                    IInk inkShape = pres.Slides[0].Shapes[0] as IInk;
                    if (inkShape != null)
                    {
                        // Retrieve the total number of Trace objects
                        int traceCount = inkShape.Traces.Length;
                        Console.WriteLine("Total number of traces: " + traceCount);
                    }
                    else
                    {
                        Console.WriteLine("The first shape is not an Ink shape.");
                    }
                }
                else
                {
                    Console.WriteLine("No slides or shapes found in the presentation.");
                }

                // Save the presentation before exiting
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}