using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace AddressablesLoad
{
    public class AddressablesSpriteLoader : MonoBehaviour
    {
        [SerializeField] private AssetReference _loadableSprite;
        [SerializeField] private Image _uiImage;

        private async void Awake()
        {
            var handle = _loadableSprite.LoadAssetAsync<Sprite>();
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                var sprite = handle.Result;
                _uiImage.sprite = sprite;
                Addressables.Release(handle);
            }
        }
    }
}
