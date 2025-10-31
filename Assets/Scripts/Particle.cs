using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem targetParticleSystem;
    public int currentStep;

    // Start is called before the first frame update
    void Start()
    {
        if (target != null) {
            target.GetComponent<Renderer>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        var emission = targetParticleSystem.emission;
        if (StepTracker.step == currentStep)
        {

            emission.enabled = true;
        }
        else
        {
            emission.enabled = false;
        }
        {
        }
    }
}
