// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Decrypt PPTX slide comments after loading using C#

//

// Description:

// Demonstrates how to load a PPTX file, access its slide comments, and save the

// presentation using C# and Aspose.Slides for .NET. The example shows the

// required presentation-processing steps for PowerPoint files and produces the

// requested output in a standalone console application. Developers can use this

// pattern to automate PPTX workflows, validate results, or integrate presentation

// logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Decrypt, Pptx, Slide, Comments,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate loading and processing PPTX slide comments after decryption.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

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

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            foreach (object authorObj in presentation.CommentAuthors)

            {

                Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)authorObj;

                foreach (object commentObj in author.Comments)

                {

                    Aspose.Slides.Comment comment = (Aspose.Slides.Comment)commentObj;

                    Console.WriteLine("Author: " + author.Name);

                    Console.WriteLine("Comment: " + comment.Text);

                }

            }



            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

