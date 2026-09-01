// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add filename watermark to PPT PDF using C#

//

// Description:

// Demonstrates how to add a filename watermark to a PowerPoint presentation

// and convert it to PDF using C# and Aspose.Slides for .NET. The example shows

// how to load a PPTX file, insert a text watermark containing the source file

// name onto the master slide so it appears on every slide, and then save the

// result as a PDF document.

//

// Keywords:

// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, Filename, Watermark,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automatically add a filename watermark to PowerPoint files before PDF export.

// - Build .NET tools for batch processing of presentations with branding.

// - Integrate watermarking into document generation pipelines.

// - Validate presentation conversion workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace PresentationToPdfWithWatermark

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine input file path

            string inputPath;

            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))

            {

                inputPath = args[0];

            }

            else

            {

                inputPath = "input.pptx";

            }



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);



                // Add watermark text to the master slide (appears on all slides)

                Aspose.Slides.IMasterSlide master = pres.Masters[0];

                Aspose.Slides.IAutoShape watermarkShape = master.Shapes.AddAutoShape(

                    Aspose.Slides.ShapeType.Rectangle,

                    0, 0, 500, 50);

                watermarkShape.AddTextFrame(Path.GetFileName(inputPath));

                watermarkShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

                watermarkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                watermarkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;



                // Define output PDF path

                string outputPath = Path.ChangeExtension(inputPath, ".pdf");



                // Save the presentation as PDF

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);



                // Dispose the presentation

                pres.Dispose();



                Console.WriteLine("PDF saved successfully: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Handle unsupported format exception

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

