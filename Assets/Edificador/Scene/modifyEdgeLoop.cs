using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProBuilder2.Common;
public class modifyEdgeLoop : MonoBehaviour {
    public pb_Edge[] depthLoop;
    public pb_Edge[] longLoop_1;
    public pb_Edge[] longLoop_2;
    pb_Object obj;

    public float profundidad;
    public float longitud;
    [ContextMenu("Save Depth")]
    public void SaveDepth()
    {
        depthLoop = obj.SelectedEdges;
    }
    [ContextMenu("Save long1")]
    public void SaveLong1()
    {
        longLoop_1 = obj.SelectedEdges;
    }
    [ContextMenu("Save long2")]
    public void SaveLong2()
    {
        longLoop_2 = obj.SelectedEdges;
    }
    public float prevZTrans = 0f;
    public float prevXTrans_1 = 0f;
    public float prevXTrans_2 = 0f;
    public Transform parentTransform;

    public void SetValues(float _prof, float _long)
    {
        this.profundidad = _prof;
        this.longitud = _long;
    }

    public void Init()
    {
        if (obj == null)
            obj = GetComponent<pb_Object>();
        if (parentTransform == null)
            parentTransform = transform.parent.parent;

    }
    public void Rotate180()
    {
        transform.parent.rotation = Quaternion.Euler(0, 180, 0);
    } 
public void Rotate0()
{
    transform.parent.rotation = Quaternion.Euler(0, 0, 0);
}
[ContextMenu("Get Selection")]
    public void _UpdateCarve()
    {
        Init();

        _UpdateDepth();
        _UpdateLong();
        
        obj.ToMesh();
        obj.Refresh();
    }
    public Vector3 translacion;

    public void _UpdateDepth()
    {
        obj.SetSelectedEdges(depthLoop);

        float distancia = parentTransform.localScale.z - profundidad;
        float mov = Mathf.Clamp(distancia, 0, parentTransform.localScale.z) - parentTransform.localScale.z / 2f;
        translacion = mov * Vector3.forward.normalized;

        prevZTrans = mov;
        obj.TranslateVertices(obj.SelectedTriangles, translacion / parentTransform.localScale.z);

    }
    public void _UpdateLong()
    {
        obj.SetSelectedEdges(longLoop_1);
 
        float distancia = (parentTransform.localScale.x - longitud) / 2f;
        float mov = Mathf.Clamp(distancia, 0, parentTransform.localScale.x / 2) - parentTransform.localScale.x / 4f;
        translacion = Vector3.right.normalized * mov/2;
        prevXTrans_1 = mov/2;
        obj.TranslateVertices(obj.SelectedTriangles, 2 * translacion / parentTransform.localScale.x);

        obj.SetSelectedEdges(longLoop_2);
        prevXTrans_2 = -mov / 2;

        obj.TranslateVertices(obj.SelectedTriangles, -2 * translacion / parentTransform.localScale.x);


    }

    [ContextMenu("Reset")]
    public void Reset()
    {
        Init();

        obj.SetSelectedEdges(depthLoop);
        translacion = Vector3.forward.normalized * -prevZTrans;
        prevZTrans = 0f;
        obj.TranslateVertices(obj.SelectedTriangles, translacion / parentTransform.localScale.z);

        obj.SetSelectedEdges(longLoop_1);
        translacion = Vector3.right.normalized * -prevXTrans_1;
        prevXTrans_1 = 0f;
        obj.TranslateVertices(obj.SelectedTriangles, 2 * translacion / parentTransform.localScale.x);

        obj.SetSelectedEdges(longLoop_2);
        translacion = Vector3.right.normalized*-prevXTrans_2;
        prevXTrans_2 = 0f;
        obj.TranslateVertices(obj.SelectedTriangles, 2 * translacion / parentTransform.localScale.x);


        obj.ToMesh();
        obj.Refresh();
    }
}
