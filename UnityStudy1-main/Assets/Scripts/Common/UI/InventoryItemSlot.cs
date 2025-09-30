using Gpm.Ui;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlotData : InfiniteScrollData
{
    public long SerialNumber;
    public int ItemId; //11001, 12001 .. �̷���
}

public class InventoryItemSlot : InfiniteScrollItem
{
    public Image _itemGradeBg;
    public Image _itemIcon;

    private InventoryItemSlotData m_inventoryItemSlotData;

    public override void UpdateData(InfiniteScrollData scrollData) //���Ǵ�Ƽ ��ũ���� ��ũ�Ѹ� �� ��,
                                                                   //���� ������Ʈ�� �����͸� �����ϴµ�,
                                                                   //�� �� ����
    {
        base.UpdateData(scrollData);

        m_inventoryItemSlotData = scrollData as InventoryItemSlotData;
        if(m_inventoryItemSlotData == null)
        {
            Logger.LogError("m_inventoryItemSlotData is invalid");
            return;
        }

        ItemGrade itemGrade = (ItemGrade)((m_inventoryItemSlotData.ItemId / 1000) % 10);
        //24002/1000 -> 24 % 10 -> 4 => �������� ���!
        var gradeBgTexture = Resources.Load<Texture2D>($"Textures/{itemGrade}");
        if (gradeBgTexture != null)
        {
            _itemGradeBg.sprite = Sprite.Create(gradeBgTexture, new Rect(0, 0, gradeBgTexture.width, gradeBgTexture.height), new Vector2(1f, 1f));
        }

        //������ �������� �������� �۾�
        StringBuilder sb = new StringBuilder(m_inventoryItemSlotData.ItemId.ToString());
        sb[1] = '1'; //1�� �о���. ��?
                    //���� _itemId�� ���� 22001�̶��, ������ �����̸��� ��ġ��Ű�� ���� 2��° �ڸ��� 1�� ���ιٲ�
        string itemIconName = sb.ToString();

        Texture2D itemIconTexture = Resources.Load<Texture2D>($"Textures/{itemIconName}"); 
        if(itemIconTexture != null)
        {
            _itemGradeBg.sprite = Sprite.Create(itemIconTexture, new Rect(0, 0, itemIconTexture.width, itemIconTexture.height), new Vector2(1f, 1f));
        }
    }
}
