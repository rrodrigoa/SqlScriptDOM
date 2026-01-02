SELECT *
FROM input
TIMESTAMP BY EntryTime

SELECT *
FROM input
TIMESTAMP BY EntryTime OVER TollId, PartitionId

SELECT
  System.Timestamp(),
  eventType,
  eventValue
FROM input
TIMESTAMP BY (
  CASE eventType
    WHEN 'A' THEN timestampA
    WHEN 'B' THEN timestampB
    ELSE NULL
  END
)

SELECT
  System.Timestamp(),
  LicensePlate,
  State
FROM input
TIMESTAMP BY DATEADD(millisecond, epochtime, '1970-01-01T00:00:00Z')

SELECT *
FROM input
