using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{

    [SerializeField] GameObject[] waypoints;
    
    int currentWaypointIndex = 0;
    float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        // nếu khoảng cách vị trí giữa PlatForm và waypoint < 1 ( tức là vị trí của platform đã trùng với waypoint)
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position,transform.position) < .1f)
        {
            currentWaypointIndex++; // tăng index của waypoint để hường đến way point tiếp theo

            // nếu waypoint index lớn hoặc bảng kích thước mảng waypoint thì cập về 0, tức là nếu vị trí waypoint hiện là 0 khi platform chạm tới đây thì điều hướng tới vị trị waypoint 1 ( vì chỉ có 2 waypoint 2 đầu để định hướng di chuyển của platform nên sẽ di chuyển xung quang 2 điểm này)
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }


        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position,Time.deltaTime * speed); // thay đổi vị trí hiện tại của platform đến hướng của waypoint trong thời gian set up (di chuyển từ từ chứ không thay đổi vị trí ngay lập tức)


    }
}
