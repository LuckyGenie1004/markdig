﻿using Textamina.Markdig.Helpers;
using Textamina.Markdig.Parsing;

namespace Textamina.Markdig.Syntax
{
    /// <summary>
    /// Repressents a thematic break.
    /// </summary>
    public class BreakBlock : LeafBlock
    {
        public new static readonly BlockParser Parser = new ParserInternal();

        public BreakBlock(BlockParser parser) : base(parser)
        {
            NoInline = true;
        }

        private class ParserInternal : BlockParser
        {
            public override MatchLineResult Match(BlockParserState state)
            {
                var liner = state.Line;
                liner.SkipLeadingSpaces3();

                var column = liner.Start;

                // 4.1 Thematic breaks 
                // A line consisting of 0-3 spaces of indentation, followed by a sequence of three or more matching -, _, or * characters, each followed optionally by any number of spaces
                var c = liner.Current;

                int count = 0;
                var matchChar = (char)0;
                bool hasSpacesSinceLastMatch = false;
                bool hasInnerSpaces = false;
                while (!liner.IsEol)
                {
                    if (count == 0 && (c == '-' || c == '_' || c == '*'))
                    {
                        matchChar = c;
                        count++;
                    }
                    else if (c == matchChar)
                    {
                        if (hasSpacesSinceLastMatch)
                        {
                            hasInnerSpaces = true;
                        }

                        count++;
                    }
                    else if (!c.IsSpace() || count == 0)
                    {
                        return MatchLineResult.None;
                    }
                    else if (c.IsSpace())
                    {
                        hasSpacesSinceLastMatch = true;
                    }
                    c = liner.NextChar();
                }

                // If it as less than 3 chars or it is a setex heading and we are already in a paragraph, let the paragraph handle it
                var previousParagraph = state.LastBlock as ParagraphBlock;

                var isSetexHeading = previousParagraph != null && matchChar == '-' && !hasInnerSpaces;
                if (isSetexHeading)
                {
                    var parent = previousParagraph.Parent;
                    if (parent is QuoteBlock || (parent is ListItemBlock && previousParagraph.Column != column))
                    {
                        isSetexHeading = false;
                    }
                }

                if (count < 3 || isSetexHeading)
                {
                    return MatchLineResult.None;
                }

                state.NewBlocks.Push(new BreakBlock(this) { Column = column });
                return MatchLineResult.Last;
            }
        }
    }
}