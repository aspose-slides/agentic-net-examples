// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Compare JPEG quality size reduction percentages using C#

//

// Description:

// Demonstrates how to compare JPEG quality size reduction percentages by

// converting a PowerPoint presentation to PDF with various JPEG quality

// settings using Aspose.Slides for .NET. The example loads a PPTX file,

// saves it as PDF multiple times with different JPEG quality levels, records

// the resulting file sizes, and calculates the percentage reduction relative

// to the highest quality output. This pattern helps developers assess the

// impact of JPEG compression on PDF size when processing presentations.

//

// Keywords:

// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, JPEG, Compare, Quality,

// Size, Presentation Processing, Office Automation

//

// Use Cases:

// - Evaluate how JPEG compression affects PDF file size for PowerPoint exports.

// - Build tools to automate PDF generation with configurable image quality.

// - Optimize presentation workflows by selecting appropriate JPEG quality.

// - Validate size reduction trade‑offs before publishing or distribution.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input presentation path

        string inputPath = "input.pptx";

        // Output directory for generated PDFs

        string outputDir = "output";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        // Ensure the output directory exists

        if (!Directory.Exists(outputDir))

        {

            Directory.CreateDirectory(outputDir);

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // JPEG quality levels to evaluate

            int[] qualities = new int[] { 100, 80, 60, 40, 20 };

            long[] fileSizes = new long[qualities.Length];



            // Iterate over each quality setting, save as PDF, and record file size

            for (int i = 0; i < qualities.Length; i++)

            {

                // Configure PDF options with the desired JPEG quality

                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();

                pdfOptions.JpegQuality = (byte)qualities[i];



                // Define output file name

                string outputPath = Path.Combine(outputDir, $"output_{qualities[i]}.pdf");



                // Save the presentation as PDF using the current JPEG quality

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);



                // Capture the resulting file size

                FileInfo info = new FileInfo(outputPath);

                fileSizes[i] = info.Length;

            }



            // Calculate and display reduction percentages relative to the 100% quality file

            long baseSize = fileSizes[0];

            Console.WriteLine($"Base size (100% quality): {baseSize} bytes");

            for (int i = 1; i < qualities.Length; i++)

            {

                double reduction = (baseSize - fileSizes[i]) * 100.0 / baseSize;

                Console.WriteLine($"Quality {qualities[i]}%: {fileSizes[i]} bytes, reduction {reduction:F2}%");

            }



            // Save the original presentation before exiting (as required)

            string tempPath = Path.Combine(outputDir, "temp_saved.pptx");

            presentation.Save(tempPath, Aspose.Slides.Export.SaveFormat.Pptx);



            // Clean up resources

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            // If the format is not supported, the exception message will indicate it

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

