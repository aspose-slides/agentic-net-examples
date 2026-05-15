using System;
using System.IO;
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace AsposeSlidesMathMlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a math shape to the first slide
            IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0f, 0f, 720f, 150f);

            // Get the MathParagraph from the shape
            IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Example: add a simple fraction to the paragraph
            MathBlock fraction = new MathBlock(new MathematicalText("x").Divide("y"));
            mathParagraph.Add(fraction);

            // Define output MathML file path
            string outputMathMlPath = "mathml_output.xml";

            // Retry logic parameters
            int maxRetries = 3;
            int delayMilliseconds = 500;

            // Write MathML with retry on transient I/O errors
            for (int attempt = 0; attempt < maxRetries; attempt++)
            {
                try
                {
                    using (FileStream stream = new FileStream(outputMathMlPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        mathParagraph.WriteAsMathMl(stream);
                    }
                    // Success, exit retry loop
                    break;
                }
                catch (IOException)
                {
                    // Transient I/O error, retry after delay unless last attempt
                    if (attempt == maxRetries - 1)
                    {
                        // Rethrow after final attempt
                        throw;
                    }
                    Thread.Sleep(delayMilliseconds);
                }
            }

            // Save the presentation
            try
            {
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Dispose presentation resources
            presentation.Dispose();
        }
    }
}