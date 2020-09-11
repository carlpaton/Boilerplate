use FooDatabase;

DROP TABLE IF EXISTS item_line;
DROP TABLE IF EXISTS tenant;

CREATE TABLE tenant (
  id UNIQUEIDENTIFIER PRIMARY KEY,
  tenant_description VARCHAR(150) NOT NULL
);

CREATE TABLE item_line (
  id UNIQUEIDENTIFIER PRIMARY KEY,
  created_date_uct DATETIME2 DEFAULT GETUTCDATE(),
  created_by_user_id UNIQUEIDENTIFIER NOT NULL,
  tenant_id UNIQUEIDENTIFIER NOT NULL,
  line_description VARCHAR(150) NOT NULL,
	CONSTRAINT fk_tenant_id FOREIGN KEY (tenant_id)
        REFERENCES tenant (id)
);

