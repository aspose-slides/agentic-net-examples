// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert ODP to SVG and XPS using C#

//

// Description:

// Demonstrates how to batch convert ODP files to SVG images (one per slide) 

// and a single XPS document using Aspose.Slides for .NET. The example shows 

// how to load each ODP presentation, export slides as SVG files into a 

// dedicated folder, and save the whole presentation as XPS. It can be run 

// as a console application with file paths supplied via command‑line arguments.

//

// Keywords:

// C#, ODP, SVG, XPS, Aspose.Slides for .NET, Batch conversion, Presentation 

// processing, Office automation

//

// Use Cases:

// - Automate batch conversion of multiple ODP presentations to SVG and XPS.

// - Build command‑line tools for PowerPoint‑compatible format processing.

// - Generate SVG assets for web or documentation from ODP slides.

// - Produce XPS files for printing or archival from ODP sources.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // List of ODP files to process

        string[] inputFiles;

        if (args.Length > 0)

        {

            inputFiles = args;

        }

        else

        {

            inputFiles = new string[] { "sample1.odp", "sample2.odp" };

        }



        foreach (string inputFile in inputFiles)

        {

            if (!File.Exists(inputFile))

            {

                Console.WriteLine($"Input file not found: {inputFile}");

                continue;

            }



            try

            {

                using (Presentation pres = new Presentation(inputFile))

                {

                    // Create directory for SVG files

                    string baseName = Path.GetFileNameWithoutExtension(inputFile);

                    string svgDirectory = Path.Combine(Path.GetDirectoryName(inputFile) ?? "", baseName + "_svg");

                    if (!Directory.Exists(svgDirectory))

                    {

                        Directory.CreateDirectory(svgDirectory);

                    }



                    // Export each slide to SVG

                    for (int i = 0; i < pres.Slides.Count; i++)

                    {

                        string svgPath = Path.Combine(svgDirectory, $"slide_{i + 1}.svg");

                        using (FileStream svgStream = File.Create(svgPath))

                        {

                            pres.Slides[i].WriteAsSvg(svgStream);

                        }

                    }



                    // Save presentation as XPS

                    string xpsPath = Path.Combine(Path.GetDirectoryName(inputFile) ?? "", baseName + ".xps");

                    // Convert without XPS options (rule: convert-without-xps-options)

                    pres.Save(xpsPath, Aspose.Slides.Export.SaveFormat.Xps);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine($"Format not supported for file: {inputFile}");

            }

            catch (Exception ex)

            {

                Console.WriteLine($"Error processing file {inputFile}: {ex.Message}");

            }

        }

    }

}

