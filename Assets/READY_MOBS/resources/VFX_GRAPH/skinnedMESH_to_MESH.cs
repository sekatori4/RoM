using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class skinnedMESH_to_MESH : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMESH;
    public VisualEffect VFXGraph;
    public float refreshRate;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateVFXGraph());
    }

    IEnumerator UpdateVFXGraph()
    {
        while (gameObject.activeSelf)
        {

            Mesh m = new Mesh();
            skinnedMESH.BakeMesh(m);
            VFXGraph.SetMesh("Mesh", m);

            yield return new WaitForSeconds(refreshRate);



        }

    }
    
}
