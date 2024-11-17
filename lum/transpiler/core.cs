using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lum.transpiler
{
    public class core
    {
        public static void Compile(string markup)
        {
            //string markup = @"
            //        # This is a header
            //        This is a regular paragraph.
            //        *This is a bold text.*
            //        _This is an italic text._";

            var interpreter = new MarkupInterpreter();
            var html = interpreter.Interpret(markup);

            Console.WriteLine(html);

            Console.ReadKey();
        }

        //Expression Interface: This will be our primary interpretative unit.
        public interface IExpression
        {
            string Interpret(string context);
        }

        //Concrete Expressions: These will handle specific patterns in our markup.
        public class HeaderExpression : IExpression
        {
            public string Interpret(string context)
            {
                return context.Replace("# ", "<h1>") + "</h1>";
            }
        }

        public class BoldExpression : IExpression
        {
            public string Interpret(string context)
            {
                return context.Replace("*", "<b>");
            }
        }

        public class ItalicExpression : IExpression
        {
            public string Interpret(string context)
            {
                return context.Replace("_", "<i>");
            }
        }

        //Interpreter: This class will utilize our expressions to interpret the entire context.
        public class MarkupInterpreter
        {
            private List<IExpression> expressions;

            public MarkupInterpreter()
            {
                expressions = new List<IExpression>
        {
            new HeaderExpression(),
            new BoldExpression(),
            new ItalicExpression()
        };
            }

            public string Interpret(string context)
            {
                foreach (var expression in expressions)
                {
                    context = expression.Interpret(context);
                }
                return context;
            }
        }
    }
}
