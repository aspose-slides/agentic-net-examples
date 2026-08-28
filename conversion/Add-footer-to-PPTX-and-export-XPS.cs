// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add footer to PPTX and export XPS using C#

//

// Description:

// Demonstrates how to add a footer to each slide of a PPTX file and then

// export the modified presentation to XPS format using Aspose.Slides for .NET.

// The example loads an existing PPTX, ensures the footer is visible, sets

// custom footer text, and saves the result as an XPS document.

//

// Keywords:

// C#, PowerPoint, PPTX, XPS, Aspose.Slides for .NET, Footer, Export, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate adding a consistent footer to PowerPoint presentations.

// - Convert PPTX files to XPS for printing or archival purposes.

// - Build .NET utilities that modify and export slide decks.

// - Validate footer presence before publishing presentations.

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

        string outputPath = "output.xps";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            using (Presentation presentation = new Presentation(inputPath))

            {

                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    IBaseSlideHeaderFooterManager headerFooter = presentation.Slides[i].HeaderFooterManager;

                    if (!headerFooter.IsFooterVisible)

                    {

                        headerFooter.SetFooterVisibility(true);

                    }

                    headerFooter.SetFooterText("My Footer");

                }



                XpsOptions options = new XpsOptions();

                // Customize XpsOptions if needed, e.g., options.DrawSlidesFrame = true;



                presentation.Save(outputPath, SaveFormat.Xps, options);

            }

        }

        catch (PptxUnsupportedFormatException)

        {

            // Format not supported

            Console.WriteLine("The presentation format is not supported for XPS conversion.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

