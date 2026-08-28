// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate JPG dimensions after conversion using C#

//

// Description:

// Demonstrates how to convert each slide of a PowerPoint presentation to JPEG

// images with specific dimensions and validate the resulting image sizes using

// Aspose.Slides for .NET. The example loads a PPTX, generates JPEGs at the

// desired width and height, checks the dimensions of each saved image, and

// saves the presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPG, Validate, Dimensions, 

// After, Conversion, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate validation of JPEG dimensions after slide conversion.

// - Build C# tools for exporting PowerPoint slides to images with exact size.

// - Ensure consistent image output in .NET presentation processing workflows.

// - Validate presentation export results before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ValidateJpgDimensions

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation path

            string inputPath = "input.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Desired output dimensions in pixels

                    int desiredWidth = 1200;

                    int desiredHeight = 800;



                    // Calculate scaling factors based on slide size (points)

                    float scaleX = (float)desiredWidth / pres.SlideSize.Size.Width;

                    float scaleY = (float)desiredHeight / pres.SlideSize.Size.Height;



                    // Process each slide

                    for (int i = 0; i < pres.Slides.Count; i++)

                    {

                        ISlide slide = pres.Slides[i];



                        // Generate JPEG image with custom scaling

                        IImage bmp = slide.GetImage(scaleX, scaleY);

                        string jpgPath = $"Slide_{i + 1}.jpg";

                        bmp.Save(jpgPath, Aspose.Slides.ImageFormat.Jpeg);



                        // Validate dimensions of the saved JPEG

                        using (Image img = Image.FromFile(jpgPath))

                        {

                            int actualWidth = img.Width;

                            int actualHeight = img.Height;



                            if (actualWidth != desiredWidth || actualHeight != desiredHeight)

                            {

                                Console.WriteLine($"Dimension mismatch in {jpgPath}: Expected {desiredWidth}x{desiredHeight}, Got {actualWidth}x{actualHeight}");

                            }

                            else

                            {

                                Console.WriteLine($"{jpgPath} dimensions are as expected.");

                            }

                        }

                    }



                    // Save the presentation before exiting

                    pres.Save("output.pptx", SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: The provided file format is not supported by Aspose.Slides.

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URLs or web services)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

