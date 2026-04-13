//------------------------------------------------------------------------------
// <copyright file="SqlScriptGeneratorVisitor.ChronosWindowCompute.cs" company="Microsoft">
//         Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace Microsoft.SqlServer.TransactSql.ScriptDom.ScriptGenerator
{
    partial class SqlScriptGeneratorVisitor
    {
        public override void ExplicitVisit(ChronosWindowClause node)
        {
            GenerateIdentifier(CodeGenerationSupporter.Window);
            GenerateSpace();
            GenerateKeyword(TSqlTokenType.By);
            GenerateSpace();
            GenerateCommaSeparatedList(node.GroupingSpecifications);
        }

        public override void ExplicitVisit(ChronosTumblingWindowExpression node)
        {
            GenerateIdentifier(CodeGenerationSupporter.TumblingWindow);
            GenerateSymbol(TSqlTokenType.LeftParenthesis);
            GenerateFragmentIfNotNull(node.Size);
            GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(ChronosDurationExpression node)
        {
            GenerateIdentifier(CodeGenerationSupporter.Duration);
            GenerateSymbol(TSqlTokenType.LeftParenthesis);
            GenerateFragmentIfNotNull(node.Unit);
            GenerateSymbol(TSqlTokenType.Comma);
            GenerateSpace();
            GenerateFragmentIfNotNull(node.Value);
            GenerateSymbol(TSqlTokenType.RightParenthesis);
        }

        public override void ExplicitVisit(ChronosComputeClause node)
        {
            GenerateKeyword(TSqlTokenType.Compute);
            GenerateSpace();

            GenerateCommaSeparatedList(node.Expressions);
        }

        public override void ExplicitVisit(ChronosComputeExpression node)
        {
            GenerateFragmentIfNotNull(node.Alias);
            GenerateSpace();
            GenerateSymbol(TSqlTokenType.EqualsSign);
            GenerateSpace();
            GenerateFragmentIfNotNull(node.Expression);
        }
    }
}
