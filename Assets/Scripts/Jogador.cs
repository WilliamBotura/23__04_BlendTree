using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour {

    float velAtual;
    public float velMaxima = 3.0f;

    public float acelInicial = 0.2f;
    public float acel = 0.01f;
    public float des = 0.07f;

    public float velRotacao = 130.0f;

    Animator anim;

	void Awake()
    {
        anim = GetComponent<Animator>();
	}
	
	void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        //print(v);
        if (v >0 && velAtual < velMaxima)
        {
            velAtual += (velAtual == 0f) ? acelInicial : acel;
        }
        else if (v == 0 && velAtual > 0)
        {
            velAtual -= des;
        }
        velAtual = Mathf.Clamp(velAtual, 0, velMaxima);
        transform.Translate(Vector3.forward * velAtual * Time.deltaTime);

        //rotação
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 rotacao = Vector3.up * h * velRotacao * Time.deltaTime;
        if (velAtual > 0)
        {
            transform.Rotate(rotacao); 
        }

        float valorAnim = Mathf.Clamp(velAtual / velMaxima, 0, 1);
        anim.SetFloat("Speed", valorAnim);

    }
}
