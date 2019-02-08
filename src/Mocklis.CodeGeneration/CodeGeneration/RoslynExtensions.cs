// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoslynExtensions.cs">
//   Copyright © 2019 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.CodeGeneration
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using F = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    #endregion

    public static class RoslynExtensions
    {
        public static ObjectCreationExpressionSyntax WithExpressionsAsArgumentList(
            this ObjectCreationExpressionSyntax objectCreationExpression,
            params ExpressionSyntax[] expressions)
        {
            return objectCreationExpression.WithArgumentList(
                F.ArgumentList(F.SeparatedList(expressions.Where(e => e != null).Select(F.Argument))));
        }

        public static InvocationExpressionSyntax WithExpressionsAsArgumentList(
            this InvocationExpressionSyntax invocationExpression,
            params ExpressionSyntax[] expressions)
        {
            return invocationExpression.WithArgumentList(
                F.ArgumentList(F.SeparatedList(expressions.Where(e => e != null).Select(F.Argument))));
        }

        public static ElementAccessExpressionSyntax WithExpressionsAsArgumentList(
            this ElementAccessExpressionSyntax elementAccessExpression,
            params ExpressionSyntax[] expressions)
        {
            return elementAccessExpression.WithArgumentList(
                F.BracketedArgumentList(
                    F.SeparatedList(expressions.Where(e => e != null).Select(F.Argument))));
        }

        public static IEnumerable<string> GetUsableNames(this ITypeSymbol typeSymbol)
        {
            while (typeSymbol != null)
            {
                foreach (var member in typeSymbol.GetMembers())
                {
                    if (member.CanBeReferencedByName)
                    {
                        yield return member.Name;
                    }
                }

                typeSymbol = typeSymbol.BaseType;
            }
        }
    }
}