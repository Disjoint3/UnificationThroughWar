using UnityEngine;

public class Test1 : BaseScript
{
    public GameObject prefab;
    private void Start()
    {
        //prefab = Instantiate<GameObject>(Resources.Load<GameObject>(ResUrl.pool_test1));
        //prefab = Resources.Load<GameObject>(ResUrl.pool_test1);
        //Debug.Log(ResUrl.pool_test1);
    }
}
