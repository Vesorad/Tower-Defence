using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainManuController : MonoBehaviour
    {
        private const int GAME_SCENE_INDEX = 1;

        [SerializeField, Min(0.1f)] private float lifeTimeStartIcon = 0.1f;
        [SerializeField] private GameObject creatorsCanvas = null;

        private float timeToDisableStartIcon;

        private void Start()
        {
            timeToDisableStartIcon = Time.time + lifeTimeStartIcon;
        }

        private void Update()
        {
            if (creatorsCanvas.activeSelf && Time.time >= timeToDisableStartIcon)
                creatorsCanvas.SetActive(false);
        }


        public void OnClickPlay() => SceneManager.LoadScene(GAME_SCENE_INDEX);

        public void OnClickSettings()
        {
            //TODO
        }

        public void OnClickCredits()
        {
            //TODO
        }

        public void OnClickScoreboard()
        {
            //TODO
        }
    }
}