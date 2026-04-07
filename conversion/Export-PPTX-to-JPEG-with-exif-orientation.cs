using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlidesToJpegWithExif
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputDir = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Create output directory if needed
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Load presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Export each slide as JPEG with EXIF orientation tag
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        ISlide slide = pres.Slides[i];
                        // Render slide to image (full scale)
                        IImage slideImage = slide.GetImage(1f, 1f);
                        string jpegPath = Path.Combine(outputDir, "slide_" + (i + 1) + ".jpg");

                        // Save as JPEG
                        slideImage.Save(jpegPath, ImageFormat.Jpeg);
                        slideImage.Dispose();

                        // Embed EXIF orientation (value 1 = normal)
                        using (System.Drawing.Image sysImg = System.Drawing.Image.FromFile(jpegPath))
                        {
                            const int orientationId = 274; // Exif tag for orientation
                            bool hasOrientation = false;
                            foreach (int id in sysImg.PropertyIdList)
                            {
                                if (id == orientationId)
                                {
                                    hasOrientation = true;
                                    break;
                                }
                            }

                            if (!hasOrientation)
                            {
                                // Create a PropertyItem for orientation
                                System.Drawing.Imaging.PropertyItem prop = (System.Drawing.Imaging.PropertyItem)Activator.CreateInstance(typeof(System.Drawing.Imaging.PropertyItem));
                                prop.Id = orientationId;
                                prop.Type = 3; // SHORT
                                prop.Len = 2;
                                prop.Value = new byte[] { 1, 0 }; // Normal orientation
                                sysImg.SetPropertyItem(prop);
                            }

                            // Overwrite the JPEG with the EXIF tag
                            sysImg.Save(jpegPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                    }

                    // Save the (unchanged) presentation before exiting
                    string savedPresentationPath = Path.Combine(outputDir, "presentation_saved.pptx");
                    pres.Save(savedPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., network, I/O)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}