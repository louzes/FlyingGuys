using UnityEngine;

public class BotController : MonoBehaviour
{
    public Transform targetPoint; // Целевая точка, к которой бот должен дойти
    public LayerMask obstacleLayer; // Слой препятствий

    public float movementSpeed = 5f; // Скорость перемещения бота
    public float avoidanceDistance = 2f; // Расстояние, на котором бот обнаруживает препятствия
    public float rotationSpeed = 5f; // Скорость поворота бота

    private void Update()
    {
        // Проверяем, есть ли целевая точка
        if (targetPoint != null)
        {
            // Получаем направление к целевой точке
            Vector3 direction = (targetPoint.position - transform.position).normalized;

            // Проверяем, есть ли препятствия на пути
            if (CheckObstacle())
            {
                // Если есть препятствие, находим новое направление для обхода
                direction = AvoidObstacle(direction);
            }

            // Поворачиваем бота в заданное направление
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Перемещаем бота вперед
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }

    // Проверка наличия препятствий впереди бота
    private bool CheckObstacle()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, avoidanceDistance, obstacleLayer))
        {
            // Если препятствие обнаружено, возвращаем true
            return true;
        }

        // Препятствий нет
        return false;
    }

    // Находим новое направление для обхода препятствия
    private Vector3 AvoidObstacle(Vector3 originalDirection)
    {
        Vector3 leftDirection = Quaternion.AngleAxis(-30, Vector3.up) * originalDirection;
        Vector3 rightDirection = Quaternion.AngleAxis(30, Vector3.up) * originalDirection;

        // Проверяем, есть ли препятствия в левом и правом направлениях
        bool obstacleLeft = Physics.Raycast(transform.position, leftDirection, avoidanceDistance, obstacleLayer);
        bool obstacleRight = Physics.Raycast(transform.position, rightDirection, avoidanceDistance, obstacleLayer);

        if (obstacleLeft && !obstacleRight)
        {
            // Если препятствие слева, поворачиваем направо
            return rightDirection;
        }
        else if (!obstacleLeft && obstacleRight)
        {
            // Если препятствие справа, поворачиваем налево
            return leftDirection;
        }
        else
        {
            // Если препятствия и слева, и справа, двигаемся назад
            return -originalDirection;
        }
    }
}
