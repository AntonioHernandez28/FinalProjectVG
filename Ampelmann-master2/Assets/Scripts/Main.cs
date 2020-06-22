using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Main : MonoBehaviour
{

    [Header("Set in Inspector")]                                             // a

    public GameObject ampelPrefab;

    public float ampelBottomY = -14f;

    public float ampelSpacingY = 2f;



    void Start()
    {
            GameObject ampel = Instantiate<GameObject>(ampelPrefab);

            Vector3 pos = Vector3.zero;

            pos.y = ampelBottomY + (ampelSpacingY);

            ampel.transform.position = pos;
    }

}
