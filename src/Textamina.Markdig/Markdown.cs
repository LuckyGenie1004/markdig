﻿// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using System;
using System.IO;
using Textamina.Markdig.Parsers;
using Textamina.Markdig.Renderers;
using Textamina.Markdig.Syntax;

namespace Textamina.Markdig
{
    /// <summary>
    /// Provides methods for parsing a Markdown string to a syntax tree and converting it to other formats.
    /// </summary>
    public class Markdown
    {
        /// <summary>
        /// Converts a Markdown string to HTML.
        /// </summary>
        /// <param name="markdown">A Markdown text.</param>
        /// <param name="pipeline">The pipeline used for the conversion.</param>
        /// <returns>The result of the conversion</returns>
        /// <exception cref="System.ArgumentNullException">if markdown variable is null</exception>
        public static string ToHtml(string markdown, MarkdownPipeline pipeline = null)
        {
            if (markdown == null) throw new ArgumentNullException(nameof(markdown));
            var reader = new StringReader(markdown);
            return ToHtml(reader, pipeline) ?? string.Empty;
        }

        /// <summary>
        /// Converts a Markdown string to HTML.
        /// </summary>
        /// <param name="reader">A Markdown text from a <see cref="TextReader"/>.</param>
        /// <param name="pipeline">The pipeline used for the conversion.</param>
        /// <returns>The result of the conversion</returns>
        /// <exception cref="System.ArgumentNullException">if markdown variable is null</exception>
        public static string ToHtml(TextReader reader, MarkdownPipeline pipeline = null)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            var writer = new StringWriter();
            ToHtml(reader, writer, pipeline);
            return writer.ToString();
        }

        /// <summary>
        /// Converts a Markdown string to HTML.
        /// </summary>
        /// <param name="reader">A Markdown text from a <see cref="TextReader"/>.</param>
        /// <param name="writer">The destination <see cref="TextWriter"/> that will receive the result of the conversion.</param>
        /// <param name="pipeline">The pipeline used for the conversion.</param>
        /// <exception cref="System.ArgumentNullException">if reader or writer variable are null</exception>
        public static void ToHtml(TextReader reader, TextWriter writer, MarkdownPipeline pipeline = null)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            if (writer == null) throw new ArgumentNullException(nameof(writer));
            pipeline = pipeline ?? new MarkdownPipeline();

            // We override the renderer with our own writer
            pipeline.Renderer = new HtmlRenderer(writer);

            var document = Parse(reader, pipeline);
            pipeline.Renderer.Render(document);
            writer.Flush();
        }

        /// <summary>
        /// Converts a Markdown string using a custom <see cref="IMarkdownRenderer"/> specified in the <see cref="MarkdownPipeline.Renderer"/>.
        /// </summary>
        /// <param name="reader">A Markdown text from a <see cref="TextReader"/>.</param>
        /// <param name="pipeline">The pipeline used for the conversion.</param>
        /// <exception cref="System.ArgumentNullException">if reader or writer variable are null</exception>
        public static object Convert(TextReader reader, MarkdownPipeline pipeline = null)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            pipeline = pipeline ?? new MarkdownPipeline();
            if (pipeline.Renderer == null)
            {
                throw new InvalidOperationException("The property MarkdownPipeline.Renderer cannot be null");
            }

            var document = Parse(reader, pipeline);
            return pipeline.Renderer.Render(document);
        }

        /// <summary>
        /// Parses the specified markdown into an AST <see cref="MarkdownDocument"/>
        /// </summary>
        /// <param name="markdown">The markdown text.</param>
        /// <returns>An AST Markdown document</returns>
        /// <exception cref="System.ArgumentNullException">if markdown variable is null</exception>
        public static MarkdownDocument Parse(string markdown)
        {
            if (markdown == null) throw new ArgumentNullException(nameof(markdown));
            return Parse(new StringReader(markdown), new MarkdownPipeline());
        }

        /// <summary>
        /// Parses the specified markdown into an AST <see cref="MarkdownDocument"/>
        /// </summary>
        /// <param name="reader">A Markdown text from a <see cref="TextReader"/>.</param>
        /// <param name="pipeline">The pipeline used for the parsing.</param>
        /// <returns>An AST Markdown document</returns>
        /// <exception cref="System.ArgumentNullException">if reader variable is null</exception>
        public static MarkdownDocument Parse(TextReader reader, MarkdownPipeline pipeline = null)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            pipeline = pipeline ?? new MarkdownPipeline();

            return MarkdownParser.Parse(reader, pipeline);
        }
    }
}