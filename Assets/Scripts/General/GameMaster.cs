using UnityEngine;

public class GameMaster : Singelton<GameMaster>
{
    private ItemDatabase itemDatabase;

    public ItemDatabase ItemDatabase
    {
        get
        {
            if(itemDatabase == null)
            {
                itemDatabase = Resources.Load<ItemDatabase>("Databases/ItemDatabase");
            }

            return itemDatabase;
        }
    }
}
