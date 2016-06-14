// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Helpers;
using Markdig.Syntax.Inlines;

namespace Markdig.Parsers.Inlines
{
    /// <summary>
    /// An inline parser for parsing <see cref="AutolinkInline"/>.
    /// </summary>
    /// <seealso cref="Markdig.Parsers.InlineParser" />
    public class AutolineInlineParser : InlineParser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutolineInlineParser"/> class.
        /// </summary>
        public AutolineInlineParser()
        {
            OpeningCharacters = new[] {'<'};
            EnableHtmlParsing = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable HTML parsing. Default is <c>true</c>
        /// </summary>
        public bool EnableHtmlParsing { get; set; }

        public override bool Match(InlineProcessor processor, ref StringSlice slice)
        {
            string link;
            bool isEmail;
            var saved = slice;
            if (LinkHelper.TryParseAutolink(ref slice, out link, out isEmail))
            {
                processor.Inline = new AutolinkInline()
                {
                    IsEmail = isEmail,
                    Url = link,
                    SourceStartPosition = processor.GetSourcePosition(saved.Start),
                    SourceEndPosition = processor.GetSourcePosition(slice.Start - 1),
                };
            }
            else if (EnableHtmlParsing)
            {
                slice = saved;
                string htmlTag;
                if (!HtmlHelper.TryParseHtmlTag(ref slice, out htmlTag))
                {
                    return false;
                }

                processor.Inline = new HtmlInline()
                {
                    Tag = htmlTag,
                    SourceStartPosition = processor.GetSourcePosition(saved.Start),
                    SourceEndPosition = processor.GetSourcePosition(slice.Start - 1),
                };
            }

            return true;
        }
    }
}