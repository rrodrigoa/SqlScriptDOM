WITH Windowed AS
(
    SELECT *
    FROM input
    TIMESTAMP BY ts
    WINDOW BY sensorId, TumblingWindow(Duration(minute, 1))
    COMPUTE avg = AVG(value)
    WHERE value > avg
)
SELECT *
FROM Windowed;
