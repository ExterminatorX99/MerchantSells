using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MerchantSells;

public class MerchantGlobal : GlobalNPC
{
	public static Dictionary<int, int[]> NPCIDToItemsSold = null!;

	public override void Load()
	{
		NPCIDToItemsSold = new()
		{
			[NPCID.Merchant] = new int[]
			{
				ItemID.LifeCrystal,
				ItemID.ManaCrystal,
			},
		};
	}

	public override void Unload()
	{
		NPCIDToItemsSold = null!;
	}

	public override bool AppliesToEntity(NPC entity, bool lateInstantiation) => NPCIDToItemsSold.ContainsKey(entity.type);

	public override void SetupShop(int type, Chest shop, ref int nextSlot)
	{
		if (!NPCIDToItemsSold.TryGetValue(type, out var itemTypes))
			return;

		foreach (int itemType in itemTypes)
		{
			Item item = shop.item[nextSlot++];
			item.SetDefaults(itemType);
			item.shopCustomPrice = Item.buyPrice(gold: 10);
		}
	}
}
