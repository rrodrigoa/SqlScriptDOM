WITH Windowed AS
(
    SELECT *
    FROM input
    TIMESTAMP BY ts
WITH WINDOW TumblingWindow(Duration(minute, 1))
    COMPUTE avg = AVG(value)
    WHERE value > avg
)
SELECT *
FROM Windowed;
