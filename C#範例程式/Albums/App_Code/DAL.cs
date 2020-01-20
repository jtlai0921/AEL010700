using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class DAL:DalBase
{
	public DAL()
	{
	}

    //計算相簿數量
    public int countAlbums()
    {
        int albums = 0 ; //相本數

        SqlDataReader dr = getDataReader("Select count(*) from AlbumData");

        while (dr.Read())
        {
            albums = Convert.ToInt16(dr[0]);
        }

        //閉關DataReader及Connection
        dr.Dispose();
        publicConnection.Close();

        return albums;
    }

    //以AlbumID代號查詢相本名稱
    public string queryAlbumName(string albumID)
    {
        string albumName = null;

        if (!string.IsNullOrEmpty(albumID))
        {
            albumID = HttpUtility.HtmlEncode(albumID);
            string strSql = string.Format("Select top 1 AlbumName from AlbumData where AlbumID={0}", albumID);
            SqlDataReader dr = getDataReader(strSql); //建立SqlDataReader
            while (dr.Read())
            {
                albumName = dr[0].ToString();
            }

            //閉關DataReader及Connection
            dr.Dispose();
            publicConnection.Close();
        }

        return albumName;
    }

    //以AlbumID代號查詢相本名稱，以SqlParameter建立安全性數查詢
    public string queryAlbumNameParam(string albumID)
    {
        string albumName = null;

        if (!string.IsNullOrEmpty(albumID))
        {
            albumID = HttpUtility.HtmlEncode(albumID);
            string strSql = "Select top 1 AlbumName from AlbumData where AlbumID=@paramAlbumID";
            SqlCommand cmd = getSqlCommand(strSql); //建立SqlCommand

            //設定SqlParameter，建立安全的參數
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@paramAlbumID";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Value = Convert.ToInt16(albumID);
            parameter.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parameter);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                albumName = dr[0].ToString();
            }

            //閉關DataReader及Connection
            dr.Close();
            dr.Dispose();
            cmd.Dispose();
            publicConnection.Close();
        }

        return albumName;
    }

    //計算某相本下所有相片數，以AlbumID為計算基準
    public int countPhotos(string albumID)
    {
        int photos = 0;
        if (!string.IsNullOrEmpty(albumID))
        {
            albumID = HttpUtility.HtmlEncode(albumID);
            string strSql = string.Format("Select count(*) from PhotoData where AlbumID={0}", albumID);
            SqlDataReader dr = getDataReader(strSql);

            while (dr.Read())
            {
                photos = Convert.ToInt16(dr[0]);
            }

            //閉關DataReader及Connection
            dr.Dispose();
            publicConnection.Close();
        }
        
        return photos;
    }

    //以PhotoGUID查詢相本之albumID
    public string queryAlbumID(string photoGUID)
    {
        string albumID = "-1";
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        string strSql = "";

        if (!string.IsNullOrEmpty(photoGUID))
        {
            photoGUID = HttpUtility.HtmlEncode(photoGUID);
            //以photoGUID查詢PhotoData資料表中的albumID
            strSql = string.Format("SELECT Top 1 AlbumID FROM PhotoData Where PhotoGUID='{0}'", photoGUID);
            cmd = getSqlCommand(strSql);
            try
            {
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    albumID = dr[0].ToString(); //取得相簿AlbumID
                }
            }
            finally
            {
                dr.Close();
                dr.Dispose();
                cmd.Dispose();
                publicConnection.Close();
            }
        }

        return albumID;
    }

    //根據AlbumID查詢相簿是否受保護
    public bool queryAlbumProtection(string photoGUID)
    {
        bool protection = true;
        int albumID = -1;
        SqlCommand cmd=null;
        SqlDataReader dr=null ;
        string strSql = "";

        if (!string.IsNullOrEmpty(photoGUID))
        {
            photoGUID = HttpUtility.HtmlEncode(photoGUID);
            //1.先以photoGUID查詢PhotoData資料表中的albumID
            strSql = string.Format("SELECT Top 1 AlbumID FROM PhotoData Where PhotoGUID='{0}'", photoGUID);
            cmd = getSqlCommand(strSql);
            try
            {
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    albumID = Convert.ToInt16(dr[0]); //取得相簿AlbumID
                }
            }
            catch (Exception ex)
            {
                
            }            
        }

        //2.再以albumID查詢AlbumData中相簿是否有保護
        if (albumID != -1)
        {
            strSql = string.Format("SELECT Top 1 AlbumID FROM AlbumData Where AlbumID={0} and (Protection='False' or Protection is null)", albumID);
            cmd.CommandText = strSql;
            dr.Close();
            dr = cmd.ExecuteReader();

            if (!dr.Read())
            {
                //如果沒有讀到任何資料，則表示相簿是有保護的
                protection = true;  
            }
        }

        dr.Close();
        dr.Dispose();
        cmd.Dispose();
        publicConnection.Close();
        publicConnection.Dispose();

        return protection;
    }

    //更新相本預設圖片
    public void updateDefaultPic(string albumID,string fileName)
    {
        if (!string.IsNullOrEmpty(albumID) && !string.IsNullOrEmpty(fileName))
        {
            albumID = HttpUtility.HtmlEncode(albumID);
            fileName = HttpUtility.HtmlEncode(fileName);
            string strSql = string.Format("Update AlbumData set DefaultPhotoGUID='{0}' where AlbumID={1}", fileName, albumID);
            SqlCommand cmd = getSqlCommand(strSql);
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Dispose();
                publicConnection.Close();
                publicConnection.Dispose();
            }
        }
    }
}
