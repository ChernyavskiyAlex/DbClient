using System;

namespace DBClient.Utils
{
    public static class QueryLib
    {
        public const String DbType = "DbType";
        public const String GetRequirementById1 = "SELECT RQ_REQ_ID, RQ_REQ_COMMENT, RQ_REQ_REVIEWED, RQ_REQ_STATUS, RQ_REQ_NAME, RQ_REQ_AUTHOR, RQ_REQ_RICH_CONTENT FROM td.REQ WHERE RQ_REQ_ID = {0}";
        public const String GetRequirementById = "SELECT * FROM td.REQ WHERE RQ_REQ_ID = {0}";
    }
}
