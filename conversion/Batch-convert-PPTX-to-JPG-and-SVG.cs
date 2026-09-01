// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert PPTX to JPG and SVG using C#

//

// Description:

// Demonstrates how to batch convert all PPTX files in a specified folder to

// individual slide images in JPEG and SVG formats using Aspose.Slides for .NET.

// The console application accepts an optional input folder argument, creates

// separate output subfolders for JPG and SVG files, and processes each slide

// of each presentation. This pattern can be used to automate image extraction

// from PowerPoint decks in .NET environments.

//

// Keywords:

// C#, .NET, Console, PowerPoint, PPTX, Aspose.Slides, JPEG, JPG, SVG, Batch,

// Image Export, Slide Rendering, File I/O, Presentation Processing

//

// Use Cases:

// - Extract slide images from multiple PPTX files for web publishing or documentation.

// - Generate SVG representations of slides for scalable graphics workflows.

// - Build automated pipelines that convert PowerPoint content to image assets.

// - Integrate slide-to-image conversion into CI/CD or reporting tools.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputFolder;

        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))

        {

            inputFolder = args[0];

        }

        else

        {

            inputFolder = "InputPptx";

        }



        if (!Directory.Exists(inputFolder))

        {

            Console.WriteLine("Input folder does not exist: " + inputFolder);

            return;

        }



        string jpgOutputFolder = Path.Combine(inputFolder, "Jpg");

        string svgOutputFolder = Path.Combine(inputFolder, "Svg");

        Directory.CreateDirectory(jpgOutputFolder);

        Directory.CreateDirectory(svgOutputFolder);



        string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");

        foreach (string pptxPath in pptxFiles)

        {

            try

            {

                Presentation pres = new Presentation(pptxPath);

                for (int i = 0; i < pres.Slides.Count; i++)

                {

                    ISlide slide = pres.Slides[i];



                    // Export slide as JPG

                    using (IImage image = slide.GetImage())

                    {

                        string jpgPath = Path.Combine(jpgOutputFolder, Path.GetFileNameWithoutExtension(pptxPath) + "_slide_" + i + ".jpg");

                        image.Save(jpgPath, Aspose.Slides.ImageFormat.Jpeg);

                    }



                    // Export slide as SVG

                    string svgPath = Path.Combine(svgOutputFolder, Path.GetFileNameWithoutExtension(pptxPath) + "_slide_" + i + ".svg");

                    using (FileStream svgStream = new FileStream(svgPath, FileMode.Create, FileAccess.Write))

                    {

                        slide.WriteAsSvg(svgStream);

                    }

                }



                // Save presentation (no changes) before exiting

                pres.Save(pptxPath, SaveFormat.Pptx);

                pres.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("File format not supported: " + pptxPath);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error processing file " + pptxPath + ": " + ex.Message);

            }

        }

    }

}

