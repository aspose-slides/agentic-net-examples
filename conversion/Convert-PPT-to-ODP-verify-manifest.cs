using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input PPT path
        string inputPath;
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            inputPath = args[0];
        }
        else
        {
            inputPath = "input.pptx"; // default input file
        }

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Define output ODP path
        string outputDir = Path.GetDirectoryName(inputPath);
        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
        string odpPath = Path.Combine(outputDir, fileNameWithoutExt + ".odp");

        try
        {
            // Load presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Save as ODP
                pres.Save(odpPath, SaveFormat.Odp);
            }

            // Extract manifest from ODP (zip archive)
            string manifestPath = Path.Combine(outputDir, "manifest.xml");
            using (FileStream odpStream = new FileStream(odpPath, FileMode.Open, FileAccess.Read))
            using (ZipArchive archive = new ZipArchive(odpStream, ZipArchiveMode.Read))
            {
                ZipArchiveEntry manifestEntry = archive.GetEntry("META-INF/manifest.xml");
                if (manifestEntry != null)
                {
                    using (Stream manifestStream = manifestEntry.Open())
                    using (FileStream outStream = new FileStream(manifestPath, FileMode.Create, FileAccess.Write))
                    {
                        manifestStream.CopyTo(outStream);
                    }
                    Console.WriteLine("Manifest extracted to: " + manifestPath);
                }
                else
                {
                    Console.WriteLine("Manifest not found in ODP package.");
                }

                // Verify inclusion of media assets (e.g., images) in the package
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.StartsWith("Pictures/"))
                    {
                        Console.WriteLine("Media asset found: " + entry.FullName);
                    }
                }
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The provided format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}