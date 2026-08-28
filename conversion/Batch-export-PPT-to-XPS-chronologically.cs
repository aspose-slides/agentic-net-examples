// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch export PPT to XPS chronologically using C#

//

// Description:

// Demonstrates how to batch export PowerPoint files (PPT, PPTX) to XPS format

// in chronological order based on file creation dates using Aspose.Slides for .NET.

// The example scans an input folder, creates date‑based subfolders in the output

// directory, and saves each presentation as an XPS file. It can be used as a

// standalone console application for automated document conversion workflows.

//

// Keywords:

// C#, PowerPoint, PPT, PPTX, XPS, Aspose.Slides for .NET, Batch Export, 

// Chronological, Presentation Conversion, Automation

//

// Use Cases:

// - Convert large collections of PowerPoint presentations to XPS for archiving.

// - Generate date‑organized XPS outputs for compliance or record‑keeping.

// - Integrate PowerPoint to XPS conversion into .NET batch processing tools.

// - Automate conversion pipelines that require chronological folder structures.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input directory containing PPT files

        string inputDir = "InputPpt";

        // Root output directory for XPS files

        string outputRootDir = "OutputXps";



        if (!Directory.Exists(inputDir))

        {

            Console.WriteLine("Input directory does not exist.");

            return;

        }



        if (!Directory.Exists(outputRootDir))

        {

            Directory.CreateDirectory(outputRootDir);

        }



        string[] pptFiles = Directory.GetFiles(inputDir, "*.ppt*");



        foreach (string pptPath in pptFiles)

        {

            try

            {

                if (!File.Exists(pptPath))

                {

                    Console.WriteLine("File not found: " + pptPath);

                    continue;

                }



                DateTime creationDate = File.GetCreationTime(pptPath);

                string dateFolder = creationDate.ToString("yyyyMMdd");

                string outputDir = Path.Combine(outputRootDir, dateFolder);



                if (!Directory.Exists(outputDir))

                {

                    Directory.CreateDirectory(outputDir);

                }



                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptPath);

                string xpsPath = Path.Combine(outputDir, fileNameWithoutExt + ".xps");



                using (Presentation pres = new Presentation(pptPath))

                {

                    // Save presentation to XPS format

                    pres.Save(xpsPath, SaveFormat.Xps);

                }



                Console.WriteLine("Converted: " + pptPath + " -> " + xpsPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("Format not supported for file: " + pptPath);

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., web service errors)

                Console.WriteLine("Error processing file " + pptPath + ": " + ex.Message);

            }

        }

    }

}

