using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class ConnectTexture
{
    public static async UniTask<List<Sprite[]>> LoadSpritesDeckFromAddressable(string textureAdress, int spriteHeight, int spriteWidth)
    {
        AsyncOperationHandle<Sprite[]> handle = Addressables.LoadAssetAsync<Sprite[]>(textureAdress);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite[] texture = handle.Result;

            List<Sprite[]> sprites = new List<Sprite[]>();

            for (int y = 0; y < spriteHeight; y++)
            {
                Sprite[] sprite = new Sprite[spriteWidth];

                for (int x = 0; x < spriteWidth; x++)
                {
                    for (int z = 0; z < spriteWidth * spriteHeight; z++)
                    {
                        if (texture[z].name == textureAdress + "_" + (y * spriteWidth + x))
                        {
                            sprite[x] = texture[z];

                            break;
                        }
                    }

                }
                sprites.Add(sprite);
            }

            UnloadAssets.AddAsyncOperationHandleForUnload(handle);

            return sprites;
        }
        else
        {
            Debug.LogError("Failed to load texture: " + handle.Status);
            return null;
        }
    }
}
