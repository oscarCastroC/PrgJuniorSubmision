using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMinion : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyTag"))
        {
            this.transform.parent.gameObject.GetComponent<PlayerBehaviour>().changeLive(-1);
        }
    }

}
