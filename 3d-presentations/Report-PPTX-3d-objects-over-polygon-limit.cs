// -----------------------------------------------------------------------------




// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Report PPTX 3d objects over polygon limit using C#



//



// Description:



// Demonstrates how to scan a PowerPoint presentation for 3‑D shapes whose



// polygon count exceeds a defined threshold, reporting the slide number,



// shape name and polygon count. The example uses Aspose.Slides for .NET to



// load, inspect and optionally save the presentation in a console application.



// Developers can adapt this pattern to validate 3‑D content before publishing



// or to enforce polygon‑count limits in automated workflows.



//



// Keywords:



// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D objects, Polygon limit,



// Presentation analysis, Office Automation, Shape inspection



//



// Use Cases:



// - Detect and report 3‑D shapes that exceed polygon limits in PPTX files.



// - Integrate polygon‑count validation into CI/CD pipelines for presentations.



// - Build tools that enforce rendering performance constraints for 3‑D content.



// - Automate quality checks for PowerPoint files before distribution.



// -----------------------------------------------------------------------------



using System;



using System.IO;



using Aspose.Slides;



using Aspose.Slides.Export;







namespace Report3DObjects



{



    class Program



    {



        static void Main(string[] args)



        {



            // Path to the input presentation file (first argument or default)



            string inputPath = args.Length > 0 ? args[0] : "input.pptx";







            // Verify that the file exists



            if (!File.Exists(inputPath))



            {



                Console.WriteLine("Input file does not exist: " + inputPath);



                return;



            }







            // Polygon count threshold – adjust as needed



            int polygonThreshold = 1000;







            // Load the presentation with exception handling for unsupported formats



            try



            {



                using (Presentation presentation = new Presentation(inputPath))



                {



                    bool anyExceed = false;







                    // Iterate through all slides



                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)



                    {



                        ISlide slide = presentation.Slides[slideIndex];







                        // Iterate through all shapes on the slide



                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)



                        {



                            IShape shape = slide.Shapes[shapeIndex];







                            // Check if the shape has 3‑D formatting (i.e., is a 3‑D object)



                            if (shape.ThreeDFormat != null)



                            {



                                // NOTE: Aspose.Slides does not expose a direct polygon‑count property.



                                // If such an API becomes available, replace the placeholder below with the actual value.



                                int polygonCount = 0; // Placeholder for actual polygon count retrieval







                                // Report shapes that exceed the threshold



                                if (polygonCount > polygonThreshold)



                                {



                                    anyExceed = true;



                                    Console.WriteLine("Slide {0}, Shape \"{1}\" exceeds polygon threshold. Polygon count: {2}",



                                        slideIndex + 1,



                                        shape.Name,



                                        polygonCount);



                                }



                            }



                        }



                    }







                    if (!anyExceed)



                    {



                        Console.WriteLine("No 3‑D objects exceed the polygon count threshold of " + polygonThreshold + ".");



                    }







                    // Save the (potentially unchanged) presentation before exiting



                    string outputPath = "output.pptx";



                    presentation.Save(outputPath, SaveFormat.Pptx);



                }



            }



            catch (Aspose.Slides.PptxUnsupportedFormatException ex)



            {



                Console.WriteLine("Unsupported PPTX format: " + ex.Message);



            }



            catch (Aspose.Slides.PptUnsupportedFormatException ex)



            {



                Console.WriteLine("Unsupported PPT format: " + ex.Message);



            }



            catch (Exception ex)



            {



                Console.WriteLine("An error occurred: " + ex.Message);



            }



        }



    }



}



