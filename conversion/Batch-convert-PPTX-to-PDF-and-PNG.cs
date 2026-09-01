// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert PPTX to PDF and PNG using C#

//

// Description:

// Demonstrates how to batch convert all PPTX files in a specified folder to

// PDF documents and individual slide PNG images using C# and Aspose.Slides for

// .NET. The example loads each presentation, saves a combined PDF, creates a

// subfolder for the slide images, and exports each slide as a PNG file. This

// pattern can be used to automate PowerPoint conversion workflows in .NET

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, PNG, Batch, Convert,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of multiple PPTX files to PDF and per‑slide PNGs.

// - Generate image previews of slides for web or mobile applications.

// - Build command‑line tools for PowerPoint content preparation.

// - Integrate presentation conversion into CI/CD pipelines or document

//   management systems.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Input directory containing PPTX files (default: current directory)

        string inputDir = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();



        // Output base directory for generated files

        string outputDir = args.Length > 1 ? args[1] : Path.Combine(Directory.GetCurrentDirectory(), "output");



        // Ensure output directory exists

        if (!Directory.Exists(outputDir))

        {

            Directory.CreateDirectory(outputDir);

        }



        // Get all PPTX files in the input directory

        string[] pptxFiles = Directory.GetFiles(inputDir, "*.pptx");



        foreach (string pptxPath in pptxFiles)

        {

            // Verify the file exists

            if (!File.Exists(pptxPath))

            {

                continue;

            }



            try

            {

                // Load the presentation

                Presentation pres = new Presentation(pptxPath);



                // Save the whole presentation as PDF

                string pdfPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(pptxPath) + ".pdf");

                pres.Save(pdfPath, SaveFormat.Pdf);



                // Create a subfolder for PNG slides

                string pngFolder = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(pptxPath) + "_png");

                if (!Directory.Exists(pngFolder))

                {

                    Directory.CreateDirectory(pngFolder);

                }



                // Export each slide to a separate PNG file

                for (int i = 0; i < pres.Slides.Count; i++)

                {

                    ISlide slide = pres.Slides[i];

                    using (IImage image = slide.GetImage())

                    {

                        string pngPath = Path.Combine(pngFolder, $"slide_{i + 1}.png");

                        image.Save(pngPath, Aspose.Slides.ImageFormat.Png);

                    }

                }



                // Dispose the presentation

                pres.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

            }

            catch (Exception)

            {

                // Handle other exceptions as needed

            }

        }

    }

}

