USE [Ris]
GO
if EXISTS (select * from Sys.objects where object_id=OBJECT_ID('getworklist') and type='p')
	Drop Proc getworklist
Go
if EXISTS (select * from Sys.objects where object_id=OBJECT_ID('UpdateMPPS') and type='p')
	Drop Proc UpdateMPPS
Go
	