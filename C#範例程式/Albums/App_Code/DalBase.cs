using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// DalBase 的摘要描述
/// </summary>
public class DalBase
{
    //取得Web.config中的AlbumDBConnectionString1連線字串設定
    public static string connString = WebConfigurationManager.ConnectionStrings["AlbumDBConnectionString1"].ConnectionString;
    public SqlConnection publicConnection = null;

	protected DalBase()
	{
        //DAL初始化時，則建立公用的SqlConnection連線
        publicConnection = getConnection();
    }

    //取得對資料庫的SqlConnection物件
    protected SqlConnection getConnection()
    {
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = connString;
        connection.Open();

        return connection;
    }


    //取得設定好連線及命令的SqlDataReader
    protected SqlDataReader getDataReader(string CommandText)
    {
        SqlConnection connection = getConnection();
        SqlCommand cmd = new SqlCommand(CommandText, publicConnection);
        
        return cmd.ExecuteReader();
    }

    //取得設定好連線的SqlCommand
    protected SqlCommand getSqlCommand(string CommandText)
    {
        SqlCommand cmd = new SqlCommand(CommandText, publicConnection);

        return cmd;
    }
}
