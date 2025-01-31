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

		public static string CreateBlogQuery { get; } =
		"INSERT INTO dbo.Tbl_Blog (BlogTitle, BlogAuthor, BlogContent, DeleteFlag) VALUES (@BlogTitle, @BlogAuthor, @BlogContent, @DeleteFlag);";

	}
}
