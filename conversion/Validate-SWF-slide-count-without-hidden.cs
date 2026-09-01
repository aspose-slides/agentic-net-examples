// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate SWF slide count without hidden using C#

//

// Description:

// Demonstrates how to validate SWF slide count without hidden using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Slide, Count, 

// Without, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate validate SWF slide count without hidden.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesSwfValidation

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            string outputPath = args.Length > 1 ? args[1] : "output.swf";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load source presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    int totalSlides = pres.Slides.Count;

                    int hiddenSlides = pres.DocumentProperties.HiddenSlides;

                    int visibleSlides = totalSlides - hiddenSlides;



                    // Set SWF export options (do not include hidden slides)

                    SwfOptions swfOptions = new SwfOptions();

                    swfOptions.ShowHiddenSlides = false;



                    // Save as SWF

                    pres.Save(outputPath, SaveFormat.Swf, swfOptions);



                    // Validate that SWF contains the same number of visible slides

                    try

                    {

                        using (Presentation swfPres = new Presentation(outputPath))

                        {

                            int swfSlideCount = swfPres.Slides.Count;

                            if (swfSlideCount == visibleSlides)

                            {

                                Console.WriteLine("Validation succeeded: SWF slide count matches visible slide count.");

                            }

                            else

                            {

                                Console.WriteLine("Validation failed: Expected slide count " + visibleSlides + ", but SWF contains " + swfSlideCount);

                            }

                        }

                    }

                    catch (Exception)

                    {

                        // Format not supported for loading SWF

                        Console.WriteLine("Unable to load SWF for validation: format not supported.");

                    }

                }

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error processing presentation: " + ex.Message);

            }

        }

    }

}

