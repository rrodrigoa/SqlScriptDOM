    TimestampByClause vTimestampByClause;
        (
            vTimestampByClause=timestampByClause
            {
                if (vFromClause == null)
                {
                    ThrowIncorrectSyntaxErrorException(vTimestampByClause);
                }
                vFromClause.TimestampByClause = vTimestampByClause;
            }
        )?
