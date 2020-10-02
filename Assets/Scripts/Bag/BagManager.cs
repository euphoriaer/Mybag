using LitJson;
using System.IO;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    public static BagManager instacne;
    private static JsonData mydata = new JsonData();//列表要用类包裹，才能进行Json序列化
    //private Item testItem = new Item();

    private void Awake()
    {
        if (instacne != null)
        {
            Destroy(this);
        }
        instacne = this;
        Mydata = ReadJson();
        BagGuiManager.instacne.RefreshItem();
    }

    public JsonData Mydata { get => mydata; set => mydata = value; }

    private void Start()
    {
        //写测试
        //    testItem.des = "描述测试";
        //    testItem.name = "Name测试";
        //    testItem.number = 1;
        //    testItem.spritePath = "UI/apple";
        //    testItem.type = "food";

        // mydata.bagData.Add(testItem);

        //读测试
        //Mydata = ReadJson();
        //Debug.Log(Mydata.bagData[0].name);
        //Debug.Log(Mydata.bagData[0].number);
        //Debug.Log(Mydata.bagData[0].des);
        //Debug.Log(Mydata.bagData[0].type);
        //Debug.Log(Mydata.bagData[0].spritePath);
    }

    public JsonData ReadJson()
    {
        JsonData m_bagData = new JsonData();
        if (File.Exists("C:/Users/17641/Desktop" + "/MyJsonData.txt"))
        {
            string jsonString = File.ReadAllText("C:/Users/17641/Desktop" + "/MyJsonData.txt");//可以使用try进行安全校验，读取Json字符串

            m_bagData = JsonMapper.ToObject<JsonData>(jsonString);

            //m_bagData = JsonUtility.FromJson<JsonData>(jsonString);//读取失败

            //用结构体接收 LitJsonData
            Debug.Log(jsonString);
            return m_bagData;
        }
        return null;
    }

    private void SaveJson(JsonData myJson)
    {
        string saveString = JsonUtility.ToJson(myJson);//转Json
        File.WriteAllText("C:/Users/17641/Desktop" + "/MyJsonData.txt", saveString);//存到文件中，如果不存在会自动创建
        if (File.Exists("C:/Users/17641/Desktop" + "/MyJsonData.txt"))
        {
            Debug.Log("Save Sucess!");
        }
    }

    public void SaveGame()
    {
        SaveJson(Mydata);
    }
}