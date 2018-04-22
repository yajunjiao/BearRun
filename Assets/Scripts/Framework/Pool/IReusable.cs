using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReusable {

    //取出
    void OnSpawn();

    //回收
    void OnUnSpawn();
	
}
