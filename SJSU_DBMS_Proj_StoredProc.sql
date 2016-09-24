use SJSU_DBMS_PROJ

/*---------------------STORED PROCEDURES------------------------*/
/*------------USER LOGIN TABLE and STORED PROC---------------------------*/
create table tblUserLogin(
username varchar(20),
password varchar(20)
)

alter procedure spLoginCheck
@username int,
@password varchar(20)
as
begin
declare @out int;
set @out=0;
if exists (select COUNT(*) from Beneficiary,InsAdmin where (BenefID=@username or AdminID=@username) and (Beneficiary.password=@password or InsAdmin.Password=@password))
begin
set @out=1
end
if (@username like '200%')
begin
set @out=1
end
else if (@username like '901%')
begin
set @out=2
end
return @out
end
exec spLoginCheck 90100,'bhargav'

alter trigger trgrAfterInsert on Claim
for insert
as
	
declare @ClaimID int;
declare @BeneficiaryID int;
declare @Notification varchar(100);
declare @claim int;
declare @benef int;

select @ClaimID=i.ClaimID from inserted i;	
select @BeneficiaryID=i.BeneficiaryID from inserted i;		

set @claim=@ClaimID;
set @benef=@BeneficiaryID;
set @Notification='Raised a Claim: by BeneficiaryID';	

insert into AllNotifications(ClaimID,BeneficiaryID,Notification,TimeOfNotification) values(@claim,@benef,@Notification,getdate()) 

alter table Claim enable trigger trgrAfterInsert

alter trigger trgrAfterUpdate on Claim
for update
as
	
declare @ClaimID int;
declare @BeneficiaryID int;
declare @ClaimStatus varchar(20);
declare @Notification varchar(100);

	select @ClaimID=i.ClaimID from inserted i;	
	select @BeneficiaryID=i.BeneficiaryID from inserted i;	
	select @ClaimStatus=i.ClaimStatus from inserted i;	
	
	if update(ClaimID)
		set @Notification='Updated ClaimID: of BeneficiaryID to Status:'+@ClaimStatus;
	insert into AllNotifications(Notification,TimeOfNotification) values(@Notification,getdate())
	
alter table Claim enable trigger trgrAfterUpdate



insert into tblUserLogin values('bhargav','bhargav')
select * from tblUserLogin

exec spLoginCheck 'bhargav','bhargav'

create procedure spUserRegistration
@BenefSsn bigint,
@BenefFName varchar(20),
@BenefLName varchar(20),
@Age int,
@Gender char,
@EmailID varchar(30),
@ContactNo bigint,
@password varchar(20),
@BenefID int output
as
begin
insert into Beneficiary(BenefSsn,BenefFName,BenefLName,Age,Gender,EmailID,ContactNo,password)
values(@BenefSsn,@BenefFName,@BenefLName,@Age,@Gender,@EmailID,@ContactNo,@password)
select BenefID from Beneficiary where BenefSsn=@BenefSsn
end

/*--------------------------------------------------------------------*/
/*------------ADD/UPDATE/DELETE HOSPITALS STORED PROC---------------------------*/

create procedure spListOfHospitals
as
begin
select HospitalID,HospitalName,Speciality,Address from Hospital
end

create procedure spAdminListOfHospitals
as
begin
select HospitalID,HospitalName,Speciality,Address from Hospital
end

create procedure spAdminManageHospitals
@HospitalID int,
@HospitalName varchar(50),
@Speciality varchar(30),
@Address varchar(100),
@flag varchar(10)
as
begin
if (@flag='Insert')
begin
exec spAddHospital @HospitalName,@Speciality,@Address
end
else if (@flag='Update')
begin
exec spUpdateHospital @HospitalID,@HospitalName,@Speciality,@Address
end
else if (@flag='Delete')
begin
exec spDeleteHospital @HospitalID
end
end

exec spAdminManageHospitals 30010,'Napa Country Hospital','Mental Health','Napa, California, United States','Update'
exec spAdminManageHospitals 30014,'Naval Child Care Center San Diego','Military','San Diego, California, United States','Update'
exec spAdminManageHospitals 30011,'VA Palo Alto Child Care System','Veteran Admin','Palo Alto, California, United States','Update'
exec spAdminManageHospitals 30012,'CSU Long Beach Memorial Medical Ctr','University/Teaching','Long Beach, California, United States','Update'
exec spAdminManageHospitals 30013,'New Samaritan Hospital','General Acute Care','San Jose, California, United States','Update'

select * from Hospital
Delete from AdmittedHospitals where HospID=30010
Delete from Claim where ClaimedInHID=30010
delete from Hospital where HospitalID=30010

create procedure spAddHospital
@HospitalName varchar(50),
@Speciality varchar(30),
@Address varchar(100)
as
begin
Insert into Hospital(HospitalName,Speciality,Address) values(@HospitalName,@Speciality,@Address)
end

create procedure spUpdateHospital
@HospitalID int,
@HospitalName varchar(50),
@Speciality varchar(30),
@Address varchar(100)
as
begin
Update Hospital set HospitalName=@HospitalName,Speciality=@Speciality,Address=@Address where HospitalID=@HospitalID
end

alter procedure spDeleteHospital
@HospitalID int
as
begin
BEGIN TRY
BEGIN TRANSACTION
Delete from AdmittedHospitals where HospID=@HospitalID
Delete from Claim where ClaimedInHID=@HospitalID
Delete from Hospital where HospitalID=@HospitalID
COMMIT TRANSACTION
PRINT 'Transaction committed'
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
PRINT 'Transaction rolled back'
END CATCH
end

/*--------------------------------------------------------------------*/
/*------------Admin Messages and Notifications STORED PROC---------------------------*/

alter procedure spAdminMessages
as
begin
select BeneficiaryID,MsgSubject,TimeOfMessage from AllMessages
end

create procedure spAdminNotifications
as
begin
select ClaimID,BeneficiaryID,Notification,TimeOfNotification from AllNotifications
end

/*--------------------------------------------------------------------*/
/*------------Beneficiary Messages and Notifications STORED PROC---------------------------*/

create procedure spBenefMessages
@BeneficiaryID int
as
begin
select MsgSubject,TimeOfMessage from AllMessages where BeneficiaryID=@BeneficiaryID
end

create procedure spBenefNotifications
@BeneficiaryID int
as
begin
select MsgSubject,TimeOfMessage from AllMessages where BeneficiaryID=@BeneficiaryID
end

create procedure spBenefListClaims
@BeneficiaryID int
as
begin
select ClaimID,ClaimedOnPID,ClaimedInHID,ClaimType,ClaimRaisedOn,ClaimAmount,ClaimStatus from Claim where BeneficiaryID=20010
end

/*--------------------------------------------------------------------*/
/*------------Admin Policies STORED PROC---------------------------*/

create procedure spAdminManagePolicies
@PolicyID int,
@PolicyName varchar(30),
@PolicyPremium int,
@MaximumLimit int,
@Benefits varchar(100),
@flag varchar(20)
as
begin
if (@flag='Insert')
begin
exec spAddPolicy @PolicyName,@PolicyPremium,@MaximumLimit,@Benefits
end
else if (@flag='Update')
begin
exec spUpdatePolicy @PolicyID,@PolicyName,@PolicyPremium,@MaximumLimit,@Benefits
end
else if (@flag='Delete')
begin
exec spDeletePolicy @PolicyID
end
end

--select * from Hospital
--Delete from AdmittedHospitals where HospID=30010
--Delete from Claim where ClaimedInHID=30010
--delete from Hospital where HospitalID=30010

create procedure spAddPolicy
@PolicyName varchar(30),
@PolicyPremium int,
@MaximumLimit int,
@Benefits varchar(100)
as
begin
Insert into Policy(PolicyName,PolicyPremium,MaximumLimit,Benefits) values(@PolicyName,@PolicyPremium,@MaximumLimit,@Benefits)
end

create procedure spUpdatePolicy
@PolicyID int,
@PolicyName int,
@PolicyPremium varchar(50),
@MaximumLimit varchar(30),
@Benefits varchar(100)
as
begin
Update Policy set PolicyName=@PolicyName,PolicyPremium=@PolicyPremium,MaximumLimit=@MaximumLimit,Benefits=@Benefits where PolicyID=@PolicyID
end

create procedure spDeletePolicy
@PolicyID int
as
begin
BEGIN TRY
BEGIN TRANSACTION
Delete from EnrolledPolicy where PolicyID=@PolicyID
Delete from Claim where ClaimedOnPID=@PolicyID
Delete from Policy where PolicyID=@PolicyID
COMMIT TRANSACTION
PRINT 'Transaction committed'
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
PRINT 'Transaction rolled back'
END CATCH
end

create procedure spListOfPolicies
as
begin
select PolicyID,PolicyName,PolicyPremium,MaximumLimit,Benefits from Policy
end

--drop procedure spListOfPolicies
--drop procedure spAdminListOfPolicies



create procedure spBenefEnrollPolicies
@BeneficiaryID int,
@PolicyID int
as
begin
insert into EnrolledPolicy(BenefID,PolicyID,FromDate,ToDate) values(@BeneficiaryID,@PolicyID,GETDATE(),dateadd(year,1,getdate()))
end

create procedure spSearchForPolicies
@Age int,
@Specialist varchar(20)
as
begin
if @Age between 0 and 15
begin
select PolicyName,PolicyPremium,MaximumLimit,Benefits from Policy
where Benefits like '%Child%'
end
else if @Age between 85 and 100
begin
select PolicyName,PolicyPremium,MaximumLimit,Benefits from Policy
where Benefits like '%Senior%Citizen%'
end
else
begin
select PolicyName,PolicyPremium,MaximumLimit,Benefits from Policy
where Benefits like '%General%'
end
end

exec spBenefEnrollPolicies 20010,40011
--insert into EnrolledPolicy(BenefID,PolicyID,FromDate,ToDate) values(20010,40010,GETDATE(),dateadd(year,1,getdate()))
--select GETDATE()
--select dateadd(year,1,getdate())

create procedure spAdminListOfPolicies
as
begin
select PolicyID,PolicyName,PolicyPremium,MaximumLimit,Benefits from Policy
end




/*-------------------------------------------------------------------------------*/
/*--------------------Admin Hospitals Stored Proc-------------------------*/
--exec spAdminManageHospitals 30010,'Napa Country Hospital','Mental Health','Napa, California, United States','Update'
--exec spAdminManageHospitals 30014,'Naval Child Care Center San Diego','Military','San Diego, California, United States','Update'
--exec spAdminManageHospitals 30011,'VA Palo Alto Child Care System','Veteran Admin','Palo Alto, California, United States','Update'
--exec spAdminManageHospitals 30012,'CSU Long Beach Memorial Medical Ctr','University/Teaching','Long Beach, California, United States','Update'
--exec spAdminManageHospitals 30013,'New Samaritan Hospital','General Acute Care','San Jose, California, United States','Update'

--select * from Hospital
--Delete from AdmittedHospitals where HospID=30010
--Delete from Claim where ClaimedInHID=30010
--delete from Hospital where HospitalID=30010

/*--------------------------------------------------------------------*/



/*--------------------------------------------------------------------*/
/*------------Admin Claims STORED PROC---------------------------*/


create procedure spAdminManageClaims
@ClaimID int,
@BeneficiaryID int,
@ClaimedOnPID int,
@ClaimedInHID int,
@ClaimType varchar(20),
@ClaimRaisedOn datetime,
@ClaimAmount int,
@ClaimStatus varchar(20),
@flag varchar(20)
as
begin
if (@flag='Insert')
begin
exec spAddClaim @BeneficiaryID,@ClaimedOnPID,@ClaimedInHID,@ClaimType,@ClaimRaisedOn,@ClaimAmount
end
else if (@flag='Update')
begin
exec spUpdateClaim @ClaimID,@BeneficiaryID,@ClaimedOnPID,@ClaimedInHID,@ClaimType,@ClaimRaisedOn,@ClaimAmount,@ClaimStatus
end
else if (@flag='Delete')
begin
exec spDeleteClaim @ClaimID
end
end

--select * from Hospital
--Delete from AdmittedHospitals where HospID=30010
--Delete from Claim where ClaimedInHID=30010
--delete from Hospital where HospitalID=30010

create procedure spAddClaim
@BeneficiaryID int,
@ClaimedOnPID int,
@ClaimedInHID int,
@ClaimType varchar(20),
@ClaimRaisedOn datetime,
@ClaimAmount int
as
begin
Insert into Claim(BeneficiaryID,ClaimedOnPID,ClaimedInHID,ClaimType,ClaimRaisedOn,ClaimAmount,ClaimStatus)
values(@BeneficiaryID,@ClaimedOnPID,@ClaimedInHID,@ClaimType,@ClaimRaisedOn,@ClaimAmount,'In Progress')
end

create procedure spUpdateClaim
@ClaimID int,
@BeneficiaryID int,
@ClaimedOnPID int,
@ClaimedInHID int,
@ClaimType varchar(20),
@ClaimRaisedOn datetime,
@ClaimAmount int,
@ClaimStatus varchar(20)
as
begin
Update Claim set BeneficiaryID=@BeneficiaryID,ClaimedOnPID=@ClaimedOnPID,
ClaimedInHID=@ClaimedInHID,ClaimType=@ClaimType,ClaimRaisedOn=@ClaimRaisedOn,
ClaimAmount=@ClaimAmount,ClaimStatus=@ClaimStatus
where ClaimID=@ClaimID
end

create procedure spDeleteClaim
@ClaimID int
as
begin
Delete from Claim where ClaimID=@ClaimID
end


create procedure spAdminListOfClaims
as
begin
select ClaimID,BeneficiaryID,ClaimedOnPID,ClaimedInHID,ClaimType,ClaimRaisedOn,ClaimAmount,ClaimStatus from Claim
end

/*--------------------------------------------------------------------*/
/*------------Benef user Claims STORED PROC---------------------------*/

create procedure spBenefListOfClaims
@BenefID int
as
begin
select ClaimID,ClaimedOnPID,ClaimedInHID,ClaimType,ClaimRaisedOn,ClaimAmount,ClaimStatus
from Claim
where BeneficiaryID=@BenefID
end

create procedure spBenefAddClaim
@BenefID int,
@ClaimedOnPID int,
@ClaimedInHID int,
@ClaimType varchar(20),
@ClaimRaisedOn datetime,
@ClaimAmount int
as
begin
insert into Claim(BeneficiaryID,ClaimedOnPID,ClaimedInHID,ClaimType,ClaimRaisedOn,ClaimAmount,ClaimStatus)
values(@BenefID,@ClaimedOnPID,@ClaimedInHID,@ClaimType,@ClaimRaisedOn,@ClaimAmount,'In Progress')
end

drop procedure spBenefAddClaim

/*--------------------------------------------------------------------*/
/*--------------------------------------------------------------------*/

sp_helptext spLoginCheck
sp_helptext spBenefClaims
sp_helptext spBenefAddClaim
sp_helptext spAddHospital
sp_helptext spUpdateHospital
sp_helptext spDeleteHospital
sp_helptext spListOfHospitals
sp_helptext spAddPolicy
sp_helptext spUpdatePolicy
sp_helptext spDeletePolicy
sp_helptext spListOfPolicies
sp_helptext spAdminManagePolicies
sp_helptext spAdminManageHospitals

drop procedure spLoginCheck
drop procedure spBenefClaims
drop procedure spBenefAddClaim
drop procedure spAddHospital
drop procedure spUpdateHospital
drop procedure spDeleteHospital
drop procedure spListOfHospitals


/*---------------------------------------*/