//------------------------------------------------------------------------------
// <copyright file="SqlScriptGeneratorVisitor.MatchRecognize.cs" company="Microsoft">
//         Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Microsoft.SqlServer.TransactSql.ScriptDom.ScriptGenerator
{
    partial class SqlScriptGeneratorVisitor
    {
        public override void ExplicitVisit(MatchRecognizeClause node)
        {
            GenerateIdentifier(CodeGenerationSupporter.MatchRecognize);
            GenerateSpace();
            GenerateSymbol(TSqlTokenType.LeftParenthesis);

            if (node.PartitionByExpressions.Count > 0)
            {
                NewLine();
                GenerateIdentifier(CodeGenerationSupporter.Partition);
                GenerateSpace();
                GenerateKeyword(TSqlTokenType.By);
                GenerateSpace();
                GenerateCommaSeparatedList(node.PartitionByExpressions);
            }

            NewLine();
            GenerateIdentifier(CodeGenerationSupporter.Limit);
            GenerateSpace();
            GenerateFragmentIfNotNull(node.Limit);

            if (node.Measures.Count > 0)
            {
                NewLine();
                GenerateIdentifier(CodeGenerationSupporter.Measures);
                GenerateSpace();
                GenerateCommaSeparatedList(node.Measures);
            }

            if (node.RowsPerMatchClause != null)
            {
                NewLine();
                GenerateFragmentIfNotNull(node.RowsPerMatchClause);
            }

            if (node.AfterMatchSkipClause != null)
            {
                NewLine();
                GenerateFragmentIfNotNull(node.AfterMatchSkipClause);
            }

            NewLine();
            GenerateIdentifier(CodeGenerationSupporter.Pattern);
            GenerateSpace();
            GenerateSymbol(TSqlTokenType.LeftParenthesis);
            GenerateFragmentIfNotNull(node.Pattern);
            GenerateSymbol(TSqlTokenType.RightParenthesis);

            NewLine();
            GenerateIdentifier(CodeGenerationSupporter.Define);
            GenerateSpace();
            GenerateCommaSeparatedList(node.Definitions);

            NewLine();
            GenerateSymbol(TSqlTokenType.RightParenthesis);
            GenerateSpace();
            GenerateKeyword(TSqlTokenType.As);
            GenerateSpace();
            GenerateFragmentIfNotNull(node.Alias);
        }

        public override void ExplicitVisit(MatchRecognizeMeasure node)
        {
            GenerateFragmentIfNotNull(node.Expression);
            GenerateSpace();
            GenerateKeyword(TSqlTokenType.As);
            GenerateSpace();
            GenerateFragmentIfNotNull(node.Alias);
        }

        public override void ExplicitVisit(MatchRecognizeOneRowPerMatchClause node)
        {
            GenerateIdentifier(CodeGenerationSupporter.One);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.Row);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.Per);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.GraphMatch);
        }

        public override void ExplicitVisit(MatchRecognizeAllRowsPerMatchClause node)
        {
            GenerateKeyword(TSqlTokenType.All);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.Rows);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.Per);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.GraphMatch);
        }

        public override void ExplicitVisit(MatchRecognizeSkipPastLastRowClause node)
        {
            GenerateIdentifier(CodeGenerationSupporter.After);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.GraphMatch);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.Skip);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.Past);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.Last);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.Row);
        }

        public override void ExplicitVisit(MatchRecognizeSkipToNextRowClause node)
        {
            GenerateIdentifier(CodeGenerationSupporter.After);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.GraphMatch);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.Skip);
            GenerateSpace();
            GenerateKeyword(TSqlTokenType.To);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.Next);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.Row);
        }

        public override void ExplicitVisit(MatchRecognizeSkipToFirstClause node)
        {
            GenerateIdentifier(CodeGenerationSupporter.After);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.GraphMatch);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.Skip);
            GenerateSpace();
            GenerateKeyword(TSqlTokenType.To);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.First);
            GenerateSpace();
            GenerateFragmentIfNotNull(node.PatternVariable);
        }

        public override void ExplicitVisit(MatchRecognizeSkipToLastClause node)
        {
            GenerateIdentifier(CodeGenerationSupporter.After);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.GraphMatch);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.Skip);
            GenerateSpace();
            GenerateKeyword(TSqlTokenType.To);
            GenerateSpace();
            GenerateIdentifier(CodeGenerationSupporter.Last);
            GenerateSpace();
            GenerateFragmentIfNotNull(node.PatternVariable);
        }

        public override void ExplicitVisit(MatchRecognizePatternVariableDefinition node)
        {
            GenerateFragmentIfNotNull(node.Variable);
            GenerateSpace();
            GenerateKeyword(TSqlTokenType.As);
            GenerateSpace();
            GenerateFragmentIfNotNull(node.Condition);
        }

        public override void ExplicitVisit(MatchRecognizePatternAlternation node)
        {
            for (int i = 0; i < node.Patterns.Count; i++)
            {
                if (i > 0)
                {
                    GenerateSpace();
                    GenerateSymbol(TSqlTokenType.VerticalLine);
                    GenerateSpace();
                }

                GenerateFragmentIfNotNull(node.Patterns[i]);
            }
        }

        public override void ExplicitVisit(MatchRecognizePatternConcatenation node)
        {
            for (int i = 0; i < node.Patterns.Count; i++)
            {
                if (i > 0)
                {
                    GenerateSpace();
                }

                GenerateFragmentIfNotNull(node.Patterns[i]);
            }
        }

        public override void ExplicitVisit(MatchRecognizePatternFactor node)
        {
            GenerateFragmentIfNotNull(node.Pattern);
            GenerateFragmentIfNotNull(node.Quantifier);
        }

        public override void ExplicitVisit(MatchRecognizePatternVariable node)
            => GenerateFragmentIfNotNull(node.Variable);

        public override void ExplicitVisit(MatchRecognizePatternGroup node)
        {
            GenerateSymbol(TSqlTokenType.LeftParenthesis);
            GenerateFragmentIfNotNull(node.Pattern);
            GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(MatchRecognizeZeroOrMoreQuantifier node)
            => GenerateSymbol(TSqlTokenType.Star);

        public override void ExplicitVisit(MatchRecognizeOneOrMoreQuantifier node)
            => GenerateSymbol(TSqlTokenType.Plus);

        public override void ExplicitVisit(MatchRecognizeOptionalQuantifier node)
            => GenerateSymbol(TSqlTokenType.QuestionMark);

        public override void ExplicitVisit(MatchRecognizeCountedQuantifier node)
        {
            GenerateSymbol(TSqlTokenType.LeftCurly);
            if (node.MinimumCount != null)
            {
                GenerateFragmentIfNotNull(node.MinimumCount);
            }

            if (node.MinimumCount == null || node.MaximumCount != null)
            {
                GenerateSymbol(TSqlTokenType.Comma);
                if (node.MaximumCount != null)
                {
                    GenerateFragmentIfNotNull(node.MaximumCount);
                }
            }

            GenerateSymbol(TSqlTokenType.RightCurly);
        }
    }
}
