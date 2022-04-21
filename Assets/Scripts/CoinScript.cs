using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public string pickupSFX = "";
    public GameObject pickupEffect;

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 50, Space.World);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            GameObject.Find("CoinManager").GetComponent<CoinManager>().AddCoin(10);
            Destroy(this.gameObject);

            //show pickup effect
            if (pickupEffect != null)
            {
                GameObject effect = GameObject.Instantiate(pickupEffect);
                effect.transform.position = transform.position;
            }

            //play sfx
            if (pickupSFX != "")
            {
                GlobalAudioPlayer.PlaySFXAtPosition(pickupSFX, transform.position);
            }
        }
    }
}