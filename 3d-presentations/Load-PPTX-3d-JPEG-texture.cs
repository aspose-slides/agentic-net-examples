// -----------------------------------------------------------------------------




// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load PPTX 3D JPEG texture using C#



//



// Description:



// Demonstrates how to load an existing PPTX file, add a JPEG image as a texture



// to a 3‑D rectangle shape, configure basic 3‑D material and extrusion settings,



// and save the modified presentation using Aspose.Slides for .NET. The example



// includes file existence checks and error handling suitable for console



// applications.



//



// Keywords:



// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Load, Texture, 3D, 



// Presentation Processing, Office Automation



//



// Use Cases:



// - Apply a JPEG texture to a 3‑D shape in an existing PowerPoint file.



// - Automate texture mapping for 3‑D objects in presentations.



// - Build .NET tools that modify PPTX files with custom 3‑D visual effects.



// - Validate and preview 3‑D texture integration before publishing.



// -----------------------------------------------------------------------------



using System;



using System.IO;



using Aspose.Slides;



using Aspose.Slides.Export;







namespace LoadPptx3dJpegTexture



{



    class Program



    {



        static void Main(string[] args)



        {



            // Paths to the source presentation and the JPEG texture image



            string presentationPath = "input.pptx";



            string textureImagePath = "texture.jpg";







            // Verify that the presentation file exists



            if (!File.Exists(presentationPath))



            {



                Console.WriteLine("Error: Presentation file not found: " + presentationPath);



                return;



            }







            // Verify that the texture image file exists



            if (!File.Exists(textureImagePath))



            {



                Console.WriteLine("Error: Texture image file not found: " + textureImagePath);



                return;



            }







            try



            {



                // Load the presentation



                using (Presentation presentation = new Presentation(presentationPath))



                {



                    // Add the JPEG image to the presentation's image collection



                    IPPImage textureImage;



                    using (FileStream imageStream = new FileStream(textureImagePath, FileMode.Open, FileAccess.Read))



                    {



                        textureImage = presentation.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);



                    }







                    // Add a rectangle shape that will act as the 3‑D object



                    IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);







                    // Apply a material preset (using a valid enum value)



                    shape.ThreeDFormat.Material = MaterialPresetType.Plastic;







                    // Set some 3‑D properties



                    shape.ThreeDFormat.Depth = 5.0;



                    shape.ThreeDFormat.ExtrusionHeight = 100.0;







                    // Apply the JPEG as a texture by setting the fill to picture type



                    shape.FillFormat.FillType = FillType.Picture;



                    shape.FillFormat.PictureFillFormat.Picture.Image = textureImage;







                    // Save the modified presentation



                    presentation.Save("output.pptx", SaveFormat.Pptx);



                }



            }



            catch (NotSupportedException)



            {



                // Format not supported



                // Comment: format not supported



                Console.WriteLine("Error: The file format is not supported.");



            }



            catch (Exception ex)



            {



                // General exception handling (e.g., external resource loading issues)



                Console.WriteLine("An error occurred: " + ex.Message);



            }



        }



    }



}



