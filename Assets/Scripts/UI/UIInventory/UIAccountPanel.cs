using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAccountPanel : BaseInventory
{
    protected override void BindDataWith(List<InventoryItem> itemsList, int hightLightIndex)
    {
        base.BindDataWith(itemsList, hightLightIndex);
        for (int i = 0; i < FarmSetting.playerMaxRepositoryCapacity; i++)
        {
            if (i < itemsList.Count)
            {
                uIInventorySlots[i].BindData(itemsList[i], i, hightLightIndex);
            }
            else
            {
                uIInventorySlots[i].BindData(new InventoryItem(-1, -1), i, hightLightIndex);
            }
        }
    }
}
