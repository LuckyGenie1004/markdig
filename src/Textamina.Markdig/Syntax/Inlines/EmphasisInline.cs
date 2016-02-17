using Textamina.Markdig.Parsing;

namespace Textamina.Markdig.Syntax
{
    public class EmphasisInline : ContainerInline
    {
        public static readonly InlineParser Parser = new ParserInternal();

        public char EscapedChar;

        private class ParserInternal : InlineParser
        {
            public ParserInternal()
            {
                FirstChars = new[] { '*', '_' };
            }

            public override bool Match(ref MatchInlineState state)
            {
                var lines = state.Lines;

                // Go to escape character
                lines.NextChar();
                if (Utility.IsASCIIPunctuation(lines.Current))
                {
                    state.Inline = new EscapeInline() { EscapedChar = lines.Current };
                    lines.NextChar();
                    return true;
                }
                return false;
            }
        }
    }
}