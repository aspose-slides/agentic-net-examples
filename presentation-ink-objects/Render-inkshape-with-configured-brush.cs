using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

namespace PresentationInkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through slides to find an Ink shape
                    foreach (ISlide slide in pres.Slides)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            Ink inkShape = shape as Ink;
                            if (inkShape != null)
                            {
                                // Ensure there is at least one trace
                                IInkTrace[] traces = inkShape.Traces;
                                if (traces.Length > 0)
                                {
                                    // Configure the brush of the first trace
                                    IInkBrush brush = traces[0].Brush;
                                    brush.Color = Color.Red;
                                    brush.Size = new SizeF(5f, 5f);
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}