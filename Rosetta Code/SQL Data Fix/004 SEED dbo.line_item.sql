use FooDatabase

SET NOCOUNT ON

DECLARE @count INT,
@upper_bound INT,
@created_date_uct DATETIME,
@log_2018 INT,
@log_2019 INT

SET @count = 1
SET @log_2018 = 0
SET @log_2019 = 0
SET @upper_bound = 20000

WHILE @count <= @upper_bound
BEGIN

	IF (@count % 3 < 2)
		BEGIN
			--- Random dates in 2018
			SET @created_date_uct = DATEADD(MINUTE, (ABS(CHECKSUM(NEWID())) % 100000) * -1, '2019-01-01')
			SET @log_2018 += 1
		END
	ELSE
		BEGIN
			--- Random dates in 2019
			SET @created_date_uct = DATEADD(MINUTE, (ABS(CHECKSUM(NEWID())) % 100000) * -1, '2020-01-01')
			SET @log_2019 += 1
		END

	INSERT INTO dbo.item_line 
		SELECT  NEWID(), 
				@created_date_uct,
				NEWID(),
				'3ba2e2e8-f093-41d8-8daf-64d5385604ac',
				CHAR((ABS(CHECKSUM(NEWID())) % 26) + 97) + CHAR((ABS(CHECKSUM(NEWID())) % 26) + 97) + 
				CHAR((ABS(CHECKSUM(NEWID())) % 26) + 97) + CHAR((ABS(CHECKSUM(NEWID())) % 26) + 97) + 
				CHAR((ABS(CHECKSUM(NEWID())) % 26) + 97) + CHAR((ABS(CHECKSUM(NEWID())) % 26) + 97) + 
				CHAR((ABS(CHECKSUM(NEWID())) % 26) + 97) + CHAR((ABS(CHECKSUM(NEWID())) % 26) + 97) + 
				CHAR((ABS(CHECKSUM(NEWID())) % 26) + 97) + CHAR((ABS(CHECKSUM(NEWID())) % 26) + 97) line_description 

	BEGIN
		IF (@count % 5000 = 0)
		PRINT(@count)
	END

	SET @count += 1
END



PRINT('-------------------')
PRINT('@log_2018 = ' + CONVERT(varchar(2000),@log_2018))
PRINT('@log_2019 = ' + CONVERT(varchar(2000),@log_2019))
PRINT('-------------------')
PRINT('DONE')