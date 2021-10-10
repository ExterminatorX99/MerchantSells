using System.Collections.Generic;

namespace MerchantSells;

public class MerchantGlobal : GlobalNPC
{
	public static Dictionary<int, int[]> NPCIDToItemsSold;

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

	public override void SetupShop(int type, Chest shop, ref int nextSlot)
	{
		if (!NPCIDToItemsSold.TryGetValue(type, out int[] itemTypes))
			return;

		foreach (int itemType in itemTypes)
		{
			Item item = shop.item[nextSlot++];
			item.SetDefaults(itemType);
			item.shopCustomPrice = Item.buyPrice(gold: 10);
		}
	}
}
