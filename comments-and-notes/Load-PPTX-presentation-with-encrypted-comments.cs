// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load PPTX presentation with encrypted comments using C#

//

// Description:

// Demonstrates how to load a PPTX presentation that contains encrypted

// comments using Aspose.Slides for .NET, iterate through the comment authors

// and their comments, output the comment text to the console, and save a

// decrypted copy of the presentation. The example is a self‑contained console

// application suitable for automating comment extraction and PPTX decryption.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Encrypted Comments,

// Decrypt, Presentation, Comments, Office Automation

//

// Use Cases:

// - Load a password‑protected PPTX file that has encrypted comments.

// - Extract and display comment authors and texts from a secured presentation.

// - Save a decrypted version of the presentation for further processing.

// - Integrate comment handling into .NET tools for PowerPoint automation.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input presentation path and password for encrypted comments

        string inputPath = "encrypted_comments.pptx";

        string password = "privateKeyPassword";

        string outputPath = "decrypted_output.pptx";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation with the provided password

            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();

            loadOptions.Password = password;

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);



            // Access and display slide comments

            foreach (object authorObj in presentation.CommentAuthors)

            {

                Aspose.Slides.CommentAuthor author = (Aspose.Slides.CommentAuthor)authorObj;

                foreach (object commentObj in author.Comments)

                {

                    Aspose.Slides.Comment comment = (Aspose.Slides.Comment)commentObj;

                    Console.WriteLine("Author: " + author.Name + " - Comment: " + comment.Text);

                }

            }



            // Save the decrypted presentation

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Handle unsupported file format

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., external URL errors)

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

