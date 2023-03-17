using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semsorAnswer : MonoBehaviour
{
    [SerializeField] private string sensorName;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerBehaviour>().setSoldiers(this.transform.parent.gameObject.GetComponent<QuestionPref>().GetAnswerQ(sensorName));
        }
    }
}
