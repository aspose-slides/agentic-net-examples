// -----------------------------------------------------------------------------










// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Check PPTX 3D shapes have names using C#







//







// Description:







// Demonstrates how to verify that all 3‑D shapes in a PPTX file have non‑empty







// names using C# and Aspose.Slides for .NET. The example iterates through each







// slide and shape, assigns a default name to any 3‑D shape lacking one, and







// saves the validated presentation. This pattern can be used to ensure proper







// naming of 3‑D objects before further processing or publishing.







//







// Keywords:







// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Check, Pptx, Shapes, Have, Names,







// 3D, Validation, Presentation Processing, Office Automation







//







// Use Cases:







// - Validate that 3‑D shapes in a presentation have names.







// - Automatically assign default names to unnamed 3‑D shapes.







// - Prepare PPTX files for downstream automation or publishing.







// - Integrate shape‑name validation into .NET PowerPoint processing tools.







// -----------------------------------------------------------------------------







using System;







using System.IO;







using Aspose.Slides;







using Aspose.Slides.Export;















namespace Validate3DShapeNames







{







    class Program







    {







        static void Main()







        {







            // Input and output file paths







            string inputPath = "input.pptx";







            string outputPath = "output_validated.pptx";















            // Verify that the input file exists







            if (!File.Exists(inputPath))







            {







                Console.WriteLine("Input file does not exist.");







                return;







            }















            // Load the presentation







            Presentation presentation = null;







            try







            {







                presentation = new Presentation(inputPath);







            }







            catch (Exception ex)







            {







                // Handle unsupported format or loading errors







                Console.WriteLine("Failed to load presentation: " + ex.Message);







                // Format not supported







                return;







            }















            // Iterate through all slides and shapes







            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)







            {







                ISlide slide = presentation.Slides[slideIndex];







                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)







                {







                    IShape shape = slide.Shapes[shapeIndex];















                    // Check if the shape has 3‑D formatting







                    if (shape.ThreeDFormat != null)







                    {







                        // Validate that the shape name is not empty







                        if (string.IsNullOrEmpty(shape.Name))







                        {







                            Console.WriteLine($"3D shape on slide {slideIndex + 1}, index {shapeIndex} has an empty name. Assigning a default name.");







                            shape.Name = $"3DShape_{slideIndex + 1}_{shapeIndex}";







                        }







                    }







                }







            }















            // Save the presentation before exiting







            presentation.Save(outputPath, SaveFormat.Pptx);







            presentation.Dispose();







        }







    }







}







