// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Calculate SWF size reduction percentage using C#

//

// Description:

// Demonstrates how to calculate the percentage reduction in SWF file size

// when compression is enabled versus disabled using Aspose.Slides for .NET.

// The example loads a PPTX presentation, saves it as SWF with and without

// compression, compares the file sizes, and outputs the reduction percentage.

// This pattern can be used in console applications to evaluate SWF compression

// effectiveness.

//

// Keywords:

// C#, Aspose.Slides, SWF, Compression, Size Reduction, Presentation Conversion,

// PowerPoint, PPTX, Console Application, File Size Comparison

//

// Use Cases:

// - Determine the benefit of SWF compression for a given presentation.

// - Automate generation of size reports for SWF conversions.

// - Integrate SWF size analysis into build or CI pipelines.

// - Provide insights for optimizing presentation assets before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfCompressionDemo

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input PowerPoint file path

            string inputPath = "input.pptx";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                // Calculate and display compression reduction

                double reduction = CalculateSwfCompressionReduction(inputPath);

                Console.WriteLine($"Compression reduction: {reduction:F2}%");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported for SWF conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine($"An error occurred: {ex.Message}");

            }

        }



        // Calculates percentage reduction in SWF size after enabling compression

        static double CalculateSwfCompressionReduction(string inputFilePath)

        {

            // Prepare output file paths

            string directory = Path.GetDirectoryName(inputFilePath);

            string outputNoCompress = Path.Combine(directory, "output_no_compress.swf");

            string outputCompress = Path.Combine(directory, "output_compress.swf");



            // Load presentation

            using (Presentation presentation = new Presentation(inputFilePath))

            {

                // Save without compression

                SwfOptions optionsNoCompress = new SwfOptions();

                optionsNoCompress.Compressed = false;

                presentation.Save(outputNoCompress, SaveFormat.Swf, optionsNoCompress);



                // Save with compression (default true)

                SwfOptions optionsCompress = new SwfOptions();

                optionsCompress.Compressed = true;

                presentation.Save(outputCompress, SaveFormat.Swf, optionsCompress);

            }



            // Get file sizes

            FileInfo infoNoCompress = new FileInfo(outputNoCompress);

            FileInfo infoCompress = new FileInfo(outputCompress);

            long sizeNoCompress = infoNoCompress.Length;

            long sizeCompress = infoCompress.Length;



            // Calculate reduction percentage

            double reduction = 0;

            if (sizeNoCompress > 0)

            {

                reduction = ((double)(sizeNoCompress - sizeCompress) / sizeNoCompress) * 100;

            }



            // Return the calculated reduction

            return reduction;

        }

    }

}

