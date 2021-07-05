﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerchantSells
{
    public class MerchantGlobal : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Merchant)
            {
                Item item = shop.item[nextSlot++];
                item.SetDefaults(ItemID.LifeCrystal);
                item.value = Item.buyPrice(gold: 5);
            }
        }
    }
}
