using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace AdoDotNetRestApiCustomService
{
	public class AdoDotNetService
	{
		private readonly string _connStr = "Data Source=.;Database=DotNetTrainingBatch5;User Id=sa;Password=sasa@123;TrustServerCertificate=True;";

		private SqlConnection GetConnection() => new(_connStr);

		

	}
}





	
