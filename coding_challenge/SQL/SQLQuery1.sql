create database CM_Db
use CM_DB

CREATE TABLE Crime (
	CrimeID INT PRIMARY KEY,
	IncidentType VARCHAR(255),
	IncidentDate DATE,
	Cr_Location VARCHAR(255),
	Cr_Description TEXT,
	Cr_Status VARCHAR(20)
)

CREATE TABLE Suspect (
	SuspectID INT PRIMARY KEY,
	CrimeID INT,
	Sus_Name VARCHAR(255),
	Sus_Description TEXT,
	CriminalHistory TEXT,
	FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID)
)

CREATE TABLE Victim (
	VictimID INT PRIMARY KEY,
	CrimeID INT,
	Vic_Name VARCHAR(255),
	ContactInfo VARCHAR(255),
	Injuries VARCHAR(255),
	FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID)
)

INSERT INTO Crime (CrimeID, IncidentType, IncidentDate, cr_Location, cr_Description, cr_Status)
VALUES
(1, 'Robbery', '2023-09-15', '123 Main St, Cityville', 'Armed robbery at a convenience store', 'Open'),
(2, 'Homicide', '2023-09-20', '456 Elm St, Townsville', 'Investigation into a murder case', 'UnderInvestigation'),
(3, 'Theft', '2023-09-10', '789 Oak St, Villagetown', 'Shoplifting incident at a mall', 'Closed')

INSERT INTO Victim (VictimID, CrimeID, vic_Name, ContactInfo, Injuries)
VALUES
(1, 1, 'John Doe', 'johndoe@example.com', 'Minor injuries'),
(2, 2, 'Jane Smith', 'janesmith@example.com', 'Deceased'),
(3, 3, 'Alice Johnson', 'alicejohnson@example.com', 'None')

INSERT INTO Suspect (SuspectID, CrimeID, sus_Name, sus_Description, CriminalHistory)
VALUES
(1, 1, 'Robber 1', 'Armed and masked robber', 'Previous robbery convictions'),
(2, 2, 'Unknown', 'Investigation ongoing', NULL),
(3, 3, 'Suspect 1', 'Shoplifting suspect', 'Prior shoplifting arrests');



--Tasks
-- Q1
select * from crime 
where Cr_Status = 'open'

--Q2
select count(crimeid) as Total_incidents from crime  

--Q3
select incidenttype from Crime 
group by IncidentType

--Q4
select * from crime 
where IncidentDate between '2023-09-01' and '2023-09-10'

--Q5
--added column to improve the output 
alter table victim add vic_age int

update Victim set vic_age = 34 where VictimID = 1 
update Victim set vic_age = 45 where VictimID = 3
update Victim set vic_age = 22 where VictimID = 2


select v.* from victim v 
order by v.vic_age desc

--Q6
select avg(vic_age) as average_age from Victim


--Q7
select incidenttype, count(incidenttype) as incident_count from crime 
group by IncidentType ,Cr_Status
having Cr_Status = 'open' 


--Q8
select * from Victim where Vic_Name like '%doe%'

--Q9

select v.vic_name as names from Victim v join Crime c 
on c.CrimeID = v.CrimeID 
where c.Cr_Status = 'open' or c.Cr_Status = 'closed'

--Q10

select c.incidenttype from crime c join Victim v
on c.CrimeID = v.CrimeID 
where v.vic_age = 30 or v.vic_age = 35 

--there is no person age is involved in 30 or 35 hence there is no output  

--Q11

select v.* from Victim v join Crime c on c.CrimeID = v.CrimeID 
where c.Incidenttype = 'robbery'


--Q12

select incidenttype from crime 
group by IncidentType , Cr_Status
having Cr_Status= 'open' and count(cr_status) > 1 

select * from Crime

--there is no case has more than one open status hence there is no output

--Q13
update Suspect set Sus_Name = 'john doe' where CrimeID = 3
update Suspect set Sus_Name ='mathew daniel' where CrimeID =1
update Suspect set Sus_Name ='mark antony' where CrimeID =2

select c.*,s.* from Suspect s join Victim v 
on s.Sus_Name = v.Vic_Name 
join Crime c on s.CrimeID = c.CrimeID

--Q14

select c.* ,v.*,s.* from crime c 
join Suspect s on c.CrimeID =s.CrimeID 
join Victim v on v.CrimeID = c.CrimeID

--Q15
--added a age table for suspect to improve the understanding of O/P

alter table suspect add sus_age int
update Suspect set sus_age = 34 where SuspectID = 3
update Suspect set sus_age = 49 where SuspectID = 2
update Suspect set sus_age = 26 where SuspectID = 1

select c.incidenttype ,c.IncidentDate from crime c 
join Suspect s on s.CrimeID = c.CrimeID 
join Victim v on v.CrimeID = s.CrimeID
where s.sus_age > v.vic_age

--Q16

select s.Sus_Name from Suspect s 
join Victim v on v.CrimeID = s.CrimeID or v.Vic_Name = s.Sus_Name
group by s.Sus_Name , v.Vic_Name
having s.Sus_Name = v.Vic_Name or count(s.Sus_Name) > 1 or count(v.vic_name) > 1


--Q17
select c.* from crime c join Suspect s
on c.CrimeID = s.CrimeID 
where s.SuspectID is null

-- Every crime has their suspect hence there is empty output

--Q18
select * from crime 
where IncidentType = 'robbery' or 
	IncidentType = any(select IncidentType from crime where IncidentType = 'homicide') 

--Q19

select c.*,s.SuspectID,s.Sus_Name ,s.Sus_Description ,s.sus_age from crime c join Suspect s 
on s.CrimeID = c.CrimeID 

--Q20

select s.*,c.IncidentType from Suspect s join crime c 
on s.CrimeID = c.CrimeID 
where c.IncidentType = 'robbery' or c.IncidentType = 'assault'

