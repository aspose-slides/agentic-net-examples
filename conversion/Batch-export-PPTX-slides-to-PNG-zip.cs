// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch export PPTX slides to PNG zip using C#

//

// Description:

// Demonstrates how to batch export PPTX slides to PNG images packaged in a zip

// archive using C# and Aspose.Slides for .NET. The example iterates through all

// PPTX files in a specified input folder, converts each slide to a PNG image,

// and stores the images in a single ZIP file. This pattern can be used to

// automate slide extraction, create image archives for presentations, or

// integrate slide processing into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Zip, Batch, Export, Slides,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of PPTX slides to PNG images.

// - Package slide images into a ZIP archive for distribution or storage.

// - Build .NET tools for PowerPoint slide extraction and archiving.

// - Integrate slide-to-image conversion into larger document processing pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.IO.Compression;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchExport

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputFolder = "InputPptx";

            string outputZipPath = "SlidesOutput.zip";



            if (!Directory.Exists(inputFolder))

            {

                Console.WriteLine("Input folder does not exist: " + inputFolder);

                return;

            }



            try

            {

                using (FileStream zipFileStream = new FileStream(outputZipPath, FileMode.Create))

                {

                    using (ZipArchive archive = new ZipArchive(zipFileStream, ZipArchiveMode.Update))

                    {

                        string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");

                        foreach (string pptxFile in pptxFiles)

                        {

                            using (Presentation pres = new Presentation(pptxFile))

                            {

                                for (int i = 0; i < pres.Slides.Count; i++)

                                {

                                    ISlide slide = pres.Slides[i];

                                    string entryName = Path.GetFileNameWithoutExtension(pptxFile) + "_slide_" + (i + 1) + ".png";

                                    ZipArchiveEntry entry = archive.CreateEntry(entryName);

                                    using (Stream entryStream = entry.Open())

                                    {

                                        using (IImage image = slide.GetImage())

                                        {

                                            image.Save(entryStream, Aspose.Slides.ImageFormat.Png);

                                        }

                                    }

                                }



                                // Save presentation (no modifications) to satisfy lifecycle rule

                                pres.Save(pptxFile, SaveFormat.Pptx);

                            }

                        }

                    }

                }

            }

            catch (PptxUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("One of the files has an unsupported format.");

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}

