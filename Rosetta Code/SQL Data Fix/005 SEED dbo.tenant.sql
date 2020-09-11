USE FooDatabase

INSERT INTO dbo.tenant
SELECT TOP 350 created_by_user_id, 'User' 
	FROM dbo.item_line
	WHERE created_date_uct >= '2018-01-01 00:00:00'
	AND created_date_uct < '2019-01-01 00:00:00';

SELECT @@ROWCOUNT