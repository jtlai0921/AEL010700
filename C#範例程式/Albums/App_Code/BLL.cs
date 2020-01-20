
/// <summary>
/// BL 的摘要描述
/// </summary>
public class BLL
{
	public BLL()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    //取得所有Album相本數
    public int getAlbums()
    {
        //呼叫資料存取層的countAlbums
        DAL myDal = new DAL();
        return myDal.countAlbums();
    }

    //傳入AlbumID代號，回傳相本名稱
    public string getAlbumName(string albumID)
    {
        string albumName = "";
        if (!string.IsNullOrEmpty(albumID))
        {
            albumName = new DAL().queryAlbumName(albumID);
        }

        return albumName;
    }

    //傳入photoGUID代號，回傳相本AlbumID
    public string getAlbumID(string photoGUID)
    {
        string albumID = "-1";
        if (!string.IsNullOrEmpty(photoGUID))
        {
            albumID = new DAL().queryAlbumID(photoGUID);
        }

        return albumID;
    }


    //計算某相本下所有相片數，以AlbumID為計算基準
    public int getPhotos(string albumID)
    {
        DAL myDal = new DAL();
        return myDal.countPhotos(albumID);
    }

    //根據PhotoGUID檢查相簿是否受保護,true為有保護
    public bool checkAlbumProtection(string photoGUID)
    {
        bool protection = true;
        if (!string.IsNullOrEmpty(photoGUID))
        {
            //回傳值若為true則為有保護，若為false則無保護
            protection = new DAL().queryAlbumProtection(photoGUID);
        }

        return protection;
    }

    //儲存相簿之預設名稱
    public void saveDefaultPic(string albumID, string fileName)
    {
        new DAL().updateDefaultPic(albumID, fileName);
    }
}
