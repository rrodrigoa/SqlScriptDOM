    TimestampByClause vTimestampByClause;
        (
            vTimestampByClause=timestampByClause
            {
                vResult.TimestampByClause = vTimestampByClause;
            }
        )?
    ;

timestampByClause returns [TimestampByClause vResult = this.FragmentFactory.CreateFragment<TimestampByClause>()]
{
    ScalarExpression vExpression;
}
    :
        tTimestamp:Timestamp
        {
            UpdateTokenInfo(vResult, tTimestamp);
        }
        By
        vExpression=expression
        {
            vResult.TimestampExpression = vExpression;
            UpdateTokenInfo(vResult, vExpression);
        }
        (
            tOver:Over
            {
                UpdateTokenInfo(vResult, tOver);
            }
            expressionList[vResult, vResult.OverExpressions]
        )?
    |   Timestamp
