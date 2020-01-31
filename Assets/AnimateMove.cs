using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateMove : MonoBehaviour
{
	public MovingFrisk mF;

	public void cS()
	{
		mF.changeScene = true;
	}

	public void moveUp()
	{
		mF.moveUp = true;
	}

	public void moveDown()
	{
		mF.moveDown = true;
	} 

	public void moveLeft()
	{
		mF.moveLeft = true;
	}

	public void moveRight()
	{
		mF.moveRight = true;
	}

	public void stopMoveUp()
	{
		mF.moveUp = false;
	}

	public void stopMoveDown()
	{
		mF.moveDown = false;
	}

	public void stopMoveLeft()
	{
		mF.moveLeft = false;
	}

	public void stopMoveRight()
	{
		mF.moveRight = false;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
