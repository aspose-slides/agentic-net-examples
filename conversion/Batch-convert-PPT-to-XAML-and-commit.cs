// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert PPT to XAML and commit using C#

//

// Description:

// Demonstrates how to batch convert PowerPoint presentations (PPT/PPTX) to

// XAML files using Aspose.Slides for .NET and move the generated files into a

// version‑controlled repository. The console application scans an input folder,

// exports each presentation to XAML (including hidden slides), and copies the

// results to an output folder, overwriting existing files.

//

// Keywords:

// C#, PowerPoint, PPT, PPTX, XAML, Aspose.Slides for .NET, Batch conversion,

// Commit, Presentation processing, Office automation

//

// Use Cases:

// - Automate bulk conversion of PPT/PPTX files to XAML for UI or documentation.

// - Integrate PowerPoint conversion into CI/CD pipelines with repository commit.

// - Build tools that prepare presentation assets for WPF or other XAML‑based

//   platforms.

// - Validate and manage presentation conversions in .NET applications.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.Export.Xaml;



namespace BatchConvertToXaml

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input directory containing PPT/PPTX files

            string inputDirectory = args.Length > 0 ? args[0] : "InputPpts";

            // Output directory for XAML files (version‑controlled repository)

            string outputDirectory = args.Length > 1 ? args[1] : "XamlRepo";



            // Verify input directory exists

            if (!Directory.Exists(inputDirectory))

            {

                Console.WriteLine("Input directory does not exist: " + inputDirectory);

                return;

            }



            // Ensure output directory exists

            if (!Directory.Exists(outputDirectory))

            {

                Directory.CreateDirectory(outputDirectory);

            }



            // Get all PowerPoint files (ppt, pptx)

            string[] presentationFiles = Directory.GetFiles(inputDirectory, "*.ppt*");



            foreach (string presentationPath in presentationFiles)

            {

                // Verify each file exists before processing

                if (!File.Exists(presentationPath))

                {

                    Console.WriteLine("File not found: " + presentationPath);

                    continue;

                }



                try

                {

                    // Load presentation

                    using (Presentation presentation = new Presentation(presentationPath))

                    {

                        // Configure XAML options (export hidden slides as an example)

                        XamlOptions xamlOptions = new XamlOptions();

                        xamlOptions.ExportHiddenSlides = true;



                        // Save presentation as XAML files

                        presentation.Save(xamlOptions);



                        // Move generated XAML files to the output repository

                        string presentationName = Path.GetFileNameWithoutExtension(presentationPath);

                        string sourceFolder = Path.GetDirectoryName(presentationPath);

                        string[] generatedXamlFiles = Directory.GetFiles(sourceFolder, presentationName + "_*.xaml");



                        foreach (string sourceFile in generatedXamlFiles)

                        {

                            string destinationFile = Path.Combine(outputDirectory, Path.GetFileName(sourceFile));

                            // Overwrite if file already exists in the repository

                            if (File.Exists(destinationFile))

                            {

                                File.Delete(destinationFile);

                            }

                            File.Move(sourceFile, destinationFile);

                        }

                    }

                }

                catch (NotSupportedException)

                {

                    // Format not supported

                    Console.WriteLine("Format not supported for file: " + presentationPath);

                }

                catch (Exception ex)

                {

                    // General error handling

                    Console.WriteLine("Error processing file " + presentationPath + ": " + ex.Message);

                }

            }

        }

    }

}

