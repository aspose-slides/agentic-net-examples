// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Hide PPTX confidential slide comments on export using C#

//

// Description:

// Demonstrates how to hide confidential slide comments on export by removing

// all comments from hidden slides in a PPTX file using Aspose.Slides for .NET.

// The example loads a presentation, iterates through its slides, deletes

// comments from any slide marked as hidden, and saves the result.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide, Confidential, Slide, Comments,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate removal of confidential comments from hidden slides before publishing.

// - Build C# tools for sanitizing PowerPoint presentations.

// - Generate or transform PPTX files while ensuring sensitive information is omitted.

// - Validate presentation workflows to comply with confidentiality requirements.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



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

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                // Iterate through all slides

                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    Aspose.Slides.ISlide slide = presentation.Slides[i];



                    // Treat hidden slides as confidential

                    if (slide.Hidden)

                    {

                        // Remove all comments from the confidential slide

                        Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);

                        for (int j = 0; j < comments.Length; j++)

                        {

                            comments[j].Remove();

                        }

                    }

                }



                // Save the modified presentation

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported.

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

