SELECT *
FROM input
TIMESTAMP BY ts
WINDOW BY category, TumblingWindow(Duration(minute, 1))
COMPUTE avg = AVG(value), std = STDDEV(value)
WHERE (value - avg) / std > 1.7;
