using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace AddressablesLoad
{
    public class AddressablesMaterialLoader : MonoBehaviour
    {
        [SerializeField] private AssetReference _loadableSprite;
        [SerializeField] private MeshRenderer _meshRenderer;

        private async void Awake()
        {
            var handle = _loadableSprite.LoadAssetAsync<Material>();
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                var material = handle.Result;
                _meshRenderer.material = material;
                Addressables.Release(handle);
            }
        }
    }
}
