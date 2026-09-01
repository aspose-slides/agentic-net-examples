// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add watermark to presentation and export PDF using C#

//

// Description:

// Demonstrates how to add a text watermark to each slide of a PowerPoint

// presentation and export the result as a PDF using Aspose.Slides for .NET.

// The example processes all supported presentation files in a given input

// directory, applies a centered "CONFIDENTIAL" watermark on the master slide,

// and saves the output PDFs to a specified folder.

//

// Keywords:

// C#, PowerPoint, PPTX, PPT, ODP, Aspose.Slides for .NET, PDF, Watermark, Presentation,

// Export, Automation, File I/O

//

// Use Cases:

// - Batch add a confidential watermark to presentations before distribution.

// - Convert watermarked PowerPoint files to PDF format in .NET applications.

// - Automate preprocessing of slide decks for compliance or branding.

// - Integrate slide watermarking and PDF conversion into CI/CD pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Input and output folders

        string inputFolder = args.Length > 0 ? args[0] : "InputPresentations";

        string outputFolder = args.Length > 1 ? args[1] : "OutputPdfs";



        // Verify input folder exists

        if (!Directory.Exists(inputFolder))

        {

            Console.WriteLine("Input folder does not exist.");

            return;

        }



        // Ensure output folder exists

        if (!Directory.Exists(outputFolder))

        {

            Directory.CreateDirectory(outputFolder);

        }



        // Process each presentation file in the input folder

        string[] files = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);

        foreach (string filePath in files)

        {

            string extension = Path.GetExtension(filePath).ToLowerInvariant();

            // Supported formats: PPTX, PPT, ODP

            if (extension != ".pptx" && extension != ".ppt" && extension != ".odp")

            {

                // format not supported

                continue;

            }



            try

            {

                // Load presentation

                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath);



                // Add watermark using the watermark-text rule

                Aspose.Slides.IMasterSlide master = pres.Masters[0];

                Aspose.Slides.IAutoShape watermarkShape = master.Shapes.AddAutoShape(

                    Aspose.Slides.ShapeType.Rectangle,

                    0,

                    0,

                    pres.SlideSize.Size.Width,

                    pres.SlideSize.Size.Height);

                watermarkShape.AddTextFrame("CONFIDENTIAL");

                watermarkShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

                watermarkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                watermarkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;



                // Save as PDF

                string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".pdf";

                string outputPath = Path.Combine(outputFolder, outputFileName);

                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);



                // Dispose presentation

                pres.Dispose();

            }

            catch (NotSupportedException)

            {

                // format not supported

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);

            }

        }

    }

}

