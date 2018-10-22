using UnityEngine;

public class GameMaster : Singelton<GameMaster>
{
    private GameObject mainCharacterPrefab;

    public GameObject MainCharacter
    {
        get;
        private set;
    }

    private void Awake()
    {
        mainCharacterPrefab = Resources.Load<GameObject>("Prefabs/MainCharacter");
        MainCharacter = SpawnObjectInstance(mainCharacterPrefab);
    }

    private void Start ()
    {        
        CameraEngine.Instance.SetTarget(MainCharacter.transform);      
	}

    private GameObject SpawnObjectInstance(GameObject prefab, Vector2 position = new Vector2(), Quaternion rotation = new Quaternion())
    {
        var newObjectInstance = Instantiate(prefab, position, rotation);
        newObjectInstance.name = prefab.name;
        return newObjectInstance;
    }
}
