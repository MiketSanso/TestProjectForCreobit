using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ConnectPrefabImage : MonoBehaviour
{
    public static async UniTask<GameObject> LoadImageFromAddressable(string textureAdress)
    {
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(textureAdress);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject gameObject = handle.Result;

            UnloadAssets.AddAsyncOperationHandleForUnload(handle);

            return gameObject;
        }
        else
        {
            Debug.LogError("Failed to load texture: " + handle.Status);
            return null;
        }
    }
}
