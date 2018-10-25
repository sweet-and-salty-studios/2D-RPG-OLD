using UnityEngine;

public class GameMaster : Singelton<GameMaster>
{ 
    private GameObject playerPrefab;

    public GameObject PlayerGameObject
    {
        get;
        private set;
    }

    private void Awake()
    {
        playerPrefab = Resources.Load<GameObject>("Prefabs/Characters/Player");
        PlayerGameObject = SpawnObjectInstance(playerPrefab);
    }

    private void Start()
    {
        CameraEngine.Instance.SetTarget(GameObject.FindGameObjectWithTag("Player").transform);
    }

    private GameObject SpawnObjectInstance(GameObject prefab, Vector2 position = new Vector2(), Quaternion rotation = new Quaternion())
    {
        var newObjectInstance = Instantiate(prefab, position, rotation);
        newObjectInstance.name = prefab.name;
        return newObjectInstance;
    }
}
