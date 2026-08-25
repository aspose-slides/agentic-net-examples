// -----------------------------------------------------------------------------










// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Handle PPTX 3d corrupted data exception using C#







//







// Description:







// Demonstrates how to detect and handle a corrupted 3D data exception in a PPTX







// file using C# and Aspose.Slides for .NET. The example loads a presentation,







// optionally processes it, and saves the result while catching specific







// Aspose.Slides exceptions for corrupted files and unsupported formats.







// This pattern helps developers build robust PowerPoint automation tools.







//







// Keywords:







// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Handle, Pptx, Corrupted, Data,







// Presentation Processing, Office Automation







//







// Use Cases:







// - Automate handling of PPTX files that may contain corrupted 3D data.







// - Build C# utilities for safe PowerPoint presentation processing.







// - Generate or transform PPTX files while gracefully handling format issues.







// - Validate and log presentation integrity before further integration.







// -----------------------------------------------------------------------------















using System;







using System.IO;







using Aspose.Slides;







using Aspose.Slides.Export;















namespace AsposeSlidesExample







{







    class Program







    {







        static void Main(string[] args)







        {







            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");







            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");















            if (!File.Exists(inputPath))







            {







                Console.WriteLine("Input file does not exist.");







                return;







            }















            try







            {







                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);







                // Perform any required processing here















                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);







                presentation.Dispose();







            }







            catch (Aspose.Slides.PptCorruptFileException ex)







            {







                Console.WriteLine("The presentation file is corrupted: " + ex.Message);







            }







            catch (Aspose.Slides.PptUnsupportedFormatException ex)







            {







                // Format not supported







                Console.WriteLine("Unsupported presentation format: " + ex.Message);







            }







            catch (Exception ex)







            {







                Console.WriteLine("An error occurred: " + ex.Message);







            }







        }







    }







}







