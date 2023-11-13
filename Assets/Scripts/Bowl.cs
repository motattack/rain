using System.Collections;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    public static int STEP_EMPTY = 0;
    public static int STEP_WATER = 1;
    public static int STEP_READY = 2;
    
    private SpriteRenderer waterSpriteRenderer;
    private SpriteRenderer wiskasSpriteRenderer;
    private SpriteRenderer bolwSpriteRenderer;

    private Item bowlItem;
    private int step = 0;

    private GameObject player;
    private bool readyForAction;

    public int Step => step;
    public int Ready => STEP_READY;

    private void Start()
    {
        bolwSpriteRenderer = GetComponent<SpriteRenderer>();
        waterSpriteRenderer = GetComponentsInChildren<SpriteRenderer>()[1];
        wiskasSpriteRenderer = GetComponentsInChildren<SpriteRenderer>()[2];

        player = GameObject.FindWithTag("Player");
    }

    private void OnMouseDown()
    {
        Item item = DB.GetHandItem();

        if (readyForAction)
        {
            if (step == STEP_EMPTY)
            {
                if (item.Type == Item.Typefood)
                {
                    DB.RemoveItem();
                    step = STEP_WATER;
                    bowlItem = item;
                    waterSpriteRenderer.sprite = Resources.Load<Sprite>("Food/water");
                    StartCoroutine(Grow());
                }
            }
            else if (step == STEP_READY)
            {
                waterSpriteRenderer.sprite = Resources.Load<Sprite>("Food/empty");
                wiskasSpriteRenderer.sprite = Resources.Load<Sprite>("Food/empty");
                DB.CheckIfItemExists(bowlItem);

                step = STEP_EMPTY;
            }
        }
    }

    private IEnumerator Grow()
    {
        yield return new WaitForSeconds(bowlItem.TimeToReady);

        waterSpriteRenderer.sprite = Resources.Load<Sprite>("Food/water");
        wiskasSpriteRenderer.sprite = Resources.Load<Sprite>("Food/wiskas");
        
        step = STEP_READY;
    }

    private void FixedUpdate()
    {
        if (step != STEP_WATER)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) < 2f)
            {
                readyForAction = true;
                bolwSpriteRenderer.sprite= Resources.Load<Sprite>("Food/bowlSelected");
            }
            else
            {
                readyForAction = false;
                bolwSpriteRenderer.sprite= Resources.Load<Sprite>("Food/bowl");
            }
        }
        else
        {
            bolwSpriteRenderer.sprite= Resources.Load<Sprite>("Food/bowl");
        }
    }
}
