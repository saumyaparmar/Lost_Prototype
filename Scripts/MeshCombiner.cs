using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    public List<MeshFilter> sourceMeshFilters;
    public MeshFilter targetMeshFilter;
    
    [ContextMenu("Combine Meshes")]
    private void CombineMeshes()
    {
        var combine = new CombineInstance[sourceMeshFilters.Count];
        for(var i =0;i<sourceMeshFilters.Count;i++)//listing all meshes to combine
        {
            combine[i].mesh = sourceMeshFilters[i].sharedMesh; //sharedMesh cuz scene mode
            combine[i].transform = sourceMeshFilters[i].transform.localToWorldMatrix;
        }

        var mesh = new Mesh();
        mesh.CombineMeshes(combine);
        targetMeshFilter.mesh = mesh;
    }
}
