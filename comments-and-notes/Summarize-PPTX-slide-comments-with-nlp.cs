// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Summarize PPTX slide comments with nlp using C#

//

// Description:

// Demonstrates how to extract slide comments from a PPTX file, summarize them

// using a placeholder NLP method, and store the summary in the presentation's

// document properties. The example uses Aspose.Slides for .NET to load the

// presentation, retrieve comments via text extraction and slide objects, and

// save the updated file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, AI, Summarize, Slide Comments,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate extraction and summarization of PPTX slide comments.

// - Build C# tools that incorporate basic NLP summarization for presentations.

// - Integrate comment analysis into .NET PowerPoint workflows.

// - Store generated summaries within presentation metadata for later review.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.AI;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Extract comments using PresentationFactory with Unarranged mode

                IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(

                    inputPath,

                    Aspose.Slides.TextExtractionArrangingMode.Unarranged);



                string allComments = string.Empty;



                // Collect comments from extracted slide text

                foreach (ISlideText slideText in presentationText.SlidesText)

                {

                    if (!string.IsNullOrEmpty(slideText.CommentsText))

                    {

                        allComments += slideText.CommentsText + "\n";

                    }

                }



                // Collect comments directly from slide objects

                foreach (ISlide slide in presentation.Slides)

                {

                    IComment[] comments = slide.GetSlideComments(null);

                    foreach (IComment comment in comments)

                    {

                        allComments += comment.Text + "\n";

                    }

                }



                // Summarize comments using a placeholder NLP method

                string summary = Summarize(allComments);



                // Store the summary in the presentation's document properties

                presentation.DocumentProperties.Comments = summary;



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (Aspose.Slides.PptxUnsupportedFormatException)

        {

            // Format not supported

            Console.WriteLine("The presentation format is not supported.");

        }

        catch (Exception ex)

        {

            // Handle other exceptions, including external service errors

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }



    // Mock summarization method; replace with actual NLP service call as needed

    static string Summarize(string text)

    {

        if (string.IsNullOrEmpty(text))

            return string.Empty;



        const int maxLength = 200;

        return text.Length <= maxLength ? text : text.Substring(0, maxLength) + "...";

    }

}

