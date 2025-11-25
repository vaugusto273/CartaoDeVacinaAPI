-- Test data
DELETE FROM VaccinationRecords;
DELETE FROM Users;
DELETE FROM Vaccines;
DELETE FROM sqlite_sequence
WHERE name = 'Users';
DELETE FROM sqlite_sequence
WHERE name = 'Vaccines';
DELETE FROM sqlite_sequence
WHERE name = 'VaccinationRecords';
PRAGMA foreign_keys = ON;
-- INSERIR USERS
INSERT INTO Users (Name, Age, Gender)
VALUES ('João da Silva', 28, 'Male'),
    ('Ana Paula', 17, 'Female'),
    ('Rogério Marcos', 32, 'Male'),
    ('Mariana Duarte', 25, 'Female'),
    ('Carlos Henrique', 41, 'Male');
-- INSERIR VACINAS
INSERT INTO Vaccines (VaccineName)
VALUES ('Hepatite B'),
    ('Tetra Viral'),
    ('Tríplice Bacteriana (DPT)'),
    ('Meningo C'),
    ('COVID-19');
-- REGISTROS DE JOÃO (UserID = 1)
INSERT INTO VaccinationRecords (
        UserID,
        VaccineID,
        DoseNumber,
        ApplicationDate,
        Notes
    )
VALUES (
        1,
        1,
        1,
        '2025-01-10',
        'Primeira dose Hepatite B.'
    ),
    (
        1,
        1,
        2,
        '2025-02-10',
        'Segunda dose Hepatite B.'
    ),
    (1, 5, 1, '2024-01-15', '1ª dose COVID.'),
    (1, 5, 2, '2024-02-15', '2ª dose COVID.'),
    (1, 5, 3, '2024-08-10', 'Reforço COVID.'),
    (1, 5, 4, '2025-01-05', '2º reforço COVID.'),
    (1, 5, 5, '2025-06-01', '3º reforço COVID.');
-- REGISTROS DE ANA PAULA (UserID = 2)
INSERT INTO VaccinationRecords (
        UserID,
        VaccineID,
        DoseNumber,
        ApplicationDate,
        Notes
    )
VALUES (
        2,
        2,
        1,
        '2024-04-12',
        'Tetra Viral – campanha escolar.'
    ),
    (2, 4, 1, '2024-05-20', 'Meningo C – 1ª dose.'),
    (2, 4, 2, '2024-06-20', 'Meningo C – 2ª dose.'),
    (
        2,
        1,
        1,
        '2025-01-15',
        'Hepatite B – início do esquema.'
    ),
    (2, 1, 2, '2025-02-15', 'Hepatite B – reforço.');
-- REGISTROS DE ROGÉRIO (UserID = 3)
INSERT INTO VaccinationRecords (
        UserID,
        VaccineID,
        DoseNumber,
        ApplicationDate,
        Notes
    )
VALUES (3, 5, 1, '2023-10-01', 'COVID – 1ª dose.'),
    (3, 5, 2, '2023-11-01', 'COVID – 2ª dose.'),
    (3, 5, 3, '2024-02-01', 'COVID – 3ª dose.'),
    (3, 3, 1, '2025-03-10', 'DPT – reforço.'),
    (3, 2, 1, '2025-04-10', 'Tetra Viral dose única.');
-- REGISTROS DE MARIANA DUARTE (UserID = 4)
INSERT INTO VaccinationRecords (
        UserID,
        VaccineID,
        DoseNumber,
        ApplicationDate,
        Notes
    )
VALUES (4, 1, 1, '2024-05-01', 'Hepatite B – 1ª dose.'),
    (4, 1, 2, '2024-06-01', 'Hepatite B – 2ª dose.'),
    (
        4,
        2,
        1,
        '2025-01-18',
        'Tetra Viral – dose única.'
    );
-- REGISTROS DE Carlos Henrique (UserID = 5)
INSERT INTO VaccinationRecords (
        UserID,
        VaccineID,
        DoseNumber,
        ApplicationDate,
        Notes
    )
VALUES (5, 3, 1, '2023-09-15', 'DPT – 1ª dose.'),
    (5, 3, 2, '2023-10-15', 'DPT – 2ª dose.'),
    (5, 3, 3, '2024-02-15', 'DPT – 3ª dose.'),
    (5, 4, 1, '2025-03-11', 'Meningo C – 1ª dose.'),
    (5, 5, 1, '2024-04-20', 'COVID – 1ª dose.');