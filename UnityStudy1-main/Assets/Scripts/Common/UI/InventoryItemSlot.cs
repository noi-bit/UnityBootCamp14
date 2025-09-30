using Gpm.Ui;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlotData : InfiniteScrollData
{
    public long SerialNumber;
    public int ItemId; //11001, 12001 .. 이런식
}

public class InventoryItemSlot : InfiniteScrollItem
{
    public Image _itemGradeBg;
    public Image _itemIcon;

    private InventoryItemSlotData m_inventoryItemSlotData;

    public override void UpdateData(InfiniteScrollData scrollData) //인피니티 스크롤을 스크롤링 할 때,
                                                                   //게임 오브젝트의 데이터를 변경하는데,
                                                                   //그 때 사용됨
    {
        base.UpdateData(scrollData);

        m_inventoryItemSlotData = scrollData as InventoryItemSlotData;
        if(m_inventoryItemSlotData == null)
        {
            Logger.LogError("m_inventoryItemSlotData is invalid");
            return;
        }

        ItemGrade itemGrade = (ItemGrade)((m_inventoryItemSlotData.ItemId / 1000) % 10);
        //24002/1000 -> 24 % 10 -> 4 => 아이템의 등급!
        var gradeBgTexture = Resources.Load<Texture2D>($"Textures/{itemGrade}");
        if (gradeBgTexture != null)
        {
            _itemGradeBg.sprite = Sprite.Create(gradeBgTexture, new Rect(0, 0, gradeBgTexture.width, gradeBgTexture.height), new Vector2(1f, 1f));
        }

        //아이템 아이콘을 가져오는 작업
        StringBuilder sb = new StringBuilder(m_inventoryItemSlotData.ItemId.ToString());
        sb[1] = '1'; //1로 밀어줌. 왜?
                    //만약 _itemId가 만약 22001이라면, 아이템 파일이름과 일치시키기 위해 2번째 자리를 1로 전부바꿈
        string itemIconName = sb.ToString();

        Texture2D itemIconTexture = Resources.Load<Texture2D>($"Textures/{itemIconName}"); 
        if(itemIconTexture != null)
        {
            _itemGradeBg.sprite = Sprite.Create(itemIconTexture, new Rect(0, 0, itemIconTexture.width, itemIconTexture.height), new Vector2(1f, 1f));
        }
    }
}
