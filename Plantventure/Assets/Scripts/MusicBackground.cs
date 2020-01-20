using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBackground : MonoBehaviour {
    /*! Instance de la musique de fond. */
    public static MusicBackground instance;

    /*!
     * Méthode qui permet de garder la même musique de fond lors du changement de scènes. Si l'instance courrante n'exite pas, alors elle est créée.
     */
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
