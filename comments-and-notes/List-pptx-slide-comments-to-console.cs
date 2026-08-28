// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: List pptx slide comments to console using C#

//

// Description:

// Demonstrates how to list pptx slide comments to console using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, List, Pptx, Slide, Comments, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate list pptx slide comments to console.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ListSlideComments

{

    class Program

    {

        static void Main(string[] args)

        {

            // Path to the input presentation

            string inputPath = "input.pptx";



            // Verify that the file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("File not found: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Iterate through each slide

                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)

                    {

                        ISlide slide = presentation.Slides[slideIndex];



                        // Retrieve all comments on the slide (null author returns all)

                        IComment[] comments = slide.GetSlideComments(null);



                        // Print comment details

                        foreach (IComment comment in comments)

                        {

                            string authorName = comment.Author != null ? comment.Author.Name : "Unknown";

                            Console.WriteLine("Slide {0} - Author: {1} - Text: {2}",

                                slide.SlideNumber, authorName, comment.Text);

                        }

                    }



                    // Save the presentation before exiting (no modifications made)

                    string outputPath = "output.pptx";

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

            }

            catch (PptxUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (PptUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

