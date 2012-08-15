--Get All Medicine for sale and Prescription with First Come First Serve Pricing Method
CREATE PROCEDURE GetAllAvailableMedicines_FirstComeFirstServe
	@clinicOID UNIQUEIDENTIFIER
AS

BEGIN
	
	SELECT MED.Id_ , MED.Name_,MED.BarCode_,MED.MedDose_ ,MED.UseDirection_ ,STD.InputPrice_ , STD.SalePrice_,STD.InsurancePrice_,UOM.Value_ 
	,(SUM(Amount_) - SUM(SoldAmount_)) Available,ExpireDate_ , WH.Name_ WarehouseName, ML.Id_ , ML.InputDate_ 
	
	FROM dbo.Material_StockTransactionDetail_ STD
	INNER JOIN dbo.Material_StockTransaction_ ST ON ST.OID_ = STD.TransactionOID_ 
	INNER JOIN dbo.Material_MaterialLot_ ML ON ML.OID_ = ST.MaterialLot_ 
	INNER JOIN dbo.Material_Warehouse_ WH ON WH.OID_ = ST.InWarehouseOID_ 
	INNER JOIN dbo.Material_StockTransactionTypeEnum_ STE ON STE.OID_ = ST.TransactionType_
	INNER JOIN ProcedureType_ MED ON STD.MaterialOID_ = MED.OID_ 
	INNER JOIN UOMEnum_ UOM ON UOM.OID_ = STD.UOM_ 
	WHERE Amount_ > SoldAmount_ 
	AND ExpireDate_ > DATEADD(dd,10,GetDate())
	AND STE.Code_ = 'INS' 
	AND STD.Deactivated_ = 0 
	AND ST.ClinicOID_ = @clinicOID
	AND ST.Deactivated_ = 0
	AND STD.Deactivated_ = 0
	AND ML.Deactivated_ = 0
	
	GROUP BY MED.Id_ , MED.Name_,MED.BarCode_,MED.MedDose_ ,MED.UseDirection_ ,STD.InputPrice_ , STD.SalePrice_,STD.InsurancePrice_,UOM.Value_ 
	,ExpireDate_ , WH.Name_ , ML.Id_ , ML.InputDate_ 

END
GO

--Get All Medicine for sale and Prescription with Average Pricing Method
CREATE PROCEDURE GetAllAvailableMedicines_Average
	@clinicOID UNIQUEIDENTIFIER
AS

BEGIN
	
	SELECT MED.Id_ , MED.Name_,MED.BarCode_ , MED.BasePrice_,MED.MedDose_ ,MED.UseDirection_ 
	,MED.InsurancePrice_ ,(SUM(Amount_) - SUM(SoldAmount_)) Available, UOM.Value_ ,WH.Name_ WarehouseName, ML.Id_ , ML.InputDate_ 
	
	FROM ProcedureType_ MED
	INNER JOIN dbo.Material_StockTransactionDetail_ STD ON STD.MaterialOID_ = MED.OID_ 
	INNER JOIN dbo.Material_StockTransaction_ ST ON ST.OID_ = STD.TransactionOID_ 
	INNER JOIN dbo.Material_MaterialLot_ ML ON ML.OID_ = ST.MaterialLot_ 
	INNER JOIN dbo.Material_Warehouse_ WH ON WH.OID_ = ST.InWarehouseOID_ 
	INNER JOIN dbo.Material_StockTransactionTypeEnum_ STE ON STE.OID_ = ST.TransactionType_
	INNER JOIN UOMEnum_ UOM ON UOM.OID_ = MED.UOM_ 
	
	WHERE Amount_ > SoldAmount_ 
	AND ExpireDate_ > DATEADD(dd,10,GetDate())
	AND STE.Code_ = 'INS' 
	AND MED.Deactivated_ = 0 
	AND ST.ClinicOID_ = @clinicOID 
	AND ST.Deactivated_ = 0
	AND STD.Deactivated_ = 0
	AND ML.Deactivated_ = 0
	
	
	GROUP BY MED.Id_ , MED.Name_,MED.BarCode_ , MED.BasePrice_,MED.MedDose_ ,MED.UseDirection_ 
	,MED.InsurancePrice_ ,UOM.Value_ ,WH.Name_ , ML.Id_ , ML.InputDate_ 
	
END
GO


--Update SoldOut Medicine Average
CREATE PROCEDURE UpdateSoldOutMedicines_Average
	@MedicineOID_ UNIQUEIDENTIFIER,
	@SoldOutAmount INT,
	@SoldPrice DECIMAL,
	
	@clinicOID UNIQUEIDENTIFIER
	
AS

BEGIN
	BEGIN TRAN
		BEGIN TRY
			UPDATE ProcedureType_ SET CurrentQuantity_ 
		END TRY
	
END
GO

