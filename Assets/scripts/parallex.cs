using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class parallex : MonoBehaviour
{
    Vector2 pz;
    Vector2 StartPos;
    public AudioSource audio;
    [SerializeField] float moveModifier;
    public TMP_Text presstostart;
    public GameObject fader;
    public TMP_Text titleText;
    public Animation anim;
    public Animation anim2;
    public Animation anim3;
    bool running = true;
    bool once = true;
    private void Start()
    {
        StartPos = transform.position;
        InvokeRepeating("calculatePos", 0.0f, 10f);
        StartCoroutine(fadingText());
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            running = false;
            StopCoroutine(fadingText());
            if(once)
            {
            StartCoroutine(WaitForSceneLoad());
            }
            once = false;
        }
        float posX = Mathf.Lerp(transform.position.x, StartPos.x + (pz.x * moveModifier), 0.05f * Time.deltaTime);
        float posY = Mathf.Lerp(transform.position.y, StartPos.y + (pz.y * moveModifier), 0.05f * Time.deltaTime);

        transform.position = new Vector3(
            (posX),
            (posY),
            0
            );
    }

    private IEnumerator WaitForSceneLoad() {
    audio.time = 0.8f;
    audio.Play();
     anim.Play("fading");
     anim2.Play("mainmenutextfade");
     anim3.Play("mainmenutextfadeplay");
     presstostart.color = new Color(1,0,0,1);

     yield return new WaitForSeconds(3);
     SceneManager.LoadScene("SampleScene");
     
     }

    void calculatePos()
    {
       pz = new Vector2(Random.Range(-0.4f, 0.4f), Random.Range(-0.4f, 0.6f)); 
    }

    IEnumerator fadingText()
    {
        while(running)
        {
            presstostart.color = new Color(1,1,1,.5f);
            yield return new WaitForSeconds(0.1f);
            presstostart.color = new Color(1,1,1,0.6f);
            yield return new WaitForSeconds(0.1f);
            presstostart.color = new Color(1,1,1,0.7f);
            yield return new WaitForSeconds(0.1f);
            presstostart.color = new Color(1,1,1,0.8f);
            yield return new WaitForSeconds(0.1f);
            presstostart.color = new Color(1,1,1,0.9f);
            yield return new WaitForSeconds(0.1f);
            presstostart.color = new Color(1,1,1,1);
            yield return new WaitForSeconds(0.1f);
            presstostart.color = new Color(1,1,1,0.9f);
            yield return new WaitForSeconds(0.1f);
             presstostart.color = new Color(1,1,1,0.8f);
            yield return new WaitForSeconds(0.1f);
            presstostart.color = new Color(1,1,1,0.7f);
            yield return new WaitForSeconds(0.1f);
            presstostart.color = new Color(1,1,1,0.6f);
            yield return new WaitForSeconds(0.1f);
            presstostart.color = new Color(1,1,1,0.5f);
        }
    }
}
