using UnityEngine;
using Zenject;

namespace Assets.Scripts.Zenject
{
    [System.Serializable]
    public class ObjectPool
    {
        [field: SerializeField] public string NameFolder { private set; get; } = "";
        [field: SerializeField] public GameObject Prefab { private set; get; } = null;
       /* [field: SerializeField] public MonoBehaviour mono { private set; get; } = null; //TODO
        [field: SerializeField] public PlaceholderFactory<MonoBehaviour> factory { private set; get; } = null;*/
        [field: SerializeField, Min(1)] public int PoolSize { private set; get; } = 1;
    }
}
