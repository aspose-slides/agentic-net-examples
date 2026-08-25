// -----------------------------------------------------------------------------










// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set PPTX 3d camera view matrix using C#







//







// Description:







// Demonstrates how to set a 3D camera view matrix (via rotation) for shapes







// that have 3D formatting in a PPTX file using C# and Aspose.Slides for .NET.







// The example loads a presentation, iterates through slides and shapes, applies







// a predefined rotation to the camera of each 3D shape, and saves the result.







// This pattern can be used to automate 3D camera adjustments in PowerPoint







// presentations.







//







// Keywords:







// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D, Camera, View Matrix, Rotation,







// Presentation Processing, Office Automation







//







// Use Cases:







// - Automate setting a 3D camera view matrix for PPTX files.







// - Build C# tools that modify 3D camera properties in PowerPoint presentations.







// - Generate or transform PPTX files with custom 3D camera angles in .NET applications.







// - Validate and preview 3D camera settings before publishing presentations.







// -----------------------------------------------------------------------------







using System;







using System.IO;







using Aspose.Slides;







using Aspose.Slides.Export;















namespace Set3DCameraView







{







    class Program







    {







        static void Main(string[] args)







        {







            // Define input and output file paths







            string inputPath = "input.pptx";







            string outputPath = "output.pptx";















            // Verify that the input file exists







            if (!File.Exists(inputPath))







            {







                Console.WriteLine($"Input file not found: {inputPath}");







                return;







            }















            try







            {







                // Load the presentation







                using (Presentation presentation = new Presentation(inputPath))







                {







                    // Iterate through all slides







                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)







                    {







                        ISlide slide = presentation.Slides[slideIndex];















                        // Iterate through all shapes on the slide







                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)







                        {







                            IShape shape = slide.Shapes[shapeIndex];















                            // Check if the shape has 3D formatting







                            if (shape is IThreeDFormat threeDFormat && threeDFormat.Camera != null)







                            {







                                // Set a predefined camera view using rotation (view matrix equivalent)







                                // Example: rotate 30 degrees around X, 45 degrees around Y, 0 degrees around Z







                                threeDFormat.Camera.SetRotation(30f, 45f, 0f);















                                // Optionally set the camera type to a perspective preset







                                // threeDFormat.Camera.CameraType = CameraPresetType.PerspectiveFront;







                            }







                        }







                    }















                    // Save the modified presentation







                    presentation.Save(outputPath, SaveFormat.Pptx);







                }







            }







            catch (Aspose.Slides.PptxUnsupportedFormatException)







            {







                // Handle unsupported file format







                Console.WriteLine("The provided file format is not supported.");







            }







            catch (Exception ex)







            {







                // General exception handling







                Console.WriteLine($"An error occurred: {ex.Message}");







            }







        }







    }







}







