using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
public class UI_Resources : MonoBehaviour
{
    public TextMeshProUGUI souls;
    public int cur_souls;
    public int max_souls;
    
    // Start is called before the first frame update
    void Start()
    {
        souls.text = cur_souls.ToString();
    }


    public void Getsouls(int count_souls)
    {
        cur_souls = cur_souls + count_souls;
        
        souls.text = cur_souls.ToString();


    }








    // Update is called once per frame
    void Update()
    {
        
    }
}
