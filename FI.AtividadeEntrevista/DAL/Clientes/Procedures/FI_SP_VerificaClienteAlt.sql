CREATE PROC FI_SP_VerificaClienteAlt
    @CPF VARCHAR(14),
    @Email VARCHAR(255),
    @Id BIGINT
AS
BEGIN
    SELECT 1 
    FROM CLIENTES 
    WHERE (CPF = @CPF OR Email = @Email) 
      AND Id <> @Id;
END
