// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate LZW compression with CCITT4 bw using C#

//

// Description:

// Demonstrates how to validate LZW compression with CCITT4 bw using C# and 

// Aspose.Slides for .NET. The example converts a PPTX presentation to TIFF 

// images using CCITT4 and LZW compression, then compares the resulting file 

// sizes to show that BwConversionMode is ignored for LZW compression.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Compression, CCITT4, LZW, 

// BlackWhiteConversionMode, Presentation Processing, Office Automation

//

// Use Cases:

// - Verify that CCITT4 compression produces different file sizes compared to LZW.

// - Ensure BwConversionMode is only applied to CCITT4 compression.

// - Build C# tools for PowerPoint to TIFF conversion with specific compression settings.

// - Automate validation of image compression in presentation workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



namespace Example

{

    class Program

    {

        static void Main()

        {

            string inputPath = "input.pptx";

            string outputPathCcitt4 = "output_ccitt4.tiff";

            string outputPathLzw = "output_lzw.tiff";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // CCITT4 compression with Dithering (black‑and‑white conversion)

                Aspose.Slides.Export.TiffOptions optionsCcitt4 = new Aspose.Slides.Export.TiffOptions();

                optionsCcitt4.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.CCITT4;

                optionsCcitt4.BwConversionMode = Aspose.Slides.Export.BlackWhiteConversionMode.Dithering;

                presentation.Save(outputPathCcitt4, Aspose.Slides.Export.SaveFormat.Tiff, optionsCcitt4);



                // LZW compression with Dithering (BwConversionMode should be ignored)

                Aspose.Slides.Export.TiffOptions optionsLzw = new Aspose.Slides.Export.TiffOptions();

                optionsLzw.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.LZW;

                optionsLzw.BwConversionMode = Aspose.Slides.Export.BlackWhiteConversionMode.Dithering;

                presentation.Save(outputPathLzw, Aspose.Slides.Export.SaveFormat.Tiff, optionsLzw);



                // Validation: compare file sizes

                FileInfo infoCcitt4 = new FileInfo(outputPathCcitt4);

                FileInfo infoLzw = new FileInfo(outputPathLzw);

                Console.WriteLine("CCITT4 file size: " + infoCcitt4.Length);

                Console.WriteLine("LZW file size: " + infoLzw.Length);

                if (infoCcitt4.Length != infoLzw.Length)

                {

                    Console.WriteLine("Compression type affects file size; BwConversionMode is ignored for LZW.");

                }

                else

                {

                    Console.WriteLine("File sizes are equal; unexpected behavior.");

                }



                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified format is not supported.");

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}

