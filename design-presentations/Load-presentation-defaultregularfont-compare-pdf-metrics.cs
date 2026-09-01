// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load presentation with default regular font and compare PDF metrics using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation while specifying a default

// regular font, save it as a PDF with the same font settings, iterate through

// slides and shapes to extract text for metric comparison, and finally save the

// (potentially modified) presentation. The example uses Aspose.Slides for .NET

// and illustrates the required steps for handling font fallback and basic

// text extraction when converting PPTX to PDF.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Load, Presentation,

// DefaultRegularFont, Compare, Text Metrics, Font Fallback, Office Automation

//

// Use Cases:

// - Ensure consistent font rendering when converting presentations to PDF.

// - Extract and compare text metrics between original PPTX and generated PDF.

// - Automate PPTX processing workflows that require font substitution.

// - Build .NET tools for validating presentation content before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input and output file paths

        string inputPath = "input.pptx";

        string pdfPath = "output.pdf";

        string outputPresentationPath = "output.pptx";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Set default regular font using LoadOptions

            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();

            loadOptions.DefaultRegularFont = "Arial";



            // Load the presentation with the specified load options

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath, loadOptions))

            {

                // Configure PDF save options with the same default regular font

                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                pdfOptions.DefaultRegularFont = "Arial";



                // Save the presentation as PDF

                pres.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);



                // Placeholder for comparing text metrics between original and PDF

                foreach (Aspose.Slides.ISlide slide in pres.Slides)

                {

                    foreach (Aspose.Slides.IShape shape in slide.Shapes)

                    {

                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;

                        if (autoShape != null && autoShape.TextFrame != null)

                        {

                            string text = autoShape.TextFrame.Text;

                            // In a real scenario, compare text metrics here

                            Console.WriteLine("Slide {0}, Shape {1}: {2}", slide.SlideNumber, shape.Name, text);

                        }

                    }

                }



                // Save the (possibly modified) presentation before exiting

                pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error: " + ex.Message);

            // Comment: format not supported

        }

    }

}

