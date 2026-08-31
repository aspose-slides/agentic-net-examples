// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Extract text from slides and save summary using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, extract raw text from each

// slide using Aspose.Slides for .NET, and write a plain‑text summary file. The

// example includes validation of the input file, handling of unsupported

// formats, and a simple console‑based workflow suitable for automation or

// integration into larger .NET applications.

//

// Keywords:

// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Text extraction, Slide summary,

// Console application, Presentation processing, Office automation

//

// Use Cases:

// - Automate extraction of slide text for indexing or search.

// - Generate textual summaries of presentations for accessibility.

// - Build command‑line tools that process PPTX files in batch.

// - Validate and log presentation content before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Text;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExtractTextExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation file path

            string inputPath = "input.pptx";

            // Output summary text file path

            string outputPath = "summary.txt";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                // Load the presentation to ensure the format is supported

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Save the presentation before exiting (as required)

                presentation.Save(inputPath, SaveFormat.Pptx);

                // Dispose the presentation object

                presentation.Dispose();



                // Extract raw text from the presentation using a valid extraction mode

                Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(

                    inputPath,

                    Aspose.Slides.TextExtractionArrangingMode.Unarranged);



                // Build the summary text

                StringBuilder summaryBuilder = new StringBuilder();

                Aspose.Slides.ISlideText[] slidesText = presentationText.SlidesText;

                for (int i = 0; i < slidesText.Length; i++)

                {

                    Aspose.Slides.ISlideText slideText = slidesText[i];

                    summaryBuilder.AppendLine($"--- Slide {i + 1} ---");

                    summaryBuilder.AppendLine(slideText.Text);

                    summaryBuilder.AppendLine();

                }



                // Write the summary to a plain‑text file

                File.WriteAllText(outputPath, summaryBuilder.ToString());

                Console.WriteLine($"Text summary saved to '{outputPath}'.");

            }

            // Handle unsupported file format exceptions

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported (PPTX).");

            }

            catch (Aspose.Slides.PptUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported (PPT).");

            }

            // General exception handling

            catch (Exception ex)

            {

                Console.WriteLine($"An error occurred: {ex.Message}");

            }

        }

    }

}

