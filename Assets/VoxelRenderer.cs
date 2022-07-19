using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class VoxelRenderer : MonoBehaviour
{
    ParticleSystem system;
    ParticleSystem.Particle[] voxels;
    bool voxelUpdated = false;
    //voxelScale is for indivisual voxels
    public float voxelScale = 0.1f;
    //scale sets the scale for the whole renderer, use transform.localscale if you do not want to define a varable
    public float scale = 1f;

    void Start()
    {
        system = GetComponent<ParticleSystem>();

        Vector3[] positions = new Vector3[10000];
        Color[] colors = new Color[10000];

        for (int i = 0; i < 10000; i++) {
            positions[i] = new Vector3(Random.value * 10, Random.value * 10, Random.value * 10);
            colors[i] = new Color(Random.value, Random.value, Random.value);
        }
        SetVoxels(positions, colors);
    }

    void Update()
    {
        if (voxelUpdated)
        {
            system.SetParticles(voxels, voxels.Length);
            voxelUpdated = false;
        }
    }
    void SetVoxels(Vector3[] positions, Color[] colors){
        voxels = new ParticleSystem.Particle[positions.Length];
        for (int i = 0; i < positions.Length; i++){
            voxels[i].position = positions[i] * scale;
            voxels[i].startColor = colors[i];
            voxels[i].startSize = voxelScale;
        }
        Debug.Log("Voxel Count" + voxels.Length);
        voxelUpdated = true;
    }
}
