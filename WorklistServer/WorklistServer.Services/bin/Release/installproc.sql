USE [Ris]
GO
if EXISTS (select * from Sys.objects where object_id=OBJECT_ID('getworklist') and type='p')
	Drop Proc getworklist
Go
/****** Object:  StoredProcedure [dbo].[GetWorklist]    Script Date: 06/23/2010 17:29:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Long chang>
-- Create date: <21-Jun-2010>
-- Description:	<Get Worklist for modalities>
-- =============================================
CREATE PROCEDURE [dbo].[GetWorklist] 
	@Mod NVARCHAR(50),
	@PatientName NVARCHAR(50),
	@AccessionNumber NVARCHAR(20),
	@PatientID NVARCHAR(50)
WITH RECOMPILE
AS
BEGIN

	SELECT DISTINCT 
	P.FamilyName_ + '^' + ISNULL(p.MiddleName_,'') + '^' + p.GivenName_ [PatientName]
	,p.Sex_ Sex, p.DateOfBirth_ Birthday ,p.MrnId_  patientID, o.AccessionNumber_ [AccessionNumber],
	ISNULL(o.ScheduledStartTime_,GETDATE()) Schedule,o.ReasonForStudy_ Indication,M.Name_ [Modality], PT.Id_ ProcedureID
	FROM Order_ o INNER JOIN patientProfile_ p On P.PatientOID_ = o.PatientOID_
	INNER JOIN Procedure_ pro On pro.OrderOID_ =o.OID_
	INNER JOIN ProcedureStep_ proStep On proStep.ProcedureOID_=pro.OID_
	INNER JOIN ProcedureStepPerformedProcedureStep_ PSP ON PSP.ProcedureStepOID_=proStep.OID_
	INNER JOIN PerformedProcedureStep_ PPS ON PPS.OID_ =PSP.PerformedProcedureStepOID_
	INNER JOIN Modality_ M On M.OID_=proStep.ModalityOID_
	INNER JOIN ProcedureType_ PT ON PT.OID_=pro.ProcedureTypeOID_
	INNER JOIN DiagnosticService_ D ON O.DiagnosticServiceOID_=D.OID_

	WHERE (PPS.State_='IP' OR PPS.State_='SC') AND (M.Name_=@Mod OR @Mod='') 
		AND (P.FamilyName_ like '%'+@PatientName+'%' OR P.MiddleName_ like '%'+@PatientName+'%' 
			OR P.GivenName_ like '%'+@PatientName+'%' OR @PatientName='')
		AND (o.AccessionNumber_=@AccessionNumber OR @AccessionNumber='')
		AND (p.MrnId_= @PatientID OR @PatientID='')
	ORDER BY [PatientName]
END
Go

if EXISTS (select * from Sys.objects where object_id=OBJECT_ID('UpdateMPPS') and type='p')
	Drop Proc UpdateMPPS
Go
-- =============================================
-- Author:		<Long chang>
-- Create date: <01-Jul-2010>
-- Description:	<Update MPPS that receive from Modality>
-- =============================================

CREATE PROC UpdateMPPS 
@status nvarchar(2),
@AccessionNumber nvarchar(20)
WITH RECOMPILE
AS
	BEGIN
	UPDATE dbo.PerformedProcedureStep_
	SET dbo.PerformedProcedureStep_.State_=@status
	WHERE dbo.PerformedProcedureStep_.OID_=
		(
			SELECT Top 1 pps.OID_
			FROM dbo.PerformedProcedureStep_ pps 
			INNER JOIN dbo.ProcedureStepPerformedProcedureStep_ pspps ON pspps.PerformedProcedureStepOID_=pps.OID_
			INNER JOIN ProcedureStep_ ps ON ps.OID_=pspps.ProcedureStepOID_
			INNER JOIN Procedure_ P ON P.OID_=ps.ProcedureOID_
			INNER JOIN Order_ O ON O.OID_=p.OrderOID_ 
			WHERE O.AccessionNumber_=@AccessionNumber AND pps.State_ ='IP'
		)
END
Go
