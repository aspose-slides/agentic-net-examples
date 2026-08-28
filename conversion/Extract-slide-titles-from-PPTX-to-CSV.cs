// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Extract slide titles from PPTX to CSV using C#

//

// Description:

// Demonstrates how to extract slide titles from a PowerPoint PPTX file and

// write them to a CSV file using C# and Aspose.Slides for .NET. The example

// loads a presentation, retrieves the raw text of each slide, treats the

// first line as the slide title, and outputs an index‑title pair to a CSV.

// This pattern can be used to automate slide‑title extraction, generate

// documentation, or integrate PowerPoint data into other systems.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Slide, Titles, CSV,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate extraction of slide titles from PPTX files to CSV reports.

// - Build C# utilities for PowerPoint content analysis.

// - Integrate slide metadata into documentation or data pipelines.

// - Validate presentation structures before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputCsv = "titles.csv";



        // Check if the input PPTX file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation (required for saving before exit)

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                // Extract raw text from slides using a valid TextExtractionArrangingMode

                Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(

                    inputPath,

                    Aspose.Slides.TextExtractionArrangingMode.Unarranged);



                Aspose.Slides.ISlideText[] slidesText = presentationText.SlidesText;



                // Write slide titles to CSV

                using (StreamWriter writer = new StreamWriter(outputCsv))

                {

                    writer.WriteLine("SlideIndex,Title");

                    for (int i = 0; i < slidesText.Length; i++)

                    {

                        string fullText = slidesText[i].Text ?? string.Empty;

                        string title = string.Empty;



                        if (!string.IsNullOrEmpty(fullText))

                        {

                            // Assume the title is the first line of the slide text

                            int newlineIndex = fullText.IndexOf('\n');

                            title = newlineIndex >= 0 ? fullText.Substring(0, newlineIndex).Trim() : fullText.Trim();

                        }



                        // Escape double quotes in title

                        string escapedTitle = title.Replace("\"", "\"\"");

                        writer.WriteLine($"{i + 1},\"{escapedTitle}\"");

                    }

                }



                // Save the presentation before exiting

                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

        }

        catch (Aspose.Slides.PptxUnsupportedFormatException)

        {

            // Format not supported

        }

        catch (Aspose.Slides.PptUnsupportedFormatException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

