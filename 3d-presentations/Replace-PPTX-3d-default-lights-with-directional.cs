// -----------------------------------------------------------------------------










// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Replace PPTX 3d default lights with directional using C#







//







// Description:







// Demonstrates how to replace the default 3D lighting of shapes in a PPTX







// presentation with a single directional light using C# and Aspose.Slides for .NET.







// The example loads a presentation, iterates through all shapes on each slide,







// modifies the ThreeDFormat lighting settings, and saves the updated file.







// This pattern can be used to automate lighting adjustments in PowerPoint files.







//







// Keywords:







// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, 3D Lights, Directional Light,







// Presentation Processing, Office Automation







//







// Use Cases:







// - Automate replacement of default 3D lights with a directional light in PPTX files.







// - Build C# utilities for PowerPoint presentation processing and styling.







// - Generate or transform PPTX files with customized 3D lighting in .NET applications.







// - Validate and standardize presentation lighting before publishing or integration.







// -----------------------------------------------------------------------------







using System;







using System.IO;







using Aspose.Slides;







using Aspose.Slides.Export;















namespace Replace3DLights







{







    class Program







    {







        static void Main(string[] args)







        {







            string inputPath;







            if (args.Length > 0)







            {







                inputPath = args[0];







            }







            else







            {







                inputPath = "input.pptx";







            }















            if (!File.Exists(inputPath))







            {







                Console.WriteLine("Input file does not exist: " + inputPath);







                return;







            }















            try







            {







                using (Presentation pres = new Presentation(inputPath))







                {







                    int slideCount = pres.Slides.Count;







                    for (int i = 0; i < slideCount; i++)







                    {







                        IShape[] shapes = pres.Slides[i].Shapes.ToArray();







                        foreach (IShape shape in shapes)







                        {







                            // Check if shape has 3D format







                            if (shape.ThreeDFormat != null)







                            {







                                // Set a single directional light source







                                shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;







                                shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;







                            }







                        }







                    }















                    string outputPath = "output.pptx";







                    pres.Save(outputPath, SaveFormat.Pptx);







                    Console.WriteLine("Presentation saved to: " + outputPath);







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







