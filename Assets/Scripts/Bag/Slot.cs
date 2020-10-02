using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item soltItem;
    public string name;
    public Image soltImage;
    public Text number;

    public void ItemOnClick()
    {
        Debug.Log("点击solt");
        BagGuiManager.instacne.itemDes.text = soltItem.des;
    }
}