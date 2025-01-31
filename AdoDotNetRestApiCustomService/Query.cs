namespace AdoDotNetRestApiCustomService
{
	public class Query
	{
		public static string GetAllBlogsQuery { get; } =
		@"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] ORDER BY BlogId DESC";
	}
}
