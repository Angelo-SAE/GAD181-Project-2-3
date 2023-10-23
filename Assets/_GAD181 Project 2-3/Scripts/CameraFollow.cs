using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  [SerializeField] private GameObject player;
  [SerializeField] private float cameraSpeed;

    void Update()
    {
      CameraFollowPlayer();
    }

    private void CameraFollowPlayer()
    {
      transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, gameObject.transform.position.z), cameraSpeed * Time.deltaTime);
    }
}
