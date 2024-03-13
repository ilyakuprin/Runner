using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace AddressablesLoad
{
    public class AddressablesMeshLoader : MonoBehaviour
    {
        [SerializeField] private AssetReference _loadableSprite;
        [SerializeField] private MeshFilter _meshFilter;

        private async void Awake()
        {
            var handle = _loadableSprite.LoadAssetAsync<Mesh>();
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                var mesh = handle.Result;
                _meshFilter.mesh = mesh;
                Addressables.Release(handle);
            }
        }
    }
}
