using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    //[Header("物体所属的背包")]
    //public BagManager Bag;

    private Item item = new Item();

    [Header("物体属性")]
    public string name;

    public int number;
    public string des;
    public string type;
    public string spritePath;

    private void Awake()//将属性赋予物体
    {
        item.name = name;
        item.number = number;
        item.des = des;
        item.type = type;
        item.spritePath = spritePath;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(this.gameObject);
        }
    }

    private void AddNewItem()
    {
        if (BagManager.instacne.Mydata.bagData.Count != 0)
        {
            foreach (var m_item in BagManager.instacne.Mydata.bagData)//检测有没有同名物体，没有就添加
            {
                if (m_item.name == item.name)//有同样的物体
                {
                    m_item.number += number;//加入触碰的物体的数据到背包中
                    Debug.Log("物体：" + item.name + "，的数量：" + m_item.number);
                    BagGuiManager.instacne.RefreshItem();//刷新背包GUI
                    BagManager.instacne.SaveGame(); //存储数据
                    return;
                }
            }
        }
        BagManager.instacne.Mydata.bagData.Add(item);//加入触碰的物体的数据到背包中
        Debug.Log("加入物体");
        BagGuiManager.instacne.RefreshItem();//刷新背包GUI
        BagManager.instacne.SaveGame(); //存储数据
        // BagGuiManager.instacne.CreatGUIItem(item);
    }
}