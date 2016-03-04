// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Textamina.Markdig.Parsers;

namespace Textamina.Markdig.Syntax.Inlines
{
    /// <summary>
    /// A delimiter for a link.
    /// </summary>
    /// <seealso cref="Textamina.Markdig.Syntax.Inlines.DelimiterInline" />
    public class LinkDelimiterInline : DelimiterInline
    {
        public LinkDelimiterInline(InlineParser parser) : base(parser)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether this delimiter is an image link.
        /// </summary>
        public bool IsImage { get; set; }

        /// <summary>
        /// Gets or sets the label of this link.
        /// </summary>
        public string Label { get; set; }

        public override string ToLiteral()
        {
            return IsImage ? "![" : "[";
        }
    }
}