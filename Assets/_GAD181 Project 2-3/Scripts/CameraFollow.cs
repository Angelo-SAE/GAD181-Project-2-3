using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  [SerializeField] private GameObject player;

    void Update()
    {
      CameraFollowPlayer();
    }

    private void CameraFollowPlayer()
    {
      transform.position = new Vector3(player.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
    }
}
