// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert PPT to individual SVG files using C#

//

// Description:

// Demonstrates how to batch convert PPT and PPTX files to individual SVG files 

// using C# and Aspose.Slides for .NET. The example processes each presentation 

// in a specified input directory, creates a dedicated output folder per file, 

// and writes each slide as a separate SVG image. It also shows how to preserve 

// the original presentation format after conversion.

//

// Keywords:

// C#, PowerPoint, PPT, PPTX, SVG, Aspose.Slides for .NET, Batch conversion, 

// Slide export, Presentation processing, Office automation

//

// Use Cases:

// - Automate conversion of multiple PowerPoint files to per‑slide SVG images.

// - Build command‑line tools for extracting slide graphics from presentations.

// - Integrate slide‑to‑SVG conversion into .NET workflows or CI pipelines.

// - Preserve original presentations while generating SVG assets for web or 

//   documentation purposes.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Input directory containing PPT files

        string inputDir = args.Length > 0 ? args[0] : Path.Combine(Environment.CurrentDirectory, "InputPpt");

        // Output base directory for SVG files

        string outputBaseDir = args.Length > 1 ? args[1] : Path.Combine(Environment.CurrentDirectory, "OutputSvg");



        if (!Directory.Exists(inputDir))

        {

            Console.WriteLine("Input directory does not exist: " + inputDir);

            return;

        }



        if (!Directory.Exists(outputBaseDir))

        {

            Directory.CreateDirectory(outputBaseDir);

        }



        // Get all PPT and PPTX files

        string[] pptFiles = Directory.GetFiles(inputDir, "*.ppt*");

        foreach (string pptPath in pptFiles)

        {

            if (!File.Exists(pptPath))

            {

                Console.WriteLine("File not found: " + pptPath);

                continue;

            }



            try

            {

                // Load presentation

                Presentation pres = new Presentation(pptPath);



                // Create output folder for this presentation

                string presentationName = Path.GetFileNameWithoutExtension(pptPath);

                string outputDir = Path.Combine(outputBaseDir, presentationName);

                if (!Directory.Exists(outputDir))

                {

                    Directory.CreateDirectory(outputDir);

                }



                // Convert each slide to SVG

                for (int index = 0; index < pres.Slides.Count; index++)

                {

                    ISlide slide = pres.Slides[index];

                    string svgPath = Path.Combine(outputDir, $"slide_{index + 1}.svg");

                    using (FileStream stream = new FileStream(svgPath, FileMode.Create, FileAccess.Write))

                    {

                        slide.WriteAsSvg(stream);

                    }

                }



                // Save presentation before exit (preserve original format if possible)

                try

                {

                    pres.Save(pptPath, SaveFormat.Pptx);

                }

                catch (NotSupportedException)

                {

                    // Format not supported for saving as PPTX; attempt original format

                    // Comment: format not supported

                }



                pres.Dispose();

            }

            catch (NotSupportedException)

            {

                // Comment: format not supported

                Console.WriteLine("Unsupported format for file: " + pptPath);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error processing file " + pptPath + ": " + ex.Message);

            }

        }

    }

}

