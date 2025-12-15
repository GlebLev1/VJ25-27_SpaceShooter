using UnityEngine;
using System.Collections;

public class Player : Damageble
{
    [Header("Movimento e tiro")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float pewpewRate = 1f;   // intervalo base

    [Header("Dano do tiro")]
    [SerializeField] private int bulletDamage = 1;

    [Header("Vidas")]
    [SerializeField] private int maxLives = 3;
    private int currentLives;
    public int CurrentLives => currentLives;

    private Vector3 position;
    private Vector3 spawnPoint;

    // Fire rate/dano atuais (podem ser buffados)
    private float currentPewpewRate;
    private int currentDamage;

    // Power up temporário
    public float powerupTimeLeft { get; private set; }
    [SerializeField] private float powerupDuration = 30f;

    private Coroutine shootRoutine;
    private Coroutine powerupRoutine;

    void Start()
    {
        currentLives = maxLives;
        spawnPoint = transform.position;

        currentPewpewRate = pewpewRate;
        currentDamage = bulletDamage;

        shootRoutine = StartCoroutine(ShootLoop());
    }

    void Update()
    {
        Movement();
    }

    void FixedUpdate()
    {
        Vector3 positionInBetween =
            Vector3.Lerp(transform.position, position, speed * Time.fixedDeltaTime);
        transform.position = positionInBetween;
    }

    IEnumerator ShootLoop()
    {
        while (true)
        {
            PewPew();
            yield return new WaitForSeconds(currentPewpewRate);
        }
    }

    void PewPew()
    {
        if (bullet == null) return;

        GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
    }

    void Movement()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        if (Input.touchSupported && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(
                touch.position.x,
                touch.position.y,
                cam.nearClipPlane
            ));

            worldPos.z = transform.position.z;
            position = worldPos;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                cam.nearClipPlane
            ));

            mousePos.z = transform.position.z;
            position = mousePos;
        }
        else
        {
            position = transform.position;
        }
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
    public override void Die()
    {
        currentLives--;

        if (currentLives > 0)
        {
            health = 3;
            transform.position = spawnPoint;
        }
        else
        {
            base.Die();
        }
    }
    public void Increment(StatType type)
    {
        if (powerupRoutine != null)
            StopCoroutine(powerupRoutine);

        powerupRoutine = StartCoroutine(PowerupRoutine(type));
    }
    IEnumerator PowerupRoutine(StatType type)
    {
        
        switch (type)
        {
            case StatType.Damage:
                currentDamage = bulletDamage * 2;      
                break;

            case StatType.ASPD:
                currentPewpewRate = pewpewRate * 0.5f; 
                break;
        }

        powerupTimeLeft = powerupDuration;
        while (powerupTimeLeft > 0f)
        {
            powerupTimeLeft -= Time.deltaTime;
            yield return null;
        }
        currentDamage = bulletDamage;
        currentPewpewRate = pewpewRate;
        powerupTimeLeft = 0f;
        powerupRoutine = null;
    }
}
