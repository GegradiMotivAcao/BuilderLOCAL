using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class rotacionaImagem : MonoBehaviour
{
   public Button rotateButton;

    void Start()
    {
        rotateButton.onClick.AddListener(RotateRight90Degrees);
    }

    void RotateRight90Degrees()
    {
        transform.Rotate(0, 0, -90);
    }
}