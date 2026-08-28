// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPT to TIFF and compress LZW using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPT/PPTX) to a TIFF

// image using Aspose.Slides for .NET and then apply LZW compression via an

// external command‑line tool. The example includes argument handling, file

// validation, conversion settings, and process execution for the compression

// step. This pattern can be used to automate presentation image generation and

// post‑process compression in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, TIFF, LZW, Compression, 

// Presentation Processing, Office Automation, Command Line Tool

//

// Use Cases:

// - Convert PowerPoint slides to high‑quality TIFF images.

// - Apply LZW compression to TIFF files using a third‑party utility.

// - Build console utilities for batch processing of presentations.

// - Integrate slide‑to‑image conversion and compression into .NET workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Diagnostics;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Determine input PPT file path

        string inputPath;

        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))

        {

            inputPath = args[0];

        }

        else

        {

            inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

        }



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        // Define output TIFF path

        string tiffPath = Path.Combine(Directory.GetCurrentDirectory(), "output.tiff");



        // Convert PPT to TIFF using Aspose.Slides

        try

        {

            Presentation pres = new Presentation(inputPath);

            TiffOptions tiffOptions = new TiffOptions();

            // Use default compression (LZW) – can be changed if needed

            tiffOptions.CompressionType = TiffCompressionTypes.Default;

            pres.Save(tiffPath, SaveFormat.Tiff, tiffOptions);

            // Save presentation before exit (already saved) and release resources

            pres.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The presentation format is not supported for conversion.");

            return;

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error during conversion: " + ex.Message);

            return;

        }



        // Path to external LZW compression tool (example executable)

        string toolPath = Path.Combine(Directory.GetCurrentDirectory(), "lzwcompress.exe");



        // Verify external tool exists

        if (!File.Exists(toolPath))

        {

            Console.WriteLine("Compression tool not found: " + toolPath);

            return;

        }



        // Prepare process start info for the external tool

        ProcessStartInfo psi = new ProcessStartInfo();

        psi.FileName = toolPath;

        psi.Arguments = $"\"{tiffPath}\"";

        psi.UseShellExecute = false;

        psi.RedirectStandardOutput = true;

        psi.RedirectStandardError = true;



        // Execute external LZW compression

        try

        {

            using (Process proc = Process.Start(psi))

            {

                proc.WaitForExit();

                string output = proc.StandardOutput.ReadToEnd();

                string error = proc.StandardError.ReadToEnd();



                if (proc.ExitCode != 0)

                {

                    Console.WriteLine("Compression tool failed: " + error);

                }

                else

                {

                    Console.WriteLine("Compression completed successfully.");

                    Console.WriteLine(output);

                }

            }

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error executing compression tool: " + ex.Message);

        }

    }

}

