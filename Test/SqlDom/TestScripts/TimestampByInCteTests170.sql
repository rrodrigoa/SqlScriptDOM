WITH Timestamped AS
(
    SELECT *
    FROM input
    TIMESTAMP BY EntryTime
)
SELECT *
FROM Timestamped;
