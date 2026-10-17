using UnityEngine;

public class ScrollLayer : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float parallaxEffect = 0.5f;

    private float spriteWidth;
    private Vector3 lastCamPos;

    private Transform[] backgrounds = new Transform[2];

    private void Start()
    {
        if (transform.childCount != 2)
        {
            Debug.LogError($"ParallaxScrollLayer only works with 2 Bg children, Fix '{name}' GameObject");
            return;
        }

        for (int i = 0; i < 2; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        if (cam == null) cam = Camera.main.transform;
        lastCamPos = cam.position;

        spriteWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void Update()
    {
        Vector3 deltaMovement = cam.position - lastCamPos;
        transform.position += new Vector3(deltaMovement.x * parallaxEffect, 0, 0);
        lastCamPos = cam.position;

        foreach (var bg in backgrounds)
        {
            float camDistance = cam.position.x - bg.position.x;
            if (Mathf.Abs(camDistance) >= spriteWidth)
            {
                float offset = (camDistance > 0) ? spriteWidth * 2f : -spriteWidth * 2f;
                bg.position += new Vector3(offset, 0, 0);
            }
        }
    }
}
