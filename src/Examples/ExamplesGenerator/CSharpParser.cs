using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ExamplesGenerator
{
	/// <summary>
	/// Reads the implemented examples from the Examples project
	/// </summary>
	internal static class CSharpParser
	{
		private static readonly Regex StartTag = new Regex(@"// tag::(?<hash>.*?)\[\]");
		private static readonly Regex EndTag = new Regex(@"// end::(?<hash>.*?)\[\]");

		private static Func<SyntaxTrivia, bool> SingleLineTriviaMatches(Regex regex)
		{
			return t => t.IsKind(SyntaxKind.SingleLineCommentTrivia) && regex.IsMatch(t.ToFullString());
		}

		public static IEnumerable<ImplementedExample> ParseImplementedExamples()
		{
			foreach (var path in Directory.EnumerateFiles(ExampleLocation.ExamplesCSharpProject.FullName, "*Page.cs", SearchOption.AllDirectories))
			{
				var compilationUnit = CSharpSyntaxTree.ParseText(File.ReadAllText(path)).GetCompilationUnitRoot();

				var classDeclaration = compilationUnit
					.Members.OfType<NamespaceDeclarationSyntax>()
					.Single()
					.Members.OfType<ClassDeclarationSyntax>()
					.Single();

				var methodDeclarations = classDeclaration.Members.OfType<MethodDeclarationSyntax>();

				foreach (var methodDeclaration in methodDeclarations)
				{
					var uAttribute = methodDeclaration.AttributeLists.Single().Attributes.Single();

					// No Skip property present on [U] attribute
					if (uAttribute.ArgumentList == null)
					{
						// opening tag comment is leading trivia on the first statement
						var openTagComment = methodDeclaration.Body.Statements.First()
							.GetLeadingTrivia().Single(SingleLineTriviaMatches(StartTag));

						var hash = StartTag.Match(openTagComment.ToFullString()).Groups["hash"].Value;

						var statements = new List<StatementSyntax>();

						for (int i = 0; i < methodDeclaration.Body.Statements.Count; i++)
						{
							var statement = methodDeclaration.Body.Statements[i];

							// end tag can be reported as leading trivia on the first match example assertion, which denotes the end of
							// statements we're interested in
							if (statement.GetLeadingTrivia().Any(SingleLineTriviaMatches(EndTag)))
								break;

							statements.Add(i == 0 ? statement.ReplaceTrivia(openTagComment, default(SyntaxTrivia)) : statement);

							if (statement.GetTrailingTrivia().Any(SingleLineTriviaMatches(EndTag)))
							{
								statements.Add(statement.WithoutTrailingTrivia());
								break;
							}
						}

						// create a new block with collected statements. We need a SyntaxNode to work with
						var body = Block(statements);

						var method = methodDeclaration.Identifier.Text;
						var startLineNumber = methodDeclaration.SyntaxTree.GetLineSpan(methodDeclaration.Span).StartLinePosition.Line + 1;
						var endLineNumber = methodDeclaration.SyntaxTree.GetLineSpan(methodDeclaration.Span).EndLinePosition.Line + 1;

						yield return new ImplementedExample(method, startLineNumber, endLineNumber, path, hash, body);
					}
				}
			}
		}
	}
}
