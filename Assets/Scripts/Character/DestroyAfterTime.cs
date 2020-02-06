using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
        public float TimeToLive = 1f;
        private void Start()
        {
            Destroy(gameObject, TimeToLive);
    }
}
