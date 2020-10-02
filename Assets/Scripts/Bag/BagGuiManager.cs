using UnityEngine;
using UnityEngine.UI;

public class BagGuiManager : MonoBehaviour
{
    public static BagGuiManager instacne;

    private void Awake()
    {
        if (instacne != null)
        {
            Destroy(this);
        }
        instacne = this;
    }

    [Header("背包")]
    public BagManager bag;

    public Slot slot;
    public GameObject slotGrid;
    public Text itemDes;

    private void OnEnable()
    {
        RefreshItem();
        itemDes.text = "";
    }

    public void CreatGUIItem(Item item)
    {
        Slot newItem = Instantiate(slot, slotGrid.transform, false);
        //newItem.gameObject.transform.SetParent(slotGrid.transform,false);//设置父物体
        newItem.soltItem = item;
        newItem.name = item.name;
        newItem.number.text = item.number.ToString();
        Debug.Log("显示的数量:" + item.number);

        //显示图片
        
        //GameObject m_Image = Resources.Load(item.spritePath) as GameObject;
        //newItem.soltImage.sprite = m_Image.GetComponent<Image>().sprite;//做成预制体，然后通过加载预制体赋予图片，as 加载方式

        newItem.soltImage.sprite = Resources.Load<Sprite>(item.spritePath);//不能使用as Sprite，会失败，要使用泛型的加载
    }

    public void RefreshItem()//刷新数量，重新生成
    {
        for (int i = 0; i < instacne.slotGrid.transform.childCount; i++)
        {
            if (instacne.slotGrid.transform.childCount == 0)
            {
                Debug.Log("没有物体可销毁");
                break;
            }
            Destroy(instacne.slotGrid.transform.GetChild(i).gameObject);

        }

        //foreach (var item in bag.Mydata.bagData)
        //{
        //
        //    CreatGUIItem(item);
        //}
        for (int i = 0; i < bag.Mydata.bagData.Count; i++)
        {
            Debug.Log("重新生成");
            CreatGUIItem(bag.Mydata.bagData[i]);
        }
    }
}