using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path
        string inputPath;
        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
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

        // Define output ODP file path
        string outputPath = Path.ChangeExtension(inputPath, ".odp");

        // Load presentation and convert to ODP
        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                pres.Save(outputPath, SaveFormat.Odp);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The format is not supported for conversion.");
            return;
        }

        // Extract manifest.xml from the ODP package
        try
        {
            using (FileStream fs = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
            {
                using (ZipArchive archive = new ZipArchive(fs, ZipArchiveMode.Read))
                {
                    ZipArchiveEntry manifestEntry = archive.GetEntry("META-INF/manifest.xml");
                    if (manifestEntry != null)
                    {
                        using (Stream manifestStream = manifestEntry.Open())
                        {
                            using (StreamReader reader = new StreamReader(manifestStream))
                            {
                                string manifestContent = reader.ReadToEnd();
                                Console.WriteLine("Manifest content:");
                                Console.WriteLine(manifestContent);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Manifest file not found in ODP.");
                    }

                    // List media assets (files under Pictures/)
                    Console.WriteLine("Media assets in ODP:");
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName.StartsWith("Pictures/"))
                        {
                            Console.WriteLine(entry.FullName);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error extracting manifest: " + ex.Message);
        }
    }
}