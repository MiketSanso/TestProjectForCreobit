using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class UnloadAssets
{
    private static List<AsyncOperationHandle> objectsForUnload = new List<AsyncOperationHandle>();

    public static void AddAsyncOperationHandleForUnload(AsyncOperationHandle operationHandle)
    {
        objectsForUnload.Add(operationHandle);
    }

    public static void UnloadAsset()
    {
        for (int a = 0; a < objectsForUnload.Count; a++)
        {
            Addressables.Release(objectsForUnload[a]);
        }

        objectsForUnload.Clear();
    }
}
