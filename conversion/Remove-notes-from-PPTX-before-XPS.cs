// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Remove notes from PPTX before XPS using C#

//

// Description:

// Demonstrates how to remove all notes from a PPTX presentation and then

// convert the cleaned presentation to XPS format using Aspose.Slides for .NET.

// The example loads a PPTX file, deletes each slide's notes slide, and saves

// the result as an XPS document. This pattern can be used in automation scripts

// or applications that need to strip notes before publishing.

//

// Keywords:

// C#, PowerPoint, PPTX, XPS, Aspose.Slides for .NET, Remove Notes, Convert, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Remove speaker notes from presentations before distribution.

// - Convert PPTX files to XPS after cleaning up notes.

// - Build .NET utilities for PowerPoint content sanitization.

// - Integrate note removal and format conversion into larger workflows.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace RemoveNotesAndConvertToXps

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output.xps";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // Remove notes from each slide

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;

                        notesManager.RemoveNotesSlide();

                    }



                    // Save to XPS format

                    Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}

