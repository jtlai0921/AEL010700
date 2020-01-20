
/// <summary>
/// Person 的摘要描述
/// </summary>
public class People
{
    //定義欄位
    string lastName;
    string firstName;
    int age;
    int height;
    int weight;
    bool gender;    //性別

    //以建構函式設定欄位初值
    public People()
    {
        lastName = null;
        firstName = null;
        age = 0;
        height = 0;
        weight = 0;
        gender = false;
    }

    //建構函式一
    public People(string LastName, string FirstName, int Height, int Weight, int Age, bool Gender)
    {
        this.lastName = LastName;
        this.firstName = FirstName;
        this.age = Age;
        this.height = Height;
        this.weight = Weight;
        this.gender = Gender;
    }


    //建構函式二
    public People(string lastName, bool gender)
    {
        this.lastName = lastName;
        this.gender = gender;
    }

    //定義Property屬性
    //LastName
    public string LastName
    {
        set
        {
            //判斷LastName是否為空字串
            if (!string.IsNullOrEmpty(value))
            {
                lastName = value;
            }
        }

        get
        {
            if (string.IsNullOrEmpty(lastName))
            {
                lastName="LastName尚未指定";
            }

            return lastName;
        }
    }

    //FirstName
    public string FirstName
    {
        set
        {
            //判斷LastName是否為空字串
            if (!string.IsNullOrEmpty(value))
            {
                firstName = value;
            }
        }

        get
        {
            if (string.IsNullOrEmpty(firstName))
            {
                firstName = "firstName尚未指定";
            }

            return firstName;
        }
    }

    //年齡
    public int Age
    {
        set 
        {
            //age設定值必須大於等於1
            if (value >= 1)
            {
                age = value;
            }
        }

        get 
        {
            //如果age為0或負值，則設定為1歲
            if (age <= 0)
            {
                age = 1;
            }

            return age; 
        }
    }

    //身高
    public int Height
    {
        set 
        {
            //判斷height身高設定值是否大於等於1
            if (value >= 1)
            {
                height = value;
            }
        }

        get 
        {
            //如果height為0或負值，則設定為1
            if (height <= 0)
            {
                height = 1;
            }

            return height; 
        }
    }

    //體重
    public int Weight
    {
        set 
        {
            if (value >= 1)
            {
                weight = value;
            }
        }

        get 
        {
            //如果weight為0或負值，則設定為1
            if (weight <= 0)
            {
                weight = 1;
            }

            return weight; 
        }
    }

    //性別
    public bool Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    /*原始的Property屬性宣告
    //定義Property屬性
    //LastName
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    //FirstName
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    //年齡
    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    //身高
    public int Height
    {
        get { return height; }
        set { height = value; }
    }

    //體重
    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    //性別
    public bool Gender
    {
        get { return gender; }
        set { gender = value; }
    }
     * */
}
