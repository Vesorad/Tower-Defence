using UnityEngine;

namespace Assets.Scripts.Zenject
{
    [System.Serializable]
    public class ObjectPool
    {
        [field: SerializeField] public string NameFolder { private set; get; } = "";
        [field: SerializeField] public GameObject Prefab { private set; get; } = null;
        [field: SerializeField, Min(1)] public int PoolSize { private set; get; } = 1;
    }
}