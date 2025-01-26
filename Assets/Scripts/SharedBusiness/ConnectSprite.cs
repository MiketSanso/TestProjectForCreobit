using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ConnectSprite : MonoBehaviour
{
    public static async UniTask<Sprite> LoadSpriteFromAddressable(string textureAdress)
    {
        AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(textureAdress);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite sprite = handle.Result;

            UnloadAssets.AddAsyncOperationHandleForUnload(handle);

            return sprite;
        }
        else
        {
            Debug.LogError("Failed to load texture: " + handle.Status);
            return null;
        }
    }
}
