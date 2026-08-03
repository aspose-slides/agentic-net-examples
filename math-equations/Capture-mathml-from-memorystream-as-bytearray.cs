// -----------------------------------------------------------------------------
// Example: Capture MathML from a MathParagraph using MemoryStream as byte array in C#
//
// Description:
// Demonstrates how to locate a MathParagraph in a PowerPoint presentation,
// export its MathML representation to a MemoryStream, retrieve the data as a
// byte array, and optionally save the MathML to a file. The example also
// shows basic presentation loading, saving, and error handling using
// Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML, MemoryStream, Byte array,
// MathParagraph, Presentation processing, Office automation
//
// Use Cases:
// - Extract MathML from equations embedded in PPTX files.
// - Build .NET tools that process or transform mathematical content.
// - Validate or archive MathML representations of slide equations.
// - Integrate MathML extraction into larger document processing pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace AsposeSlidesMathMLExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Find the first MathParagraph in the presentation (placeholder logic)
                Aspose.Slides.MathText.MathParagraph mathParagraph = null;
                foreach (Aspose.Slides.ISlide slide in pres.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.MathText.MathParagraph)
                        {
                            mathParagraph = (Aspose.Slides.MathText.MathParagraph)shape;
                            break;
                        }
                    }
                    if (mathParagraph != null)
                    {
                        break;
                    }
                }

                if (mathParagraph == null)
                {
                    Console.WriteLine("No MathParagraph found in the presentation.");
                }
                else
                {
                    // Export MathML to a MemoryStream and capture as byte array
                    using (MemoryStream ms = new MemoryStream())
                    {
                        mathParagraph.WriteAsMathMl(ms);
                        byte[] mathMlBytes = ms.ToArray();

                        // Example: write the MathML bytes to a file for verification
                        File.WriteAllBytes("mathml_output.xml", mathMlBytes);
                    }
                }

                // Save the presentation before exiting
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
