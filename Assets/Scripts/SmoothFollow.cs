using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {
	public GameObject target,target1;
	public float distance = 10.0f;      //与目标对象的距离
	public float height = 5.0f;         //与目标对象的高度差
	public float heightDamping = 2.0f;  //高度变化中的阻尼参数
	public float rotationDamping = 30.0f;//绕y轴的旋转中的阻尼参数
    public GameObject Timg;
    private int flag = 0;
	void Start () {
        Timg.SetActive(false);
	}

	void Update()
	{
        if (Input.GetMouseButtonDown(1)) {
            flag = (flag == 0) ? 1 : 0;
        }
        // 如果目标对象不存在将跳出方法
		if (!target)
			return;
	

        if (flag == 0)
        {
            Timg.SetActive(false);
            float wantedRotationAngle = target.transform.eulerAngles.y;
            float wantedHeight = target.transform.position.y + height;

            // 摄像机当前的旋转角度及高度
            float currentRotationAngle = transform.eulerAngles.y;
            float currentHeight = transform.position.y;

            // 计算摄像机绕y轴的旋转中的阻尼
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

            // 计算摄像机高度变化中的阻尼
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            // 转换成旋转角度
            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            // 摄像机距离目标背后的距离
            transform.position = target.transform.position;
            transform.position -= currentRotation * Vector3.forward * distance;

            // 设置摄像机的高度
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z); ;

            // 摄像机一直注视目标
            transform.LookAt(target.transform);

        }
        else
        {
            Timg.SetActive(true);
            float wantedRotationAngle = target1.transform.eulerAngles.y;
            float wantedHeight = target1.transform.position.y ;

            // 摄像机当前的旋转角度及高度
            float currentRotationAngle = transform.eulerAngles.y;
            float currentHeight = transform.position.y;

            // 计算摄像机绕y轴的旋转中的阻尼
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

            // 计算摄像机高度变化中的阻尼
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime*300);

            // 转换成旋转角度
            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            // 摄像机距离目标背后的距离
            transform.position = target1.transform.position;
            transform.position -= currentRotation * Vector3.forward * distance*0.1f;

            // 设置摄像机的高度
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z); ;

            // 摄像机一直注视目标
            transform.LookAt(target1.transform);
        }
    }
}
