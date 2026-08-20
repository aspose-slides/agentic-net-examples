// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Toggle PPTX 3d model visibility flag using C#

//

// Description:

// Demonstrates how to toggle the visibility of 3‑D models in a PPTX file by

// adjusting the extrusion height of shapes that have a ThreeDFormat. The

// example loads a presentation, optionally sets the visibility based on a

// command‑line argument, and saves the modified file. It uses Aspose.Slides for

// .NET and can be integrated into automation scripts or desktop tools.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Toggle, 3D Model, Visibility,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Programmatically hide or show 3‑D objects in PowerPoint slides.

// - Build .NET utilities for batch processing of PPTX files.

// - Validate 3‑D model settings before publishing presentations.

// - Integrate 3‑D visibility control into larger document‑generation workflows.

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

        if (args.Length > 0)

        {

            inputPath = args[0];

        }



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        bool show3D = true;

        if (args.Length > 1)

        {

            bool parsed;

            if (bool.TryParse(args[1], out parsed))

            {

                show3D = parsed;

            }

        }



        try

        {

            using (Presentation pres = new Presentation(inputPath))

            {

                ISlide slide = pres.Slides[0];

                for (int i = 0; i < slide.Shapes.Count; i++)

                {

                    IShape shape = slide.Shapes[i];

                    if (shape.ThreeDFormat != null)

                    {

                        if (show3D)

                        {

                            shape.ThreeDFormat.ExtrusionHeight = 100; // make 3D visible

                        }

                        else

                        {

                            shape.ThreeDFormat.ExtrusionHeight = 0; // hide 3D

                        }

                    }

                }



                string outputPath = "output.pptx";

                pres.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (Aspose.Slides.PptxUnsupportedFormatException)

        {

            // format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

