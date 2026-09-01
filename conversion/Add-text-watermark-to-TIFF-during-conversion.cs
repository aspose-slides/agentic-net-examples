// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add text watermark to TIFF during conversion using C#

//

// Description:

// Demonstrates how to add a text watermark to a PowerPoint presentation

// and convert it to a TIFF image using Aspose.Slides for .NET. The example

// creates a watermark shape on the master slide, configures TIFF export

// options, and saves the result as a multi‑page TIFF file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Text Watermark, TIFF, Conversion,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Add a confidential or branding watermark to PPTX files before exporting to TIFF.

// - Automate batch conversion of presentations to TIFF with watermarks.

// - Integrate watermarking into .NET applications that generate or process slides.

// - Validate presentation output in image format for publishing or archiving.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace WatermarkTiffConversion

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.tiff";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);



                // Add watermark text to the first master slide

                Aspose.Slides.IMasterSlide master = pres.Masters[0];

                Aspose.Slides.IAutoShape watermarkShape = master.Shapes.AddAutoShape(

                    Aspose.Slides.ShapeType.Rectangle,

                    0, 0, 500, 50);

                watermarkShape.AddTextFrame("CONFIDENTIAL");

                watermarkShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

                watermarkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                watermarkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;



                // Configure TIFF options (optional customizations)

                Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

                // Example: set pixel format to 8bpp indexed

                tiffOptions.PixelFormat = Aspose.Slides.Export.ImagePixelFormat.Format8bppIndexed;



                // Save the presentation as TIFF with watermark applied

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);



                // Ensure the presentation is saved before exit

                pres.Dispose();



                Console.WriteLine("Conversion completed successfully.");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: format not supported

                Console.WriteLine("The provided file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URLs, web services)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

