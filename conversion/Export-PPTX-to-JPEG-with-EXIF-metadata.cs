using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Check for input argument
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: program <presentation-file>");
            return;
        }

        string sourcePath = args[0];

        // Verify that the source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("File does not exist: " + sourcePath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Export each slide to JPEG with EXIF metadata
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    Aspose.Slides.IImage image = slide.GetImage();

                    string outputFile = $"slide_{i + 1}.jpg";

                    // Save slide as JPEG
                    image.Save(outputFile, Aspose.Slides.ImageFormat.Jpeg);

                    // Insert EXIF metadata (timestamp and source file name)
                    try
                    {
                        Image sysImage = Image.FromFile(outputFile);

                        // DateTimeOriginal (0x9003)
                        PropertyItem dateProp = sysImage.PropertyItems[0];
                        dateProp.Id = 0x9003;
                        dateProp.Type = 2; // ASCII
                        string dateValue = DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss");
                        dateProp.Value = Encoding.ASCII.GetBytes(dateValue + '\0');
                        dateProp.Len = dateProp.Value.Length;
                        sysImage.SetPropertyItem(dateProp);

                        // ImageDescription (0x010E) – store source file name
                        PropertyItem descProp = sysImage.PropertyItems[0];
                        descProp.Id = 0x010E;
                        descProp.Type = 2; // ASCII
                        string descValue = sourcePath;
                        descProp.Value = Encoding.ASCII.GetBytes(descValue + '\0');
                        descProp.Len = descProp.Value.Length;
                        sysImage.SetPropertyItem(descProp);

                        // Overwrite the JPEG with updated EXIF data
                        sysImage.Save(outputFile, ImageFormat.Jpeg);
                        sysImage.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("EXIF insertion failed for " + outputFile + ": " + ex.Message);
                    }
                }

                // Save the presentation before exiting (optional)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported – comment as required
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}