using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// Singleton
/// </summary>
public class SpawnManager : MonoBehaviour
{
    // [Singleton] - Ref Awake()
    public static SpawnManager instance;

    // private
    // float sum = 0f;
    const float genTime = 2f;
    const ushort MAX_COUNT = 5;

    // Unity Functions
    void Awake() {
        if(instance == null)
            instance = this;

        // resource.LoadOthersByFolder("Monster/");
        ResourceManager.instance.LoadOthersByFolder("Monster");
    }
    // ResourceManager resource = new ResourceManager();
    void Start()
    {
    }
    float spawnTime = 0;
    private void Update() {
        MonsterSelect();
        spawnTime += Time.deltaTime;
        if(spawnTime > 2.0f){ // 2초에 한번 스폰
            spawnTime -= 2.0f;
            CreateMonster("TrollGiantLow", "Monster", 5);
        }
    }

    // Custom Fuctions
    public GameObject monsterParent;
    NavMonster CreateMonster(string mobname, string tag, int cnt = 1)
    {
        if (GameManager.instance.Monsters.FindAll((x) => x.gameObject.activeSelf).Count >= cnt)
            return null;

        NavMonster enableMob = GetEnableMonster();
        if (enableMob == null)
        {
            // GameObject tmp = resource.GetOther(mobname); 
            GameObject tmp = ResourceManager.instance.GetOther(mobname);
            enableMob = Instantiate<GameObject>(tmp).AddComponent<NavMonster>();
            enableMob.tag = tag;
            if(monsterParent != null)
                enableMob.gameObject.transform.SetParent(monsterParent.transform);
            GameManager.instance.Monsters.Add(enableMob);
        }
        enableMob.gameObject.SetActive(true);
        return enableMob;
    }
    private NavMonster GetEnableMonster()
    {
        return GameManager.instance.Monsters.Find((x) => !x.gameObject.activeSelf);
    }

    void CreatePlayer(string name){
        GameObject obj = Instantiate<GameObject>(ResourceManager.instance.GetPlayer("Player"));
        GameManager.instance.Player = obj.AddComponent<Player>();

        // CustomCamera cam = Camera.main.gameObject.AddComponent<CustomCamera>();
    }
    bool DisactivateMob(Collider col)
    {
        try
        {
            NavMonster disactivate = GameManager.instance.Monsters.Find(
                (x) => x.Equals(col.gameObject.GetComponent<NavMonster>())
            );
            disactivate.gameObject.SetActive(false);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }
    void MonsterSelect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.collider.CompareTag("Monster"))
                {
                    if (DisactivateMob(hitInfo.collider))
                    {
                        Debug.Log($"{hitInfo.collider.name} : Disactivate");
                    }
                }
            }
        }
    }
}
