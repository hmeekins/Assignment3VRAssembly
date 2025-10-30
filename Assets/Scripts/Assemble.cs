using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class Assemble : MonoBehaviour
{
    public Transform target;

    public bool isSolved;

    private AudioSource audioSource;
    private Rigidbody rigidbody;
    private MeshCollider meshCollider;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        meshCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < .05f && !isSolved)
        {
            IEnumerable<GrabInteractor> setInteractors = transform.GetChild(0).GetComponent<GrabInteractable>().Interactors;
            foreach (GrabInteractor interactor in setInteractors) { interactor.Unselect(); }

            transform.SetPositionAndRotation(target.position, target.rotation);
            target.gameObject.SetActive(false);

            rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            meshCollider.enabled = false;

            audioSource.Play();

            isSolved = true;
        }
    }
}
