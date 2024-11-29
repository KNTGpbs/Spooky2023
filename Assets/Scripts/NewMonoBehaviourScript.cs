using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private int poleInt;
    
    public GameObject poleGameObject;

    private Collider2D poleCollider2D;
    private Transform poleTransform;

    private void Start()
    {
        poleCollider2D = this.gameObject.GetComponent<Collider2D>();
        poleTransform = this.gameObject.transform;
    }

    private void Update()
    {
        poleInt++;
        transform.position = new Vector3(poleInt, 0, 0);
    }
}
