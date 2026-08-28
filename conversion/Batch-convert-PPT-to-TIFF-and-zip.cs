// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert PPT to TIFF and zip using C#

//

// Description:

// Demonstrates how to batch convert PPT to TIFF and zip using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PPT, Batch, Convert, Tiff, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch convert PPT to TIFF and zip.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.IO.Compression;

using Aspose.Slides.Export;



namespace BatchTiffConverter

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine output directory

            string currentDirectory = Directory.GetCurrentDirectory();

            string outputDirectory = Path.Combine(currentDirectory, "output");

            if (!Directory.Exists(outputDirectory))

            {

                Directory.CreateDirectory(outputDirectory);

            }



            // List to hold generated TIFF file paths

            System.Collections.Generic.List<string> tiffFiles = new System.Collections.Generic.List<string>();



            // Process each input file path provided as argument

            foreach (string inputPath in args)

            {

                // Check if file exists

                if (!File.Exists(inputPath))

                {

                    Console.WriteLine($"Input file does not exist: {inputPath}");

                    continue;

                }



                try

                {

                    // Load presentation

                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                    // Prepare TIFF options (default options)

                    Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();



                    // Determine output TIFF file name

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

                    string tiffPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tiff");



                    // Save as TIFF

                    presentation.Save(tiffPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);



                    // Add to list for zipping

                    tiffFiles.Add(tiffPath);



                    // Dispose presentation

                    presentation.Dispose();

                }

                catch (NotSupportedException)

                {

                    // Format not supported

                    // Comment: format not supported

                    Console.WriteLine($"Format not supported for file: {inputPath}");

                }

                catch (Exception ex)

                {

                    // Handle other exceptions (e.g., external URLs)

                    Console.WriteLine($"Error processing file {inputPath}: {ex.Message}");

                }

            }



            // Create ZIP archive of all TIFF files

            if (tiffFiles.Count > 0)

            {

                string zipPath = Path.Combine(outputDirectory, "TIFFs.zip");

                try

                {

                    using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))

                    {

                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))

                        {

                            foreach (string tiffFile in tiffFiles)

                            {

                                string entryName = Path.GetFileName(tiffFile);

                                archive.CreateEntryFromFile(tiffFile, entryName);

                            }

                        }

                    }

                }

                catch (Exception ex)

                {

                    Console.WriteLine($"Error creating ZIP archive: {ex.Message}");

                }

            }



            // Ensure presentation saved before exit (already saved during processing)

        }

    }

}

