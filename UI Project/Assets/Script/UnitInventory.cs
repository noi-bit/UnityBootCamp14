using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;

public class UnitInventory : MonoBehaviour
{
    public int gold = 500;
    public string[] ingredient;//재료
    public string ingredientList = "USB,헤드폰,마이크,루비,핸드폰";

    //public enum Ingredient_control
    //{
    //    None = 0,
    //    USB,
    //    헤드폰,
    //    마이크,
    //    루비,
    //    핸드폰
    //}



    //public Text money;
    //public Text indList;

    //private void Start()
    //{
    //    mikuhave();
    //    Ingredient();
    //}

    //private void mikuhave()
    //{
    //    money.text = $"{gold} gold";
    //}

    

    //private void Ingredient()
    //{
    //    indList.text = " ";
    //    ingredient = ingredientList.Split(',');
    //    foreach (string item in ingredient)
    //    {
    //        indList.text += $"{item} ";
    //    }
    //}
    

    //item_table = item.Split(,); 
}
