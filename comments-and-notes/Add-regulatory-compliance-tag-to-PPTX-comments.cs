// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add regulatory compliance tag to PPTX comments using C#

//

// Description:

// Demonstrates how to add a regulatory compliance tag to PPTX comments using C#

// and Aspose.Slides for .NET. The example loads a presentation, iterates through

// all comment authors and their comments, appends a compliance tag to each

// comment text, and saves the updated presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Regulatory, Compliance, Comments,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automatically tag PowerPoint comments with regulatory compliance markers.

// - Build C# utilities for annotating PPTX files in compliance workflows.

// - Integrate comment tagging into document management or review systems.

// - Ensure presentation comments meet audit and regulatory requirements.

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



        // Check if the input file exists

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

                // Iterate through all comment authors

                foreach (Aspose.Slides.ICommentAuthor commentAuthor in presentation.CommentAuthors)

                {

                    // Iterate through each comment of the author

                    foreach (Aspose.Slides.IComment comment in commentAuthor.Comments)

                    {

                        // Append a regulatory compliance tag to the comment text

                        comment.Text = comment.Text + " [RegulatoryCompliance:Approved]";

                    }

                }



                // Save the modified presentation

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

        }

        catch (Aspose.Slides.PptxUnsupportedFormatException ex)

        {

            // Format not supported

            Console.WriteLine("File format not supported: " + ex.Message);

        }

        catch (NotSupportedException ex)

        {

            // Unsupported operation

            Console.WriteLine("Operation not supported: " + ex.Message);

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

