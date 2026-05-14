using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CompareSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation paths
            string presentationPath1 = "Presentation1.pptx";
            string presentationPath2 = "Presentation2.pptx";

            // Verify that input files exist
            if (!File.Exists(presentationPath1))
            {
                Console.WriteLine("File not found: " + presentationPath1);
                return;
            }

            if (!File.Exists(presentationPath2))
            {
                Console.WriteLine("File not found: " + presentationPath2);
                return;
            }

            // Output presentation that will contain side‑by‑side comparison slides
            string outputPath = "ComparisonSlides.pptx";

            try
            {
                // Load the two source presentations
                using (Presentation pres1 = new Presentation(presentationPath1))
                using (Presentation pres2 = new Presentation(presentationPath2))
                using (Presentation resultPres = new Presentation())
                {
                    // Iterate through slides of both presentations and find matching slides
                    for (int i = 0; i < pres1.Slides.Count; i++)
                    {
                        for (int j = 0; j < pres2.Slides.Count; j++)
                        {
                            // Use BaseSlide.Equals to compare slide content
                            if (pres1.Slides[i].Equals(pres2.Slides[j]))
                            {
                                // Generate images for the matching slides
                                using (IImage image1 = pres1.Slides[i].GetImage())
                                using (IImage image2 = pres2.Slides[j].GetImage())
                                {
                                    // Add images to the result presentation's image collection
                                    IPPImage imgRef1 = resultPres.Images.AddImage(image1);
                                    IPPImage imgRef2 = resultPres.Images.AddImage(image2);

                                    // Create a new blank slide in the result presentation
                                    ISlide blankSlide = resultPres.Slides.AddEmptySlide(resultPres.LayoutSlides.GetByType(SlideLayoutType.Blank));

                                    // Add first picture frame on the left
                                    IPictureFrame pictureFrame1 = blankSlide.Shapes.AddPictureFrame(
                                        ShapeType.Rectangle,
                                        0,
                                        0,
                                        imgRef1.Width,
                                        imgRef1.Height,
                                        imgRef1);

                                    // Add second picture frame on the right (placed after the first image width)
                                    IPictureFrame pictureFrame2 = blankSlide.Shapes.AddPictureFrame(
                                        ShapeType.Rectangle,
                                        imgRef1.Width,
                                        0,
                                        imgRef2.Width,
                                        imgRef2.Height,
                                        imgRef2);

                                    // Optional: add a thin border between the two images
                                    pictureFrame2.LineFormat.Width = 1;
                                    pictureFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
                                    pictureFrame2.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
                                }
                            }
                        }
                    }

                    // Save the result presentation
                    resultPres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("One of the input files has an unsupported format.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}