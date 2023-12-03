﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
public class VolumetricFire : MonoBehaviour
{
    private Mesh mesh;
    private Material material;

    [SerializeField, Range(1, 20), Tooltip("Controls the number of additional meshes to render in front of and behind the original mesh")]
    private int thickness = 1;
    [SerializeField, Range(0.01f,1f), Tooltip("Controls the total distance between the frontmost mesh and the backmost mesh")]
    private float spread = 0.2f;


    [SerializeField] private bool billboard = true;
    private MaterialPropertyBlock materialPropertyBlock;
    private int internalCount;
    private float randomStatic;
    Collider boundaryCollider;

    // Start is called before the first frame update
    void Start()
    {
        materialPropertyBlock = new MaterialPropertyBlock();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;

        material = meshRenderer.sharedMaterial;
        mesh = GetComponent<MeshFilter>().sharedMesh;
        
        boundaryCollider = GetComponent<Collider>();

        randomStatic = Random.Range(0f, 1f);
    }

    private void OnEnable()
    {
        RenderPipelineManager.beginCameraRendering += RenderFlames;
    }

    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= RenderFlames;
    }

    // Courtesy of Staggart Creations via https://forum.unity.com/threads/camera-current-returns-null-when-calling-it-in-onwillrenderobject-with-universalrp.929880/
    private static bool IsVisible(Camera camera, Bounds bounds)
    {
        Plane[] frustrumPlanes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(frustrumPlanes, bounds);
    }

    private void RenderFlames(ScriptableRenderContext context, Camera camera)
    {
       // bool isVisible = IsVisible(camera, boundaryCollider.bounds);

 
        internalCount = (thickness - 1) * 2;

        float gap = 0;
        if (internalCount > 0)
        {
            gap = spread / internalCount;
        }

        for (int i = 0; i <= internalCount; i++)
        {
            float itemNumber = i - (internalCount * 0.5f);

            SetupMaterialPropertyBlock(itemNumber);
            CreateItem(gap, itemNumber, camera);
        }
    }

    void SetupMaterialPropertyBlock(float item)
    {
        if (materialPropertyBlock == null)
            return;

        materialPropertyBlock.SetFloat("_ITEMNUMBER", item);
        materialPropertyBlock.SetFloat("_INTERNALCOUNT", internalCount);
        materialPropertyBlock.SetFloat("_INITIALPOSITIONINT", randomStatic);
    }

    void CreateItem(float spacing, float item, Camera camera)
    {
        Quaternion newRot = Quaternion.identity;
        Vector3 position = Vector3.zero;
        if (billboard)
        {
            newRot *= camera.transform.rotation;
            Vector3 direction = (transform.position - camera.transform.position).normalized;
            position = transform.position - (direction * item * spacing);
        }
        else
        {
            newRot = transform.rotation;
            position = transform.position - (transform.forward * item * spacing);
        }
        

        Matrix4x4 matrix = Matrix4x4.TRS(position, newRot, transform.localScale);
        Graphics.DrawMesh(mesh, matrix, material, 0, camera, 0, materialPropertyBlock, false, false, false);
    }
}
