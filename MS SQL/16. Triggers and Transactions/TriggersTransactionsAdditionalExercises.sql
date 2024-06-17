
--Triggers Transactions Additional Exercises
--1


select SUBSTRING(Email,CHARINDEX('@',Email)+1,Len(Email) - CHARINDEX('@',Email)+1) as [Email Provider],
Count(*) as [Number of Users]
from Users
Group by SUBSTRING(Email,CHARINDEX('@',Email)+1,Len(Email) - CHARINDEX('@',Email)+1)
ORDER BY [Number of Users] desc, [Email Provider]

--2
SELECT g.[Name] AS Game,
gt.[Name] AS [Game Type],
u.Username,
ug.[Level],
ug.Cash,
c.[Name] as [Character]
FROM
Users u
Join UsersGames ug ON ug.UserId = u.Id 
Join Games g ON  ug.GameId = g.Id
JOIN GameTypes gt ON gt.Id = g.GameTypeId
Join Characters c ON c.Id = ug.CharacterId
ORDER BY ug.[Level] DESC,
u.Username ASC,
Game


--3
SELECT u.Username,
g.[Name] as Game,
Count(ugi.ItemId) AS [Items Count],
SUM(i.Price) as [Items Price]
FROM
Users as u
JOIN UsersGames ug ON ug.UserId = u.Id
JOIN Games g ON ug.GameId = g.Id
JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
JOIN Items i ON ugi.ItemId = i.Id
GROUP BY u.Username, g.[Name]
HAVING Count(ugi.ItemId) >=10
ORDER BY [Items Count] DESC, [Items Price] DESC, u.Username ASC


--4


--5
WITH AvgStatistics AS (
    SELECT 
        AVG(Mind) AS AvgMind,
        AVG(Luck) AS AvgLuck,
        AVG(Speed) AS AvgSpeed
    FROM [Statistics]
)
SELECT 
    i.[Name],
    i.[Price],
    i.MinLevel,
    st.Strength,
    st.Defence,
    st.Speed,
    st.Luck,
    st.Mind
FROM 
    Items i
JOIN 
    [Statistics] st ON st.Id = i.StatisticId
Where 
    st.Mind > (Select AvgMind from AvgStatistics) AND
    st.Luck > (Select AvgLuck from AvgStatistics) AND
    st.Speed > (Select AvgSpeed from AvgStatistics)
GROUP BY 
    i.[Name], i.[Price], i.MinLevel, st.Strength, st.Defence, st.Speed, st.Luck, st.Mind
ORDER BY 
    i.[Name] ASC;


--6
SELECT i.[Name] AS Item,
i.Price,
i.MinLevel,
gt.[Name] AS [Forbidden Game Type]
FROM Items i
LEFT JOIN GameTypeForbiddenItems  gfi ON gfi.ItemId = i.Id
LEFT JOIN GameTypes gt ON gfi.GameTypeId= gt.Id
ORDER BY [Forbidden Game Type] DESC,
Item ASC


--7
Declare @userId int = (Select Id from Users where Username = 'Alex')
Declare @gameId int = (Select Id from Games where [Name] = 'Edinburgh')
Declare @userGameId int = (Select Id from UsersGames where UserId = @userId and GameId = @gameId)

Declare @itemId1 int = (Select Id from Items where [Name] = 'Blackguard')
Declare @itemId2 int = (Select Id from Items where [Name] = 'Bottomless Potion of Amplification')
Declare @itemId3 int = (Select Id from Items where [Name] = 'Eye of Etlich (Diablo III)')
Declare @itemId4 int = (Select Id from Items where [Name] = 'Gem of Efficacious Toxin')
Declare @itemId5 int = (Select Id from Items where [Name] = 'Golden Gorget of Leoric')
Declare @itemId6 int = (Select Id from Items where [Name] = 'Hellfire Amulet')

Declare @totalAmount Decimal(18,2) = (
Select Sum(Price) from Items
where Id in (@itemId1,@itemId2,@itemId3,@itemId4,@itemId5,@itemId6)
)


Update UsersGames
Set Cash-= @totalAmount
Where Id = @userGameId

Insert into UserGameItems (ItemId,UserGameId)
Values (@itemId1,@userGameId),
(@itemId2,@userGameId),
(@itemId3,@userGameId),
(@itemId4,@userGameId),
(@itemId5,@userGameId),
(@itemId6,@userGameId)


select u.Username,
g.[Name],
ug.Cash,
i.[Name] AS [Item Name]
from Users u
JOIN UsersGames ug ON ug.UserId = u.Id
JOIN Games g ON ug.GameId = g.Id
JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
JOIN Items i ON ugi.ItemId = i.Id
where g.Id = @gameId
ORDER BY i.[Name]


--8 
Use Geography

SELECT p.PeakName, 
m.MountainRange AS Mountain,
p.Elevation
FROM Mountains m
JOIN Peaks p ON p.MountainId = m.Id
ORDER BY Elevation DESC, p.PeakName ASC

--9
SELECT p.PeakName, 
m.MountainRange AS Mountain,
c.CountryName,
cnt.ContinentName
FROM Mountains m
JOIN Peaks p ON p.MountainId = m.Id
JOIN MountainsCountries mc ON mc.MountainId = m.Id
JOIN Countries c ON mc.CountryCode = c.CountryCode
JOIN Continents cnt ON cnt.ContinentCode = c.ContinentCode
ORDER BY p.PeakName ASC, c.CountryName ASC


--10
SELECT c.CountryName,
cnt.ContinentName,
CASE 
		WHEN Count(r.Id) > 0 THEN  COUNT(r.ID)
		ELSE 0
END AS [RiversCount],
CASE 
		WHEN Count(r.Id) > 0 THEN  SUM(r.[Length])
		ELSE 0
END AS [TotalLength]
FROM Countries c
LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers r ON r.Id = cr.RiverId
LEFT JOIN Continents cnt ON cnt.ContinentCode = c.ContinentCode
GROUP BY c.CountryName,cnt.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, c.CountryName ASC


--11
SELECT cu.CurrencyCode,
cu.[Description] AS Currency,
COUNT(co.CountryCode) AS NumberOfCountries
FROM Countries AS co
RIGHT JOIN Currencies AS cu ON co.CurrencyCode = cu.CurrencyCode
GROUP BY cu.CurrencyCode, cu.[Description]
ORDER BY NumberOfCountries DESC, Currency ASC

--12
SELECT co.ContinentName,
SUM(c.AreaInSqKm) AS CountriesArea,
SUM(CAST(c.[Population] AS bigint)) AS CountriesPopulation
FROM Countries AS c
JOIN Continents AS co ON co.ContinentCode = c.ContinentCode
GROUP BY co.ContinentName
ORDER BY CountriesPopulation DESC



--13
CREATE TABLE Monasteries(
Id int PRIMARY KEY IDENTITY(1,1),
[Name] varchar(255) NOT NULL,
CountryCode char(2) FOREIGN KEY REFERENCES Countries(CountryCode)
)

INSERT INTO Monasteries([Name], CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

--ALTER TABLE Countries
--Alter Column IsDeleted BIT 

--Update Countries 
--Set IsDeleted = 0



UPDATE c
SET c.IsDeleted = 1
FROM Countries AS c
JOIN (

    SELECT cr.CountryCode
    FROM CountriesRivers AS cr
    GROUP BY cr.CountryCode
    HAVING COUNT(cr.RiverId) > 3
) AS subquery ON c.CountryCode = subquery.CountryCode;

SELECT m.[Name] AS Monastery,
c.CountryName
FROM Monasteries AS m
JOIN Countries AS c ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted =0
ORDER BY Monastery



--14
Update Countries 
SET CountryName = 'Burma'
where CountryName = 'Myanmar'

Insert into Monasteries([Name],CountryCode)
Select 'Hanga Abbey', CountryCode
from Countries
Where CountryName = 'Tanzania'


Insert into Monasteries([Name],CountryCode)
Select 'Myin-Tin-Daik',CountryCode
from Countries
Where CountryName = 'Myanmar'

/*DELETE FROM Monasteries
Where [Name] = 'Hanga Abbey'*/

/*DELETE FROM Monasteries
Where [Name] = 'Myin-Tin-Daik'*/

SELECT 
co.ContinentName,
c.CountryName,
COUNT(m.Id) AS [MonasteriesCount]
FROM Countries AS c
LEFT JOIN Continents AS co ON c.ContinentCode = co.ContinentCode
LEFT JOIN Monasteries AS m ON m.CountryCode = c.CountryCode 
WHERE c.IsDeleted = 0
GROUP BY co.ContinentName,c.CountryName
ORDER BY MonasteriesCount DESC, c.CountryName ASC

SELECT * FROM Monasteries
SELECT * FROM Countries
SELECT * FROM Currencies
SELECT * FROM CountriesRivers
SELECT * FROM Rivers
SELECT * FROM Continents