using UnityEngine;
using TMPro;
public class JugadorController : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidad = 5;
    private int contador = 0;
    public TextMeshProUGUI textoContador, textoGanar;
    // Use this for initialization
    void Start()
    {
        //Capturo esa variable al iniciar el juego
        rb = GetComponent<Rigidbody>();
        //Actualizo el texto del contador por pimera vez
        setTextoContador();
        //Inicio el texto de ganar a vacío
        textoGanar.text = "";
    }
    // Para que se sincronice con los frames de física del motor
    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoH, 0.0f,
        movimientoV);
        rb.AddForce(movimiento * velocidad);
    }
    //Se ejecuta al entrar a un objeto con la opción isTrigger seleccionada
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 1;
            //Actualizo elt exto del contador
            setTextoContador();

        }
    }

    void setTextoContador()
    {
        textoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12)
        {
            textoGanar.text = "¡Ganaste!";
        }

    }
}
