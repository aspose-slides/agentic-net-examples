// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch export PPTX to HTML5 gzip js using C#

//

// Description:

// Demonstrates how to batch export PPTX files to HTML5 format and compress the

// generated JavaScript resources using GZIP. The example loads each presentation

// from an input folder, saves it as HTML5 with embedded images, writes the

// supporting files to an output folder, and then compresses all .js files to

// .js.gz, optionally removing the original JavaScript files. This pattern can be

// used to automate PowerPoint to web‑ready HTML5 conversions in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Batch, Export, Html5, Gzip, 

// JavaScript, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of PPTX presentations to HTML5 for web publishing.

// - Reduce JavaScript payload size by applying GZIP compression.

// - Integrate PowerPoint conversion into CI/CD pipelines or server‑side services.

// - Prepare offline‑compatible HTML5 presentations with compressed resources.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.IO.Compression;

using Aspose.Slides.Export;



namespace BatchExportHtml5

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output directories

            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Input");

            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Output");



            // Verify input folder exists

            if (!Directory.Exists(inputFolder))

            {

                Console.WriteLine("Input folder does not exist: " + inputFolder);

                return;

            }



            // Ensure output folder exists

            Directory.CreateDirectory(outputFolder);



            // Get all PPTX files in the input folder

            string[] presentationFiles = Directory.GetFiles(inputFolder, "*.pptx");



            foreach (string inputPath in presentationFiles)

            {

                // Verify each file exists before processing

                if (!File.Exists(inputPath))

                {

                    Console.WriteLine("File not found: " + inputPath);

                    continue;

                }



                try

                {

                    // Load the presentation

                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                    // Configure HTML5 export options

                    Aspose.Slides.Export.Html5Options html5Options = new Aspose.Slides.Export.Html5Options();

                    html5Options.SkipJavaScriptLinks = false; // keep JavaScript for compression

                    html5Options.EmbedImages = true; // embed images to reduce external resources



                    // Determine output paths

                    string presentationName = Path.GetFileNameWithoutExtension(inputPath);

                    string presentationResourcesPath = Path.Combine(outputFolder, presentationName);

                    html5Options.OutputPath = presentationResourcesPath; // folder for external resources

                    string htmlOutputPath = Path.Combine(outputFolder, presentationName + ".html");



                    // Save as HTML5

                    presentation.Save(htmlOutputPath, Aspose.Slides.Export.SaveFormat.Html5, html5Options);



                    // Compress JavaScript files using Gzip

                    if (Directory.Exists(presentationResourcesPath))

                    {

                        string[] jsFiles = Directory.GetFiles(presentationResourcesPath, "*.js", SearchOption.AllDirectories);

                        foreach (string jsFile in jsFiles)

                        {

                            try

                            {

                                byte[] jsContent = File.ReadAllBytes(jsFile);

                                string gzFilePath = jsFile + ".gz";



                                using (FileStream gzFileStream = new FileStream(gzFilePath, FileMode.Create, FileAccess.Write))

                                using (GZipStream compressionStream = new GZipStream(gzFileStream, CompressionMode.Compress))

                                {

                                    compressionStream.Write(jsContent, 0, jsContent.Length);

                                }



                                // Optionally delete the original .js file after compression

                                File.Delete(jsFile);

                            }

                            catch (Exception ex)

                            {

                                // Handle compression errors

                                Console.WriteLine("Failed to compress JavaScript file: " + jsFile);

                                Console.WriteLine("Error: " + ex.Message);

                            }

                        }

                    }



                    // Dispose the presentation

                    presentation.Dispose();

                }

                catch (NotSupportedException)

                {

                    // Format not supported

                    Console.WriteLine("File format not supported: " + inputPath);

                }

                catch (Exception ex)

                {

                    // General error handling

                    Console.WriteLine("Error processing file: " + inputPath);

                    Console.WriteLine("Error: " + ex.Message);

                }

            }

        }

    }

}

