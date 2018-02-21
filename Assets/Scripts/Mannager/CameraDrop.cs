using UnityEngine;
using System.Collections;

public class CameraDrop : MonoBehaviour {


    #region Singleton
    private static CameraDrop instance;

    public static CameraDrop Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CameraDrop>();
            }
            return CameraDrop.instance;
        }
        set { CameraDrop.instance = value; }
    }
    #endregion

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
   // public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;



    void OnEnable()
    {
        originalPos = this.transform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            this.transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            this.transform.localPosition = originalPos;
        }
    }
}
