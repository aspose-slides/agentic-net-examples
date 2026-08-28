// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX notes to concatenated HTML using C#

//

// Description:

// Demonstrates how to export PPTX notes to concatenated HTML using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML, Export, Pptx, Notes, 

// Concatenated, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate export PPTX notes to concatenated HTML.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Text;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string notesHtmlPath = "notes.html";

        string presentationSavePath = "output.pptx";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                StringBuilder htmlBuilder = new StringBuilder();

                htmlBuilder.AppendLine("<html><body>");



                for (int index = 0; index < presentation.Slides.Count; index++)

                {

                    Aspose.Slides.ISlide slide = presentation.Slides[index];

                    Aspose.Slides.INotesSlideManager notesManager = slide.NotesSlideManager;

                    Aspose.Slides.INotesSlide notesSlide = notesManager.NotesSlide;

                    string notesText = string.Empty;



                    if (notesSlide != null && notesSlide.NotesTextFrame != null)

                    {

                        notesText = notesSlide.NotesTextFrame.Text;

                    }



                    htmlBuilder.AppendLine("<h2>Slide " + (index + 1) + "</h2>");

                    if (!string.IsNullOrEmpty(notesText))

                    {

                        htmlBuilder.AppendLine("<p>" + System.Net.WebUtility.HtmlEncode(notesText) + "</p>");

                    }

                    else

                    {

                        htmlBuilder.AppendLine("<p>No notes.</p>");

                    }

                }



                htmlBuilder.AppendLine("</body></html>");



                File.WriteAllText(notesHtmlPath, htmlBuilder.ToString());



                // Save the presentation before exiting (required by rule)

                presentation.Save(presentationSavePath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

        }

        catch (Aspose.Slides.PptUnsupportedFormatException)

        {

            // Format not supported

            Console.WriteLine("The presentation format is not supported.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

