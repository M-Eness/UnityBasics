using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour

{
    public int kan;
    public TMP_Text bloodText;
    void Start()
    {
        kan = BloodManager.KanSayacı.currentBlood;
        bloodText.text = (kan + "");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
