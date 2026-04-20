SELECT *
FROM input
TIMESTAMP BY ts
MATCH_RECOGNIZE (
    LIMIT Duration(minute, 1)
    MEASURES
        A.price AS start_price,
        LAST(B.price) AS end_price
    ONE ROW PER MATCH
    AFTER MATCH SKIP TO NEXT ROW
    PATTERN (A B)
    DEFINE
        A AS A.kind = 'A',
        B AS B.kind = 'B'
) AS mr;

SELECT *
FROM input
TIMESTAMP BY ts
MATCH_RECOGNIZE (
    PARTITION BY device
    LIMIT Duration(minute, 5)
    ALL ROWS PER MATCH
    AFTER MATCH SKIP PAST LAST ROW
    PATTERN ((A | B)+ C)
    DEFINE
        A AS A.kind = 'A',
        B AS B.kind = 'B',
        C AS C.kind = 'C'
) AS matches;

SELECT *
FROM input
TIMESTAMP BY ts
MATCH_RECOGNIZE (
    LIMIT Duration(minute, 2)
    ONE ROW PER MATCH
    AFTER MATCH SKIP TO FIRST B
    PATTERN (A B{2,} C?)
    DEFINE
        A AS A.kind = 'A',
        B AS B.kind = 'B',
        C AS C.kind = 'C'
) AS first_skip;

SELECT *
FROM input
TIMESTAMP BY ts
MATCH_RECOGNIZE (
    LIMIT Duration(minute, 2)
    ONE ROW PER MATCH
    AFTER MATCH SKIP TO LAST C
    PATTERN ((A B){2} C{,3})
    DEFINE
        A AS A.kind = 'A',
        B AS B.kind = 'B',
        C AS C.kind = 'C'
) AS last_skip;
