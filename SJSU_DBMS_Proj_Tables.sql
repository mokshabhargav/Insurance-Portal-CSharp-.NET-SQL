use SJSU_DBMS_Proj

--use master

/*------------CREATE TABLES--------------------*/
create table Beneficiary(
BenefID int identity(20010,1) Primary Key,
BenefSsn bigint Unique,
BenefFName varchar(20),
BenefMName varchar(20),
BenefLName varchar(20),
Age int,
Gender char,
EmailID varchar(30),
ContactNo bigint
)
alter table Beneficiary add password varchar(20)
alter table Beneficiary drop column BenefMName

create table Hospital(
HospitalID int identity(30010,1) Primary Key,
HospitalName varchar(50),
Speciality varchar(30),
Address varchar(100)
)

create table Policy(
PolicyID int identity(40010,1) Primary Key,
PolicyName varchar(30),
PolicyPremium int,
MaximumLimit int,
Benefits varchar(100)
)

Create table EnrolledPolicy(
BenefID int Foreign key References Beneficiary(BenefID),
PolicyID int Foreign key References Policy(PolicyID),
FromDate date,
ToDate date
)

create table AdmittedHospitals(
BenefID int Foreign key References Beneficiary(BenefID),
HospID int Foreign key References Hospital(HospitalID)
)

create table InsAdmin(
AdminID int identity(90100,10) Primary Key,
Password varchar (20)
)

create table Claim(
ClaimID int identity(10010,1) Primary Key,
BeneficiaryID int Foreign key References Beneficiary(BenefID),
ClaimedOnPID int Foreign key References Policy(PolicyID),
ClaimedInHID int Foreign key References Hospital(HospitalID),
ClaimType varchar(20),
ClaimRaisedOn datetime,
ClaimAmount int,
ClaimStatus varchar(20),
ManagedByAdminID int Foreign key References InsAdmin(AdminID)
)

create table AllMessages(
BeneficiaryID int Foreign key References Beneficiary(BenefID),
MsgSubject varchar(100),
TimeOfMessage datetime
)

create table AllNotifications(
ClaimID int,
BeneficiaryID int,
Notification varchar(100),
TimeOfNotification datetime
)


/*----------------------------------------------------------*/

/*
select * from Beneficiary
select * from Hospital
select * from Policy
select * from EnrolledPolicy
select * from AdmittedHospitals
select * from InsAdmin
select * from Claim
select * from AllMessages
select * from AllNotifications

--drop table Beneficiary
--drop table Hospital
--drop table Policy
--drop table EnrolledPolicy
--drop table AdmittedHospitals
--drop table InsAdmin
--drop table Claim
--drop table AllMessages
--drop table AllNotifications
*/

/*
Insert into Beneficiary(BenefSsn,BenefFName,BenefLName,Age,Gender,EmailID,ContactNo) values(010011638,'Moksha Bhargav','Vanam',24,'M','mokshabhargav@gmail.com','4086806348')
update Beneficiary set password='password' where BenefID=20010

Insert into Hospital(HospitalName,Speciality,Address) values('Napa State Hospital','Mental Health','Napa, California, United States')
Insert into Hospital(HospitalName,Speciality,Address) values('VA Palo Alto Health Care System','Veteran Admin','Palo Alto, California, United States')
Insert into Hospital(HospitalName,Speciality,Address) values('Long Beach Memorial Medical Ctr','University/Teaching','Long Beach, California, United States')
Insert into Hospital(HospitalName,Speciality,Address) values('Good Samaritan Hospital','General Acute Care','San Jose, California, United States')
Insert into Hospital(HospitalName,Speciality,Address) values('Naval Medical Center San Diego','Military','San Diego, California, United States')

Insert into Policy(PolicyName,PolicyPremium,MaximumLimit,Benefits) values('Policy1',1000,1000,'fulfilled through hospitals, doctors, and other providers with which the HMO has a contract')

Insert into EnrolledPolicy(BenefID,PolicyID,FromDate,ToDate) values(20010,40010,'2014-01-01','2015-01-01')

Insert into AdmittedHospitals(BenefID,HospID) values(20010,30022)
Insert into AdmittedHospitals(BenefID,HospID) values(20010,30016)

Insert into InsAdmin(Password) values ('bhargav')

Insert into Claim(BeneficiaryID,ClaimedOnPID,ClaimedInHID,ClaimType,ClaimRaisedOn,ClaimAmount,ClaimStatus,ManagedByAdminID) values(20010,40010,30017,'Death Claim','2014-11-18 01:05:00 ',1000,'In Progress',90100)
Insert into Claim(BeneficiaryID,ClaimedOnPID,ClaimedInHID,ClaimType,ClaimRaisedOn,ClaimAmount,ClaimStatus,ManagedByAdminID) values(20010,40010,30018,'Maturity Claim',getdate(),500,'In Progress',90100)

Insert into AllMessages(BeneficiaryID,MsgSubject,TimeOfMessage) values(20010,'BenefID: 20010 Subject',getdate())

Insert into AllNotifications(BeneficiaryID,Notification,TimeOfNotification) values(20010,'BenefID: 20010 Notification',getdate())

*/

/*--------------------------------------------------------------------*/

/*--------------------------ALL ELSE-----------------------------------------*/

select ClaimID,HospitalName,ClaimRaisedOn,ClaimAmount,ClaimStatus,PolicyName,ClaimType from Claim,Hospital,Policy
where HospitalID=ClaimedInHID and PolicyID=ClaimedOnPID and BeneficiarySsn=010011638
select * from Claim
select * from Policy
select * from Beneficiary
select * from Hospital

exec spBenefClaims 010011638

create table tblCountry(

)
select * from Claim
delete from Claim where ClaimID in(10010,10011)
delete from InsAdmin where AdminID=90110