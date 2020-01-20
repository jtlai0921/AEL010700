
/// <summary>
/// Person 的摘要描述
/// </summary>
public class Person
{
    //定義欄位
    public string lastName;
    public string firstName;
    public int age;
    public decimal height;
    public decimal weight;
    public bool gender;    //性別

    //預設建構函式
    public Person()
    {
        lastName = "未指定";
        firstName = "未指定";
        age = 1;
        height = 1;
        weight = 1;
        gender = true;
    }
}
