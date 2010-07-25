using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MSBuildVersioning
{
    public delegate string TokenFunction();
    public delegate string TokenFunction<T>(T arg);

    public abstract class AbstractVersionTokenReplacer
    {
        private IList<Token> tokens;

        protected AbstractVersionTokenReplacer()
        {
            tokens = new List<Token>();
        }

        protected void AddToken(string tokenName, TokenFunction function)
        {
            tokens.Add(new NoArgsToken
            {
                tokenName = tokenName,
                function = function
            });
        }

        protected void AddToken(string tokenName, TokenFunction<int> function)
        {
            tokens.Add(new IntArgToken
            {
                tokenName = tokenName,
                function = function
            });
        }

        protected void AddToken(string tokenName, TokenFunction<string> function)
        {
            tokens.Add(new StringArgToken
            {
                tokenName = tokenName,
                function = function
            });
        }

        public virtual string Replace(string content)
        {
            foreach (Token token in tokens)
            {
                content = token.Replace(content);
            }
            return content;
        }

        private abstract class Token
        {
            public string tokenName;

            public abstract string Replace(string str);
        }

        private class NoArgsToken : Token
        {
            public TokenFunction function;

            public override string Replace(string str)
            {
                string token = "$" + tokenName + "$";
                if (str.Contains(token))
                {
                    str = str.Replace(token, function());
                }
                return str;
            }
        }

        private class IntArgToken : Token
        {
            public TokenFunction<int> function;

            public override string Replace(string str)
            {
                MatchCollection revnumModMatches = Regex.Matches(str,
                    @"\$" + tokenName + @"\((\d+)\)\$");
                foreach (Match match in revnumModMatches)
                {
                    string token = match.Groups[0].Value;
                    int arg = int.Parse(match.Groups[1].Value);
                    str = str.Replace(token, function(arg));
                }
                return str;
            }
        }

        private class StringArgToken : Token
        {
            public TokenFunction<string> function;

            public override string Replace(string str)
            {
                MatchCollection revnumModMatches = Regex.Matches(str,
                    @"\$" + tokenName + @"\(""(.+?)""\)\$");
                foreach (Match match in revnumModMatches)
                {
                    string token = match.Groups[0].Value;
                    string arg = match.Groups[1].Value;
                    str = str.Replace(token, function(arg));
                }
                return str;
            }
        }
    }
}
