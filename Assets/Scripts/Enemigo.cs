using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int indiceEnLista;
    private bool destruido = false;
    public AudioClip sonidoColision;
    public bool EstaDestruido()
    {
        return destruido;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Principal") && !destruido)
        {
            Debug.Log("Colisión con jugador: " + this.name);
            if (sonidoColision != null)
            {
                AudioSource.PlayClipAtPoint(sonidoColision, transform.position);
            }

            GestorEnemigos gestor = FindObjectOfType<GestorEnemigos>();
            if (gestor != null && indiceEnLista == gestor.ObtenerIndiceActual())
            {
                gestor.SiguienteEnemigo();
            }

            destruido = true;
            Destroy(this.gameObject);
        }
    }
}
