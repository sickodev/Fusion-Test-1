using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static Vector3 GetRandomSpawnPoint() => new Vector3(Random.Range(-5, 5), 0.7f, Random.Range(-5, 5));

    public static void SetRenderLayerInChildren(Transform transform, int layerNumber)
    {
        foreach (Transform trans in transform.GetComponentInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
