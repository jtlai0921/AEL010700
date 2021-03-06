using System;
using System.Configuration;
using System.Net.Configuration;
using System.Web.Configuration;

public partial class ReadMailSettings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		//開啓Request所在路徑網站的Web.config檔
		Configuration config = WebConfigurationManager.OpenWebConfiguration(this.Request.ApplicationPath);
		//取得Web.config中Mail設定區段
        MailSettingsSectionGroup mail = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

		//讀取顯示mailSettingsx設定相關值
        Response.Write("Mail主機名稱：" + mail.Smtp.Network.Host + "<BR>");
        Response.Write("Mail主機Port：" + mail.Smtp.Network.Port + "<BR>");
        Response.Write("Mail訊息：" + mail.Smtp.From + "<BR>");
		//如果Mail的Authentication驗證模式選擇Basic，則可讀取UserName及Password
		//Response.Write("使用者姓名：" + netSmtpMailSection.Smtp.Network.UserName + "<BR>");
		//Response.Write("使用者密碼：" + netSmtpMailSection.Smtp.Network.Password + "<BR>");
    }
}
