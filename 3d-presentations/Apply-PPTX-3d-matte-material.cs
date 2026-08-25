// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply PPTX 3d matte material using C#

//

// Description:

// Demonstrates how to apply a matte material to 3‑D shapes in a PPTX file using

// C# and Aspose.Slides for .NET. The example creates a sample presentation with a

// 3‑D rectangle when the input file is missing, otherwise it loads an existing

// presentation, iterates through all shapes, and sets the material of any shape

// that has a ThreeDFormat to MaterialPresetType.Matte. The result is saved as a

// new PPTX file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, 3D, Matte, Material, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automatically apply matte material to all 3‑D objects in a presentation.

// - Generate sample PPTX files with 3‑D shapes for testing.

// - Integrate PPTX material adjustments into .NET automation pipelines.

// - Validate and transform existing presentations before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ApplyMatteMaterial

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Allow overriding input path via command line argument

            if (args.Length > 0)

            {

                inputPath = args[0];

            }



            // If the input file does not exist, create a new presentation with a sample 3D shape

            if (!File.Exists(inputPath))

            {

                using (Presentation pres = new Presentation())

                {

                    // Add a rectangle shape and give it a 3D effect

                    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 200);

                    shape.ThreeDFormat.Depth = 5;

                    shape.ThreeDFormat.Material = MaterialPresetType.Matte;



                    // Save the newly created presentation

                    pres.Save(outputPath, SaveFormat.Pptx);

                }



                return;

            }



            try

            {

                // Load the existing presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Iterate through all slides and shapes

                    foreach (ISlide slide in pres.Slides)

                    {

                        foreach (IShape shape in slide.Shapes)

                        {

                            // Apply matte material to any shape that has a ThreeDFormat

                            if (shape.ThreeDFormat != null)

                            {

                                shape.ThreeDFormat.Material = MaterialPresetType.Matte;

                            }

                        }

                    }



                    // Save the modified presentation

                    pres.Save(outputPath, SaveFormat.Pptx);

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported for PPTX files

                Console.WriteLine("The presentation format is not supported (PPTX).");

            }

            catch (Aspose.Slides.PptUnsupportedFormatException)

            {

                // Format not supported for PPT files

                Console.WriteLine("The presentation format is not supported (PPT).");

            }

        }

    }

}

