using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ScoreCanvasController
    {
        private GameObject canvas;

        public ScoreCanvasController(GameObject canvas)
        {
            this.canvas = canvas;
        }

        public void ShowScoreCanvas() => canvas.SetActive(true);
    }
}