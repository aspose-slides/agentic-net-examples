// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert presentation to PDF with font substitution using C#

//

// Description:

// Demonstrates how to batch convert PowerPoint presentations (PPT, PPTX, ODP, etc.) 

// to PDF while applying font substitution using Aspose.Slides for .NET. The example 

// loads external system fonts, sets a default regular font for missing fonts, and 

// processes each supported presentation file in a given input directory, saving 

// the resulting PDFs to an output subfolder.

//

// Keywords:

// C#, PowerPoint, PPTX, PPT, ODP, Aspose.Slides for .NET, PDF, Batch conversion, 

// Font substitution, Presentation processing, Office automation

//

// Use Cases:

// - Automate batch conversion of presentations to PDF with consistent font handling.

// - Build command‑line tools for PowerPoint to PDF transformation in .NET.

// - Ensure missing fonts are substituted to avoid rendering issues.

// - Integrate presentation conversion into CI/CD pipelines or document workflows.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchConvertToPdf

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine input directory

            string inputDirectory = (args.Length > 0 && !String.IsNullOrEmpty(args[0])) ? args[0] : "InputPresentations";



            // Verify input directory exists

            if (!Directory.Exists(inputDirectory))

            {

                Console.WriteLine("Input directory not found: " + inputDirectory);

                return;

            }



            // Load external fonts (adds system font folders and any custom folders previously added)

            string[] fontFolders = FontsLoader.GetFontFolders();

            FontsLoader.LoadExternalFonts(fontFolders);



            // Prepare output directory

            string outputDirectory = Path.Combine(inputDirectory, "OutputPdf");

            if (!Directory.Exists(outputDirectory))

            {

                Directory.CreateDirectory(outputDirectory);

            }



            // Get all presentation files (ppt, pptx, odp, etc.)

            string[] presentationFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string filePath in presentationFiles)

            {

                // Filter supported presentation extensions

                string extension = Path.GetExtension(filePath).ToLowerInvariant();

                if (extension != ".ppt" && extension != ".pptx" && extension != ".odp" && extension != ".pptm" && extension != ".ppsx")

                {

                    // Skip unsupported formats

                    continue;

                }



                // Verify file exists (redundant but follows rule)

                if (!File.Exists(filePath))

                {

                    Console.WriteLine("Input file not found: " + filePath);

                    continue;

                }



                try

                {

                    // Set load options with default font substitution

                    LoadOptions loadOptions = new LoadOptions();

                    loadOptions.DefaultRegularFont = "Arial";



                    // Load presentation with load options

                    using (Presentation presentation = new Presentation(filePath, loadOptions))

                    {

                        // Prepare PDF options (optional customizations)

                        PdfOptions pdfOptions = new PdfOptions();

                        pdfOptions.DefaultRegularFont = "Arial";



                        // Determine output PDF path

                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);

                        string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");



                        // Ensure output directory exists (already created above)

                        string outputDir = Path.GetDirectoryName(outputPath);

                        if (!Directory.Exists(outputDir))

                        {

                            Directory.CreateDirectory(outputDir);

                        }



                        // Save presentation as PDF

                        presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

                        Console.WriteLine("Converted: " + filePath + " -> " + outputPath);

                    }

                }

                catch (DirectoryNotFoundException dirEx)

                {

                    Console.WriteLine("Directory not found: " + dirEx.Message);

                }

                catch (FileNotFoundException fileEx)

                {

                    Console.WriteLine("File not found: " + fileEx.Message);

                }

                catch (NotSupportedException notSupEx)

                {

                    // Format not supported

                    Console.WriteLine("Format not supported for file: " + filePath);

                }

                catch (Exception ex)

                {

                    // General exception handling

                    Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);

                }

            }

        }

    }

}

