﻿// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Textamina.Markdig.Parsers.Inlines;
using Textamina.Markdig.Renderers;

namespace Textamina.Markdig.Extensions.Tables
{
    /// <summary>
    /// Extension that allows to use pipe tables.
    /// </summary>
    /// <seealso cref="Textamina.Markdig.IMarkdownExtension" />
    public class PipeTableExtension : IMarkdownExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PipeTableExtension"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public PipeTableExtension(PipeTableOptions options = null)
        {
            Options = options ?? new PipeTableOptions();
        }

        /// <summary>
        /// Gets the options.
        /// </summary>
        public PipeTableOptions Options { get; }

        public void Setup(MarkdownPipeline pipeline)
        {
            if (!pipeline.InlineParsers.Contains<PipeTableParser>())
            {
                pipeline.InlineParsers.InsertBefore<EmphasisInlineParser>(new PipeTableParser(Options));
            }

            var htmlRenderer = pipeline.Renderer as HtmlRenderer;
            if (htmlRenderer != null && !htmlRenderer.ObjectRenderers.Contains<HtmlTableRenderer>())
            {
                htmlRenderer.ObjectRenderers.Add(new HtmlTableRenderer());
            }
        }
    }
}