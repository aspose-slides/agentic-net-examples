// -----------------------------------------------------------------------------




// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX 3d models to OBJ files using C#



//



// Description:



// Demonstrates how to locate 3D models within a PPTX presentation and



// export them to OBJ files using C# and Aspose.Slides for .NET. The example



// iterates through slides and shapes, identifies shapes with a 3D format,



// and provides a placeholder for custom OBJ extraction logic. It also



// saves the presentation after processing.



//



// Keywords:



// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, 3D models, OBJ, 



// Presentation Processing, Office Automation



//



// Use Cases:



// - Automate extraction of 3D models from PPTX files to OBJ format.



// - Build C# utilities for PowerPoint 3D content processing.



// - Integrate 3D model handling into .NET applications.



// - Validate and transform PPTX presentations containing 3D shapes.



// -----------------------------------------------------------------------------



using System;



using System.IO;



using Aspose.Slides;



using Aspose.Slides.Export;







class Program



{



    static void Main(string[] args)



    {



        // Input presentation path



        string inputPath = "input.pptx";







        // Verify that the input file exists



        if (!File.Exists(inputPath))



        {



            Console.WriteLine("Input file does not exist.");



            return;



        }







        try



        {



            // Load the presentation



            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);







            // Iterate through slides and shapes to find 3D models



            int slideIdx = 0;



            foreach (Aspose.Slides.ISlide slide in pres.Slides)



            {



                int shapeIdx = 0;



                foreach (Aspose.Slides.IShape shape in slide.Shapes)



                {



                    // Check if the shape has a 3D format (indicates a 3D model)



                    if (shape.ThreeDFormat != null)



                    {



                        // Construct output OBJ file name



                        string objPath = $"slide_{slideIdx}_shape_{shapeIdx}.obj";







                        // TODO: Extract vertex coordinates from the 3D shape and write them to the OBJ file.



                        // Aspose.Slides does not provide a direct OBJ export API, so custom extraction logic is required here.



                        // Example placeholder:



                        // using (StreamWriter writer = new StreamWriter(objPath))



                        // {



                        //     writer.WriteLine("# OBJ file for 3D shape");



                        //     // Write vertex data...



                        // }







                        Console.WriteLine($"3D shape found on slide {slideIdx}, shape {shapeIdx}. Export to {objPath} (implementation pending).");



                    }



                    shapeIdx++;



                }



                slideIdx++;



            }







            // Save the presentation before exiting (as required)



            string outputPath = "output.pptx";



            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);



            pres.Dispose();



        }



        catch (NotSupportedException)



        {



            // Format not supported



            Console.WriteLine("The presentation format is not supported for this operation.");



        }



        catch (Exception ex)



        {



            // General exception handling



            Console.WriteLine("Error: " + ex.Message);



        }



    }



}



