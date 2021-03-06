// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MocklisCodeFixProvider.cs">
//   SPDX-License-Identifier: MIT
//   Copyright © 2019-2020 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.MockGenerator
{
    #region Using Directives

    using System.Collections.Immutable;
    using System.Composition;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CodeActions;
    using Microsoft.CodeAnalysis.CodeFixes;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Mocklis.CodeGeneration;
    using Mocklis.CodeGeneration.Compatibility;

    #endregion

    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(MocklisCodeFixProvider))]
    [Shared]
    public class MocklisCodeFixProvider : CodeFixProvider
    {
        private const string MocklisEmptiedClass = "mocklis_emptied_class";

        private const string Title = "Update Mocklis Class";

        public sealed override ImmutableArray<string> FixableDiagnosticIds =>
            ImmutableArray.Create(MocklisAnalyzer.CreateDiagnosticId, MocklisAnalyzer.UpdateDiagnosticId);

        public sealed override FixAllProvider? GetFixAllProvider() => null;

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;

            // Find the type declaration identified by the diagnostic.
            var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<TypeDeclarationSyntax>().First();

            // Register a code action that will invoke the fix.
            context.RegisterCodeFix(
                CodeAction.Create(
                    title: Title,
                    createChangedSolution: c => UpdateMocklisClassAsync(context.Document, declaration, c),
                    equivalenceKey: Title),
                diagnostic);
        }

        private async Task<Solution> UpdateMocklisClassAsync(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
        {
            if (!(typeDecl is ClassDeclarationSyntax classDecl))
            {
                return document.Project.Solution;
            }

            var semanticModel = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
            MocklisSymbols mocklisSymbols = new MocklisSymbols(semanticModel.Compilation);

            bool isMocklisClass = classDecl.AttributeLists.SelectMany(al => al.Attributes)
                .Any(a => semanticModel.GetSymbolInfo(a).Symbol.ContainingType.Equals(mocklisSymbols.MocklisClassAttribute));

            if (!isMocklisClass)
            {
                return document.Project.Solution;
            }

            var classIsInNullableContext = semanticModel.ClassIsInNullableContext(classDecl);

            var oldRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);

            var emptyClassDecl = MocklisClass.EmptyMocklisClass(classDecl).WithAdditionalAnnotations(new SyntaxAnnotation(MocklisEmptiedClass));
            var emptyRoot = oldRoot.ReplaceNode(classDecl, emptyClassDecl);
            var emptyDoc = document.WithSyntaxRoot(emptyRoot);
            emptyRoot = await emptyDoc.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);

            semanticModel = await emptyDoc.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);

            // And find the class again
            emptyClassDecl = emptyRoot.DescendantNodesAndSelf().OfType<ClassDeclarationSyntax>()
                .FirstOrDefault(n => n.GetAnnotations(MocklisEmptiedClass).Any());

            if (emptyClassDecl == null)
            {
                return document.Project.Solution;
            }

            var newClassDecl = MocklisClass.UpdateMocklisClass(semanticModel, emptyClassDecl, mocklisSymbols, classIsInNullableContext);

            var newRoot = emptyRoot.ReplaceNode(emptyClassDecl, newClassDecl);
            return emptyDoc.WithSyntaxRoot(newRoot).Project.Solution;
        }
    }
}
