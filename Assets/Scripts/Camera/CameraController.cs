using Assets.Scripts.Managers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.CameraInGame
{
    public class CameraController : IInitializable, ITickable
    {
        private GameManager gameManager;
        private float multipleSpeedCamera;
        private Transform cameraTransform;

        private Vector2 minMaxCameraMovement;

        private float startCameraHigh;
        private float timeOnStartUpdate;
        private float cameraHighRange;
        private float newCameraHigh
        {
            get => cameraHighRange;
            set
            {
                if (value > minMaxCameraMovement.y)
                    cameraHighRange = minMaxCameraMovement.y;
                else if (value < minMaxCameraMovement.x)
                    cameraHighRange = minMaxCameraMovement.x;
                else
                    cameraHighRange = value;
            }
        }

        public CameraController(GameManager gameManager, float multipleSpeedCamera, Transform cameraTransform)
        {
            this.gameManager = gameManager;
            this.multipleSpeedCamera = multipleSpeedCamera;
            this.cameraTransform = cameraTransform;
        }

        public void Initialize()
        {
            minMaxCameraMovement = new Vector2(gameManager.HighRoof.y, gameManager.HighRoof.y);

            newCameraHigh = gameManager.HighTower.y;
        }

        public void Tick()
        {
            if (Input.GetMouseButton(0))
                newCameraHigh -= Input.GetAxis("Mouse Y"); //TODO zamieniæ na placel

            if (cameraTransform.position.y != newCameraHigh)
                cameraTransform.position = new Vector3(cameraTransform.position.x, ChangeInTimePosCamera(), cameraTransform.position.z);
        }

        public void UpdateMaxRangeCamera()
        {
            minMaxCameraMovement.y = gameManager.HighTower.y;
            ChangeHighCamera(gameManager.HighTower.y);
        }

        public void ChangeHighCamera(float newHigh)
        {
            newCameraHigh = newHigh;

            timeOnStartUpdate = Time.time;
            startCameraHigh = cameraTransform.position.y;
        }

        private float ChangeInTimePosCamera() => Mathf.Lerp(startCameraHigh, newCameraHigh, (Time.time - timeOnStartUpdate) * multipleSpeedCamera);
    }
}