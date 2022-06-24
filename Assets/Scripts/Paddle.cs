using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    public float minRelativePosX = 1f;  // assumes paddle size of 1 relative unit
    
    [SerializeField]
    public float maxRelativePosX = 15f;  // assumes paddle size of 1 relative unit
    
    [SerializeField]
    public float fixedRelativePosY = .64f;  // paddle does not move on the Y directiob
    
    // Unity units of the WIDTH of the screen (e.g. 16)
    [SerializeField]
    public float screenWidthUnits = 16;

    [SerializeField] float _speed = 10f;

    public float speedMultiplier = 1f;

    

    // Start is called before the first frame update
    void Start()
    {
        //float startPosX = ConvertPixelToRelativePosition(screenWidthUnits / 2, Screen.width);
        //transform.position = GetUpdatedPaddlePosition(startPosX);

        Vector3 startPos = new Vector2((minRelativePosX + maxRelativePosX) / 2, 1);
        transform.position = startPos;
    } 

    // Update is called once per frame
    void Update()
    {
        //var relativePosX = ConvertPixelToRelativePosition(pixelPosition: Input.mousePosition.x, Screen.width);
        //transform.position = GetUpdatedPaddlePosition(relativePosX);

        float horizontal = Input.GetAxis("Horizontal") * _speed * speedMultiplier * Time.deltaTime;
        transform.Translate(Vector3.right * horizontal);

        if (transform.position.x < minRelativePosX)
        {
            transform.position = new Vector2(minRelativePosX, transform.position.y);
        }
        if (transform.position.x > maxRelativePosX)
        {
            transform.position = new Vector2(maxRelativePosX, transform.position.y);
        }
        
    }

    public Vector2 GetUpdatedPaddlePosition(float relativePosX)
    {
        // clamps the X position
        float clampedRelativePosX = Mathf.Clamp(relativePosX, minRelativePosX, maxRelativePosX);
        
        Vector2 newPaddlePosition = new Vector2(clampedRelativePosX, fixedRelativePosY);
        return newPaddlePosition;
    }
    
    public float ConvertPixelToRelativePosition(float pixelPosition, int screenWidth)
    { 
        var relativePosition = pixelPosition/screenWidth * screenWidthUnits;
        return relativePosition;
    }

}