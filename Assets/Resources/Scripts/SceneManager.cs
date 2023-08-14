using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace GameJam
{
    public enum Scenes
    {
        Level1 = 1,
    }

    public static class SceneManager
    {
        public static async void LoadScene(Scenes sceneId) => await LoadSceneAsync(sceneId);

        private static async Task LoadSceneAsync(Scenes sceneId)
        {
            var operation =
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int) sceneId, LoadSceneMode.Single);

            while (!operation.isDone)
            {
                await Task.Delay(100);
            }
        }
    }
}