// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to PDF 800x600 keep hidden using C#

//

// Description:

// Demonstrates how to convert a PPTX file to a PDF with a custom slide size of

// 800x600 points while preserving hidden slides using C# and Aspose.Slides for

// .NET. The example loads a presentation, adjusts the slide dimensions with

// content scaling, configures PDF export options to include hidden slides, and

// saves the result as a PDF file. This pattern can be used to automate

// presentation conversion workflows in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Convert, 800x600, Keep Hidden Slides, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to PDF with specific slide dimensions.

// - Include hidden slides in exported PDF documents.

// - Build C# utilities for PowerPoint presentation processing and transformation.

// - Validate and generate PDF outputs from PowerPoint sources in .NET environments.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



namespace MyApp

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output.pdf";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // Set custom slide size 800x600 points with content scaling

                    presentation.SlideSize.SetSize(800f, 600f, Aspose.Slides.SlideSizeScaleType.EnsureFit);



                    // Configure PDF options to include hidden slides

                    PdfOptions pdfOptions = new PdfOptions();

                    pdfOptions.ShowHiddenSlides = true;



                    // Save as PDF

                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

