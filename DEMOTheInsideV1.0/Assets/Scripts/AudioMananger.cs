using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMananger : MonoBehaviour
{
    public AudioClip abrirCandado;
    public AudioClip botonesCandado;
    public AudioClip unlock;

    public AudioClip pasos;
    public AudioClip respiracion;

    public AudioClip cambioDimension;
    public AudioClip campana;
    

    public AudioClip romperTile;

    public AudioClip tomarObjeto;
   

    public AudioClip closeDoor;
    public AudioClip openDoor;

    public AudioClip cuadroPared;
    public AudioClip dropCuadro;

    public AudioClip Papel;

    AudioSource audiosFoley;


    void Start()
    {
        audiosFoley = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
