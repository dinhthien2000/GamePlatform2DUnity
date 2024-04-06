using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCollect : MonoBehaviour
{
    private int cherries;

    [SerializeField] private Text cherriesText;
    [SerializeField] GameObject[] gameObjects;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime; // đếm thời gian
        if (isDurationTime(timer, 3f))
        {
            setEnabledObjectsByTag("Cherries");
        }

        //foreach (GameObject gameObject in gameObjects)
        //{

        //    if (!gameObject.activeSelf)
        //    {
        //        Debug.Log("" + gameObject.activeSelf);
        //        gameObject.SetActive(true);
        //    }
        //}
    }

    // hàm sẽ được gọi khi có sự va chạm giữa 2 đối tượng Rigibody2D (1 là đối tượng đang sở hữu đoạn code này và 2 là đối tượng khác )
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // đoạn code này khi player va chạm cherries thì thu gom và hủy bỏ đối tưởn cherries
        //if (collision.gameObject.CompareTag("Cherries"))
        //{
        //    Destroy(collision.gameObject);
        //    cherries++;
        //    //Debug.Log("Cherries was collected: "+cherries);
        //    cherriesText.text = "Cherries: " + cherries;

        //}

        // đoạn code này thu gom và ẩn/hiện cherries sẽ xuất hiện sau 1 khoảng thời gian
        if (collision.gameObject.CompareTag("Cherries"))
        {
            collision.gameObject.SetActive(false);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;
            Debug.Log("Cherries was collected: " + cherries);
            Debug.Log("Cherries isActiveAndEnabled: " + cherries);
 
        }
    }

    // đặt khoảng thời gian theo mốc gốc và đích 
    private bool isDurationTime(float timer, float offsetTime)
    {
        bool flag = false;
        // yield return new WaitForSeconds(4); // thời gian đợi là 4 giây

        if (timer > offsetTime) // timer mốc gốc, offsetTime là đích
        {
            this.timer = 0f;
            flag = true;
        }
        return flag;
    }

    private void setEnabledObjectsByTag(string tag)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            if (!gameObject.activeInHierarchy) // !gameObject.activeInHierarchy
            {
                gameObject.SetActive(true);
            }
        }
    }
}
