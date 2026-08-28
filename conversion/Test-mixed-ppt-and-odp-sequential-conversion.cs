// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test mixed ppt and odp sequential conversion using C#

//

// Description:

// Demonstrates how to sequentially convert and merge a PowerPoint (PPT) file

// and an OpenDocument Presentation (ODP) file into a single PPTX presentation

// using Aspose.Slides for .NET. The example loads each source file, clones its

// slides into a new presentation, and saves the combined result.

//

// Keywords:

// C#, PowerPoint, PPT, ODP, PPTX, Aspose.Slides for .NET, Mixed Format Conversion,

// Sequential Conversion, Presentation Merging, Office Automation

//

// Use Cases:

// - Combine slides from different presentation formats into one PPTX.

// - Automate batch processing of mixed-format presentations.

// - Validate and transform PPT and ODP files in .NET applications.

// - Build tools for presentation content consolidation.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace MixedFormatConversion

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input files (PPT and ODP)

            string pptPath = "input.ppt";

            string odpPath = "input.odp";

            // Output combined presentation

            string outputPath = "combined_output.pptx";



            // Verify input files exist

            if (!File.Exists(pptPath))

            {

                Console.WriteLine($"File not found: {pptPath}");

                return;

            }

            if (!File.Exists(odpPath))

            {

                Console.WriteLine($"File not found: {odpPath}");

                return;

            }



            // Create a new empty presentation to hold combined slides

            Aspose.Slides.Presentation combinedPresentation = new Aspose.Slides.Presentation();



            try

            {

                // Process PPT file

                Aspose.Slides.IPresentationInfo pptInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(pptPath);

                Aspose.Slides.LoadFormat pptFormat = pptInfo.LoadFormat;

                if (pptFormat != Aspose.Slides.LoadFormat.Ppt && pptFormat != Aspose.Slides.LoadFormat.Pptx && pptFormat != Aspose.Slides.LoadFormat.Ppt95)

                {

                    // Format not supported for this file

                    Console.WriteLine("PPT file format not supported.");

                }

                else

                {

                    Aspose.Slides.Presentation pptPresentation = new Aspose.Slides.Presentation(pptPath);

                    for (int i = 0; i < pptPresentation.Slides.Count; i++)

                    {

                        combinedPresentation.Slides.AddClone(pptPresentation.Slides[i]);

                    }

                    pptPresentation.Dispose();

                }



                // Process ODP file

                Aspose.Slides.IPresentationInfo odpInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(odpPath);

                Aspose.Slides.LoadFormat odpFormat = odpInfo.LoadFormat;

                if (odpFormat != Aspose.Slides.LoadFormat.Odp && odpFormat != Aspose.Slides.LoadFormat.Fodp)

                {

                    // Format not supported for this file

                    Console.WriteLine("ODP file format not supported.");

                }

                else

                {

                    Aspose.Slides.Presentation odpPresentation = new Aspose.Slides.Presentation(odpPath);

                    for (int i = 0; i < odpPresentation.Slides.Count; i++)

                    {

                        combinedPresentation.Slides.AddClone(odpPresentation.Slides[i]);

                    }

                    odpPresentation.Dispose();

                }



                // Save combined presentation as PPTX

                combinedPresentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

            catch (NotSupportedException ex)

            {

                // Handle unsupported format exception

                Console.WriteLine($"Format not supported: {ex.Message}");

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., file access issues)

                Console.WriteLine($"Error: {ex.Message}");

            }

            finally

            {

                // Ensure the combined presentation is saved before exit

                combinedPresentation.Dispose();

            }

        }

    }

}

