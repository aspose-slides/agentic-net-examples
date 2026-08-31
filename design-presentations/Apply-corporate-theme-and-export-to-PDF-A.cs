// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply corporate theme and export to PDF/A using C#

//

// Description:

// Demonstrates how to apply a corporate .thmx theme to each master slide of

// PowerPoint presentations and export the result as PDF/A-1b files using

// Aspose.Slides for .NET. The example processes all supported presentation

// files in a given input folder, applies the external theme, and saves the

// themed output as PDF/A in an output folder.

//

// Keywords:

// C#, PowerPoint, PPTX, PPT, ODP, Aspose.Slides for .NET, PDF/A, Corporate Theme,

// Export, Presentation Processing, Office Automation

//

// Use Cases:

// - Batch apply a corporate theme to multiple presentations.

// - Generate PDF/A compliant documents for archiving or legal purposes.

// - Automate PowerPoint to PDF/A conversion in .NET applications.

// - Integrate theme application and PDF/A export into CI/CD pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Input directory containing presentations

        string inputDir = "InputPresentations";

        // Path to the corporate theme file (.thmx)

        string themePath = "CorporateTheme.thmx";

        // Output directory for PDF/A files

        string outputDir = "OutputPdfA";



        // Verify input directory exists

        if (!Directory.Exists(inputDir))

        {

            Console.WriteLine("Input directory does not exist.");

            return;

        }



        // Verify theme file exists

        if (!File.Exists(themePath))

        {

            Console.WriteLine("Theme file does not exist.");

            return;

        }



        // Ensure output directory exists

        if (!Directory.Exists(outputDir))

        {

            Directory.CreateDirectory(outputDir);

        }



        // Get all files in the input directory

        string[] presentationFiles = Directory.GetFiles(inputDir, "*.*", SearchOption.TopDirectoryOnly);

        foreach (string presPath in presentationFiles)

        {

            // Check if the file format is supported

            string extension = Path.GetExtension(presPath).ToLowerInvariant();

            if (extension != ".pptx" && extension != ".ppt" && extension != ".odp")

            {

                // Format not supported.

                continue;

            }



            // Verify the presentation file exists

            if (!File.Exists(presPath))

            {

                // Input file does not exist.

                continue;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(presPath))

                {

                    // Apply the external corporate theme to each master slide

                    foreach (IMasterSlide master in presentation.Masters)

                    {

                        master.ApplyExternalThemeToDependingSlides(themePath);

                    }



                    // Configure PDF/A compliance options

                    PdfOptions pdfOptions = new PdfOptions();

                    pdfOptions.Compliance = Aspose.Slides.Export.PdfCompliance.PdfA1b;

                    pdfOptions.IncludeOleData = true; // optional inclusion of OLE data



                    // Save the themed presentation as PDF/A

                    string outputFile = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(presPath) + ".pdf");

                    presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported.

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., theme application failure)

                Console.WriteLine($"Error processing {presPath}: {ex.Message}");

            }

        }

    }

}

