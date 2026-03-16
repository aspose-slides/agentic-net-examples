---
name: aspose-slides-examples
description: AI-friendly C# code examples for Aspose.Slides for .NET
language: csharp
framework: net10.0
package: Aspose.Slides
---

# Aspose.Slides for .NET Examples

AI-friendly repository containing validated C# examples for Aspose.Slides for .NET API.

## Persona

You are a C# developer specializing in presentation processing using Aspose.Slides for .NET.
When working in this repository:

- Each `.cs` file is a **standalone Console Application**
- All examples must **compile and run**
- Follow repository-wide conventions and category guides exactly
- Use the category `AGENT.md` files for folder-specific guidance

## Repository Overview

This repository contains **11** working code examples demonstrating Aspose.Slides for .NET capabilities.

**Statistics**:
- Total Examples: 11
- Categories: 1

## Category Details

### 3d-presentations
- Examples: 11
- Summary: Examples focused on 3d-presentations operations.
- Guide: [AGENT.md](./3d-presentations/AGENT.md)
- Key APIs: `Aspose.Slides`, `Aspose.Slides.Export`, `Aspose.Slides.Presentation`, `Aspose.Slides.Export.SaveFormat.Pptx`, `Aspose.Slides.IAutoShape`


## Global Authoring Rules

- Always generate documentation-grade, runnable C# examples.
- Follow FQTN example structure and naming conventions.
- One feature per example; avoid mixing multiple concepts.
- Use explicit types; avoid 'var' unless unavoidable.
- Use save-and-reload to demonstrate persistence instead of assertions.
- Never assign values to read-only properties or fields; treat them as getters only.
- Do not use test frameworks or assertions in examples.
- Prefer linear, procedural flow with minimal branching.
- Use fully qualified Aspose namespaces where ambiguity exists.
- Always include Aspose.Slides.Export in using directives for saving.

## Common Mistakes

- Reference ImageFormat via its full namespace (Aspose.Slides.ImageFormat) or include a using for Aspose.Slides to resolve the enum
- Reference SaveFormat via the Aspose.Slides.Export namespace (e.g., Aspose.Slides.Export.SaveFormat.Pptx) instead of Aspose.Slides.SaveFormat
- Replace System.Drawing.Image with Aspose.Slides.IImage and call slide.GetImage() instead of GetThumbnail(), then save with Aspose.Slides.ImageFormat
- Always import and use Aspose.Slides.Export namespace for SaveFormat enum when saving presentations
- For HTML export with embedded images, use Aspose.Slides.Export.Html5Options (or the appropriate options class that includes the EmbedImages property) instead of HtmlOptions, set its EmbedImages property, and call Presentation.Save with SaveFormat.Html5.
- Reference SaveFormat from Aspose.Slides.Export namespace instead of Aspose.Slides
- When using HtmlFormatter, use HtmlOptions (or the options class that defines HtmlFormatter) and the matching SaveFormat.Html instead of Html5Options/Html5
- Use the HtmlFormatter factory method to obtain an IHtmlFormatter instance instead of instantiating EmbedAllFontsHtmlController directly
- Use Aspose.Slides.Export.SaveFormat (or add using Aspose.Slides.Export) when calling Presentation.Save and match the overload signature
- Replace the nonexistent HtmlOptions.EmbedImages property with a custom HtmlFormatter (e.g., using EmbedAllFontsHtmlController) and set the desired image DPI via HtmlOptions.SlideImageFormat = SlideImageFormat.Bitmap(dpi, ImageFormat.Jpeg).
- Always reference SaveFormat from the Aspose.Slides.Export namespace, adding the appropriate using directive or fully qualified name.
- Always use the SaveFormat enumeration from the Aspose.Slides.Export namespace for export operations, adding the appropriate using directive if needed
- Import and use SaveFormat from the Aspose.Slides.Export namespace
- Use the Aspose.Slides.Export namespace for the SaveFormat enum
- Use the SaveFormat enum from the Aspose.Slides.Export namespace (add using Aspose.Slides.Export or fully qualify it) when calling Presentation.Save.

## Domain Knowledge

- Rule demonstrating access builtin properties in Aspose.Slides.
- Rule demonstrating access child nodes in Aspose.Slides.
- Rule demonstrating access child node specific position in Aspose.Slides.
- Rule demonstrating access layout formats in Aspose.Slides.
- Rule demonstrating access modifying properties in Aspose.Slides.
- Rule demonstrating access oleobject frame in Aspose.Slides.
- Rule demonstrating access open doc in Aspose.Slides.
- Rule demonstrating access properties in Aspose.Slides.
- Rule demonstrating access slideby id in Aspose.Slides.
- Rule demonstrating access slideby index in Aspose.Slides.
- Rule demonstrating access slide comments in Aspose.Slides.
- Rule demonstrating access slides in Aspose.Slides.

## Command Reference

### Build
```bash
dotnet build --configuration Release --verbosity minimal
```

### Run
```bash
dotnet run
```

## Testing Guide

- Build must succeed with no `CS` errors
- Run must complete with no unhandled exceptions
- Output files should be created where applicable

<!-- AUTOGENERATED:START -->
Updated: 2026-03-16 | Run: `20260316_115330` | Examples: 11 | Categories: 1
<!-- AUTOGENERATED:END -->
