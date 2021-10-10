namespace MerchantSells;

public class MerchantGlobal : GlobalNPC
{
	private readonly int[] MerchantItems =
	{
		ItemID.LifeCrystal,
		ItemID.ManaCrystal
	};

	public override void SetupShop(int type, Chest shop, ref int nextSlot)
	{
		switch (type)
		{
			case NPCID.Merchant:
				foreach (int itemType in MerchantItems)
				{
					Item item = shop.item[nextSlot++];
					item.SetDefaults(itemType);
					item.shopCustomPrice = Item.buyPrice(gold: 10);
				}

				break;
		}
	}
}
